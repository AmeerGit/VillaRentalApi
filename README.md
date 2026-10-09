# VillaRentalApi

An ASP.NET Core Web API (.NET 10) for villa rentals, built with controllers, Entity Framework Core and SQLite. It's a learning project and a starting point for a fuller CRUD API.

## Tech stack

- .NET 10 / ASP.NET Core (controller-based API)
- Entity Framework Core 10 with SQLite
- OpenAPI plus [Scalar](https://github.com/scalar/scalar) for interactive API docs (Development only)

## Project structure

```
VillaRentalApi/
├── controllers/            API controllers (VillaController)
├── Data/                   EF Core DbContext (AppDbContext)
├── Models/                 Entity models (Villa)
├── Migrations/             EF Core migrations
├── Properties/             Launch settings
├── Program.cs              App startup and service configuration
├── VillaRentalApi.csproj   Project file
└── VillaRentalApi.http     Sample requests for VS Code / Visual Studio
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- EF Core CLI tool: `dotnet tool install --global dotnet-ef`

## Getting started

```bash
# restore packages
dotnet restore

# create the SQLite database (Villa.db) from the migrations
dotnet ef database update

# run the API
dotnet run
```

The API listens on `http://localhost:5214` and `https://localhost:7252` (see [Properties/launchSettings.json](Properties/launchSettings.json)).

In Development, interactive API docs are available at `/scalar/v1`, and the OpenAPI document at `/openapi/v1.json`.

## Endpoints

| Method | Route                    | Description                              |
| ------ | ------------------------ | ---------------------------------------- |
| GET    | `/api/villa`             | List all villas (placeholder)            |
| GET    | `/api/villa/{id}`        | Get a villa by id (placeholder)          |
| GET    | `/api/villa/{id}/{name}` | Get a villa by id and name (placeholder) |

> The controller currently returns placeholder strings. Wiring it to `AppDbContext` is the next step.

## Data model

`Villa`: `Id` (int), `Name` (string), `Rate` (double). It's stored in the `Villas` table in `Villa.db`.

## Working with migrations

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

## Roadmap

- [ ] Replace placeholder responses with EF Core queries
- [ ] Add create, update and delete endpoints
- [ ] Add DTOs and validation
- [ ] Add unit and integration tests
