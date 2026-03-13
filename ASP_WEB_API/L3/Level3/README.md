# ASP.NET Core Web API with JWT Authentication

This project demonstrates a complete implementation of JWT authentication and authorization in ASP.NET Core Web API.

## Features

- JWT Token-based authentication
- Role-based authorization (Admin and User roles)
- Entity Framework Core with SQL Server
- ASP.NET Core Identity Framework
- Secure password hashing
- Token expiration (3 hours)

## Project Structure

```
Level3/
├── Controllers/
│   ├── AuthenticateController.cs    # Authentication endpoints
│   └── WeatherForecastController.cs # Protected sample endpoint
├── Models/
│   ├── ApplicationUser.cs           # Custom user model
│   ├── RegisterModel.cs             # Registration DTO
│   ├── LoginModel.cs                # Login DTO
│   └── Response.cs                  # API response model
├── Auth/
│   └── UserRoles.cs                 # Role constants
├── Data/
│   └── ApplicationDbContext.cs      # EF Core DbContext
├── appsettings.json                 # Configuration including JWT settings
└── Program.cs                       # Application startup
```

## Prerequisites

- .NET 10.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

## Setup Instructions

### 1. Restore NuGet Packages

```bash
dotnet restore
```

### 2. Update Connection String

Edit `appsettings.json` and update the connection string if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Level3AuthDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. Run Entity Framework Migrations

Open Package Manager Console in Visual Studio or use the command line:

```bash
# Add initial migration
dotnet ef migrations add Initial

# Update database
dotnet ef database update
```

Or in Package Manager Console:
```
Add-Migration Initial
Update-Database
```

### 4. Run the Application

```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`

## API Endpoints

### Authentication Endpoints

#### 1. Register User
- **URL**: `POST /api/authenticate/register`
- **Body**:
```json
{
  "username": "testuser",
  "email": "testuser@example.com",
  "password": "Test@123"
}
```
- **Response**:
```json
{
  "status": "Success",
  "message": "User created successfully!"
}
```

#### 2. Register Admin
- **URL**: `POST /api/authenticate/register-admin`
- **Body**:
```json
{
  "username": "admin",
  "email": "admin@example.com",
  "password": "Admin@123"
}
```
- **Response**:
```json
{
  "status": "Success",
  "message": "Admin user created successfully!"
}
```

#### 3. Login
- **URL**: `POST /api/authenticate/login`
- **Body**:
```json
{
  "username": "testuser",
  "password": "Test@123"
}
```
- **Response**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2026-03-13T18:30:00Z"
}
```

### Protected Endpoints

#### Get Weather Forecast (Admin Only)
- **URL**: `GET /weatherforecast`
- **Headers**: 
  - `Authorization: Bearer {your-jwt-token}`
- **Access**: Admin role required

## Testing with Postman

### Step 1: Register a User

1. Create a new POST request to `https://localhost:5001/api/authenticate/register`
2. Set Headers: `Content-Type: application/json`
3. Set Body (raw JSON):
```json
{
  "username": "testuser",
  "email": "testuser@example.com",
  "password": "Test@123"
}
```
4. Send the request

### Step 2: Register an Admin

1. Create a new POST request to `https://localhost:5001/api/authenticate/register-admin`
2. Set Headers: `Content-Type: application/json`
3. Set Body (raw JSON):
```json
{
  "username": "admin",
  "email": "admin@example.com",
  "password": "Admin@123"
}
```
4. Send the request

### Step 3: Login

1. Create a new POST request to `https://localhost:5001/api/authenticate/login`
2. Set Headers: `Content-Type: application/json`
3. Set Body (raw JSON):
```json
{
  "username": "admin",
  "password": "Admin@123"
}
```
4. Send the request
5. Copy the `token` value from the response

### Step 4: Access Protected Endpoint

1. Create a new GET request to `https://localhost:5001/weatherforecast`
2. Go to the Authorization tab
3. Select Type: "Bearer Token"
4. Paste the token from Step 3
5. Send the request

**Note**: Only users with Admin role can access the WeatherForecast endpoint.

## JWT Configuration

The JWT settings are configured in `appsettings.json`:

```json
"JWT": {
  "ValidAudience": "http://localhost:5000",
  "ValidIssuer": "http://localhost:5000",
  "Secret": "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"
}
```

### JWT Token Details

- **Expiration**: 3 hours
- **Algorithm**: HMAC SHA256
- **Claims**:
  - Username (ClaimTypes.Name)
  - Unique Token ID (JwtRegisteredClaimNames.Jti)
  - User Roles (ClaimTypes.Role)

## Security Considerations

1. **Secret Key**: Change the JWT Secret in production to a strong, unique value
2. **HTTPS**: Always use HTTPS in production
3. **Password Policy**: Configure stronger password requirements in production
4. **Token Storage**: Store tokens securely on the client side
5. **Connection String**: Use environment variables or Azure Key Vault for sensitive data

## Role-Based Authorization

The project includes two roles:

- **User**: Default role for registered users
- **Admin**: Administrative role with elevated permissions

### Protecting Endpoints

Use the `[Authorize]` attribute to protect endpoints:

```csharp
// Require authentication
[Authorize]
public class MyController : ControllerBase { }

// Require specific role
[Authorize(Roles = UserRoles.Admin)]
public class AdminController : ControllerBase { }

// Multiple roles
[Authorize(Roles = "Admin,User")]
public class SharedController : ControllerBase { }
```

## Troubleshooting

### Database Connection Issues
- Ensure SQL Server is running
- Verify the connection string in appsettings.json
- Check if the database was created successfully

### Migration Issues
```bash
# Remove last migration
dotnet ef migrations remove

# List migrations
dotnet ef migrations list

# Update to specific migration
dotnet ef database update {MigrationName}
```

### 401 Unauthorized
- Verify the token is valid and not expired
- Check if the token is properly formatted in the Authorization header
- Ensure the user has the required role

## Additional Resources

- [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [JWT Authentication](https://jwt.io/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
