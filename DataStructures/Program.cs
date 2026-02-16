using System;
using DataStructures.Collections;
using DataStructures.CustomDS;
namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDemo.Run();
            DictionaryDemo.Run();
            HashSetDemo.Run();
            StackDemo.Run();
            QueueDemo.Run();
            LinkedListDemo.Run();
            SortedListDemo.Run();
            SortedDictionaryDemo.Run();
            SortedSetDemo.Run();
            CustomStack<int>.Demo();
            CustomQueue<string>.Demo();
            CustomLinkedList<int>.Demo();
            BinarySearchTree<int>.Demo();
        }
    }
}
