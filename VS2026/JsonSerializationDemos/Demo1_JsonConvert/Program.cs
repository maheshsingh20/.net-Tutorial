using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Demo1_JsonConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Employee emp = new Employee() { EmpID = 101, EmpName = "Robert" };
            Employee[] empList = new Employee[]
            {
                 new Employee() { EmpID = 101, EmpName = "Robin" },
                 new Employee() { EmpID = 102, EmpName = "Robert" },
                 new Employee() { EmpID = 103, EmpName = "Rashmi" }

            };

            string empString = JsonConvert.SerializeObject(empList);
            Console.WriteLine($"JSON Serialized Employee Object is : {Environment.NewLine} {empString}");

            // Employee deserializedEmp = JsonConvert.DeserializeObject<Employee>(empString);
            Employee[] deserializedEmp = JsonConvert.DeserializeObject<Employee[]>(empString);
            Console.WriteLine($"{Environment.NewLine}JSON Deserialized Employee Object is : ");
            foreach (var item in deserializedEmp)
            {
                Console.WriteLine($"Employee ID : {item.EmpID}");
                Console.WriteLine($"Employee Name : {item.EmpName}");
            }
            //Console.WriteLine($"Employee ID : {deserializedEmp.EmpID}");
            //Console.WriteLine($"Employee Name : {deserializedEmp.EmpName}");

            Console.ReadKey();
        }
    }
}
