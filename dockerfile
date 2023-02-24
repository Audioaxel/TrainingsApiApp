# Basisimage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Arbeitsverzeichnis
WORKDIR /app

# Kopieren der Projektdateien in das Arbeitsverzeichnis
COPY . .

# Erstellen und Veröffentlichen der Class-Library WebApiLib
WORKDIR /app/WebApiLib
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Erstellen und Veröffentlichen der Class-Library DbAccessLib
WORKDIR /app/DbAccessLib
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Erstellen und Veröffentlichen der Konsolenanwendung
WORKDIR /app/ConsoleApp
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Basisimage für die Laufzeit
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Arbeitsverzeichnis
WORKDIR /app

# Kopieren der Veröffentlichungsdateien der Class-Library WebApiLib aus dem Build-Container
COPY --from=build-env /app/WebApiLib/out ./

# Kopieren der Veröffentlichungsdateien der Class-Library DbAccessLib aus dem Build-Container
COPY --from=build-env /app/DbAccessLib/out ./

# Kopieren der Veröffentlichungsdateien der Konsolenanwendung aus dem Build-Container
COPY --from=build-env /app/ConsoleApp/out ./

# Copy appsettings.json
COPY ./WebApiLib/appsettings.json .

# Starten der Konsolenanwendung
# EXPOSE 5000 5050 5080
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]
