# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos la solución y los proyectos
COPY Yorugua.sln ./
COPY Yorugua/Yorugua.csproj Yorugua/
COPY DataAccess/DataAccess.csproj DataAccess/
COPY Domain/Domain.csproj Domain/
COPY Dtos/Dtos.csproj Dtos/
COPY IDataAccess/IDataAccess.csproj IDataAccess/
COPY IServiceLogic/IServiceLogic.csproj IServiceLogic/
COPY ServiceLogic/ServiceLogic.csproj ServiceLogic/

# Restaurar dependencias
RUN dotnet restore Yorugua.sln

# Copiar el resto del código fuente
COPY . .

# Publicar el proyecto web
RUN dotnet publish Yorugua/Yorugua.csproj -c Release -o /app/publish

# Etapa final: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Yorugua.dll"]