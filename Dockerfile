FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/Pekkupekku.Server.csproj", "Server/"]
COPY ["Client/Pekkupekku.Client.csproj", "Client/"]
COPY ["Shared/Pekkupekku.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Pekkupekku.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Pekkupekku.Server.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Pekkupekku.Server.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pekkupekku.Server.dll"]
