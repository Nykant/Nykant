FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

COPY certificate.pfx /etc/ssl/letsencrypt/certificate.pfx

ENV ASPNETCORE_URLS https://*:5003
ENV ASPNETCORE_HTTPS_PORT 5001
ENV ASPNETCORE_Kestrel__Certificates__Default__Password specialpassword123
ENV ASPNETCORE_Kestrel__Certificates__Default__Path /etc/ssl/letsencrypt/certificate.pfx

ENTRYPOINT ["dotnet", "NykantAPI.dll"]