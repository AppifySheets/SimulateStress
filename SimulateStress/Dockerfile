FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SimulateStress/SimulateStress.csproj", "SimulateStress/"]
RUN dotnet restore "SimulateStress/SimulateStress.csproj"
COPY . .
WORKDIR "/src/SimulateStress"
RUN dotnet build "SimulateStress.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimulateStress.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimulateStress.dll"]
