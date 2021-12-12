FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:5000

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["CarsApp.API.csproj", "./"]
RUN dotnet restore "CarsApp.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CarsApp.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CarsApp.API.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarsApp.API.dll"]
