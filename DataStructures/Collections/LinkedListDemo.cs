using System;
using System.Collections.Generic;

namespace DataStructures.Collections
{
    public class LinkedListDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== LinkedList Demo ===");
            
            // Creating a LinkedList
            LinkedList<int> linkedList = new LinkedList<int>();
            
            // Adding elements
            linkedList.AddLast(10);
            linkedList.AddLast(20);
            linkedList.AddLast(30);
            linkedList.AddFirst(5);
            
            Console.WriteLine("LinkedList elements:");
            foreach (int num in linkedList)
            {
                Console.Write(num + " ");
            }
            
            // Adding after a specific node
            LinkedListNode<int> node = linkedList.Find(20);
            if (node != null)
            {
                linkedList.AddAfter(node, 25);
            }
            
            Console.WriteLine($"\nAfter adding 25 after 20: {string.Join(", ", linkedList)}");
            
            // Adding before a specific node
            LinkedListNode<int> firstNode = linkedList.First;
            linkedList.AddBefore(firstNode, 1);
            
            Console.WriteLine($"After adding 1 before first: {string.Join(", ", linkedList)}");
            
            // Removing elements
            linkedList.Remove(30);
            Console.WriteLine($"After removing 30: {string.Join(", ", linkedList)}");
            
            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            Console.WriteLine($"After removing first and last: {string.Join(", ", linkedList)}");
            
            Console.WriteLine($"Count: {linkedList.Count}");
        }
    }
}
