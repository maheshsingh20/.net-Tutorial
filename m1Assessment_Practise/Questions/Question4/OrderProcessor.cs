using System.Collections.Concurrent;

namespace m1Assessment_Practise.Questions.Question4;

class OrderProcessor
{
    private readonly BlockingCollection<Order> _orderQueue = new();
    private int _processedCount = 0;
    private readonly object _lock = new();

    public async Task<int> ProcessOrdersAsync(int totalOrders, int consumerCount = 3)
    {
        var producerTask = Task.Run(() => Producer(totalOrders));
        
        var consumerTasks = new List<Task>();
        for (int i = 1; i <= consumerCount; i++)
        {
            int workerId = i;
            consumerTasks.Add(Task.Run(() => Consumer(workerId)));
        }

        await producerTask;
        _orderQueue.CompleteAdding();
        await Task.WhenAll(consumerTasks);
        
        return _processedCount;
    }

    private void Producer(int totalOrders)
    {
        Console.WriteLine("Producer started");
        for (int i = 1; i <= totalOrders; i++)
        {
            var order = new Order { OrderId = i, Product = $"Product{i}" };
            _orderQueue.Add(order);
            Console.WriteLine($"Produced: Order {i}");
            Thread.Sleep(100);
        }
        Console.WriteLine("Producer completed\n");
    }

    private void Consumer(int workerId)
    {
        Console.WriteLine($"Consumer {workerId} started");
        
        foreach (var order in _orderQueue.GetConsumingEnumerable())
        {
            Console.WriteLine($"Consumer {workerId} processing Order {order.OrderId}");
            Thread.Sleep(300);
            
            lock (_lock)
            {
                _processedCount++;
            }
            
            Console.WriteLine($"Consumer {workerId} completed Order {order.OrderId}");
        }
        
        Console.WriteLine($"Consumer {workerId} finished");
    }
}
