# How to Run Each Question

## ✨ Simple Method (Recommended)

Navigate to any question folder and run:

```bash
cd m1Assessment_Practise/Questions/Question1
dotnet run
```

That's it! Each question folder has its own project file.

### Examples:

**Run Question 1:**
```bash
cd m1Assessment_Practise/Questions/Question1
dotnet run
```

**Run Question 8:**
```bash
cd m1Assessment_Practise/Questions/Question8
dotnet run
```

**Run Question 25:**
```bash
cd m1Assessment_Practise/Questions/Question25
dotnet run
```

---

## Alternative: Run from Root Directory

If you don't want to change directories:

```bash
# Run Question 1
dotnet run --project m1Assessment_Practise/Questions/Question1/Question1.csproj

# Run Question 5
dotnet run --project m1Assessment_Practise/Questions/Question5/Question5.csproj

# Run Question 15
dotnet run --project m1Assessment_Practise/Questions/Question15/Question15.csproj
```

---

## Quick Reference - All Questions

Copy and paste these commands to run each question:

```bash
# Question 1 - Concurrent Ticket Booking
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question1.Problem

# Question 2 - Rate Limiter
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question2.Problem

# Question 3 - Resilient Payment Gateway
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question3.Problem

# Question 4 - Producer-Consumer
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question4.Problem

# Question 5 - Log Analyzer
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question5.Problem

# Question 6 - Money Transfer
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question6.Problem

# Question 7 - JSON Validation
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question7.Problem

# Question 8 - Cache with TTL
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question8.Problem

# Question 9 - Parallel Aggregation
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question9.Problem

# Question 10 - Command Pattern
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question10.Problem

# Question 11 - Deadlock-Free Banking
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question11.Problem

# Question 12 - Workflow Engine
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question12.Problem

# Question 13 - CSV Import
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question13.Problem

# Question 14 - Password Hashing
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question14.Problem

# Question 15 - Custom LINQ
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question15.Problem

# Question 16 - Multi-Tenant Reports
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question16.Problem

# Question 17 - Async Pipeline
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question17.Problem

# Question 18 - Duplicate Detection
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question18.Problem

# Question 19 - Audit Tracking
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question19.Problem

# Question 20 - RBAC Engine
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question20.Problem

# Question 21 - Bulk Email Sender
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question21.Problem

# Question 22 - Fraud Detection
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question22.Problem

# Question 23 - Plugin Loader
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question23.Problem

# Question 24 - Thread-Safe Singleton
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question24.Problem

# Question 25 - Mini Order System
dotnet run --project m1Assessment_Practise.csproj /p:StartupObject=m1Assessment_Practise.Questions.Question25.Problem
```

---

## Using Visual Studio / VS Code

### Visual Studio:
1. Right-click on the `Problem.cs` file you want to run
2. Select "Set as Startup Object"
3. Press F5 or click Run

### VS Code:
1. Open `m1Assessment_Practise.csproj`
2. Edit the `<StartupObject>` line
3. Press F5 or run `dotnet run` in terminal

---

## Troubleshooting

### Error: "Multiple entry points found"
- Make sure only ONE `<StartupObject>` is set in the .csproj file
- Or use Method 2 with the command line parameter

### Error: "Cannot find the specified startup object"
- Check the namespace and class name are correct
- Ensure the Problem.cs file has a `static void Main` method

### Build Errors:
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

---

## Project Structure

```
m1Assessment_Practise/
├── Questions/
│   ├── Question1/
│   │   ├── Problem.cs          ← Main entry point
│   │   ├── Seat.cs             ← Entity
│   │   └── TicketBookingSystem.cs  ← Logic
│   ├── Question2/
│   │   ├── Problem.cs
│   │   └── RateLimiter.cs
│   └── ... (Question3 - Question25)
├── m1Assessment_Practise.csproj
└── HOW_TO_RUN.md (this file)
```

Each `Problem.cs` contains the `Main` method and demonstrates the solution.
