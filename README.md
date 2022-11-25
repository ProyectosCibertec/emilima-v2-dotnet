# emilima-v2-dotnet

This is the next version of the previous project for Emilima with better implementation using .NET Core for cross-compatibility and forcing a jump to Microsoft technologies.

## Project setup

In order to run this project you need to follow this guide thoroughly.

### Requirements

- .NET 6 SDK
- .NET CLI
- Visual Studio (2022 or above)
- SQL Server in your system
- Git (if you would like to contribute to this project)

### Environment variables

Create a `.\EmilimaV2Web\appsettings.Development.json` file to provide your own configurations. Additionally insert a connection string to connect with a database.

``` json
{
  "ConnectionStrings": {
    "Connection": "Data Source = <Your server>; Initial Catalog = <Your database>; User Id = <Your username>; Password = <Your password>; Encrypt=False; TrustServerCertificate=True;"
  }
}
```

Note that \<Your server\> may be any of these options: `(local)`, `.` or `YOUR-SERVER/SQLSERVER`

### Database

Now that you configured the project, create the database in order to get information from a data source in your local machine. Use the scripts `Script.sql` and `DataScript.sql` saved in `.\EmilimaV2Web\Database\` and execute them.

## Build and run

### Install dependencies

``` bash
$ npm run install-all
```

### Start project in local
``` bash	
$ npm run dev
```

## Docker setup

Soon or later son.