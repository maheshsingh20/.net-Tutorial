using System;
using System.Collections.Generic;

namespace TopBrains.Questions
{
    public class Question24
    {
        public static int CalculateTotalSalary(Dictionary<int, int> salaryDict, List<int> employeeIds)
        {
            int totalSalary = 0;
            
            foreach (int id in employeeIds)
            {
                if (salaryDict.ContainsKey(id))
                {
                    totalSalary += salaryDict[id];
                }
            }
            
            return totalSalary;
        }
        
        public static void Main(string[] args)
        {
            Dictionary<int, int> salaryDict = new Dictionary<int, int>();
            
            Console.Write("Enter number of employees in dictionary: ");
            int dictCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < dictCount; i++)
            {
                Console.Write($"Enter employee ID {i + 1}: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write($"Enter salary for ID {id}: ");
                int salary = int.Parse(Console.ReadLine());
                salaryDict[id] = salary;
            }
            
            Console.Write("Enter number of IDs to lookup: ");
            int lookupCount = int.Parse(Console.ReadLine());
            
            List<int> employeeIds = new List<int>();
            for (int i = 0; i < lookupCount; i++)
            {
                Console.Write($"Enter lookup ID {i + 1}: ");
                int id = int.Parse(Console.ReadLine());
                employeeIds.Add(id);
            }
            
            int totalSalary = CalculateTotalSalary(salaryDict, employeeIds);
            Console.WriteLine($"Total Salary: {totalSalary}");
        }
    }
}