FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["dockerTest2/dockerTest2.csproj", "dockerTest2/"]
RUN dotnet restore "dockerTest2/dockerTest2.csproj"
COPY . .
WORKDIR "/src/dockerTest2"
RUN dotnet build "dockerTest2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dockerTest2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dockerTest2.dll"]