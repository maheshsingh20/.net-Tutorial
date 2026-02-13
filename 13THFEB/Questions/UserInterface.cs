using System;

namespace SmartBank
{
    public class UserInterface
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter employment type: 1: Salaried, 2: Self-Employed:  ");
            string employmentType = Console.ReadLine();

            Console.Write("Enter monthly income: ");
            double monthlyIncome = double.Parse(Console.ReadLine());

            Console.Write("Enter existing credit dues: ");
            double dues = double.Parse(Console.ReadLine());

            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine());

            Console.Write("Enter number of loan defaults: ");
            int defaults = int.Parse(Console.ReadLine());

            try
            {
                CreditRiskProcessor.ValidateCustomerDetails(age, employmentType, monthlyIncome, dues, creditScore, defaults);
                int creditLimit = CreditRiskProcessor.CalculateCreditLimit(monthlyIncome, dues, creditScore, defaults);
                Console.WriteLine($"Customer Name: {customerName}");
                Console.WriteLine($"Approved Credit Limit: ₹{creditLimit}");
            }
            catch (InvalidCreditDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
