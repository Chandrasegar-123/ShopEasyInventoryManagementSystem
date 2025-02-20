# ShopEasy Inventory Management System
# ASP.NET Core Web API - .NET 8

## Prerequisites

Ensure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload) or [Visual Studio Code](https://code.visualstudio.com/) with C# extension
- [Postman](https://www.postman.com/) or any API testing tool (optional)

## Getting Started

### 1. Clone the Repository
```sh
git clone <repository-url>
cd <project-folder>
```

### 2. Restore Dependencies
```sh
dotnet restore
```

### 3. Build the Project
```sh
dotnet build
```

### 4. Run the API
```sh
dotnet run
```

### 5. Open in Browser or API Tool
By default, the API runs on `https://localhost:5001` and `http://localhost:5000`.
- Open your browser and navigate to `https://localhost:5001/swagger` (if Swagger is enabled).
- Use Postman or any API client to send requests.

## Configuration

### App Settings
Modify `appsettings.json` for configuration changes (e.g., database connection strings, logging, etc.).

### Change Database Connection URL
To update the database connection string, modify the `ConnectionStrings` section in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-server>;Database=<your-database>;User Id=<your-username>;Password=<your-password>;"
  }
}
```
Alternatively, set it using an environment variable:
```sh
set ConnectionStrings__DefaultConnection="Server=<your-server>;Database=<your-database>;User Id=<your-username>;Password=<your-password>;"
```
For Linux/macOS:
```sh
export ConnectionStrings__DefaultConnection="Server=<your-server>;Database=<your-database>;User Id=<your-username>;Password=<your-password>;"
```

### Environment Variables
To set environment variables for development:
```sh
set ASPNETCORE_ENVIRONMENT=Development
```
For Linux/macOS:
```sh
export ASPNETCORE_ENVIRONMENT=Development
```

## Data Migration

### 1. Add a New Migration
```sh
dotnet ef migrations add InitialCreate
```

### 2. Apply Migrations to Database
```sh
dotnet ef database update
```

### 3. Rollback Last Migration (If Needed)
```sh
dotnet ef migrations remove
```

Ensure `Microsoft.EntityFrameworkCore.Design` and `Microsoft.EntityFrameworkCore.SqlServer` packages are installed in your project.

## Additional Resources
- [Microsoft ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)

---

Enjoy building your ASP.NET Core Web API with .NET 8! 🚀


- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)

---

Enjoy building your ASP.NET Core Web API with .NET 8! 🚀

