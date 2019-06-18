FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["ConsoleApp1/ConsoleApp1.csproj", "ConsoleApp1/"]
RUN dotnet restore "ConsoleApp1/ConsoleApp1.csproj"
COPY . .
WORKDIR "/src/ConsoleApp1"
RUN dotnet build "ConsoleApp1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ConsoleApp1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConsoleApp1.dll"]