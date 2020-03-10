# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c release -o app/ .

# final stage/image

WORKDIR /app
COPY /app /app
ENTRYPOINT ["dotnet", "DomainTeamWebsite.dll"]