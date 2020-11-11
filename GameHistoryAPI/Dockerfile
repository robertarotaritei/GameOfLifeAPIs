#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GameHistoryAPI/GameHistoryAPI.csproj", "GameHistoryAPI/"]
RUN dotnet restore "GameHistoryAPI/GameHistoryAPI.csproj"
COPY . .
WORKDIR "/src/GameHistoryAPI"
RUN dotnet build "GameHistoryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameHistoryAPI.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://+:3003
ENV ASPNETCORE_URLS=https://+:5003
EXPOSE 3003 5003
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameHistoryAPI.dll"]