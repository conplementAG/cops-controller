#!/bin/bash

set -eo pipefail
programname=$0

function usage {
    echo "usage: $programname [-r repository] [-t tag]"
    echo "  MAKE SURE YOU SPECIFY THE ARGUMENTS IN THE EXACT ORDER AS BELOW, THIS SCRIPT DOES NOT SUPPORT OUT OF ORDER ARGUMENTS!"
    echo "  -r repository   (MANDATORY) cops controller image repository. Should be accessible from the cluster (e.g. remote registry or local one shared with the cluster)."
    echo "  -t tag          (MANDATORY) cops controller image tag."
    echo "  --install-helm  (optional) use to install global helm in the cluster. Make sure you have Helm > 2.16 if you use this option and you are running on k8s > 1.16"
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
    echo "       - eval $(minikube docker-env)"
    echo "       - docker build . -t cops-controller:latest"
    echo "       - ./tests.sh -r cops-controller -t latest --install-helm"
    exit 1
}

exit_code=0  
initialContext=$(kubectl config current-context)

# the cleanup function will be the exit point
cleanup () {
    echo "Setting back the initial context $initialContext"
    kubectl config use-context $initialContext

    exit $exit_code
}

# mandatory params check
if [ $1 != "-r" ] || [ -z "$2" ] || [ $3 != "-t" ] || [ -z "$4" ]; then
    usage
else
    repository=$2
    tag=$4
    
    # optional params check
    if [ -n "$5" ] && [ $5 != "--install-helm" ]; then
        usage
    else
        # register the cleanup function for all signal types (emulating finally block)
        trap cleanup EXIT ERR INT TERM

        . ./tests/tests.sh $repository $tag $5

        # set the exit_code with the real result, used when cleanup is called
        exit_code=$?
    fi 
fi