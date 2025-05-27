FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["Starwars/*", "Starwars/"]

RUN dotnet tool install --global dotnet-ef
RUN dotnet tool install -g dotnet-reportgenerator-globaltool

# Instalar vsdbg para el debugging
RUN apt-get update && apt-get install -y unzip && \
    curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg
ENV PATH="${PATH}:/root/.dotnet/tools"