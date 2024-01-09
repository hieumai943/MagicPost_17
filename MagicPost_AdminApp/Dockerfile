#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MagicPost_AdminApp/MagicPost_AdminApp.csproj", "MagicPost_AdminApp/"]
COPY ["MagicPost_ApiIntergration/MagicPost_ApiIntergration.csproj", "MagicPost_ApiIntergration/"]
COPY ["MagicPostUtilities.cs/MagicPostUtilities.cs.csproj", "MagicPostUtilities.cs/"]
COPY ["MagicPost_ViewModel/MagicPost_ViewModel.csproj", "MagicPost_ViewModel/"]
COPY ["MagicPost__Data/MagicPost__Data.csproj", "MagicPost__Data/"]
RUN dotnet restore "MagicPost_AdminApp/MagicPost_AdminApp.csproj"
COPY . .
WORKDIR "/src/MagicPost_AdminApp"
RUN dotnet build "MagicPost_AdminApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagicPost_AdminApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagicPost_AdminApp.dll"]