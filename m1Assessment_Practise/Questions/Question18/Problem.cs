// Question 18: Duplicate Detection with Fuzzy Matching
namespace m1Assessment_Practise.Questions.Question18;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 18: Duplicate Detection ===\n");

        var customers = new List<Customer>
        {
            new() { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "1234567890" },
            new() { Id = 2, Name = "John Doe", Email = "john@example.com", Phone = "9876543210" },
            new() { Id = 3, Name = "Jon Doe", Email = "jon@test.com", Phone = "1234567890" },
            new() { Id = 4, Name = "Jane Smith", Email = "jane@example.com", Phone = "5555555555" },
            new() { Id = 5, Name = "Jane Smyth", Email = "jane2@example.com", Phone = "6666666666" }
        };

        var detector = new DuplicateDetector();
        var duplicates = detector.FindDuplicates(customers);

        Console.WriteLine($"Found {duplicates.Count} duplicate groups:\n");
        foreach (var group in duplicates)
        {
            Console.WriteLine($"Group: Customer IDs [{string.Join(", ", group.CustomerIds)}]");
            Console.WriteLine($"Reason: {group.Reason}\n");
        }
    }
}
