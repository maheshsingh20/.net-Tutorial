using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDAL daoObj = new StudentDAL();

            // Insert a new student
            Console.WriteLine("=== Adding New Student ===");
            Studentt newStudent = new Studentt
            {
                Roll_Number = 105,
                Name = "Anjali Verma",
                Age = 22,
                City = "Chandigarh"
            };
            daoObj.InsertStudent(newStudent);

            Console.WriteLine("\n=== All Students ===");
            // Display all students
            List<Studentt> ls = daoObj.GetAllStudents();
            if (ls.Count > 0)
            {
                foreach (var iten in ls)
                {
                    Console.WriteLine($"{iten.Roll_Number}\t{iten.Name}\t{iten.Age}\t{iten.City}");
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }

            Console.ReadLine();
        }
    }
}
