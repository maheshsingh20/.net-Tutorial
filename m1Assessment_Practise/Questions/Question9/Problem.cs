// Question 9: Parallel Data Aggregation (PLINQ/Tasks)
namespace m1Assessment_Practise.Questions.Question9;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 9: Parallel Data Aggregation ===\n");

        var sales = GenerateSampleSales();
        var analyzer = new SalesAnalyzer();
        
        var (regionReports, bestDay) = analyzer.AnalyzeSales(sales);

        Console.WriteLine("=== Sales by Region ===");
        foreach (var report in regionReports)
        {
            Console.WriteLine($"{report.Region}: Total = {report.TotalSales:C}, Top Category = {report.TopCategory}");
        }

        Console.WriteLine($"\n=== Best Sales Day: {bestDay:yyyy-MM-dd} ===");
    }

    static List<Sale> GenerateSampleSales()
    {
        var regions = new[] { "North", "South", "East", "West" };
        var categories = new[] { "Electronics", "Clothing", "Food", "Books" };
        var random = new Random(42);
        var sales = new List<Sale>();

        for (int i = 0; i < 100; i++)
        {
            sales.Add(new Sale
            {
                Region = regions[random.Next(regions.Length)],
                Category = categories[random.Next(categories.Length)],
                Amount = random.Next(100, 1000),
                Date = DateTime.Now.AddDays(-random.Next(0, 30))
            });
        }

        return sales;
    }
}
