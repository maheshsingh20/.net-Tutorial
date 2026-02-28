# Feb27MeetingProblem - Employee LINQ Queries

A .NET console application demonstrating LINQ queries on an Employee collection.

## Problem Statement

Create a console application with an Employee class and perform various LINQ queries on a collection of employees.

## Employee Class

The Employee class contains the following properties:
- EmployeeID (Integer)
- FirstName (String)
- LastName (String)
- Title (String)
- DOB (Date of Birth)
- DOJ (Date of Joining)
- City (String)

## LINQ Queries Implemented

### a. Display all employees
Shows complete details of all 10 employees in the collection.

### b. Employees NOT in Mumbai
Filters and displays employees whose location is not Mumbai.
Result: 6 employees (Pune and Chennai locations)

### c. Employees with title 'AsstManager'
Displays employees with the title "AsstManager".
Result: 1 employee (Asdin Dhalla)

### d. Employees with Last Name starting with 'S'
Shows employees whose last name starts with the letter 'S'.
Result: 3 employees (Saba Shaikh, Nazia Shaikh, Sumit Shah)

### e. Employees who joined before 1/1/2015
Lists all employees who joined the company before January 1, 2015.
Result: 4 employees

## Project Structure

```
Feb27MeetingProblem/
├── Employee.cs          # Employee class definition
├── Program.cs           # Main program with LINQ queries
├── Feb27MeetingProblem.csproj
└── README.md
```

## How to Run

1. Navigate to the project directory:
   ```bash
   cd Feb27MeetingProblem
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

## Sample Output

The application displays formatted output for each LINQ query with employee details including ID, name, title, dates, and city.

## Technology

- .NET 10.0
- C# with LINQ (Language Integrated Query)
- Generic List<T> collection
