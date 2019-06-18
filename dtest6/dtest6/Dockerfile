FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["dtest6/dtest6.csproj", "dtest6/"]
RUN dotnet restore "dtest6/dtest6.csproj"
COPY . .
WORKDIR "/src/dtest6"
RUN dotnet build "dtest6.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dtest6.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dtest6.dll"]