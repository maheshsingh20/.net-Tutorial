using System;
using System.Collections.Generic;

namespace TopBrains.Questions
{
    public class StudentRecord
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }
        
        public StudentRecord(string name, int age, int marks)
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
    
    public class StudentRecordComparer : IComparer<StudentRecord>
    {
        public int Compare(StudentRecord? x, StudentRecord? y)
        {
            if (x == null || y == null)
                return 0;
            
            int marksComparison = y.Marks.CompareTo(x.Marks);
            if (marksComparison != 0)
                return marksComparison;
            
            return x.Age.CompareTo(y.Age);
        }
    }
    
    public class Question20
    {
        public static List<StudentRecord> SortStudents(List<StudentRecord> students)
        {
            List<StudentRecord> sortedStudents = new List<StudentRecord>(students);
            sortedStudents.Sort(new StudentRecordComparer());
            return sortedStudents;
        }
    }
}
