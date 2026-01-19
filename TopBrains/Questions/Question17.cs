using System;

namespace TopBrains.Questions
{
    public abstract class Employee
    {
        public abstract decimal CalculatePay();
    }
    
    public class HourlyEmployee : Employee
    {
        public decimal Rate { get; set; }
        public decimal Hours { get; set; }
        
        public HourlyEmployee(decimal rate, decimal hours)
        {
            Rate = rate;
            Hours = hours;
        }
        
        public override decimal CalculatePay()
        {
            return Rate * Hours;
        }
    }
    
    public class SalariedEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }
        
        public SalariedEmployee(decimal monthlySalary)
        {
            MonthlySalary = monthlySalary;
        }
        
        public override decimal CalculatePay()
        {
            return MonthlySalary;
        }
    }
    
    public class CommissionEmployee : Employee
    {
        public decimal Commission { get; set; }
        public decimal BaseSalary { get; set; }
        
        public CommissionEmployee(decimal commission, decimal baseSalary)
        {
            Commission = commission;
            BaseSalary = baseSalary;
        }
        
        public override decimal CalculatePay()
        {
            return BaseSalary + Commission;
        }
    }
    
    public class Question17
    {
        public static decimal ComputeTotalPayroll(string[] employees)
        {
            decimal totalPay = 0;
            
            foreach (string empData in employees)
            {
                string[] parts = empData.Split(' ');
                if (parts.Length < 2) continue;
                
                Employee employee = null;
                
                switch (parts[0])
                {
                    case "H":
                        if (parts.Length >= 3 && 
                            decimal.TryParse(parts[1], out decimal rate) &&
                            decimal.TryParse(parts[2], out decimal hours))
                        {
                            employee = new HourlyEmployee(rate, hours);
                        }
                        break;
                        
                    case "S":
                        if (decimal.TryParse(parts[1], out decimal salary))
                        {
                            employee = new SalariedEmployee(salary);
                        }
                        break;
                        
                    case "C":
                        if (parts.Length >= 3 &&
                            decimal.TryParse(parts[1], out decimal commission) &&
                            decimal.TryParse(parts[2], out decimal baseSalary))
                        {
                            employee = new CommissionEmployee(commission, baseSalary);
                        }
                        break;
                }
                
                if (employee != null)
                {
                    totalPay += employee.CalculatePay();
                }
            }
            
            return Math.Round(totalPay, 2);
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter number of employees: ");
            int count = int.Parse(Console.ReadLine());
            
            string[] employees = new string[count];
            Console.WriteLine("Enter employee data:");
            Console.WriteLine("H rate hours (Hourly)");
            Console.WriteLine("S monthlySalary (Salaried)");
            Console.WriteLine("C commission baseSalary (Commission)");
            
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Employee {i + 1}: ");
                employees[i] = Console.ReadLine();
            }
            
            decimal totalPay = ComputeTotalPayroll(employees);
            Console.WriteLine($"Total Payroll: {totalPay:F2}");
        }
    }
}