#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProjectVR.WebAPI/ProjectVR.WebAPI.csproj", "ProjectVR.WebAPI/"]
COPY ["ProjectVR.BusinessLogic/ProjectVR.BusinessLogic.csproj", "ProjectVR.BusinessLogic/"]
COPY ["ProjectVR.Domain/ProjectVR.Domain.csproj", "ProjectVR.Domain/"]
COPY ["ProjectVR.DataAccess/ProjectVR.DataAccess.csproj", "ProjectVR.DataAccess/"]
RUN dotnet restore "ProjectVR.WebAPI/ProjectVR.WebAPI.csproj"
COPY . .
WORKDIR "/src/ProjectVR.WebAPI"
RUN dotnet build "ProjectVR.WebAPI.csproj" -c Release -o /app/build



FROM build AS publish
RUN dotnet publish "ProjectVR.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectVR.WebAPI.dll"]