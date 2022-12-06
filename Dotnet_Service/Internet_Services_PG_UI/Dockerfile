FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Internet_Services_PG_UI/Internet_Services_PG_UI.csproj", "Internet_Services_PG_UI/"]
RUN dotnet restore "Internet_Services_PG_UI/Internet_Services_PG_UI.csproj"
COPY . .
WORKDIR "/src/Internet_Services_PG_UI"
RUN dotnet build "Internet_Services_PG_UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Internet_Services_PG_UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Internet_Services_PG_UI.dll"]
