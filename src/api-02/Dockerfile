FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY ["IngaiaService02.Api/IngaiaService02.Api.csproj", "./"]
RUN dotnet restore "./IngaiaService02.Api.csproj"

COPY . .
RUN dotnet build "/src/IngaiaService02.Api/IngaiaService02.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/IngaiaService02.Api/IngaiaService02.Api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser


CMD ASPNETCORE_URLS="http://*:$PORT" dotnet IngaiaService02.Api.dll


