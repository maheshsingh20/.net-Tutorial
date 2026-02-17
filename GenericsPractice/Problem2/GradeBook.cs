using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice.Problem2
{
    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<(TStudent, TCourse), double> _grades = new();
        private EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
        {
            _enrollmentSystem = enrollmentSystem;
        }

        public bool AddGrade(TStudent student, TCourse course, double grade, out string message)
        {
            if (grade < 0 || grade > 100)
            {
                message = $"Grade must be between 0 and 100. Provided: {grade}";
                return false;
            }

            if (!_enrollmentSystem.IsStudentEnrolled(student, course))
            {
                message = $"Student {student.Name} is not enrolled in {course.CourseCode}";
                return false;
            }

            var key = (student, course);
            _grades[key] = grade;
            message = $"Grade {grade:F2} added for {student.Name} in {course.CourseCode}";
            return true;
        }

        public double? CalculateGPA(TStudent student)
        {
            var studentGrades = _grades
                .Where(kvp => kvp.Key.Item1.StudentId == student.StudentId)
                .ToList();

            if (studentGrades.Count == 0)
                return null;

            double totalPoints = 0;
            int totalCredits = 0;

            foreach (var gradeEntry in studentGrades)
            {
                var course = gradeEntry.Key.Item2;
                var grade = gradeEntry.Value;

                double gradePoint = ConvertToGradePoint(grade);
                totalPoints += gradePoint * course.Credits;
                totalCredits += course.Credits;
            }

            return totalCredits > 0 ? totalPoints / totalCredits : null;
        }

        private double ConvertToGradePoint(double percentage)
        {
            if (percentage >= 90) return 4.0;
            if (percentage >= 80) return 3.0;
            if (percentage >= 70) return 2.0;
            if (percentage >= 60) return 1.0;
            return 0.0;
        }

        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var courseGrades = _grades
                .Where(kvp => kvp.Key.Item2.CourseCode == course.CourseCode)
                .ToList();

            if (courseGrades.Count == 0)
                return null;

            var topEntry = courseGrades.OrderByDescending(kvp => kvp.Value).First();
            return (topEntry.Key.Item1, topEntry.Value);
        }

        public double? GetGrade(TStudent student, TCourse course)
        {
            var key = (student, course);
            return _grades.ContainsKey(key) ? _grades[key] : null;
        }

        public void DisplayGrades()
        {
            Console.WriteLine("\nGrade Book:");
            var groupedByStudent = _grades.GroupBy(kvp => kvp.Key.Item1);

            foreach (var studentGroup in groupedByStudent)
            {
                var student = studentGroup.Key;
                Console.WriteLine($"\n{student.Name} (ID: {student.StudentId}):");

                foreach (var gradeEntry in studentGroup)
                {
                    var course = gradeEntry.Key.Item2;
                    var grade = gradeEntry.Value;
                    Console.WriteLine($"  {course.CourseCode}: {grade:F2}%");
                }

                var gpa = CalculateGPA(student);
                if (gpa.HasValue)
                {
                    Console.WriteLine($"  GPA: {gpa.Value:F2}");
                }
            }
        }
    }
}
