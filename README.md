# TrainingsApiApp

For developement:
Add your sql ConnectionString into the appsettings.json located in /WebApiLib/appsettings.json. Copy file into /ConsoleApp

Build Docker image:
1. Add a solution into root folder -> Dotnet add sln
2. Add all Projects to solution -> Dotnet sln add "Complete Path to Project"
3. Add sql ConnectionString into appsettings.json located in /WebApiLib/appsettings.json
3. Docker build -t "image-name" .

Note: At the moment there is no automated Database Migration. You need to add TestModel to your Database!

Get Docker Image:
docker run -it -p 2001:2000 -e PORT=2000 audioaxel1/trainings_api:1.0.0

Note: This repository is private:-)


 

