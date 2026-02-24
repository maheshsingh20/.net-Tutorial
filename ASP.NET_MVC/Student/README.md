# Student MVC Application

A minimal ASP.NET Core MVC application demonstrating the fundamentals of the MVC pattern with data models.

## Project Structure

```
Student/
├── Controllers/          # Handle requests and business logic
│   ├── HomeController.cs
│   ├── PractiseController.cs
│   └── PupilController.cs
├── Models/              # Data models
│   └── Pupil.cs
├── Views/               # UI templates
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Practise/
│   │   └── Index.cshtml
│   ├── Pupil/
│   │   ├── Index.cshtml
│   │   └── Show.cshtml
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
- Pupil List: `http://localhost:5000/Pupil`
- Pupil Details: `http://localhost:5000/Pupil/Show`

## Key Files Explained

### Program.cs
Application entry point that:
- Configures services with `AddControllersWithViews()`
- Sets up middleware pipeline (HTTPS, Routing, Authorization)
- Defines routing pattern: `{controller=Home}/{action=Index}/{id?}`
- Starts the web server with `app.Run()`

### Controllers
Handle HTTP requests and return responses.

**HomeController.cs** - Default controller
```csharp
public IActionResult Index() => View();
```
Maps to: `Views/Home/Index.cshtml`

**PractiseController.cs** - Practice controller
```csharp
public IActionResult Index() => View();
```
Maps to: `Views/Practise/Index.cshtml`

**PupilController.cs** - Pupil management with data
```csharp
public IActionResult Show()
{
    List<Pupil> pupils = new List<Pupil>
    {
        new Pupil { Id = 1, Name = "Alice", Age = 14, Grade = "9th", City = "New York" },
        new Pupil { Id = 2, Name = "Bob", Age = 15, Grade = "10th", City = "Los Angeles" },
        new Pupil { Id = 3, Name = "Charlie", Age = 13, Grade = "8th", City = "Chicago" }
    };
    return View(pupils);
}
```
Maps to: `Views/Pupil/Show.cshtml` with data

### Models
Data structures representing application entities.

**Pupil.cs** - Pupil data model
```csharp
public class Pupil
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public string City { get; set; }
}
```

### Views
Razor templates that generate HTML.

**_Layout.cshtml** - Master template with navigation and footer

**_ViewStart.cshtml** - Sets default layout for all views

**_ViewImports.cshtml** - Global imports and Tag Helpers

**Show.cshtml** - Strongly-typed view with model
```razor
@model List<Student.Models.Pupil>

@foreach (var s in Model)
{
    <tr>
        <td>@s.Name</td>
        <td>@s.Age</td>
    </tr>
}
```

## Routing

| URL | Controller | Action | View |
|-----|------------|--------|------|
| `/` | Home | Index | Views/Home/Index.cshtml |
| `/Home` | Home | Index | Views/Home/Index.cshtml |
| `/Practise` | Practise | Index | Views/Practise/Index.cshtml |
| `/Pupil` | Pupil | Index | Views/Pupil/Index.cshtml |
| `/Pupil/Show` | Pupil | Show | Views/Pupil/Show.cshtml |

## MVC Pattern with Data Flow

```
User Request → Routing → Controller → Model (Data) → View → Response
```

1. User visits URL
2. Routing matches controller and action
3. Controller creates/fetches model data
4. Controller passes model to view
5. View renders HTML with model data
6. Response sent to browser

## Key Concepts Demonstrated

### 1. Basic MVC Structure
- Controllers handle requests
- Views display UI
- Routing maps URLs to controllers

### 2. Data Models
- Created `Pupil` model class
- Defined properties (Id, Name, Age, Grade, City)
- Represents data structure

### 3. Passing Data to Views
- Controller creates `List<Pupil>`
- Uses `return View(pupils)` to pass data
- View receives data via `@model` directive

### 4. Strongly-Typed Views
- View declares expected model type: `@model List<Student.Models.Pupil>`
- Access data with `@Model` in view
- IntelliSense support for model properties

### 5. Dynamic Content Rendering
- Use `@foreach` to loop through collections
- Display model properties with `@s.Name`, `@s.Age`
- Generate HTML dynamically based on data

## Adding New Features

### Add a New Controller with Data

1. Create model in `Models/`:
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

2. Create controller in `Controllers/`:
```csharp
public class StudentController : Controller
{
    public IActionResult List()
    {
        var students = new List<Student>
        {
            new Student { Id = 1, Name = "John" }
        };
        return View(students);
    }
}
```

3. Create view in `Views/Student/List.cshtml`:
```razor
@model List<Student.Models.Student>

@foreach (var s in Model)
{
    <p>@s.Name</p>
}
```

4. Access at: `/Student/List`

## Technologies

- .NET 10.0
- ASP.NET Core MVC
- Razor View Engine
- C# Models and Collections
