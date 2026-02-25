# University Web API

ASP.NET Core Web API project providing RESTful endpoints for university management system.

## Project Overview

This is a .NET Web API built with ASP.NET Core that provides various endpoints for managing university data, including student information, greetings, and age validation.

## Technology Stack

- ASP.NET Core Web API
- .NET 10.0
- C# 13.0
- OpenAPI/Swagger for API documentation
- CORS enabled for React frontend integration

## Project Structure

```
University/
├── Controllers/          # API Controllers
│   ├── StudentController.cs
│   ├── AgeController.cs
│   ├── GreetingController.cs
│   ├── HelloController.cs
│   └── LandingController.cs
├── Models/              # Data Models
│   └── Student.cs
├── Properties/          # Project properties
├── appsettings.json     # Configuration
└── Program.cs           # Application entry point
```

## Configuration

### CORS Policy
The API is configured to allow requests from the React frontend running on `http://localhost:5173`.

```csharp
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowReact", policy =>
  {
    policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
  });
});
```

### API Base URL
- Development: `https://localhost:7270`
- HTTP Redirect: Enabled

## Data Models

### Student Model
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
```

## API Controllers

### 1. StudentController
Manages student data operations.

**Base Route:** `/api/student`

#### Endpoints:

**GET /api/student**
- Description: Retrieves all students
- Method: GET
- Response: 200 OK
- Response Body:
```json
[
  {
    "id": 1,
    "name": "Alice",
    "age": 20
  },
  {
    "id": 2,
    "name": "Bob",
    "age": 22
  },
  {
    "id": 3,
    "name": "Charlie",
    "age": 21
  }
]
```

**Example Request:**
```bash
curl -X GET https://localhost:7270/api/student
```

**Use Case:** Fetch all student records for display in the frontend application.

---

### 2. AgeController
Validates and returns student age information.

**Base Route:** `/api/age`

#### Endpoints:

**GET /api/age/{age}**
- Description: Validates and returns age information
- Method: GET
- Parameters:
  - `age` (int, required) - Student age to validate
- Response: 200 OK or 400 Bad Request
- Response Body (Success):
```json
"Student age is 20"
```
- Response Body (Error):
```json
"Invalid Age"
```

**Example Requests:**
```bash
# Valid age
curl -X GET https://localhost:7270/api/age/20

# Invalid age (negative)
curl -X GET https://localhost:7270/api/age/-5
```

**Validation Rules:**
- Age must be non-negative (>= 0)
- Returns BadRequest for negative values

**Use Case:** Validate student age before processing enrollment or registration.

---

### 3. GreetingController
Provides greeting messages with optional personalization.

**Base Route:** `/api/greeting`

#### Endpoints:

**GET /api/greeting**
- Description: Returns a simple greeting message
- Method: GET
- Response: 200 OK
- Response Body:
```json
"Greetings!"
```

**Example Request:**
```bash
curl -X GET https://localhost:7270/api/greeting
```

**GET /api/greeting/{name}/{message}**
- Description: Returns a personalized greeting with custom message
- Method: GET
- Parameters:
  - `name` (string, required) - Person's name
  - `message` (string, required) - Custom message
- Response: 200 OK
- Response Body:
```json
"Alice, Greetings , Welcome!"
```

**Example Request:**
```bash
curl -X GET https://localhost:7270/api/greeting/Alice/Welcome
```

**Console Output:**
- Simple greeting: "Hello from the GreetingController!"
- Personalized: "Hello Alice, Welcome from the GreetingController!"

**Use Case:** Welcome messages for user login or dashboard display.

---

### 4. HelloController
Simple hello world endpoint with optional name parameter.

**Base Route:** `/api/hello`

#### Endpoints:

**GET /api/hello**
- Description: Returns a hello world message
- Method: GET
- Response: 200 OK
- Response Body:
```json
"Hello World!"
```

**Example Request:**
```bash
curl -X GET https://localhost:7270/api/hello
```

**GET /api/hello/{name}**
- Description: Returns a personalized hello message
- Method: GET
- Parameters:
  - `name` (string, required) - Person's name
- Response: 200 OK
- Response Body:
```json
"Hello, Alice!"
```

**Example Request:**
```bash
curl -X GET https://localhost:7270/api/hello/Alice
```

**Use Case:** Testing API connectivity and basic personalization.

---

### 5. LandingController
Provides welcome message for the API landing page.

**Base Route:** `/api/landing`

#### Endpoints:

**GET /api/landing**
- Description: Returns welcome message for the University API
- Method: GET
- Response: 200 OK
- Response Body:
```json
"Welcome to the University API!"
```

**Example Request:**
```bash
curl -X GET https://localhost:7270/api/landing
```

**Console Output:**
"Welcome to the University API!"

**Use Case:** API health check and welcome page display.

---

## Running the API

### Prerequisites
- .NET 10.0 SDK or later
- Visual Studio 2022 or VS Code
- Port 7270 (HTTPS) available

### Steps to Run

1. Navigate to the project directory:
```bash
cd ASP_WEB_API/University
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run
```

5. Access the API:
- HTTPS: `https://localhost:7270`
- OpenAPI/Swagger: `https://localhost:7270/openapi/v1.json` (Development only)

