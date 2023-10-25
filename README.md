# cops controller
## Introduction

This is the Kubernetes Controller implementation for Conplement CoreOps specific Kubernetes extensions. Can be seen as a backend to the companion project [copsctl](https://github.com/conplementAG/copsctl)

This project is "based" on [metacontroller](https://github.com/GoogleCloudPlatform/metacontroller) and written in C#, mainly for three reasons:

- Metacontroller is the simplest custom controller approach in Kubernetes, and offers easy parent / child resource tracking
- Metacontroller integrates with "business" code via webhooks, which leaves us free to select any language for the implementation
- [Azure Dev Spaces](https://docs.microsoft.com/en-us/azure/dev-spaces/), an excelent tool for development / debugging in Kubernetes, works at the moment the best with C#
- [Telepresence](https://telepresence.io) an excelent tool for development / debugging controller within Kubernetes 

## Setup

Check the instructions on the [release page](https://github.com/conplementAG/cops-controller/releases).

## Development

For developing, we use Visual Studio Code and Telepresence (intercepting cluster workload and redirect traffic to local service).

1. Create / update your cops cluster to the latest state. Metacontroller, which is required for this controller to work, is delivered out of the box.

2. Install / setup telepresence in your cluster

`telepresence helm install` to install telepresence
`telepresence intercept cops-controller -n coreops-cops-controller --port 5000:80` intercept the cops-controller service 

Make sure you are running a version of cops-controller locally listing to port 5000 ( see 5. )

3. Deploy the custom resource definitions `kubectl apply -f deployment/crds`

4. Install / setup Visual Studio Code with following extensions:
    - C#
    - Docker
    - NuGet Package Manager

    Also, you might have issues with C# and .NET Core unless you install the dotnet core build tools as well: https://github.com/OmniSharp/omnisharp-roslyn/issues/1311#issuecomment-428361674

5. Run `donet restore` / `dotnet build` and you are ready to go. 

Hints on development:
 - When running inside Kubernetes, follow both metacontroller and this container logs. Metacontroller logs can be reached via `kubectl logs metacontroller-0 -n metacontroller -f` or a similar command. 