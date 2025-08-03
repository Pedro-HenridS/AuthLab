FROM mcr.microsoft.com/dotnet/sdk:9.0.302 AS build-env
WORKDIR /app

COPY . .

WORKDIR /app/API

RUN dotnet restore

RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "API.dll"]