using System;
namespace TopBrains.Questions
{
    public class Question10
    {
        public static T[] MergeSortedArrays<T>(T[] a, T[] b) where T : IComparable<T>
        {
            T[] result = new T[a.Length + b.Length];
            int i = 0, j = 0, k = 0;
            
            while (i < a.Length && j < b.Length)
            {
                if (a[i].CompareTo(b[j]) <= 0)
                {
                    result[k++] = a[i++];
                }
                else
                {
                    result[k++] = b[j++];
                }
            }
            while (i < a.Length)
            {
                result[k++] = a[i++];
            }
            
            while (j < b.Length)
            {
                result[k++] = b[j++];
            }
            return result;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter size of first array: ");
            int size1 = int.Parse(Console.ReadLine());
            int[] array1 = new int[size1];
            
            Console.WriteLine("Enter sorted elements for first array:");
            for (int i = 0; i < size1; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array1[i] = int.Parse(Console.ReadLine());
            }
            
            Console.Write("Enter size of second array: ");
            int size2 = int.Parse(Console.ReadLine());
            int[] array2 = new int[size2];
            
            Console.WriteLine("Enter sorted elements for second array:");
            for (int i = 0; i < size2; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array2[i] = int.Parse(Console.ReadLine());
            }
            
            int[] merged = MergeSortedArrays(array1, array2);
            
            Console.Write("Merged array: [");
            for (int i = 0; i < merged.Length; i++)
            {
                Console.Write(merged[i]);
                if (i < merged.Length - 1)
                    Console.Write(",");
            }
            Console.WriteLine("]");
        }
    }
}