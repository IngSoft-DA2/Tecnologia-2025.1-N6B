FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Starwars/starwars.WebApi/starwars.WebApi.csproj", "Starwars/starwars.WebApi/"]
RUN dotnet restore "Starwars\starwars.WebApi\starwars.WebApi.csproj"
COPY . .
WORKDIR "/src/Starwars/starwars.WebApi"
RUN dotnet build "starwars.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "starwars.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "starwars.WebApi.dll"]
