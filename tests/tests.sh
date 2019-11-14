#!/bin/bash
set -eo pipefail

function fail {
    colorecho "RED" "$1"
    exit 1
}

function success {
    colorecho "GREEN" "$1"
}

function logTestStarted {
    colorecho "YELLOW" "$1"
}

#########################################################################
#                               Globals                                 #
#########################################################################

serviceAccountsNamespace="default"
darthVaderAccount="cops-controller-darth-vader"
kyloRenAccount="cops-controller-kylo-ren"

#########################################################################
#                           Arrange helpers                             #
#########################################################################
function setupCluster {
    installController=$1
    repository=$2
    tag=$3

    if [ $installController == "yes" ]; then
        kubectl -n kube-system create serviceaccount tiller --dry-run=true -o yaml | kubectl apply -f -
        kubectl create clusterrolebinding tiller --clusterrole=cluster-admin --serviceaccount=kube-system:tiller --dry-run=true -o yaml | kubectl apply -f -
        helm init --service-account tiller --wait --upgrade

        # ensure metacontroller dependency in the cluster
        metacontrollerVersion="v0.4.0"
        kubectl apply -f "https://raw.githubusercontent.com/GoogleCloudPlatform/metacontroller/${metacontrollerVersion}/manifests/metacontroller-namespace.yaml"
        kubectl apply -f "https://raw.githubusercontent.com/GoogleCloudPlatform/metacontroller/${metacontrollerVersion}/manifests/metacontroller-rbac.yaml"
        kubectl apply -f "https://raw.githubusercontent.com/GoogleCloudPlatform/metacontroller/${metacontrollerVersion}/manifests/metacontroller.yaml"

        # install cops controller via the local chart
        copsControllerNamespace="coreops-cops-controller-component-test"
        kubectl apply -f deployment/crds

        helm upgrade --install --wait --timeout 60 --namespace $copsControllerNamespace \
            --set image.repository=$repository \
            --set image.tag=$tag \
            cops-controller deployment/cops-controller
    fi
}

function setupTheEmpireServiceAccounts {
    setupServiceAccount $darthVaderAccount $serviceAccountsNamespace
    setupServiceAccount $kyloRenAccount $serviceAccountsNamespace
}

function setupServiceAccount {
    testAccount=$1
    testAccountNamespace=$2

    # create account
    kubectl create serviceaccount $testAccount -n $testAccountNamespace --dry-run=true -o yaml | kubectl apply -f -

    # extract the secret, set into kubeconfig
    serviceAccountSecret=$(kubectl get serviceaccount $testAccount -n $testAccountNamespace -o jsonpath={.secrets[0].name})
    token=$(kubectl get secret $serviceAccountSecret -n $testAccountNamespace -o jsonpath={.data.token} | base64 --decode)
    kubectl config set-credentials $testAccount --token=$token    

    # create the new kubeconfig context
    kubectl config set-context $testAccount --user=$testAccount --cluster=$(kubectl config view --minify -o jsonpath={.clusters[0].name})

    # bind the test service account to initial rights as the users have them
    cat "tests/0-test-rights.yaml" | sed "s/{{SERVICE_ACCOUNT}}/$testAccount/g" \
     | sed "s/{{SERVICE_ACCOUNT_NAMESPACE}}/$testAccountNamespace/g" \
     | sed "s/{{BINDING_NAME}}/copsnamespace-creator-binding-$testAccount/g" \
     | kubectl apply -f -
}

#########################################################################
#                           Assert helpers                              #
#########################################################################
function ensureAccessToNamespace {
    namespaceName=$1

    # we have to retry here because it might take a second or two to create the namespace
    n=1
    until [ $n -ge 15 ]
    do
        echo "Attempting to list basic namespace resources... Attempt $n out of 15."
        kubectl get pods,svc,deploy -n $namespaceName && break
        n=$[$n+1]
        sleep 2
    done

    # last check after all attempts so that we can pipe the failure correctly
    kubectl get pods,svc,deploy -n $namespaceName || fail "It was expected that the namespace setup is completed at this point."
}

function expectApplyToFail {
    hasFailed="no"

    kubectl apply -f $1 || hasFailed="yes"

     if [ $hasFailed == "no" ]; then
        fail "$1 succeeded, which was unexpected!"
    fi
}

#########################################################################
#                              The Tests                                #
#########################################################################

