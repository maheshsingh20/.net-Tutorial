using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        public int age;
        public string name;

        public Person()
        {
            age = 0;
            name = string.Empty;
            Console.WriteLine("Person constructor is called");
        }
        ~Person()
        {
            Console.WriteLine("Person Destructor is called");
        }

    }
}
