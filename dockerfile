FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

COPY . .

RUN dotnet clean ibrahim-kabiru-P1.sln

RUN dotnet publish webAPI --configuration Release -o ./publish