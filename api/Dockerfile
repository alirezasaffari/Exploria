#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Exploria-Task/Api.csproj", "Exploria-Task/"]
COPY ["app/app.csproj", "app/"]
COPY ["Domain/domain.csproj", "Domain/"]
COPY ["infra/infra.csproj", "infra/"]
RUN dotnet restore "Exploria-Task/Api.csproj"
COPY . .
WORKDIR "/src/Exploria-Task"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]