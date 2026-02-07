// Question 13: CSV Import with Partial Success
namespace m1Assessment_Practise.Questions.Question13;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 13: CSV Import with Partial Success ===\n");

        string csvPath = "products.csv";
        File.WriteAllText(csvPath, @"ProductId,Name,Price
P001,Laptop,999.99
P002,Mouse,
P003,,50.00
P004,Keyboard,75.50
INVALID_LINE
P005,Monitor,-100
P006,Headphones,45.00");

        var importer = new ProductImporter();
        var result = importer.ImportProducts(csvPath);

        Console.WriteLine($"Inserted: {result.InsertedCount}");
        Console.WriteLine($"Failed: {result.Errors.Count}\n");

        if (result.Errors.Count > 0)
        {
            Console.WriteLine("=== Import Errors ===");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Row {error.RowNumber}: {error.Reason}");
            }
        }

        importer.DisplayProducts();
        File.Delete(csvPath);
    }
}
