using System;
using System.Collections.Generic;

namespace TopBrains.Questions
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }
        
        public Student(string name, int age, int marks)
        {
            Name = name;
            Age = age;
            Marks = marks;
        }
        
        public override string ToString()
        {
            return $"{Name} (Age: {Age}, Marks: {Marks})";
        }
    }
    
    public class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                return 0;
            
            // First: Sort by highest marks (descending)
            int marksComparison = y.Marks.CompareTo(x.Marks);
            if (marksComparison != 0)
                return marksComparison;
            
            // Second: If marks are equal, sort by youngest age (ascending)
            return x.Age.CompareTo(y.Age);
        }
    }
    
    public class Question20
    {
        public static List<Student> SortStudents(List<Student> students)
        {
            List<Student> sortedStudents = new List<Student>(students);
            sortedStudents.Sort(new StudentComparer());
            return sortedStudents;
        }
        
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            
            Console.Write("Enter number of students: ");
            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter name for student {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter age for student {i + 1}: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write($"Enter marks for student {i + 1}: ");
                int marks = int.Parse(Console.ReadLine());
                
                students.Add(new Student(name, age, marks));
            }
            
            Console.WriteLine("\nOriginal list:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            
            List<Student> sortedStudents = SortStudents(students);
            
            Console.WriteLine("\nSorted list (Highest Marks → Youngest Age):");
            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}