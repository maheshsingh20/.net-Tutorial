using System;

namespace DataStructures.CustomDS
{
    public class CustomStack<T>
    {
        private T[] items;
        private int top;
        private int capacity;
        
        public CustomStack(int size = 10)
        {
            capacity = size;
            items = new T[capacity];
            top = -1;
        }
        
        public void Push(T item)
        {
            if (top == capacity - 1)
            {
                Resize();
            }
            items[++top] = item;
        }
        
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[top--];
        }
        
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[top];
        }
        
        public bool IsEmpty()
        {
            return top == -1;
        }
        
        public int Count()
        {
            return top + 1;
        }
        
        private void Resize()
        {
            capacity *= 2;
            T[] newItems = new T[capacity];
            Array.Copy(items, newItems, items.Length);
            items = newItems;
        }
        
        public void Display()
        {
            Console.Write("Stack: ");
            for (int i = top; i >= 0; i--)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
        
        public static void Demo()
        {
            Console.WriteLine("\n=== Custom Stack Demo ===");
            
            CustomStack<int> stack = new CustomStack<int>(5);
            
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            
            stack.Display();
            
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            
            stack.Display();
            Console.WriteLine($"Count: {stack.Count()}");
        }
    }
}
