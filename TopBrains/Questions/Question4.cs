using System;
using System.Linq;
using System.Text.Json;

namespace TopBrains.Questions
{
    public record Student(string Name, int Score);
    
    public class Question4
    {
        public static string ProcessStudents(string[] items, int minScore)
        {
            var students = items
                .Select(item => item.Split(':'))
                .Where(parts => parts.Length == 2 && int.TryParse(parts[1], out _))
                .Select(parts => new Student(parts[0], int.Parse(parts[1])))
                .Where(student => student.Score >= minScore)
                .OrderByDescending(student => student.Score)
                .ThenBy(student => student.Name)
                .ToArray();
            
            return JsonSerializer.Serialize(students);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int count = int.Parse(Console.ReadLine());
            
            string[] items = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter student {i + 1} (Name:Score): ");
                items[i] = Console.ReadLine();
            }
            Console.Write("Enter minimum score: ");
            int minScore = int.Parse(Console.ReadLine());
            string result = ProcessStudents(items, minScore);
            Console.WriteLine($"Result: {result}");
        }
    }
}