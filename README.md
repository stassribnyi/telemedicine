# Telemedicine Project <!-- TOC ignore:true -->

> **_NOTE:_** This app was created as part of my diploma project and is provided as is.

## Table of Contents <!-- TOC ignore:true -->

- [Telemedicine Project](#telemedicine-project)
  - [Table of Contents <!-- TOC ignore:true -->](#table-of-contents)
  - [Goal](#goal)
  - [Tech stack](#tech-stack)
  - [Software](#software)
  - [App Modules](#app-modules)
  - [Getting started](#getting-started)

## Goal

The main goal is the creation of the remote administration software for telemedical systems (RASoTS). The system provides an ability to manage patients and its telemedical data, performing analysis of the retrieved patient's data and remote treatment advice.

To simplify the integration process, the system should be designed to be used primarily through the browser.

## Tech stack

- .NET Framework 4.5.2 and C# (ASP.NET MVC)
- Code first / LINQ
- Microsoft SQL Server
- Angular v1.5.3
- Bootstrap v3.3.6
- Bootswatch v3.3.6 (Cerulean)

## Software

- Microsoft SQL Server
- Visual Studio 2017 or higher

## App Modules

- App uses DDD (domain driven design) architectural approach

| Module name             | Description.                                                                                   |
| ----------------------- | ---------------------------------------------------------------------------------------------- |
| Domain.Core             | Contains domain related classes.                                                               |
| Domain.Interfaces       | Contains interfaces of data access services working with domain model.                         |
| Business.Interfaces     | Contains interfaces of the business services and DTO classes.                                  |
| Infrastructure.Business | Contains implementation of Business.Interfaces                                                 |
| Infrastructure.Data     | Contains implementation of Domain.Interfaces                                                   |
| Security                | Contains implementation of authentication and authorization mechanisms. Is part of Web module. |
| Common                  | Contains common functionality used across different modules.                                   |
| Web                     | Contains SPA client application with all client forms.                                         |

## Getting started

- Clone repository

```bash
git clone https://github.com/stassribnyi/telemedicine.git
```

- Install all required software
- Open solution file **Telemedicine/Telemedicine.sln** with Visual Studio
- Change connectionString in **Web.config**, replace _<Your-Server/Name>_ with the name of your sql server

```xml
  <connectionStrings>
    <add name="TelemedicineContext" connectionString="Data Source=<Your-Server/Name>;Initial Catalog=telemedicine_storage;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

- Restore NuGet Packages
- Restore Database backup using [telemedicine_storage.bak](https://drive.google.com/open?id=1ebRaXdP0es1vi6bew07giJv6EYWMUdh2)
- Clean and Rebuild
- Start IIS Express
- Login Credentials (**login:** igor.alexandrov, **password:** Password123)
