using System;

namespace TopBrains.Questions
{
    public class Question8
    {
        public static int SumOfDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
        
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }
        
        public static bool IsLuckyNumber(int x)
        {
            if (IsPrime(x)) return false;
            
            int sx = SumOfDigits(x);
            int sxx = SumOfDigits(x * x);
            
            return sxx == sx * sx;
        }
        
        public static int CountLuckyNumbers(int m, int n)
        {
            int count = 0;
            for (int i = m; i <= n; i++)
            {
                if (IsLuckyNumber(i))
                    count++;
            }
            return count;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter m: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            
            int result = CountLuckyNumbers(m, n);
            Console.WriteLine($"Lucky Numbers count: {result}");
        }
    }
}