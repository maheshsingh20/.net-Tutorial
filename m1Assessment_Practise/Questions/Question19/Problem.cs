// Question 19: Audit Trigger Simulation (Change Tracking)
namespace m1Assessment_Practise.Questions.Question19;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 19: Audit Trigger Simulation ===\n");

        var employee = new Employee
        {
            Id = 1,
            Name = "John Doe",
            Salary = 50000,
            Department = "IT"
        };

        var tracker = new EntityTracker<Employee>();
        tracker.StartTracking(employee);

        Console.WriteLine("Original Employee:");
        Console.WriteLine($"Name: {employee.Name}, Salary: {employee.Salary:C}, Dept: {employee.Department}\n");

        employee.Name = "John Smith";
        employee.Salary = 60000;

        var changes = tracker.GetChanges(employee);

        Console.WriteLine($"Detected {changes.Count} changes:\n");
        foreach (var change in changes)
        {
            Console.WriteLine($"Property: {change.PropertyName}");
            Console.WriteLine($"  Old: {change.OldValue}");
            Console.WriteLine($"  New: {change.NewValue}");
            Console.WriteLine($"  Time: {change.Timestamp:HH:mm:ss}\n");
        }
    }
}
