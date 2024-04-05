FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy AS build-env

## Tooling prerequisites CycloneDX Docker ##################
ARG SYFT_RELEASE=0.99.0
ARG SYFT_SHA256=fc06ec6bc3f3ae47ddf5938098c2de982777d9e9545513d764bd759732fa353c
RUN curl -sLO https://github.com/anchore/syft/releases/download/v${SYFT_RELEASE}/syft_${SYFT_RELEASE}_linux_amd64.deb && \
  echo "${SYFT_SHA256} syft_${SYFT_RELEASE}_linux_amd64.deb" | sha256sum --check --status && \
  dpkg -i syft_${SYFT_RELEASE}_linux_amd64.deb && \
  rm syft_${SYFT_RELEASE}_linux_amd64.deb
## CycloneDX CLI                 
ARG CycloneDXCLIVersion=0.25.0
RUN curl -LO https://github.com/CycloneDX/cyclonedx-cli/releases/download/v${CycloneDXCLIVersion}/cyclonedx-linux-x64
RUN chmod +x cyclonedx-linux-x64
RUN mv cyclonedx-linux-x64 $GOPATH/bin
RUN cyclonedx-linux-x64 --version


RUN dotnet tool install --global CycloneDX 

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore ConplementAG.CopsController.csproj

COPY . ./
RUN dotnet publish ConplementAG.CopsController.csproj -c Release -o out

RUN mkdir /sboms
WORKDIR /sboms
RUN /root/.dotnet/tools/dotnet-CycloneDX /app/ConplementAG.CopsController.csproj -o .
RUN syft packages mcr.microsoft.com/dotnet/aspnet:6.0-jammy -o cyclonedx-xml=./docker-sbom.xml
RUN cyclonedx-linux-x64 merge --input-files bom.xml docker-sbom.xml --output-file cops-controller-sbom.xml


FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy

RUN useradd -u 8877 donetuser
USER donetuser

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env --chown=donetuser:donetuser /sboms/cops-controller-sbom.xml /sboms/cops-controller-sbom.xml
ENTRYPOINT ["dotnet", "ConplementAG.CopsController.dll"]