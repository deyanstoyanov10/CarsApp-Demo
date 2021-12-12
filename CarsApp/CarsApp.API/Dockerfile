FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarsApp.API/CarsApp.API.csproj", "CarsApp.API/"]
COPY ["CarsApp.Infrastructure/CarsApp.Infrastructure.csproj", "CarsApp.Infrastructure/"]
COPY ["CarsApp.Common/CarsApp.Common.csproj", "CarsApp.Common/"]
COPY ["CarsApp.Data/CarsApp.Data.csproj", "CarsApp.Data/"]
COPY ["CarsApp.Services/CarsApp.Services.csproj", "CarsApp.Services/"]
COPY ["CarsApp.Models/CarsApp.Models.csproj", "CarsApp.Models/"]
RUN dotnet restore "CarsApp.API/CarsApp.API.csproj"
COPY . .
WORKDIR "/src/CarsApp.API"
RUN dotnet build "CarsApp.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CarsApp.API.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarsApp.API.dll"]