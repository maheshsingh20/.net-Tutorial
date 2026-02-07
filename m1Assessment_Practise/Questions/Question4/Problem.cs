// Question 4: Producer–Consumer Order Processing
namespace m1Assessment_Practise.Questions.Question4;

class Problem
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Question 4: Producer-Consumer Order Processing ===\n");

        var processor = new OrderProcessor();
        int totalProcessed = await processor.ProcessOrdersAsync(totalOrders: 10, consumerCount: 3);
        
        Console.WriteLine($"\n=== Total Orders Processed: {totalProcessed} ===");
    }
}
