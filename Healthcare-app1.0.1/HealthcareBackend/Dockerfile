# Use official .NET 8 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY . . 
RUN dotnet restore

# Build the project
RUN dotnet publish -c Release -o /out

# Use lightweight runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy built files
COPY --from=build /out .

# Expose API port
EXPOSE 5000
EXPOSE 5001

# Run the application
ENTRYPOINT ["dotnet", "MyHealthcareApp.dll"]
