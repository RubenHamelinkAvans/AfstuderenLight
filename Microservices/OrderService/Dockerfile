FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY OrderService/*.csproj ./OrderService/
COPY OrderServiceTests/*.csproj ./OrderServiceTests/
RUN dotnet restore

# copy everything else and build app
COPY OrderService/. ./OrderService/
COPY OrderServiceTests/. ./OrderServiceTests/
WORKDIR /app/OrderService
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/OrderService/out ./
ENTRYPOINT ["dotnet", "OrderService.dll"]