FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

# Copy and build
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0

# Setup TLS overrides
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1\nMaxProtocol = TLSv1/' /etc/ssl/openssl.cnf \
 && sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf

WORKDIR /App
COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "MyConsole.dll"]