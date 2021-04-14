FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore ConplementAG.CopsController.csproj

COPY . ./
RUN dotnet publish ConplementAG.CopsController.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0

RUN useradd -u 8877 donetuser
USER donetuser

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConplementAG.CopsController.dll"]