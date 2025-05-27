# .NET 8 LTS End of Lifetime is on 10/11/2026
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore ConplementAG.CopsController.csproj

COPY . ./
RUN dotnet publish ConplementAG.CopsController.csproj -c Release -o out

# .NET 8 LTS End of Lifetime is on 10/11/2026
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled

USER app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConplementAG.CopsController.dll"]