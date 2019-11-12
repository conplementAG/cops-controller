#!/bin/bash

function fail {
    echo $1
    exit 1
}

function setupCluster {
    set -eo pipefail

    repository=$1
    tag=$2
    installHelm=$3

    if [ -n "$3" ]; then
        kubectl -n kube-system create serviceaccount tiller --dry-run=true -o yaml | kubectl apply -f -
        kubectl create clusterrolebinding tiller --clusterrole=cluster-admin --serviceaccount=kube-system:tiller --dry-run=true -o yaml | kubectl apply -f -
        helm init --service-account tiller --wait --upgrade
    fi

    # ensure metacontroller dependency in the cluster
    metacontrollerVersion="v0.4.0"
    kubectl apply -f "https://raw.githubusercontent.com/GoogleCloudPlatform/metacontroller/${metacontrollerVersion}/manifests/metacontroller-namespace.yaml"
    kubectl apply -f "https://raw.githubusercontent.com/GoogleCloudPlatform/metacontroller/${metacontrollerVersion}/manifests/metacontroller-rbac.yaml"
    kubectl apply -f "https://raw.githubusercontent.com/GoogleCloudPlatform/metacontroller/${metacontrollerVersion}/manifests/metacontroller.yaml"

    # install cops controller via the local chart
    copsControllerNamespace="coreops-cops-controller-component-test"
    kubectl apply -f deployment/crds

    helm upgrade --install --wait --timeout 60 --namespace $copsControllerNamespace \
        --set image.repository=$1 \
        --set image.tag=$2 \
        cops-controller deployment/cops-controller
}

function setupTestServiceAccount {
    testAccount=$1
    testAccountNamespace=$2

    # create account
    kubectl create serviceaccount $testAccount --dry-run=true -o yaml | kubectl apply -f -

    # extract the secret, set into kubeconfig
    serviceAccountSecret=$(kubectl get serviceaccount $testAccount -n $testAccountNamespace -o jsonpath={.secrets[0].name})
    token=$(kubectl get secret $serviceAccountSecret -n $testAccountNamespace -o jsonpath={.data.token} | base64 --decode)
    kubectl config set-credentials $testAccount --token=$token    

    # create the new kubeconfig context
    kubectl config set-context $testAccount --user=$testAccount --cluster=$(kubectl config view --minify -o jsonpath={.clusters[0].name})
}

function should_deploy_valid_cns {
    # Arrange
    testAccount=$1
    testAccountNamespace=$2

    # Act
    cat "tests/1-valid-cns.yaml" | sed "s/{{SERVICE_ACCOUNT}}/$testAccount/g" \
     | sed "s/{{SERVICE_ACCOUNT_NAMESPACE}}/$testAccountNamespace/g" \
     | kubectl apply -f -

    # Assert
    kubectl get ns test-one
}

function should_update_valid_cns {
    # Arrange & Act
    kubectl apply -f tests/2-updated-cns.yaml

    # Assert
}

setupCluster $1 $2 $3

testServiceAccount="cops-controller-test-user"
testServiceAccountNamespace="default"
setupTestServiceAccount $testServiceAccount $testServiceAccountNamespace

# bind the test service account to the only right required for the cops-controller, which is currently the right
# to manage cops namespaces
cat "tests/0-test-rights.yaml" | sed "s/{{SERVICE_ACCOUNT}}/$testServiceAccount/g" \
 | sed "s/{{SERVICE_ACCOUNT_NAMESPACE}}/$testServiceAccountNamespace/g" \
 | kubectl apply -f -

# switch to the test user
kubectl config use-context $testServiceAccount

should_deploy_valid_cns $testServiceAccount $testServiceAccountNamespace
# should_update_valid_cns $testServiceAccount $testServiceAccountNamespace