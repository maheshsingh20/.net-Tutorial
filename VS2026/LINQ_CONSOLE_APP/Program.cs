using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_CONSOLE_APP
{
    internal class Program
    {

        public static void LinqToObjectDemo()
        {
            int[] num = { 1, 2, 3, 8, 9, 4, 5, 6, 7, 8, 9, };
            string[] arr = { "Alok", "Sunil", "Riya", "Ankit","Mahi","Kartik"};

            /*
            foreach (int i in num)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }*/

            Console.WriteLine("Enter the name: ");

            string dataToSearch= Console.ReadLine();

            /*var result =from data in arr where data==dataToSearch select data;
            Console.WriteLine(result);*/

            var result = arr.Where(n => n == dataToSearch);
            Console.WriteLine(result);

        }
        static void Main(string[] args)
        {
            LinqToObjectDemo();
        }
    }
}
