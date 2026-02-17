using System;

namespace GenericsPractice.Problem2
{
    public class CourseRegistrationDemo
    {
        public static void Run()
        {
            Console.WriteLine("Problem 2: Course Registration System\n");

            var enrollmentSystem = new EnrollmentSystem<EngineeringStudent, LabCourse>();
            var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollmentSystem);

            Console.WriteLine("STEP 1: Creating Students\n");

            var student1 = new EngineeringStudent
            {
                StudentId = 1001,
                Name = "Alice Johnson",
                Semester = 5,
                Specialization = "Computer Science"
            };

            var student2 = new EngineeringStudent
            {
                StudentId = 1002,
                Name = "Bob Smith",
                Semester = 3,
                Specialization = "Electrical Engineering"
            };

            var student3 = new EngineeringStudent
            {
                StudentId = 1003,
                Name = "Charlie Brown",
                Semester = 6,
                Specialization = "Mechanical Engineering"
            };

            Console.WriteLine($"Created: {student1}");
            Console.WriteLine($"Created: {student2}");
            Console.WriteLine($"Created: {student3}");

            Console.WriteLine("\n\nSTEP 2: Creating Lab Courses\n");

            var course1 = new LabCourse
            {
                CourseCode = "CS401",
                Title = "Advanced Algorithms Lab",
                MaxCapacity = 2,
                Credits = 4,
                LabEquipment = "High-Performance Computers",
                RequiredSemester = 4
            };

            var course2 = new LabCourse
            {
                CourseCode = "EE301",
                Title = "Digital Electronics Lab",
                MaxCapacity = 3,
                Credits = 3,
                LabEquipment = "Oscilloscopes",
                RequiredSemester = 3
            };

            Console.WriteLine($"Created: {course1}");
            Console.WriteLine($"Created: {course2}");

            Console.WriteLine("\n\nSTEP 3: Successful Enrollments\n");

            if (enrollmentSystem.EnrollStudent(student1, course1, out string reason1))
            {
                Console.WriteLine($"✓ {reason1}");
            }

            if (enrollmentSystem.EnrollStudent(student3, course1, out string reason2))
            {
                Console.WriteLine($"✓ {reason2}");
            }

            if (enrollmentSystem.EnrollStudent(student2, course2, out string reason3))
            {
                Console.WriteLine($"✓ {reason3}");
            }

            Console.WriteLine("\n\nSTEP 4: Failed Enrollments\n");

            Console.WriteLine("Test 1: Course at full capacity");
            if (!enrollmentSystem.EnrollStudent(student2, course1, out string failReason1))
            {
                Console.WriteLine($"✗ {failReason1}");
            }

            Console.WriteLine("\nTest 2: Prerequisite not met");
            var juniorStudent = new EngineeringStudent
            {
                StudentId = 1004,
                Name = "David Lee",
                Semester = 2,
                Specialization = "Computer Science"
            };
            if (!enrollmentSystem.EnrollStudent(juniorStudent, course1, out string failReason2))
            {
                Console.WriteLine($"✗ {failReason2}");
            }

            enrollmentSystem.DisplayEnrollments();

            Console.WriteLine("\n\nSTEP 5: Student Workload Calculation\n");

            int workload1 = enrollmentSystem.CalculateStudentWorkload(student1);
            int workload2 = enrollmentSystem.CalculateStudentWorkload(student2);
            int workload3 = enrollmentSystem.CalculateStudentWorkload(student3);

            Console.WriteLine($"{student1.Name}: {workload1} credits");
            Console.WriteLine($"{student2.Name}: {workload2} credits");
            Console.WriteLine($"{student3.Name}: {workload3} credits");

            Console.WriteLine("\n\nSTEP 6: Grade Assignment\n");

            gradeBook.AddGrade(student1, course1, 92.5, out string gradeMsg1);
            Console.WriteLine($"✓ {gradeMsg1}");

            gradeBook.AddGrade(student3, course1, 88.0, out string gradeMsg2);
            Console.WriteLine($"✓ {gradeMsg2}");

            gradeBook.AddGrade(student2, course2, 85.5, out string gradeMsg3);
            Console.WriteLine($"✓ {gradeMsg3}");

            Console.WriteLine("\n\nSTEP 7: GPA Calculation\n");

            var gpa1 = gradeBook.CalculateGPA(student1);
            var gpa2 = gradeBook.CalculateGPA(student2);
            var gpa3 = gradeBook.CalculateGPA(student3);

            Console.WriteLine($"{student1.Name}: GPA = {(gpa1.HasValue ? gpa1.Value.ToString("F2") : "N/A")}");
            Console.WriteLine($"{student2.Name}: GPA = {(gpa2.HasValue ? gpa2.Value.ToString("F2") : "N/A")}");
            Console.WriteLine($"{student3.Name}: GPA = {(gpa3.HasValue ? gpa3.Value.ToString("F2") : "N/A")}");

            Console.WriteLine("\n\nSTEP 8: Top Student per Course\n");

            var topInCourse1 = gradeBook.GetTopStudent(course1);
            if (topInCourse1.HasValue)
            {
                Console.WriteLine($"{course1.CourseCode}: {topInCourse1.Value.student.Name} with {topInCourse1.Value.grade:F2}%");
            }

            var topInCourse2 = gradeBook.GetTopStudent(course2);
            if (topInCourse2.HasValue)
            {
                Console.WriteLine($"{course2.CourseCode}: {topInCourse2.Value.student.Name} with {topInCourse2.Value.grade:F2}%");
            }

            gradeBook.DisplayGrades();

            Console.WriteLine("\n\nProgram completed successfully!");
        }
    }
}
