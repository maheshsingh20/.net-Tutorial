# UMS (User Management System)

An ASP.NET Core MVC web application with Identity authentication and Entity Framework Core for user management.

## Technology Stack

- ASP.NET Core 10.0
- Entity Framework Core 10.0.3
- ASP.NET Core Identity
- SQL Server (LocalDB/SQLExpress)
- Razor Pages & MVC

## Features

- User authentication and authorization using ASP.NET Core Identity
- User registration with email confirmation
- Secure login/logout functionality
- SQL Server database integration
- Entity Framework Core migrations
- MVC architecture with Razor views

## Project Structure

```
UMS/
├── Controllers/        # MVC Controllers
├── Models/            # Data models and view models
├── Views/             # Razor views
├── Data/              # Database context and migrations
├── Areas/             # Identity UI areas
├── wwwroot/           # Static files (CSS, JS, images)
└── Program.cs         # Application entry point
```

## Prerequisites

- .NET 10.0 SDK
- SQL Server Express or SQL Server LocalDB
- Visual Studio 2022 or VS Code

## Configuration

### Database Connection

The application uses SQL Server with the following connection string (configured in `appsettings.json`):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLExpress;Database=Trial_LBU_DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

Update this connection string based on your SQL Server instance.

## Setup Instructions

1. Clone or navigate to the project directory
2. Update the connection string in `appsettings.json` if needed
3. Run database migrations:
   ```bash
   dotnet ef database update
   ```
4. Build the project:
   ```bash
   dotnet build
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

## Running the Application

The application will start on HTTPS by default. Navigate to:
- `https://localhost:5001` (or the port shown in the console)

## Key Dependencies

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - Identity framework
- `Microsoft.EntityFrameworkCore.SqlServer` - SQL Server provider
- `Microsoft.AspNetCore.Identity.UI` - Pre-built Identity UI
- `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` - EF Core diagnostics

## Development Notes

- The application requires email confirmation for new user accounts
- HTTPS redirection is enabled by default
- Development environment uses migrations endpoint for database errors
- Production environment uses custom error handling

## Database Migrations

To create a new migration:
```bash
dotnet ef migrations add MigrationName
```

To update the database:
```bash
dotnet ef database update
```

## Security Features

- Password hashing and salting
- Anti-forgery tokens
- HTTPS enforcement
- Secure authentication cookies
- Email confirmation requirement
