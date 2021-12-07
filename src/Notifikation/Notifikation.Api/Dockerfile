#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Notifikation/Notifikation.Api/Notifikation.Api.csproj", "src/Notifikation/Notifikation.Api/"]
COPY ["src/Notifikation/Notifikation.Infrastucture/Notifikation.Infrastructure.csproj", "src/Notifikation/Notifikation.Infrastucture/"]
COPY ["src/Notifikation/Notifikation.Domain/Notifikation.Domain.csproj", "src/Notifikation/Notifikation.Domain/"]
COPY ["src/eDocument/eDocument.Infrastructure/eDocument.Infrastructure.csproj", "src/eDocument/eDocument.Infrastructure/"]
COPY ["src/eDocument/eDocument.Domain/eDocument.Domain.csproj", "src/eDocument/eDocument.Domain/"]
RUN dotnet restore "src/Notifikation/Notifikation.Api/Notifikation.Api.csproj"
COPY . .
WORKDIR "/src/src/Notifikation/Notifikation.Api"
RUN dotnet build "Notifikation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notifikation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifikation.Api.dll"]