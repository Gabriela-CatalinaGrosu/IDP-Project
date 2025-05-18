# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.21 AS build-env
WORKDIR /app

COPY MobyLabWebProgramming.Core ./MobyLabWebProgramming.Core
COPY MobyLabWebProgramming.Infrastructure ./MobyLabWebProgramming.Infrastructure
COPY MobyLabWebProgramming.Backend ./MobyLabWebProgramming.Backend

RUN dotnet restore MobyLabWebProgramming.Backend/MobyLabWebProgramming.Backend.csproj
RUN dotnet publish MobyLabWebProgramming.Backend/MobyLabWebProgramming.Backend.csproj -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.21
WORKDIR /app

COPY --from=build-env /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "MobyLabWebProgramming.Backend.dll"]
