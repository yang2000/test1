FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["dtest5/dtest5.csproj", "dtest5/"]
RUN dotnet restore "dtest5/dtest5.csproj"
COPY . .
WORKDIR "/src/dtest5"
RUN dotnet build "dtest5.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dtest5.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dtest5.dll"]