FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY MobyLabWebProgramming.Core /app/MobyLabWebProgramming.Core
COPY MobyLabWebProgramming.Infrastructure /app/MobyLabWebProgramming.Infrastructure
COPY webapp.DbService /app/webapp.DbService

RUN dotnet restore webapp.DbService/webapp.DbService.csproj
RUN dotnet publish webapp.DbService/webapp.DbService.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "webapp.DbService.dll"]