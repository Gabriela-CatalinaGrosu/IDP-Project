# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiem fișierele de proiect
COPY MobyLabWebProgramming.sln ./
COPY MobyLabWebProgramming.Core/*.csproj ./MobyLabWebProgramming.Core/
COPY MobyLabWebProgramming.Infrastructure/*.csproj ./MobyLabWebProgramming.Infrastructure/
COPY MobyLabWebProgramming.Backend/*.csproj ./MobyLabWebProgramming.Backend/

# Restore dependencies
RUN dotnet restore

# Copiem restul fișierelor
COPY . .

# Build
WORKDIR /src/MobyLabWebProgramming.Backend
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MobyLabWebProgramming.Backend.dll"]
