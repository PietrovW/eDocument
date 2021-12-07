#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OCR/OCR.Api/OCR.Api.csproj", "src/OCR/OCR.Api/"]
COPY ["src/OCR/OCR.Infrastructure/OCR.Infrastructure.csproj", "src/OCR/OCR.Infrastructure/"]
COPY ["src/eDocument/eDocument.Infrastructure/eDocument.Infrastructure.csproj", "src/eDocument/eDocument.Infrastructure/"]
COPY ["src/eDocument/eDocument.Domain/eDocument.Domain.csproj", "src/eDocument/eDocument.Domain/"]
RUN dotnet restore "src/OCR/OCR.Api/OCR.Api.csproj"
COPY . .
WORKDIR "/src/src/OCR/OCR.Api"
RUN dotnet build "OCR.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OCR.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OCR.Api.dll"]