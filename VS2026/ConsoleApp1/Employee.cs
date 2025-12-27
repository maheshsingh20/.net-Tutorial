using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee
    {
        public int salary;
        public string designation;
        public Employee()
        {
            this.salary = 1;
            this.designation = string.Empty;
            Console.WriteLine("Employee constructor called");

        }
        ~Employee()
        {
            Console.WriteLine("Employee Destructor called");
        }

    }
}
