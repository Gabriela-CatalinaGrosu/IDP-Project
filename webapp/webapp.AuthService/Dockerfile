FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY MobyLabWebProgramming.Core /app/MobyLabWebProgramming.Core
COPY MobyLabWebProgramming.Infrastructure /app/MobyLabWebProgramming.Infrastructure
COPY webapp.AuthService /app/webapp.AuthService

RUN dotnet restore webapp.AuthService/webapp.AuthService.csproj
RUN dotnet publish webapp.AuthService/webapp.AuthService.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

RUN apt-get update \
    && apt-get install -y curl

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

COPY webapp.AuthService/startup.sh .
CMD ["./startup.sh"]