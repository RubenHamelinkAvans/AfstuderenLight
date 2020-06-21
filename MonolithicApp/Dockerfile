FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MonolithicApp/*.csproj ./MonolithicApp/
COPY MonolithicAppTests/*.csproj ./MonolithicAppTests/
RUN dotnet restore

# copy everything else and build app
COPY MonolithicApp/. ./MonolithicApp/
COPY MonolithicAppTests/. ./MonolithicAppTests/
WORKDIR /app/MonolithicApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/MonolithicApp/out ./
ENTRYPOINT ["dotnet", "MonolithicApp.dll"]