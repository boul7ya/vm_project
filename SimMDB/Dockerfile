# 1) Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY MdbApi.csproj ./
RUN dotnet restore MdbApi.csproj

COPY . .
RUN dotnet publish MdbApi.csproj -c Release -o /app/out --no-restore

# 2) Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MdbApi.dll"]
