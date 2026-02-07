namespace m1Assessment_Practise.Questions.Question17;

class AsyncPipeline
{
    private readonly SemaphoreSlim _semaphore;

    public AsyncPipeline(int maxConcurrency)
    {
        _semaphore = new SemaphoreSlim(maxConcurrency);
    }

    public async Task<List<Output>> ProcessAsync(List<Input> items)
    {
        var tasks = items.Select(async (item, index) =>
        {
            await _semaphore.WaitAsync();
            try
            {
                var output = await ProcessItemAsync(item);
                return (index, output);
            }
            finally
            {
                _semaphore.Release();
            }
        });

        var results = await Task.WhenAll(tasks);

        return results
            .OrderBy(r => r.index)
            .Select(r => r.output)
            .ToList();
    }

    private async Task<Output> ProcessItemAsync(Input item)
    {
        Console.WriteLine($"Processing item {item.Id}...");
        await Task.Delay(new Random().Next(100, 500));
        
        return new Output
        {
            Id = item.Id,
            Result = $"Processed: {item.Data.ToUpper()}"
        };
    }
}
