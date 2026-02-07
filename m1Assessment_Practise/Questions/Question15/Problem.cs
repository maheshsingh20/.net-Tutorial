// Question 15: Custom LINQ Extension Methods
namespace m1Assessment_Practise.Questions.Question15;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 15: Custom LINQ Extensions ===\n");

        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 3, 4 };

        var evens = numbers.WhereEx(n => n % 2 == 0);
        Console.WriteLine($"Even numbers: {string.Join(", ", evens)}");

        var squares = numbers.SelectEx(n => n * n);
        Console.WriteLine($"Squares: {string.Join(", ", squares.Take(5))}...");

        var distinct = numbers.DistinctEx();
        Console.WriteLine($"Distinct: {string.Join(", ", distinct)}");

        var grouped = numbers.GroupByEx(n => n % 3);
        Console.WriteLine("\nGrouped by modulo 3:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"  Key {group.Key}: {string.Join(", ", group)}");
        }
    }
}
