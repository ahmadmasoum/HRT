# HRT

### Pre-requirements

* [.NET8.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)
* [ABP CLI](https://abp.io/docs/latest/cli)

### Before running the application

* Run `abp install-libs` command on your solution folder to install client-side package dependencies

* Run `HRT.DbMigrator` to create the initial database. This should be done in the first run. It is also needed if a new database migration is added to the solution later.

### Solution structure

This is a layered monolith application that consists of the following applications:

* `HRT.DbMigrator`: A console application which applies the migrations and also seeds the initial data. It is useful on development as well as on production environment.
** `HRT.Web`: ASP.NET Core MVC / Razor Pages application that is the essential web application of the solution.


### After running

* You can find swagger with `BaseURL/swagger`

* The login credentials are `admin`, `1q2w3E*` 
