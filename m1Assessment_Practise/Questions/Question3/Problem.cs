// Question 3: Resilient Payment Gateway Call (Retry + Circuit Breaker)
namespace m1Assessment_Practise.Questions.Question3;

class Problem
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Question 3: Resilient Payment Gateway ===\n");

        var gateway = new ResilientPaymentGateway();
        
        for (int i = 1; i <= 10; i++)
        {
            var request = new PaymentRequest { TransactionId = $"TXN{i}", Amount = 100 };
            var result = await gateway.ProcessPaymentAsync(request);
            Console.WriteLine($"Payment {i}: {result.Message}\n");
            await Task.Delay(500);
        }
    }
}
