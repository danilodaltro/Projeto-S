#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ProjetoS.API/ProjetoS.API.csproj", "src/ProjetoS.API/"]
COPY ["src/ProjetoS.Application/ProjetoS.Application.csproj", "src/ProjetoS.Application/"]
COPY ["src/ProjetoS.Infra.Data/ProjetoS.Infra.Data.csproj", "src/ProjetoS.Infra.Data/"]
COPY ["src/ProjetoS.Domain/ProjetoS.Domain.csproj", "src/ProjetoS.Domain/"]
RUN dotnet restore "src/ProjetoS.API/ProjetoS.API.csproj"
COPY . .
WORKDIR "/src/src/ProjetoS.API"
RUN dotnet build "ProjetoS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoS.API.dll"]
