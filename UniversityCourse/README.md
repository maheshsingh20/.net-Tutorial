# University Course Registration System

## Overview
A complete console-based university course registration system implemented in C#. This system allows managing courses, students, and course registrations with validation for prerequisites, credit limits, and course capacity.

## Features Implemented

### Course Management
- ✅ Add courses with code, name, credits, capacity, and prerequisites
- ✅ Track course enrollment (current/max capacity)
- ✅ Validate course capacity before enrollment
- ✅ Check prerequisites before allowing registration
- ✅ Display all available courses with enrollment info

### Student Management
- ✅ Add students with ID, name, major, and max credit limit
- ✅ Track completed courses for prerequisite validation
- ✅ Register students for courses with validation
- ✅ Drop courses from student schedule
- ✅ Display individual student schedules
- ✅ Calculate total credits for enrolled courses

### System Features
- ✅ Credit limit validation (default 18 credits)
- ✅ Prerequisite checking
- ✅ Course capacity management
- ✅ Duplicate registration prevention
- ✅ System summary with statistics
- ✅ Menu-driven interface

## How to Run

### Method 1: Visual Studio
1. Open `UniverSity Course Registration System.sln`
2. Press F5 or click Run

### Method 2: Command Line
```bash
cd "UniverSity Course Registration System/UniverSity Course Registration System"
dotnet run
```

## Menu Options

1. **Add Course** - Create a new course with prerequisites
2. **Add Student** - Register a new student
3. **Register Student for Course** - Enroll student in a course
4. **Drop Student from Course** - Remove student from a course
5. **Display All Courses** - Show all available courses
6. **Display Student Schedule** - View a student's enrolled courses
7. **Display System Summary** - View system statistics
8. **Exit** - Close the application

## Example Usage

### Adding a Course
```
Enter Course Code: CS101
Enter Course Name: Introduction to Programming
Enter Credits: 3
Enter Max Capacity: 30
Enter Prerequisites: (press Enter for none)
```

### Adding a Student
```
Enter Student ID: S001
Enter Student Name: John Doe
Enter Major: Computer Science
Enter Max Credits: 18
Enter Completed Courses: (press Enter for none)
```

### Registering for a Course
```
Enter Student ID: S001
Enter Course Code: CS101
```

## Validation Rules

### Course Registration
- ✅ Student cannot register for the same course twice
- ✅ Total credits cannot exceed student's max credit limit
- ✅ All course prerequisites must be completed
- ✅ Course must not be at full capacity

### Course Prerequisites
- Courses can have multiple prerequisites
- Prerequisites are checked against student's completed courses
- Registration is blocked if prerequisites are not met

### Credit Limits
- Default max credits: 18
- Can be customized per student
- System prevents over-enrollment

## Class Structure

### Course.cs
- Properties: CourseCode, CourseName, Credits, MaxCapacity, Prerequisites
- Methods: IsFull(), HasPrerequisites(), EnrollStudent(), DropStudent()

### Student.cs
- Properties: StudentId, Name, Major, MaxCredits, CompletedCourses, RegisteredCourses
- Methods: GetTotalCredits(), CanAddCourse(), AddCourse(), DropCourse(), DisplaySchedule()

### UniversitySystem.cs
- Manages all courses and students
- Handles registration and course management
- Provides system-wide operations and statistics

### Program.cs
- Menu-driven interface
- User input handling
- Exception handling

## Sample Test Scenario

```
1. Add Course: CS101, Intro to Programming, 3 credits, 30 capacity, no prerequisites
2. Add Course: CS201, Data Structures, 4 credits, 25 capacity, prerequisite: CS101
3. Add Student: S001, John Doe, Computer Science, 18 max credits, completed: CS101
4. Register S001 for CS201 (should succeed - has prerequisite)
5. Display Student Schedule for S001
6. Display System Summary
```

## Error Handling

The system handles:
- Duplicate course codes
- Duplicate student IDs
- Invalid student/course lookups
- Credit limit violations
- Prerequisite violations
- Course capacity violations
- Invalid user input

## Statistics Displayed

System Summary shows:
- Total number of students
- Total number of courses
- Total enrollments across all courses
- Average enrollment per course
- Most popular course

## Technologies Used

- C# 8.0+
- .NET 8.0
- Console Application
- LINQ for data queries
- Collections (Dictionary, List)

## Completed Functions

All TODO items have been implemented:

### Course.cs
- ✅ IsFull()
- ✅ HasPrerequisites()
- ✅ EnrollStudent()
- ✅ DropStudent()

### Student.cs
- ✅ GetTotalCredits()
- ✅ CanAddCourse()
- ✅ AddCourse()
- ✅ DropCourse()
- ✅ DisplaySchedule()

### UniversitySystem.cs
- ✅ AddCourse()
- ✅ AddStudent()
- ✅ RegisterStudentForCourse()
- ✅ DropStudentFromCourse()
- ✅ DisplayAllCourses()
- ✅ DisplayStudentSchedule()
- ✅ DisplaySystemSummary()

### Program.cs
- ✅ Complete menu-driven interface
- ✅ All 8 menu options implemented
- ✅ Input validation and error handling

## Notes

- The system uses nullable reference types (C# 8.0+)
- Build warnings about nullable references are expected and safe
- All core functionality is fully implemented and tested
