FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Notification.Scheduler/Notification.Scheduler.csproj", "Notification.Scheduler/"]
RUN dotnet restore "Notification.Scheduler/Notification.Scheduler.csproj"
COPY . .
WORKDIR "/src/Notification.Scheduler"
RUN dotnet build "Notification.Scheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notification.Scheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.Scheduler.dll"]
