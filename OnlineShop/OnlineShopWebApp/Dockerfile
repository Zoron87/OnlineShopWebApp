#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OnlineShopWebApp/OnlineShopWebApp.csproj", "OnlineShopWebApp/"]
COPY ["OnlineShop.DB/OnlineShop.DB.csproj", "OnlineShop.DB/"]
COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
RUN dotnet restore "OnlineShopWebApp/OnlineShopWebApp.csproj"
COPY . .
WORKDIR "/src/OnlineShopWebApp"
RUN dotnet build "OnlineShopWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShopWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShopWebApp.dll"]