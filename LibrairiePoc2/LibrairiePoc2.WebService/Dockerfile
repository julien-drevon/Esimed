#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibrairiePoc2.WebService/LibrairiePoc2.WebService.csproj", "LibrairiePoc2.WebService/"]
RUN dotnet restore "LibrairiePoc2.WebService/LibrairiePoc2.WebService.csproj"
COPY . .
WORKDIR "/src/LibrairiePoc2.WebService"
RUN dotnet build "LibrairiePoc2.WebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibrairiePoc2.WebService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibrairiePoc2.WebService.dll"]