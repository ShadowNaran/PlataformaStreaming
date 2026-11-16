FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY PlataformaStreaming.csproj ./
RUN dotnet restore PlataformaStreaming.csproj
COPY . ./
RUN dotnet build PlataformaStreaming.csproj --no-restore -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
COPY --from=build /app/build ./
USER $APP_UID
ENTRYPOINT ["dotnet", "PlataformaStreaming.dll"]
