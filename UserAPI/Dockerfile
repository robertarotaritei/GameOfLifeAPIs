FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["UserAPI/UserAPI.csproj", "UserAPI/"]
RUN dotnet restore "UserAPI/UserAPI.csproj"
COPY . .
WORKDIR "/src/UserAPI"
RUN dotnet build "UserAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAPI.csproj" -c Release -o /app/publish

FROM base AS final
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=https://+:5001
EXPOSE 5001
WORKDIR /app
COPY --from=base /app/publish .
ENTRYPOINT ["./UserAPI"]