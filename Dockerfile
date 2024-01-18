
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app


COPY Api/TetePizza.Api.csproj ./
RUN dotnet restore


COPY . .


RUN dotnet publish Api/TetePizza.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "TetePizza.Api.dll"]
