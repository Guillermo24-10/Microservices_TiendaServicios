# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app
ENV  ASPNETCORE_URLS=http://+:80
EXPOSE 80


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TiendaServicios.Api.Autor/TiendaServicios.Api.Autor.csproj", "TiendaServicios.Api.Autor/"]
COPY ["TiendaServicios.Autor.Application/TiendaServicios.Autor.Application.csproj", "TiendaServicios.Autor.Application/"]
COPY ["TiendaServicios.Api.Shared/TiendaServicios.Api.Shared.csproj", "TiendaServicios.Api.Shared/"]
COPY ["TiendaServicios.Autor.Domain/TiendaServicios.Autor.Domain.csproj", "TiendaServicios.Autor.Domain/"]
COPY ["TiendaServicios.Autor.Infrastructure/TiendaServicios.Autor.Infrastructure.csproj", "TiendaServicios.Autor.Infrastructure/"]
RUN dotnet restore "./TiendaServicios.Api.Autor/TiendaServicios.Api.Autor.csproj"
COPY . .
WORKDIR "/src/TiendaServicios.Api.Autor"
RUN dotnet build "./TiendaServicios.Api.Autor.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TiendaServicios.Api.Autor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendaServicios.Api.Autor.dll"]