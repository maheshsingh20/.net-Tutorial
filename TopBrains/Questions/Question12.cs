using System;

namespace TopBrains.Questions
{
    public class Question12
    {
        public static int SumPositiveUntilZero(int[] nums)
        {
            int sum = 0;
            
            foreach (int num in nums)
            {
                if (num == 0)
                    break;
                
                if (num > 0)
                    sum += num;
            }
            
            return sum;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int count = int.Parse(Console.ReadLine());
            
            int[] nums = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Element {i + 1}: ");
                nums[i] = int.Parse(Console.ReadLine());
            }
            
            int result = SumPositiveUntilZero(nums);
            Console.WriteLine($"Sum: {result}");
        }
    }
}