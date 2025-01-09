# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy the .csproj file to the working directory
COPY ./BookReadingApp/BookReadingApp.csproj ./

# Restore dependencies
RUN dotnet restore 

# Copy all files to the working directory
COPY . ./

# Build the application
RUN dotnet publish -c Release -o /out

# Use the official ASP.NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build /out .

# Expose necessary ports
EXPOSE 80
EXPOSE 443

# Run the application
ENTRYPOINT ["dotnet", "BookReadingApp.dll"]
