// Question 7: JSON Batch Validation Pipeline
namespace m1Assessment_Practise.Questions.Question7;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 7: JSON Batch Validation Pipeline ===\n");

        var jsonPayloads = new List<string>
        {
            @"{""Name"":""John Doe"",""Email"":""john@example.com"",""Age"":25,""PAN"":""ABCDE1234F""}",
            @"{""Name"":"""",""Email"":""invalid-email"",""Age"":17,""PAN"":""INVALID""}",
            @"{""Name"":""Jane Smith"",""Email"":""jane@test.com"",""Age"":30,""PAN"":""XYZAB5678C""}",
            @"{""Name"":""Bob"",""Email"":""bob@mail.com"",""Age"":65,""PAN"":""PQRST9012D""}",
            @"invalid json"
        };

        var validator = new CustomerValidator();
        var report = validator.ValidateBatch(jsonPayloads);

        Console.WriteLine($"Total Records: {report.TotalRecords}");
        Console.WriteLine($"Valid: {report.ValidCount}");
        Console.WriteLine($"Invalid: {report.InvalidCount}\n");

        if (report.Errors.Count > 0)
        {
            Console.WriteLine("=== Validation Errors ===");
            foreach (var error in report.Errors)
            {
                Console.WriteLine($"\nRecord {error.RecordIndex}:");
                foreach (var err in error.Errors)
                {
                    Console.WriteLine($"  - {err}");
                }
            }
        }
    }
}
