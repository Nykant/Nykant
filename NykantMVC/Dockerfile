FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

#RUN apt-get update
#RUN apt-get -y install rpm
#ADD wkhtmltox-0.12.6-1.centos7.x86_64.rpm ./wwwroot/wkhtmltopdf/wkhtmltox-0.12.6-1.centos7.x86_64.rpm

#RUN rpm -i ./wwwroot/wkhtmltopdf/wkhtmltox-0.12.6-1.centos7.x86_64.rpm

RUN apt update
RUN apt install -y libgdiplus
RUN ln -s /usr/lib/libgdiplus.so /lib/x86_64-linux-gnu/libgdiplus.so
RUN apt-get install -y --no-install-recommends zlib1g fontconfig libfreetype6 libx11-6 libxext6 libxrender1 wget gdebi
RUN wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6.1-2/wkhtmltox_0.12.6.1-2.bullseye_amd64.deb

RUN gdebi --n wkhtmltox_0.12.6.1-2.bullseye_amd64.deb
RUN apt install libssl1.1
RUN ln -s /usr/local/lib/libwkhtmltox.so /usr/lib/libwkhtmltox.so


ADD wkhtmltopdf ./wwwroot/wkhtmltopdf

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_HTTPS_PORT 443

ENTRYPOINT ["dotnet", "NykantMVC.dll"]