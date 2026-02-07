// Question 17: Async Pipeline with Ordering Guaranteed
namespace m1Assessment_Practise.Questions.Question17;

class Problem
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Question 17: Async Pipeline with Ordering ===\n");

        var inputs = Enumerable.Range(1, 10)
            .Select(i => new Input { Id = i, Data = $"data{i}" })
            .ToList();

        var pipeline = new AsyncPipeline(maxConcurrency: 4);
        var outputs = await pipeline.ProcessAsync(inputs);

        Console.WriteLine("\n=== Results (Order Preserved) ===");
        foreach (var output in outputs)
        {
            Console.WriteLine($"ID {output.Id}: {output.Result}");
        }
    }
}
