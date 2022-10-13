FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy-amd64 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy-amd64 AS runtime
WORKDIR /app

## START - INSTALL WKHTMLTOPDF
#
#ADD wkhtmltopdf ./wwwroot/wkhtmltopdf

ENV WKHTMLTOX wkhtmltox_0.12.6.1-2.jammy_amd64.deb
ENV BUILD_PACKAGES build-essential
ENV MAIN_PACKAGES fontconfig libfreetype6 libjpeg-turbo8 libxext6 libpng16-16 libx11-6 libxcb1  libxrender1 xfonts-75dpi xfonts-base 

COPY deps/$WKHTMLTOX ./

RUN set -xe \
    && apt-get update -qq \
    && apt-get install --no-install-recommends -yq $BUILD_PACKAGES $MAIN_PACKAGES \
    && dpkg -i ${WKHTMLTOX} \
    && apt-get remove -y $BUILD_PACKAGES \
    && apt-get autoremove -y \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/* \
    && rm -rf ${WKHTMLTOX} \
    && truncate -s 0 /var/log/*log
## END - INSTALL WKHTMLTPDF

WORKDIR /usr/local/bin
RUN mkdir Linux \
    && mv wkhtmltopdf Linux
WORKDIR /app

COPY --from=build /app/out ./

ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_HTTPS_PORT 443

ENTRYPOINT ["dotnet", "NykantMVC.dll"]