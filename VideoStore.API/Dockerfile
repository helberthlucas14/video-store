#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["VideoStore.API/VideoStore.API.csproj", "VideoStore.API/"]
COPY ["VideoStore.Infrastructure/VideoStore.Infrastructure.csproj", "VideoStore.Infrastructure/"]
COPY ["VideoStore.Infrastructure.CrossCutting.Commons/VideoStore.Infrastructure.CrossCutting.Commons.csproj", "VideoStore.Infrastructure.CrossCutting.Commons/"]
COPY ["VideoStore.Core/VideoStore.Core.csproj", "VideoStore.Core/"]
COPY ["VideoStore.Application/VideoStore.Application.csproj", "VideoStore.Application/"]

RUN dotnet restore "VideoStore.API/VideoStore.API.csproj"
COPY . .
WORKDIR "/src/VideoStore.API"

ENV DATABASE_HOST $DATABASE_HOST
ENV DATABASE_USER $DATABASE_USER
ENV DATABASE_PASSWORD $DATABASE_PASSWORD
ENV ASPNETCORE_ENVIRONMENT $ENVIRONMENT
ENV ASPNETCORE_URLS $ASPNETCORE_URLS

RUN dotnet build "VideoStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideoStore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoStore.API.dll"]
