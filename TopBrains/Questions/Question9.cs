using System;

namespace TopBrains.Questions
{
    public class Question9
    {
        public static int ProcessTransactions(int initialBalance, int[] transactions)
        {
            int balance = initialBalance;
            
            foreach (int transaction in transactions)
            {
                if (transaction >= 0)
                {
                    balance += transaction;
                }
                else
                {
                    if (balance >= Math.Abs(transaction))
                    {
                        balance += transaction;
                    }
                }
            }
            
            return balance;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter initial balance: ");
            int initialBalance = int.Parse(Console.ReadLine());
            
            Console.Write("Enter number of transactions: ");
            int count = int.Parse(Console.ReadLine());
            
            int[] transactions = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Transaction {i + 1}: ");
                transactions[i] = int.Parse(Console.ReadLine());
            }
            
            int finalBalance = ProcessTransactions(initialBalance, transactions);
            Console.WriteLine($"Final balance: {finalBalance}");
        }
    }
}