function test_noAccessPerDefault {
    logTestStarted ${FUNCNAME[0]}

    kubectl config use-context $darthVaderAccount

    authOutput=$(kubectl auth can-i get pods -n default) || success "No access in default, good"
    
    if [ $authOutput != "no" ]; then
        fail "Listing pods in default as darth vader should have failed!"
    fi

    authOutput=$(kubectl auth can-i get pods -n kube-system) || success "No access in kube-system, good"
    
    if [ $authOutput != "no" ]; then
        fail "Listing pods in kube-system as darth vader should have failed!"
    fi
}

function test_validDefinitions {
    logTestStarted ${FUNCNAME[0]}

    kubectl apply -f tests/valid-definitions
}

function test_invalidDefinitions {
    logTestStarted ${FUNCNAME[0]}

    hasFailed="no"

    expectApplyToFail "tests/invalid-definitions/1.yaml" 
    expectApplyToFail "tests/invalid-definitions/2.yaml" 
    expectApplyToFail "tests/invalid-definitions/3.yaml" 
    expectApplyToFail "tests/invalid-definitions/4.yaml" 
    expectApplyToFail "tests/invalid-definitions/5.yaml" 
    expectApplyToFail "tests/invalid-definitions/6.yaml" 
    expectApplyToFail "tests/invalid-definitions/7.yaml" 
}

# Tests following business cases:
# - user can create a cops namespace and gain rights inside it
# - all other users are denied access
function test_shouldDeployEmpireCnsWithValidRbac {
    logTestStarted ${FUNCNAME[0]}

    # Arrange
    kubectl config use-context $darthVaderAccount
    namespaceName="empire"

    # Act
    cat "tests/1-empire-cns.yaml" | sed "s/{{SERVICE_ACCOUNT}}/$darthVaderAccount/g" \
     | sed "s/{{SERVICE_ACCOUNT_NAMESPACE}}/$serviceAccountsNamespace/g" \
     | sed "s/{{NAMESPACE}}/$namespaceName/g" \
     | kubectl apply -f -

    # Assert
    ensureAccessToNamespace $namespaceName

    # no access for other accounts
    kubectl config use-context $kyloRenAccount
    
    authOutput=$(kubectl auth can-i get pods -n $namespaceName) || success "Kylo ren didn't have access, which was expected :)"
    
    if [ $authOutput != "no" ]; then
        fail "Listing pods as kylo ren should have failed!"
    fi
}

# Tests following business cases:
# - namespace admin user edit the namespace and extend it with additional rbac
function test_shouldUpdateEmpireCnsWithAdditionalRbac {
    logTestStarted ${FUNCNAME[0]}

    # Arrange
    kubectl config use-context $darthVaderAccount
    namespaceName="empire"

    # Act
    cat "tests/2-updated-cns.yaml" | sed "s/{{SERVICE_ACCOUNT}}/$darthVaderAccount/g" \
     | sed "s/{{SERVICE_ACCOUNT_NAMESPACE}}/$testAccountNamespace/g" \
     | sed "s/{{ADDITIONAL_SERVICE_ACCOUNT_NAMESPACE}}/$testAccountNamespace/g" \
     | sed "s/{{ADDITIONAL_SERVICE_ACCOUNT}}/$kyloRenAccount/g" \
     | sed "s/{{NAMESPACE}}/$namespaceName/g" \
     | kubectl apply -f -

    # Assert
    ensureAccessToNamespace $namespaceName # darth should still have access

    # but kylo too
    kubectl config use-context $kyloRenAccount
    ensureAccessToNamespace $namespaceName

    # to check the changes for user accounts, we can only ensure changes were done in RBAC. Real
    # RBAC testing we cannot do because we cannot impersonate user accounts
    kubectl config use-context $INITIAL_CONTEXT
    users=$(kubectl get clusterrolebinding copsnamespace-editor-empire -o jsonpath={.subjects[*].name} --ignore-not-found)
    
    echo "Found users: $users"

    if [[ $users != *"First.User"* ]] || [[ $users == *"Second.User"* ]] || [[ $users != *"Fourth.User"* ]] || [[ $users != *"Third.User"* ]]; then
        fail "Users were not updated correctly."
    fi
}

#########################################################################
#                              Test runner                              #
#########################################################################

setupCluster "$1" "$2" "$3"

setupTheEmpireServiceAccounts

# now we can run all the tests
test_noAccessPerDefault # this test has to run first

test_validDefinitions
test_invalidDefinitions
test_shouldDeployEmpireCnsWithValidRbac
test_shouldUpdateEmpireCnsWithAdditionalRbac