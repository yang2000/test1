#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["WebCoriMVCApp2/WebCoriMVCApp2.csproj", "WebCoriMVCApp2/"]
RUN dotnet restore "WebCoriMVCApp2/WebCoriMVCApp2.csproj"
COPY . .
WORKDIR "/src/WebCoriMVCApp2"
RUN dotnet build "WebCoriMVCApp2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebCoriMVCApp2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebCoriMVCApp2.dll"]