FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Presentation/MoneyManager.API/MoneyManager.API.csproj", "Presentation/MoneyManager.API/"]
COPY ["Core/MoneyManager.Application/MoneyManager.Application.csproj", "Core/MoneyManager.Application/"]
COPY ["Core/MoneyManager.Domain/MoneyManager.Domain.csproj", "Core/MoneyManager.Domain/"]
COPY ["Infrastructure/MoneyManager.Persistence/MoneyManager.Persistence.csproj", "Infrastructure/MoneyManager.Persistence/"]
COPY ["Infrastructure/MoneyManager.Infrastructure/MoneyManager.Infrastructure.csproj", "Infrastructure/MoneyManager.Infrastructure/"]
RUN dotnet restore "Presentation/MoneyManager.API/MoneyManager.API.csproj"

COPY . .
WORKDIR "/src/Presentation/MoneyManager.API"
RUN dotnet build "MoneyManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MoneyManager.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Elasticsearch environment değişkenlerini kullanarak başlat
ENV ELASTICSEARCH_URL=http://elasticsearch:9200

ENTRYPOINT ["dotnet", "MoneyManager.API.dll"]