FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MovieClub.Migrations/MovieClub.Migrations.csproj", "MovieClub.Migrations/"]
RUN dotnet restore "MovieClub.Migrations/MovieClub.Migrations.csproj"
COPY . .
WORKDIR "/src/MovieClub.Migrations"
RUN dotnet build "MovieClub.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MovieClub.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieClub.Migrations.dll"]
