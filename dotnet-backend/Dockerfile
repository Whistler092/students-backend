FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Students.sln ./
COPY Api/Students.csproj Api/

RUN dotnet restore
COPY . .
WORKDIR /src/Api
RUN dotnet build -c Release -o  /app/

FROM build AS publish
RUN dotnet publish -c Release -o /app/

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "/app/Students.dll"]