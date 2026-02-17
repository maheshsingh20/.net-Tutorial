using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice.Problem2
{
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<TCourse, List<TStudent>> _enrollments = new();

        public bool EnrollStudent(TStudent student, TCourse course, out string reason)
        {
            if (!_enrollments.ContainsKey(course))
            {
                _enrollments[course] = new List<TStudent>();
            }

            if (_enrollments[course].Count >= course.MaxCapacity)
            {
                reason = $"Course {course.CourseCode} is at full capacity ({course.MaxCapacity} students)";
                return false;
            }

            if (_enrollments[course].Any(s => s.StudentId == student.StudentId))
            {
                reason = $"Student {student.Name} is already enrolled in {course.CourseCode}";
                return false;
            }

            if (course is LabCourse labCourse)
            {
                if (student.Semester < labCourse.RequiredSemester)
                {
                    reason = $"Student {student.Name} (Semester {student.Semester}) does not meet prerequisite (Semester {labCourse.RequiredSemester}) for {course.CourseCode}";
                    return false;
                }
            }

            _enrollments[course].Add(student);
            reason = $"Successfully enrolled {student.Name} in {course.CourseCode}";
            return true;
        }

        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            if (_enrollments.ContainsKey(course))
            {
                return _enrollments[course].AsReadOnly();
            }
            return new List<TStudent>().AsReadOnly();
        }

        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            return _enrollments
                .Where(kvp => kvp.Value.Any(s => s.StudentId == student.StudentId))
                .Select(kvp => kvp.Key);
        }

        public int CalculateStudentWorkload(TStudent student)
        {
            return GetStudentCourses(student).Sum(c => c.Credits);
        }

        public bool IsStudentEnrolled(TStudent student, TCourse course)
        {
            if (!_enrollments.ContainsKey(course))
                return false;

            return _enrollments[course].Any(s => s.StudentId == student.StudentId);
        }

        public int GetEnrollmentCount(TCourse course)
        {
            return _enrollments.ContainsKey(course) ? _enrollments[course].Count : 0;
        }

        public void DisplayEnrollments()
        {
            Console.WriteLine("\nCurrent Enrollments:");
            foreach (var enrollment in _enrollments)
            {
                Console.WriteLine($"\n{enrollment.Key.CourseCode} - {enrollment.Key.Title}:");
                Console.WriteLine($"  Enrolled: {enrollment.Value.Count}/{enrollment.Key.MaxCapacity}");
                foreach (var student in enrollment.Value)
                {
                    Console.WriteLine($"    - {student.Name} (Semester {student.Semester})");
                }
            }
        }
    }
}
