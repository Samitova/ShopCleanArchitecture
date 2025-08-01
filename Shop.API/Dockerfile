#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Shop.API/Shop.API.csproj", "Shop.API/"]
COPY ["Shop.Application/Shop.Application.csproj", "Shop.Application/"]
COPY ["Shop.Domain/Shop.Domain.csproj", "Shop.Domain/"]
COPY ["Shop.Infrastructure/Shop.Infrastructure.csproj", "Shop.Infrastructure/"]
RUN dotnet restore "./Shop.API/Shop.API.csproj"
COPY . .
WORKDIR "/src/Shop.API"
RUN dotnet build "./Shop.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Shop.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shop.API.dll"]