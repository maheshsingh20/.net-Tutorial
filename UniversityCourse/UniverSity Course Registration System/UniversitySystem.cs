using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException($"Course {code} already exists");

            var course = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses[code] = course;
            Console.WriteLine($"Course {code} - {name} added successfully");
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            if (Students.ContainsKey(id))
                throw new ArgumentException($"Student {id} already exists");

            var student = new Student(id, name, major, maxCredits, completedCourses);
            Students[id] = student;
            Console.WriteLine($"Student {id} - {name} added successfully");
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine($"Student {studentId} not found");
                return false;
            }

            if (!AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine($"Course {courseCode} not found");
                return false;
            }

            var student = Students[studentId];
            var course = AvailableCourses[courseCode];

            return student.AddCourse(course);
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine($"Student {studentId} not found");
                return false;
            }

            var student = Students[studentId];
            return student.DropCourse(courseCode);
        }

        public void DisplayAllCourses()
        {
            Console.WriteLine("\n=== Available Courses ===");
            
            if (AvailableCourses.Count == 0)
            {
                Console.WriteLine("No courses available");
                return;
            }

            Console.WriteLine("Code\t\tName\t\t\t\tCredits\tEnrollment\tPrerequisites");
            Console.WriteLine("--------------------------------------------------------------------------------");
            
            foreach (var course in AvailableCourses.Values)
            {
                string prereqs = course.Prerequisites.Count > 0 
                    ? string.Join(", ", course.Prerequisites) 
                    : "None";
                
                Console.WriteLine($"{course.CourseCode}\t\t{course.CourseName,-30}\t{course.Credits}\t{course.GetEnrollmentInfo()}\t\t{prereqs}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine($"Student {studentId} not found");
                return;
            }

            var student = Students[studentId];
            student.DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            Console.WriteLine("\n=== System Summary ===");
            Console.WriteLine($"Total Students: {Students.Count}");
            Console.WriteLine($"Total Courses: {AvailableCourses.Count}");

            if (AvailableCourses.Count > 0)
            {
                int totalEnrollments = Students.Values.Sum(s => s.RegisteredCourses.Count);
                double avgEnrollment = AvailableCourses.Count > 0 
                    ? (double)totalEnrollments / AvailableCourses.Count 
                    : 0;
                
                Console.WriteLine($"Total Enrollments: {totalEnrollments}");
                Console.WriteLine($"Average Enrollment per Course: {avgEnrollment:F2}");
            }

            // Most popular course
            if (Students.Values.Any(s => s.RegisteredCourses.Count > 0))
            {
                var courseEnrollments = Students.Values
                    .SelectMany(s => s.RegisteredCourses)
                    .GroupBy(c => c.CourseCode)
                    .Select(g => new { CourseCode = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .FirstOrDefault();

                if (courseEnrollments != null)
                {
                    Console.WriteLine($"Most Popular Course: {courseEnrollments.CourseCode} ({courseEnrollments.Count} students)");
                }
            }
        }
    }
}
