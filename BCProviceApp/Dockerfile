#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BCProviceApp/BCProviceApp.csproj", "BCProviceApp/"]
COPY ["BCProviceApp.DataAccess/BCProviceApp.DataAccess.csproj", "BCProviceApp.DataAccess/"]
COPY ["BCProviceApp.Model/BCProviceApp.Model.csproj", "BCProviceApp.Model/"]
RUN dotnet restore "BCProviceApp/BCProviceApp.csproj"
COPY . .
WORKDIR "/src/BCProviceApp"
RUN dotnet build "BCProviceApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BCProviceApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCProviceApp.dll"]