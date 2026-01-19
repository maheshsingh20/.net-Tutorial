using System;

namespace TopBrains.Questions
{
    public class Question3
    {
        public static int[] GetMultiplicationTable(int n, int upto)
        {
            int[] result = new int[upto];
            
            for (int i = 0; i < upto; i++)
            {
                result[i] = n * (i + 1);
            }
            
            return result;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter upto: ");
            int upto = int.Parse(Console.ReadLine());
            
            int[] table = GetMultiplicationTable(n, upto);
            
            Console.Write("Result: [");
            for (int i = 0; i < table.Length; i++)
            {
                Console.Write(table[i]);
                if (i < table.Length - 1)
                    Console.Write(",");
            }
            Console.WriteLine("]");
        }
    }
}