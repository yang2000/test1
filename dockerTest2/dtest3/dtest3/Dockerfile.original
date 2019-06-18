FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["dtest3/dtest3.csproj", "dtest3/"]
RUN dotnet restore "dtest3/dtest3.csproj"
COPY . .
WORKDIR "/src/dtest3"
RUN dotnet build "dtest3.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dtest3.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dtest3.dll"]