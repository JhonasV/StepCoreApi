# StepCore
StepCore is a RRHH hire management system

Client made with Flutter+Dart


[Client app repository](https://github.com/JhonasV/Step)


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

## Installation

Restore the dependecies in the folder `StepCoreApi` root

```bash
dotnet restore
```
Add Sql Server connection string in  `StepCore/appsettings.development.json` file

```bash
 "DefaultConnection": "Your Sql Server connection string here"
```
Go in the root of the folder `StepCoreApi\StepCore.Data` and setup the database


```bash
Update-database
```
OR  
### EF CORE CLI

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
Default user with admin role
```bash
 username: admin
 password: admin
```


