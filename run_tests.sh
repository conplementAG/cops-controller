#!/bin/bash

set -eo pipefail
programname=$0

UNIVERSAL_TEST_IDENTIFIED="cops-controller-component-tests"

function usage {
    echo "usage: $programname [--install-helm-and-cops-controller] [-r repository] [-t tag]"
    echo "  MAKE SURE YOU SPECIFY THE ARGUMENTS IN THE EXACT ORDER AS BELOW, THIS SCRIPT DOES NOT SUPPORT OUT OF ORDER ARGUMENTS!"
    echo "  --install-helm-and-cops-controller (optional) use to install global helm in the cluster and to deploy the cops controller specified by the -r and -t arguments. Make sure you have Helm > 2.16 if you use this option and you are running on k8s > 1.16"
    echo "  -r repository   (optional) cops controller image repository. Should be accessible from the cluster (e.g. remote registry or local one shared with the cluster)."
    echo "  -t tag          (optional) cops controller image tag."
    echo " "
    echo "Prerequisites: "
    echo "   To run the tests, you need a running k8s cluster and docker engine"
    echo " "
    echo "Test cluster setup:"
    echo "   1. For example, you can install Docker for Windows or Minikube, or use a remote cluster"
    echo "       Ubuntu instructions:"
    echo "       - install VirtualBox"
    echo "       - curl -Lo minikube https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64 && chmod +x minikube"
    echo "       - sudo install minikube /usr/local/bin/"
    echo "   2. The cluster has to have access to the docker registry with the pushed image. Either you push to a remote registry,"
    echo "      or you can use something like minikube docker-env to share the images on your machine."
    echo "       Ubuntu with minikube instructions:"
    echo "       - minikube start"
    echo "       - import variables with eval from: minikube docker-env"
    echo "       - docker build . -t cops-controller:latest"
    echo "       - ./run_tests.sh --install-helm-and-cops-controller -r cops-controller -t latest"
    exit 1
}

function colorecho {
    RED="\033[0;31m"
    GREEN="\033[0;32m"
    YELLOW="\033[1;33m"
    # ... ADD MORE COLORS
    NC="\033[0m" # No Color

    printf "${!1}${2} ${NC}\n"
}

# the cleanup function will be the exit point
initialContext=$(kubectl config current-context)

function cleanup {
    exit_code=$?
    echo "Setting back the initial context $initialContext"
    
    kubectl config use-context $initialContext
    
    echo "Deleting all cops namespaces for cleanup..."

    namespaces=$(kubectl get cns -l tests=$UNIVERSAL_TEST_IDENTIFIED -o name)

    if [ -n "$namespaces" ]; then 
        kubectl delete $namespaces --ignore-not-found
    fi

    echo "Deleting all remaining RBAC rules..."
    clusterRoles=$(kubectl get clusterroles -o name -l tests=$UNIVERSAL_TEST_IDENTIFIED)
    clusterRoleBindings=$(kubectl get clusterrolebindings -o name -l tests=$UNIVERSAL_TEST_IDENTIFIED)

    if [ -n "$clusterRoles" ]; then
        kubectl delete $clusterRoles --ignore-not-found
    fi

    if [ -n "$clusterRoleBindings" ]; then
        kubectl delete $clusterRoleBindings --ignore-not-found
    fi

    if [ $exit_code != 0 ]; then
        colorecho "RED" "Tests failed, check for the last error occured."
    else
        colorecho "GREEN" "All tests succeeded."
        colorecho "GREEN" "Stdout could contain some failure statements, but this is because we pipe everything to stdout, even the failure checks where we expect to fail."
    fi

    exit $exit_code
}

installController="no"
repository=""
tag=""

if [ -n "$1" ]; then # if any argument specified
    # all parameters mandatory now, in correct order
    if [ $1 != "--install-helm-and-cops-controller" ] || [ $2 != "-r" ] || [ -z "$3" ] || [ $4 != "-t" ] || [ -z "$5" ]; then
        usage
    else
        installController="yes"
        repository=$3
        tag=$5
    fi
fi

# register the cleanup function for all signal types (emulating finally block)
trap cleanup EXIT ERR INT TERM

. ./tests/tests.sh "$installController" "$repository" "$tag"