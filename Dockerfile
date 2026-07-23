# .NET 10 LTS End of Lifetime is on 11/14/2028
FROM mcr.microsoft.com/dotnet/sdk:10.0-noble AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore ConplementAG.CopsController.csproj

COPY . ./
RUN dotnet publish ConplementAG.CopsController.csproj -c Release -o out

# .NET 10 LTS End of Lifetime is on 11/14/2028
FROM mcr.microsoft.com/dotnet/aspnet:10.0-noble-chiseled

USER app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConplementAG.CopsController.dll"]