### Development Mode
In development mode, OpenAPI documentation is automatically generated and available.

## Testing the API

### Using cURL

**Test Student Endpoint:**
```bash
curl -X GET https://localhost:7270/api/student
```

**Test Age Validation:**
```bash
curl -X GET https://localhost:7270/api/age/25
```

**Test Greeting:**
```bash
curl -X GET https://localhost:7270/api/greeting/John/Welcome
```

### Using Browser
Simply navigate to:
- `https://localhost:7270/api/student`
- `https://localhost:7270/api/hello`
- `https://localhost:7270/api/landing`

### Using Postman
1. Import the API endpoints
2. Set base URL: `https://localhost:7270`
3. Test each endpoint with appropriate parameters

## API Response Formats

### Success Response (200 OK)
```json
{
  "data": "response data",
  "status": "success"
}
```

### Error Response (400 Bad Request)
```json
{
  "error": "error message",
  "status": "error"
}
```

## CORS Configuration

The API allows cross-origin requests from:
- `http://localhost:5173` (React development server)

To add more origins, modify the CORS policy in `Program.cs`:
```csharp
policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
```

## Security Considerations

1. HTTPS is enforced in production
2. CORS is restricted to specific origins
3. Input validation is implemented (e.g., age validation)
4. Authorization middleware is configured (can be extended)

## Future Enhancements

1. Add POST, PUT, DELETE endpoints for Student CRUD operations
2. Implement database integration (Entity Framework Core)
3. Add authentication and authorization (JWT)
4. Implement logging and error handling middleware
5. Add data validation attributes to models
6. Implement pagination for student list
7. Add search and filter capabilities
8. Implement unit and integration tests

## Common Issues

### Port Already in Use
If port 7270 is already in use, modify `launchSettings.json` in Properties folder.

### CORS Errors
Ensure the React app is running on `http://localhost:5173` or update the CORS policy.

### SSL Certificate Issues
Trust the development certificate:
```bash
dotnet dev-certs https --trust
```

## API Endpoints Summary

| Endpoint | Method | Description | Parameters |
|----------|--------|-------------|------------|
| `/api/student` | GET | Get all students | None |
| `/api/age/{age}` | GET | Validate age | age (int) |
| `/api/greeting` | GET | Simple greeting | None |
| `/api/greeting/{name}/{message}` | GET | Personalized greeting | name, message |
| `/api/hello` | GET | Hello world | None |
| `/api/hello/{name}` | GET | Personalized hello | name |
| `/api/landing` | GET | Welcome message | None |

## Contact & Support

For issues or questions, please refer to the project documentation or contact the development team.

## License

This project is for educational purposes.
