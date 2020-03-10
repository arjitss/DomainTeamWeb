# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY /app /app
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DomainTeamWebsite.dll
