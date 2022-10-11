# emilima-v2-dotnet

This is the next version of the previous project for Emilima with better implementation using .NET Core for cross-compatibility and forcing a jump to Microsoft technologies.

## Configuration

There are additional configurations that you have to set to run this app.

### Environment variables

Create a `.\EmilimaV2Web\appsettings.Development.json` file to provide your own configurations. Additionally provide a connection string to connect with a database.

``` json
{
  "ConnectionStrings": {
    "Connection": "Data Source = {Your server}; Initial Catalog = {Your database}; User Id = {Your username}; Password = {Your password}; Encrypt=False; TrustServerCertificate=True;"
  }
}
```