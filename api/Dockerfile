FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
ENV ASPNETCORE_URLS=http://+:30511

# copy csproj and restore as distinct layers
COPY *.sln .
COPY api/*.csproj ./api/
RUN dotnet restore

# copy everything else and build app
COPY api/. ./api/
WORKDIR /source/api
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "api.dll"]