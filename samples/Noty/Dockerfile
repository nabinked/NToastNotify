FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Noty.csproj", "."]
RUN dotnet restore "Noty.csproj"
COPY . .
RUN dotnet build "Noty.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Noty.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Noty.dll"]