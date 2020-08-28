#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DilaAPI/DilaAPI.csproj", "DilaAPI/"]
COPY ["DilaApplication/DilaApplication.csproj", "DilaApplication/"]
COPY ["DilaRepository/DilaRepository.csproj", "DilaRepository/"]
COPY ["DilaEntities/DilaEntities.csproj", "DilaEntities/"]
COPY ["DilaShared/DilaShared.csproj", "DilaShared/"]
RUN dotnet restore "DilaAPI/DilaAPI.csproj"
COPY . .
WORKDIR "/src/DilaAPI"
RUN dotnet build "DilaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DilaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DilaAPI.dll"]
