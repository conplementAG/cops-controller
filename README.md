# cops controller

[![Build Status](https://cpgithub.visualstudio.com/GitHubPipelines/_apis/build/status/conplementAG.cops-controller?branchName=master)](https://cpgithub.visualstudio.com/GitHubPipelines/_build/latest?definitionId=10&branchName=master)

## Introduction

This is the Kubernetes Controller implementation for Conplement CoreOps specific Kubernetes extensions. Can be seen as a backend to the companion project [copsctl](https://github.com/conplementAG/copsctl)


This project is "based" on [metacontroller](https://github.com/GoogleCloudPlatform/metacontroller) and written in C#, mainly for three reasons:

- Metacontroller is the simplest custom controller approach in Kubernetes, and offers easy parent / child resource tracking
- Metacontroller integrates with "business" code via webhooks, which leaves us free to select any language for the implementation
- [Azure Dev Spaces](https://docs.microsoft.com/en-us/azure/dev-spaces/), an excelent tool for development / debugging in Kubernetes, works at the moment the best with C#

## Setup

tbd after first release

## Development

For developing, we use Visual Studio Code and Azure Dev Spaces (running inside our CoreOps clusters).

1. Create / update your cops cluster to the latest state. Metacontroller, which is required for this controller to work, is delivered out of the box.

2. Install / setup Azure DevSpaces on your cluster, incl. your DevSpace 

`az aks use-dev-spaces -g ... -n ... --space space_name`

Install the Azure DevSpaces CLI and run:
`azds space select --name your_space_name`

3. Deploy the custom resource definitions `kubectl apply -f deployment/crds`

4. Install / setup Visual Studio Code with following extensions:
    - C#
    - Docker
    - NuGet Package Manager
    - Azure Dev Spaces

    Also, you might have issues with C# and .NET Core unless you install the dotnet core build tools as well: https://github.com/OmniSharp/omnisharp-roslyn/issues/1311#issuecomment-428361674

5. Run `donet restore` / `dotnet build` and you are ready to go. For Azure DevSpace, either run `azds up` or simply start debugging through VS Code (launch configuration for Azure DevSpaces is included with the repository).

Hints on development:
 - When running inside Kubernetes, follow both metacontroller and this container logs. Metacontroller logs can be reached via `kubectl logs metacontroller-0 -n metacontroller -f` or a similar command. 

## Creating a new release

Release is created by starting the Azure DevOps release pipeline. Follow the instructions documented in the pipeline itself.