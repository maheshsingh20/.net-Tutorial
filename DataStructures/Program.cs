using System;
using DataStructures.Collections;
using DataStructures.CustomDS;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   DATA STRUCTURES DEMONSTRATION");
            Console.WriteLine("========================================");
            
            // Built-in Collections
            ListDemo.Run();
            DictionaryDemo.Run();
            HashSetDemo.Run();
            StackDemo.Run();
            QueueDemo.Run();
            LinkedListDemo.Run();
            SortedListDemo.Run();
            SortedDictionaryDemo.Run();
            SortedSetDemo.Run();
            
            // Custom Implementations
            CustomStack<int>.Demo();
            CustomQueue<string>.Demo();
            CustomLinkedList<int>.Demo();
            BinarySearchTree<int>.Demo();
            
            Console.WriteLine("\n========================================");
            Console.WriteLine("   ALL DEMOS COMPLETED!");
            Console.WriteLine("========================================");
        }
    }
}
