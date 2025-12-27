using System;
using System.Collections;
using System.Collections.Generic;

namespace Day7Demo
{
    public class Collections
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine("Stack Elements are:");
            foreach (var item in stack)
                Console.WriteLine(item);

            ArrayList arr = new ArrayList();
            arr.Add(7);
            arr.Add(8);
            arr.Add(9);
            arr.Add(10);

            Console.WriteLine("Array Elements are:");
            foreach (var item in arr)
                Console.WriteLine(item);

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Dequeue();

            Console.WriteLine("Queue Elements are:");
            foreach (var item in q)
                Console.WriteLine(item);

            List<Product> products = new List<Product>()
            {
                new Product(){Id=1, Name="Laptop", Price=45000, IsAvailable=true},
                new Product(){Id=2, Name="Mobile", Price=25000, IsAvailable=false},
                new Product(){Id=3, Name="Tablet", Price=15000, IsAvailable=true}
            };

            Console.WriteLine("Product List:");
            foreach (var item in products)
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Price: {item.Price}");

            Console.WriteLine("Enter Product Id to search:");
            int idd = Int32.Parse(Console.ReadLine());

            Product foundProduct = products.Find(p => p.Id == idd);

            if (foundProduct != null)
            {
                Console.WriteLine($"Product Found: {foundProduct.Name}");
                Console.WriteLine($"Available: {foundProduct.IsAvailable}");
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }
    }
}
