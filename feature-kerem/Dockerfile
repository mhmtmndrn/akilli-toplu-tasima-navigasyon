FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/SmartTransitNavigation.csproj ./src/
RUN dotnet restore ./src/SmartTransitNavigation.csproj

COPY src/ ./src/
RUN dotnet publish ./src/SmartTransitNavigation.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SmartTransitNavigation.dll"]
