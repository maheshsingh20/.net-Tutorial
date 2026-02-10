using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            return RegisteredCourses.Sum(course => course.Credits);
        }

        public bool CanAddCourse(Course course)
        {
            // Check if already registered
            if (RegisteredCourses.Any(c => c.CourseCode == course.CourseCode))
            {
                Console.WriteLine($"Already registered for {course.CourseCode}");
                return false;
            }

            // Check credit limit
            if (GetTotalCredits() + course.Credits > MaxCredits)
            {
                Console.WriteLine($"Cannot add {course.CourseCode}: Would exceed max credits ({MaxCredits})");
                return false;
            }

            // Check prerequisites
            if (!course.HasPrerequisites(CompletedCourses))
            {
                Console.WriteLine($"Cannot add {course.CourseCode}: Prerequisites not met");
                return false;
            }

            return true;
        }

        public bool AddCourse(Course course)
        {
            if (!CanAddCourse(course))
                return false;

            if (course.IsFull())
            {
                Console.WriteLine($"Cannot add {course.CourseCode}: Course is full");
                return false;
            }

            RegisteredCourses.Add(course);
            course.EnrollStudent();
            Console.WriteLine($"Successfully registered for {course.CourseCode} - {course.CourseName}");
            return true;
        }

        public bool DropCourse(string courseCode)
        {
            var course = RegisteredCourses.FirstOrDefault(c => c.CourseCode == courseCode);
            
            if (course == null)
            {
                Console.WriteLine($"Not registered for course {courseCode}");
                return false;
            }

            RegisteredCourses.Remove(course);
            course.DropStudent();
            Console.WriteLine($"Successfully dropped {courseCode}");
            return true;
        }

        public void DisplaySchedule()
        {
            Console.WriteLine($"\n=== Schedule for {Name} ({StudentId}) ===");
            Console.WriteLine($"Major: {Major} | Max Credits: {MaxCredits}");
            
            if (RegisteredCourses.Count == 0)
            {
                Console.WriteLine("No courses registered");
                return;
            }

            Console.WriteLine($"\nRegistered Courses (Total Credits: {GetTotalCredits()}):");
            Console.WriteLine("Code\t\tName\t\t\t\tCredits");
            Console.WriteLine("------------------------------------------------------------");
            
            foreach (var course in RegisteredCourses)
            {
                Console.WriteLine($"{course.CourseCode}\t\t{course.CourseName,-30}\t{course.Credits}");
            }
        }
    }
}
