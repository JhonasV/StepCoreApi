# StepCore
StepCore is a RRHH hire management system

Client made with Flutter+Dart

```dash
https://github.com/JhonasV/Step
````

## Features
Managment for:
- Language
- Competencies
- Users
- Roles
- Applicants
- Trainings
- Employees
- JobPositions
- LaborExperiences

## Technologies
- ASP.NET Core 5 API 
- EntityFramework Core
- JWT Bearer Token
- 

## Installation

Restore the dependecies

```bash
dotnet restore
```
Add Sql Server connection string in  `appsettings.development.json` file

```bash
 "DefaultConnection": "Your connection string here"
```
Go in the root of the folder `StepCoreApi\StepCore.Data` and setup the database

### NUGET
```bash
Update-database
```
### EF CORE LI

```bash
dotnet ef database update
```


## Run the project
Go to the project root folder
```bash
dotnet run -p StepCore
```

App Running must be running in ports:
```bash
 localhost:5001 OR localhost:5000
```



