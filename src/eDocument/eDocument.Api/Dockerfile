#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/eDocument/eDocument.Api/eDocument.Api.csproj", "src/eDocument/eDocument.Api/"]
COPY ["src/eDocument/eDocument.Infrastructure/eDocument.Infrastructure.csproj", "src/eDocument/eDocument.Infrastructure/"]
COPY ["src/eDocument/eDocument.Domain/eDocument.Domain.csproj", "src/eDocument/eDocument.Domain/"]
RUN dotnet restore "src/eDocument/eDocument.Api/eDocument.Api.csproj"
COPY . .
WORKDIR "/src/src/eDocument/eDocument.Api"
RUN dotnet build "eDocument.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eDocument.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eDocument.Api.dll"]