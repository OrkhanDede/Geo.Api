#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Geo.Api/Geo.Api.csproj", "Geo.Api/"]
RUN dotnet restore "Geo.Api/Geo.Api.csproj"
COPY . .
WORKDIR "/src/Geo.Api"
RUN dotnet build "Geo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Geo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Geo.Api.dll"]