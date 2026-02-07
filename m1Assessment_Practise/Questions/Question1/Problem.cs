// Question 1: Concurrent Ticket Booking (Thread Safety + Lock)
namespace m1Assessment_Practise.Questions.Question1;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 1: Concurrent Ticket Booking ===\n");

        var bookingSystem = new TicketBookingSystem(10);
        var tasks = new List<Task>();

        string[] users = { "User1", "User2", "User3", "User4", "User5" };
        
        foreach (var user in users)
        {
            tasks.Add(Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    bool success = bookingSystem.BookSeat(i, user);
                    Console.WriteLine($"{user} tried to book Seat {i}: {(success ? "SUCCESS" : "FAILED")}");
                    Thread.Sleep(10);
                }
            }));
        }

        Task.WaitAll(tasks.ToArray());

        Console.WriteLine("\n=== Final Seat Status ===");
        bookingSystem.DisplaySeats();
    }
}
