# Web.Truck
> Project that demonstrates WebApi, ORM (EntityFramework Core), Migrations and Unit Testing

## Installing / Getting started

Install:
- [.NET Core 5 SDK](https://www.microsoft.com/net/core/)

Execute:
```shell
$ dotnet --version

5.0.301
```

```shell
$ dotnet build

$ cd Web.Truck.API

$ dotnet run
```

## Tests

Run Tests (go to test directory "\Web.Truck.UnitTest"")

```shell
$ dotnet test
```

## Api Reference

http://localhost:5000/Swagger

## Database

SQLite (localDB)

## Developing

### Built With
Main packages: .Net Core 5, Entity Framework Core 5, Swashbuckle, AutoMapper, FluentValidation, xunit

### Prerequisites
What is needed to set up the dev environment. For instance, global dependencies or any other tools. include download links.

Install:
- [.NET Core 5 SDK](https://www.microsoft.com/net/core/)

Execute:
```shell
$ dotnet --version

5.0.301
```

```shell
$ dotnet tool install --global dotnet-ef
```

```shell
$ dotnet restore

$ dotnet build

cd Web.Truck.API

$ dotnet run
```