# Use the official .NET SDK image as a build environment
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
# WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app


# Copy the project files
COPY . ./
RUN dotnet restore

# Copy the rest of the application files
COPY . ./
RUN dotnet publish -o out

# Use the official .NET runtime image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "MyWebApi.dll"]