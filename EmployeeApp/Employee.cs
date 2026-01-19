using System;
namespace EmployeeApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = "Unknown";
            Salary = 0.0m;
        }
        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Employee ID: {Id}, Name: {Name}, Salary: ${Salary:F2}";
        }
    }
}