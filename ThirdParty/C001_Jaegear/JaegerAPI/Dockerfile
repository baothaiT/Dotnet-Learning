FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["C001_Jaegear.csproj", "./"]
RUN dotnet restore "C001_Jaegear.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "C001_Jaegear.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "C001_Jaegear.dll"]
