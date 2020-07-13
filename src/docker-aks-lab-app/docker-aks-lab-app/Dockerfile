#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/docker-aks-lab-app/docker-aks-lab-app/docker-aks-lab-app.csproj", "src/docker-aks-lab-app/docker-aks-lab-app/"]
RUN dotnet restore "src/docker-aks-lab-app/docker-aks-lab-app/docker-aks-lab-app.csproj"
COPY . .
WORKDIR "/src/src/docker-aks-lab-app/docker-aks-lab-app"
RUN dotnet build "docker-aks-lab-app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "docker-aks-lab-app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "docker-aks-lab-app.dll"]