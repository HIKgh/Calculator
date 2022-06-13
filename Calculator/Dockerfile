#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5074 5123
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Calculator/Calculator.csproj", "Calculator/"]
COPY ["Calculator.Application/Calculator.Application.csproj", "Calculator.Application/"]
COPY ["Calculator.Infrastructure/Calculator.Infrastructure.csproj", "Calculator.Infrastructure/"]
RUN dotnet restore "Calculator/Calculator.csproj"
COPY . .
WORKDIR "/src/Calculator"
RUN dotnet build "Calculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calculator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calculator.dll"]