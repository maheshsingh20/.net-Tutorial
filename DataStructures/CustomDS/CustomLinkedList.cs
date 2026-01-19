using System;

namespace DataStructures.CustomDS
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    
    public class CustomLinkedList<T>
    {
        private Node<T> head;
        private int count;
        
        public CustomLinkedList()
        {
            head = null;
            count = 0;
        }
        
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = head;
            head = newNode;
            count++;
        }
        
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }
        
        public void InsertAt(int position, T data)
        {
            if (position < 0 || position > count)
            {
                throw new ArgumentOutOfRangeException("Invalid position");
            }
            
            if (position == 0)
            {
                AddFirst(data);
                return;
            }
            
            Node<T> newNode = new Node<T>(data);
            Node<T> current = head;
            
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }
        
        public bool Remove(T data)
        {
            if (head == null) return false;
            
            if (head.Data.Equals(data))
            {
                head = head.Next;
                count--;
                return true;
            }
            
            Node<T> current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return true;
                }
                current = current.Next;
            }
            
            return false;
        }
        
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        
        public int Count()
        {
            return count;
        }
        
        public void Display()
        {
            Console.Write("LinkedList: ");
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
        
        public static void Demo()
        {
            Console.WriteLine("\n=== Custom LinkedList Demo ===");
            
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddFirst(5);
            
            list.Display();
            
            list.InsertAt(2, 15);
            Console.WriteLine("After inserting 15 at position 2:");
            list.Display();
            
            list.Remove(20);
            Console.WriteLine("After removing 20:");
            list.Display();
            
            Console.WriteLine($"Contains 15? {list.Contains(15)}");
            Console.WriteLine($"Count: {list.Count()}");
        }
    }
}
