# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["pricing_poc.csproj", "./"]
RUN dotnet restore "./pricing_poc.csproj"
COPY . .
RUN dotnet publish "./pricing_poc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "pricing_poc.dll"]
