# Student MVC Application

A minimal ASP.NET Core MVC application demonstrating the fundamentals of the MVC pattern.

## Project Structure

```
Student/
├── Controllers/          # Handle requests and business logic
│   ├── HomeController.cs
│   └── PractiseController.cs
├── Views/               # UI templates
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Practise/
│   │   └── Index.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/             # Static files (empty)
├── Program.cs           # Application entry point
├── Student.csproj       # Project configuration
└── appsettings.json     # App settings
```

## How to Run

```cmd
cd Student
dotnet run
```

Or with hot reload:

```cmd
dotnet watch run
```

Access the application:
- Home: `http://localhost:5000/` or `https://localhost:5001/`
- Practise: `http://localhost:5000/Practise`

## Key Files Explained

### Program.cs
Application entry point that:
- Configures services
- Sets up middleware pipeline
- Defines routing: `{controller=Home}/{action=Index}/{id?}`

### Controllers
Handle HTTP requests and return responses.

**HomeController.cs** - Default controller
```csharp
public IActionResult Index() => View();
```
Maps to: `Views/Home/Index.cshtml`

**PractiseController.cs** - Custom controller
```csharp
public IActionResult Index() => View();
```
Maps to: `Views/Practise/Index.cshtml`

### Views
Razor templates that generate HTML.

**_Layout.cshtml** - Master template with navigation and footer

**_ViewStart.cshtml** - Sets default layout for all views

**_ViewImports.cshtml** - Global imports and Tag Helpers

## Routing

| URL | Controller | Action | View |
|-----|------------|--------|------|
| `/` | Home | Index | Views/Home/Index.cshtml |
| `/Home` | Home | Index | Views/Home/Index.cshtml |
| `/Practise` | Practise | Index | Views/Practise/Index.cshtml |

## MVC Pattern

```
User Request → Routing → Controller → View → Response
```

1. User visits URL
2. Routing matches controller and action
3. Controller processes request
4. Controller returns view
5. View renders HTML
6. Response sent to browser

## Adding New Pages

1. Create controller in `Controllers/`:
```csharp
public class StudentController : Controller
{
    public IActionResult List() => View();
}
```

2. Create view in `Views/Student/List.cshtml`:
```html
<h1>Student List</h1>
```

3. Access at: `/Student/List`

## Technologies

- .NET 10.0
- ASP.NET Core MVC
- Razor View Engine
