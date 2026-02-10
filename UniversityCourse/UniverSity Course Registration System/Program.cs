using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": // Add Course
                            Console.Write("Enter Course Code: ");
                            string courseCode = Console.ReadLine();
                            
                            Console.Write("Enter Course Name: ");
                            string courseName = Console.ReadLine();
                            
                            Console.Write("Enter Credits: ");
                            int credits = int.Parse(Console.ReadLine());
                            
                            Console.Write("Enter Max Capacity (default 50): ");
                            string capacityInput = Console.ReadLine();
                            int maxCapacity = string.IsNullOrWhiteSpace(capacityInput) ? 50 : int.Parse(capacityInput);
                            
                            Console.Write("Enter Prerequisites (comma-separated, or press Enter for none): ");
                            string prereqInput = Console.ReadLine();
                            List<string> prerequisites = null;
                            if (!string.IsNullOrWhiteSpace(prereqInput))
                            {
                                prerequisites = prereqInput.Split(',').Select(p => p.Trim()).ToList();
                            }
                            
                            system.AddCourse(courseCode, courseName, credits, maxCapacity, prerequisites);
                            break;

                        case "2": // Add Student
                            Console.Write("Enter Student ID: ");
                            string studentId = Console.ReadLine();
                            
                            Console.Write("Enter Student Name: ");
                            string studentName = Console.ReadLine();
                            
                            Console.Write("Enter Major: ");
                            string major = Console.ReadLine();
                            
                            Console.Write("Enter Max Credits (default 18): ");
                            string maxCreditsInput = Console.ReadLine();
                            int maxCredits = string.IsNullOrWhiteSpace(maxCreditsInput) ? 18 : int.Parse(maxCreditsInput);
                            
                            Console.Write("Enter Completed Courses (comma-separated, or press Enter for none): ");
                            string completedInput = Console.ReadLine();
                            List<string> completedCourses = null;
                            if (!string.IsNullOrWhiteSpace(completedInput))
                            {
                                completedCourses = completedInput.Split(',').Select(c => c.Trim()).ToList();
                            }
                            
                            system.AddStudent(studentId, studentName, major, maxCredits, completedCourses);
                            break;

                        case "3": // Register Student for Course
                            Console.Write("Enter Student ID: ");
                            string regStudentId = Console.ReadLine();
                            
                            Console.Write("Enter Course Code: ");
                            string regCourseCode = Console.ReadLine();
                            
                            system.RegisterStudentForCourse(regStudentId, regCourseCode);
                            break;

                        case "4": // Drop Student from Course
                            Console.Write("Enter Student ID: ");
                            string dropStudentId = Console.ReadLine();
                            
                            Console.Write("Enter Course Code: ");
                            string dropCourseCode = Console.ReadLine();
                            
                            system.DropStudentFromCourse(dropStudentId, dropCourseCode);
                            break;

                        case "5": // Display All Courses
                            system.DisplayAllCourses();
                            break;

                        case "6": // Display Student Schedule
                            Console.Write("Enter Student ID: ");
                            string scheduleStudentId = Console.ReadLine();
                            
                            system.DisplayStudentSchedule(scheduleStudentId);
                            break;

                        case "7": // Display System Summary
                            system.DisplaySystemSummary();
                            break;

                        case "8": // Exit
                            exit = true;
                            Console.WriteLine("Thank you for using the University Course Registration System!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

