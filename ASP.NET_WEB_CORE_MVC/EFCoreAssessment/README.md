# Library Book Management System - Repository Pattern Implementation

## About This Project

This is a training project that demonstrates the implementation of the Repository Pattern in ASP.NET Core MVC. The project was built to showcase how to design a flexible data access layer that can be easily switched between different storage implementations without affecting the rest of the application.

The project follows a two-phase approach:
1. **Phase 1**: Start with in-memory storage for rapid development and testing
2. **Phase 2**: Migrate to SQL Server for persistent data storage

This approach teaches important software design principles including:
- Dependency Injection
- Interface-based programming
- Separation of concerns
- SOLID principles (especially Dependency Inversion)

## Overview

The Library Book Management System allows users to manage a collection of books with full CRUD operations (Create, Read, Update, Delete). The application demonstrates how the Repository Pattern enables switching between in-memory and database storage by changing just one line of code in the dependency injection configuration.

The application uses a clean, custom CSS design without external frameworks like Bootstrap, keeping the focus on the architectural patterns rather than UI frameworks.

## Project Structure

```
├── Models/
│   └── Book.cs                          # Book entity model
├── Repositories/
│   ├── IBookRepository.cs               # Repository interface
│   ├── MemoryBookRepository.cs          # Phase 1: In-memory implementation
│   └── SqlBookRepository.cs             # Phase 2: SQL Server implementation
├── Data/
│   └── LibraryDbContext.cs              # EF Core DbContext with seed data
├── Controllers/
│   └── BookController.cs                # MVC Controller (unchanged between phases)
├── Views/Book/
│   ├── List.cshtml                      # Display all books
│   ├── Details.cshtml                   # Display single book
│   ├── Create.cshtml                    # Add new book
│   └── Delete.cshtml                    # Delete book confirmation
└── wwwroot/css/
    └── site.css                         # Custom CSS styling
```

## Switching Between Phases

### Phase 1: In-Memory Storage
Edit `Program.cs` and use:
```csharp
builder.Services.AddScoped<IBookRepository, MemoryBookRepository>();
```

### Phase 2: SQL Server Storage (Current Configuration)
Edit `Program.cs` and use:
```csharp
builder.Services.AddScoped<IBookRepository, SqlBookRepository>();
```

**Note**: Only this single line needs to change! The controller and views remain identical.

## Database Configuration

Connection String (in `appsettings.json`):
```
Server=.\\SQLExpress;Database=StudentPortal;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```

### Database Setup

The database has been created with Entity Framework Core migrations:

1. **Initial Migration**: Creates the Books table
2. **Seed Data Migration**: Populates the database with 3 sample books

To recreate the database:
```bash
dotnet ef database drop
dotnet ef database update
```

## Running the Application

1. **Restore packages**:
   ```bash
   dotnet restore
   ```

2. **Run the application**:
   ```bash
   dotnet run
   ```

3. **Navigate to**: `http://localhost:5136` (or the port shown in the console)
   - Default route redirects to `/Book/List`

## Features

- **List Books**: View all books in the library with a clean table layout
- **View Details**: See detailed information about a specific book
- **Add Book**: Create a new book entry with form validation
- **Delete Book**: Remove a book from the library with confirmation

## Initial Sample Data

The system comes pre-loaded with 3 books:
1. Clean Code - Robert C. Martin ($45.99)
2. Design Patterns - GoF ($54.99)
3. Refactoring - Martin Fowler ($49.99)

## Key Benefits of Repository Pattern

1. **Separation of Concerns**: Data access logic is isolated from business logic
2. **Easy Testing**: Controllers can be tested with mock repositories
3. **Flexibility**: Switch data sources without changing application code
4. **Maintainability**: Changes to data access only affect repository implementations
5. **Dependency Injection**: Loose coupling through constructor injection

## Technologies Used

- ASP.NET Core MVC (.NET 10.0)
- Entity Framework Core 9.0
- SQL Server Express
- Custom CSS (no external frameworks)

## Design Decisions

- **No layout pages**: Each view is self-contained with its own HTML structure for simplicity
- **Clean, minimal CSS**: Custom CSS without Bootstrap to focus on functionality
- **Direct routing**: Application routes directly to Book controller (no Home controller)
- **Repository pattern**: Enables easy data source switching with minimal code changes
- **Seed data**: Configured in DbContext for consistent initial state across environments
- **Constructor injection**: All dependencies injected through constructors following best practices
- **Interface segregation**: Single responsibility interfaces for clean architecture

## Project Requirements Met

This project fulfills the following requirements:

### Phase 1 Requirements ✓
- Book model with BookId, Title, Author, and Price properties
- IBookRepository interface with GetAllBooks, GetBookById, AddBook, and DeleteBook methods
- MemoryBookRepository implementation using Dictionary<int, Book>
- BookController using constructor injection (no List<Book> in controller)
- Initial data with 3 sample books
- Full CRUD operations without database dependency

### Phase 2 Requirements ✓
- LibraryDbContext with DbSet<Book>
- SqlBookRepository implementation using Entity Framework Core
- Database migrations created and applied
- Connection string configured for SQL Server Express
- Dependency injection configuration in Program.cs
- No changes required to controller or views when switching implementations

## Learning Outcomes

By studying this project, you will learn:

1. **Repository Pattern**: How to abstract data access logic behind interfaces
2. **Dependency Injection**: How to use ASP.NET Core's built-in DI container
3. **Entity Framework Core**: How to configure DbContext, create migrations, and seed data
4. **MVC Architecture**: How to structure controllers, models, and views
5. **Interface-based Design**: How to program against abstractions rather than concrete implementations
6. **Migration Strategy**: How to evolve from simple to complex storage solutions

## Future Enhancements

Potential improvements for learning purposes:
- Add Update/Edit functionality
- Implement search and filtering
- Add pagination for large book lists
- Include unit tests for repositories
- Add validation attributes to the Book model
- Implement async/await patterns
- Add logging and error handling
- Create an API layer (Web API controllers)
