FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY controller.usuario/controller.usuario.csproj controller.usuario/
RUN dotnet restore controller.usuario/controller.usuario.csproj
COPY . .
WORKDIR /src/controller.usuario
RUN dotnet build controller.usuario.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish controller.usuario.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "controller.usuario.dll"]
