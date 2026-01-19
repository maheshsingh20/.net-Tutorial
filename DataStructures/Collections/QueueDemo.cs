using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class QueueDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Queue Demo (FIFO - First In First Out) ===");
            
            // Creating a Queue
            Queue<string> customers = new Queue<string>();
            
            // Enqueue (add to end)
            customers.Enqueue("Customer 1");
            customers.Enqueue("Customer 2");
            customers.Enqueue("Customer 3");
            customers.Enqueue("Customer 4");
            
            Console.WriteLine($"Queue Count: {customers.Count}");
            
            // Peek (view front element without removing)
            Console.WriteLine($"Front customer (Peek): {customers.Peek()}");
            
            // Dequeue (remove and return front element)
            Console.WriteLine($"Serving: {customers.Dequeue()}");
            Console.WriteLine($"Serving: {customers.Dequeue()}");
            
            Console.WriteLine($"\nRemaining customers in queue:");
            foreach (string customer in customers)
            {
                Console.WriteLine(customer);
            }
            
            // Check if queue contains element
            Console.WriteLine($"\nContains 'Customer 3'? {customers.Contains("Customer 3")}");
            
            Console.WriteLine($"Count: {customers.Count}");
        }
    }
}
