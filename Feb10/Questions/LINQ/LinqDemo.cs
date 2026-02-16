using System;
using System.Collections.Generic;
using System.Linq;

namespace Feb10.Questions.LINQ
{
    // Entity for LINQ demonstrations
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Department { get; set; } = "";
        public decimal Salary { get; set; }
        public string City { get; set; } = "";
    }

    class LinqDemo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== LINQ Demonstrations ===\n");

            var employees = GetEmployees();

            // 1. Where - Filtering
            Console.WriteLine("1. WHERE - Employees with Salary > 50000:");
            var highSalary = employees.Where(e => e.Salary > 50000);
            foreach (var emp in highSalary)
            {
                Console.WriteLine($"   {emp.Name} - {emp.Salary:C}");
            }

            // 2. Select - Projection
            Console.WriteLine("\n2. SELECT - Employee Names Only:");
            var names = employees.Select(e => e.Name);
            foreach (var name in names)
            {
                Console.WriteLine($"   {name}");
            }

            // 3. OrderBy - Sorting
            Console.WriteLine("\n3. ORDERBY - Employees by Age (Ascending):");
            var sortedByAge = employees.OrderBy(e => e.Age);
            foreach (var emp in sortedByAge)
            {
                Console.WriteLine($"   {emp.Name} - Age: {emp.Age}");
            }

            // 4. OrderByDescending
            Console.WriteLine("\n4. ORDERBYDESCENDING - Employees by Salary:");
            var sortedBySalary = employees.OrderByDescending(e => e.Salary);
            foreach (var emp in sortedBySalary)
            {
                Console.WriteLine($"   {emp.Name} - {emp.Salary:C}");
            }

            // 5. GroupBy
            Console.WriteLine("\n5. GROUPBY - Employees by Department:");
            var groupedByDept = employees.GroupBy(e => e.Department);
            foreach (var group in groupedByDept)
            {
                Console.WriteLine($"   {group.Key}: {group.Count()} employees");
                foreach (var emp in group)
                {
                    Console.WriteLine($"      - {emp.Name}");
                }
            }

            // 6. First / FirstOrDefault
            Console.WriteLine("\n6. FIRST - First Employee:");
            var firstEmp = employees.First();
            Console.WriteLine($"   {firstEmp.Name}");

            // 7. Single / SingleOrDefault
            Console.WriteLine("\n7. SINGLE - Employee with Id = 3:");
            var singleEmp = employees.Single(e => e.Id == 3);
            Console.WriteLine($"   {singleEmp.Name}");

            // 8. Any
            Console.WriteLine("\n8. ANY - Any employee from Mumbai?");
            bool anyMumbai = employees.Any(e => e.City == "Mumbai");
            Console.WriteLine($"   {anyMumbai}");

            // 9. All
            Console.WriteLine("\n9. ALL - All employees age > 20?");
            bool allAbove20 = employees.All(e => e.Age > 20);
            Console.WriteLine($"   {allAbove20}");

            // 10. Count
            Console.WriteLine("\n10. COUNT - Total Employees:");
            int count = employees.Count();
            Console.WriteLine($"   {count}");

            // 11. Sum
            Console.WriteLine("\n11. SUM - Total Salary:");
            decimal totalSalary = employees.Sum(e => e.Salary);
            Console.WriteLine($"   {totalSalary:C}");

            // 12. Average
            Console.WriteLine("\n12. AVERAGE - Average Salary:");
            decimal avgSalary = employees.Average(e => e.Salary);
            Console.WriteLine($"   {avgSalary:C}");

            // 13. Min / Max
            Console.WriteLine("\n13. MIN/MAX - Salary Range:");
            decimal minSalary = employees.Min(e => e.Salary);
            decimal maxSalary = employees.Max(e => e.Salary);
            Console.WriteLine($"   Min: {minSalary:C}, Max: {maxSalary:C}");

            // 14. Take
            Console.WriteLine("\n14. TAKE - First 3 Employees:");
            var firstThree = employees.Take(3);
            foreach (var emp in firstThree)
            {
                Console.WriteLine($"   {emp.Name}");
            }

            // 15. Skip
            Console.WriteLine("\n15. SKIP - Skip First 2 Employees:");
            var skipTwo = employees.Skip(2);
            foreach (var emp in skipTwo)
            {
                Console.WriteLine($"   {emp.Name}");
            }

            // 16. Distinct
            Console.WriteLine("\n16. DISTINCT - Unique Cities:");
            var cities = employees.Select(e => e.City).Distinct();
            foreach (var city in cities)
            {
                Console.WriteLine($"   {city}");
            }

            // 17. Join (with Departments)
            Console.WriteLine("\n17. JOIN - Employees with Department Info:");
            var departments = GetDepartments();
            var joined = employees.Join(
                departments,
                emp => emp.Department,
                dept => dept.Name,
                (emp, dept) => new { emp.Name, emp.Department, dept.Location }
            );
            foreach (var item in joined)
            {
                Console.WriteLine($"   {item.Name} - {item.Department} ({item.Location})");
            }

            // 18. SelectMany - Flattening
            Console.WriteLine("\n18. SELECTMANY - All Skills:");
            var empWithSkills = GetEmployeesWithSkills();
            var allSkills = empWithSkills.SelectMany(e => e.Skills);
            foreach (var skill in allSkills)
            {
                Console.WriteLine($"   {skill}");
            }

            // 19. ThenBy - Multiple Sorting
            Console.WriteLine("\n19. THENBY - Sort by Department, then by Age:");
            var multiSort = employees.OrderBy(e => e.Department).ThenBy(e => e.Age);
            foreach (var emp in multiSort)
            {
                Console.WriteLine($"   {emp.Department} - {emp.Name} (Age: {emp.Age})");
            }

            // 20. Method Chaining
            Console.WriteLine("\n20. METHOD CHAINING - Complex Query:");
            var complexQuery = employees
                .Where(e => e.Age > 25)
                .OrderByDescending(e => e.Salary)
                .Take(3)
                .Select(e => new { e.Name, e.Age, e.Salary });
            
            foreach (var emp in complexQuery)
            {
                Console.WriteLine($"   {emp.Name} - Age: {emp.Age}, Salary: {emp.Salary:C}");
            }

            // 21. Query Syntax vs Method Syntax
            Console.WriteLine("\n21. QUERY SYNTAX - Employees from IT:");
            var queryResult = from e in employees
                             where e.Department == "IT"
                             orderby e.Name
                             select e;
            
            foreach (var emp in queryResult)
            {
                Console.WriteLine($"   {emp.Name}");
            }

            // 22. Aggregate
            Console.WriteLine("\n22. AGGREGATE - Concatenate Names:");
            var allNames = employees.Select(e => e.Name).Aggregate((a, b) => a + ", " + b);
            Console.WriteLine($"   {allNames}");

            // 23. ToList / ToArray / ToDictionary
            Console.WriteLine("\n23. CONVERSION - ToList, ToArray, ToDictionary:");
            var empList = employees.ToList();
            var empArray = employees.ToArray();
            var empDict = employees.ToDictionary(e => e.Id, e => e.Name);
            Console.WriteLine($"   List Count: {empList.Count}");
            Console.WriteLine($"   Array Length: {empArray.Length}");
            Console.WriteLine($"   Dictionary Keys: {string.Join(", ", empDict.Keys)}");

            Console.WriteLine("\n=== End of LINQ Demonstrations ===");
        }

        static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Amit", Age = 28, Department = "IT", Salary = 55000, City = "Mumbai" },
                new Employee { Id = 2, Name = "Priya", Age = 32, Department = "HR", Salary = 48000, City = "Delhi" },
                new Employee { Id = 3, Name = "Raj", Age = 25, Department = "IT", Salary = 52000, City = "Bangalore" },
                new Employee { Id = 4, Name = "Sneha", Age = 30, Department = "Finance", Salary = 60000, City = "Mumbai" },
                new Employee { Id = 5, Name = "Vikram", Age = 35, Department = "IT", Salary = 70000, City = "Pune" },
                new Employee { Id = 6, Name = "Anjali", Age = 27, Department = "HR", Salary = 45000, City = "Delhi" }
            };
        }

        static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Name = "IT", Location = "Tech Park" },
                new Department { Name = "HR", Location = "Main Office" },
                new Department { Name = "Finance", Location = "Tower A" }
            };
        }

        static List<EmployeeWithSkills> GetEmployeesWithSkills()
        {
            return new List<EmployeeWithSkills>
            {
                new EmployeeWithSkills { Name = "Amit", Skills = new List<string> { "C#", "SQL", "Azure" } },
                new EmployeeWithSkills { Name = "Priya", Skills = new List<string> { "Recruitment", "Training" } }
            };
        }
    }

    class Department
    {
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
    }

    class EmployeeWithSkills
    {
        public string Name { get; set; } = "";
        public List<string> Skills { get; set; } = new();
    }
}
