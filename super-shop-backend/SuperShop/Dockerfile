FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000;
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SuperShop/SuperShop.csproj", "SuperShop/"]
RUN dotnet restore SuperShop/SuperShop.csproj
COPY . .
WORKDIR "/src/SuperShop"
RUN dotnet build "SuperShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuperShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuperShop.dll"]
