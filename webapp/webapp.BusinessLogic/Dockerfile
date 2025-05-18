FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY MobyLabWebProgramming.Core /app/MobyLabWebProgramming.Core
COPY MobyLabWebProgramming.Infrastructure /app/MobyLabWebProgramming.Infrastructure
COPY webapp.BusinessLogic /app/webapp.BusinessLogic

RUN dotnet restore webapp.BusinessLogic/webapp.BusinessLogic.csproj
RUN dotnet publish webapp.BusinessLogic/webapp.BusinessLogic.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

RUN apt-get update \
    && apt-get install -y curl

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

COPY webapp.BusinessLogic/startup.sh .
CMD ["./startup.sh"]