using System;
namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            Console.WriteLine(emp1.ToString());
            Employee emp2 = new Employee(101, "Mahesh", 50000.00m);
            Console.WriteLine(emp2.ToString());
            Employee emp3 = new Employee(102, "Chandan", 65000.50m);
            Console.WriteLine(emp3.ToString());
            emp1.Id = 103;
            emp1.Name = "Karan";
            emp1.Salary = 45000.75m;
            Console.WriteLine(emp1.ToString());
            Console.ReadKey();
        }
    }
}
