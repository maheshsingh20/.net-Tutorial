using Feb27MeetingProblem;
class Program
{
    static void Main(string[] args)
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "Consultant", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Associate", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Manager", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2016, 1, 2), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "SE", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
        };

        // a. Display detail of all the employee
        Console.WriteLine("a. All employees:");
        var allEmployees = from emp in empList select emp;
        foreach (var emp in allEmployees)
        {
            Console.WriteLine(emp);
        }
        // b. Display details of all the employee whose location is not Mumbai
        Console.WriteLine("\nb. Employees NOT in Mumbai:");
        var notMumbaiEmployees = from emp in empList where emp.City != "Mumbai" select emp;
        foreach (var emp in notMumbaiEmployees)
        {
            Console.WriteLine(emp);
        }
        // c. Display details of all the employee whose title is AsstManager
        Console.WriteLine("\nc. Employees with title AsstManager:");
        var asstManagers = from emp in empList where emp.Title == "AsstManager" select emp;
        foreach (var emp in asstManagers)
        {
            Console.WriteLine(emp);
        }
        // d. Display details of all the employee whose Last Name start with S
        Console.WriteLine("\nd. Employees with Last Name starting with S:");
        var lastNameStartsWithS = from emp in empList where emp.LastName.StartsWith("S") select emp;
        foreach (var emp in lastNameStartsWithS)
        {
            Console.WriteLine(emp);
        }
        // e. Display a list of all the employee who have joined before 1/1/2015
        Console.WriteLine("\ne. Employees who joined before 1/1/2015:");
        var joinedBefore2015 = from emp in empList where emp.DOJ < new DateTime(2015, 1, 1) select emp;
        foreach (var emp in joinedBefore2015)
        {
            Console.WriteLine(emp);
        }
        // f. Display a list of all the employee whose date of birth is after 1/1/1990
        Console.WriteLine("\nf. Employees whose DOB is after 1/1/1990:");
        var dobAfter1990 = from emp in empList where emp.DOB > new DateTime(1990, 1, 1) select emp;
        foreach (var emp in dobAfter1990)
        {
            Console.WriteLine(emp);
        }
        // g. Display a list of all the employee whose designation is Consultant and Associate
        Console.WriteLine("\ng. Employees with designation Consultant or Associate:");
        var consultantsAndAssociates = from emp in empList where emp.Title == "Consultant" || emp.Title == "Associate" select emp;
        foreach (var emp in consultantsAndAssociates)
        {
            Console.WriteLine(emp);
        }
        // h. Display total number of employees
        Console.WriteLine("\nh. Total number of employees:");
        var totalEmployees = empList.Count();
        Console.WriteLine($"Total: {totalEmployees}");
        // i. Display total number of employees belonging to "Chennai"
        Console.WriteLine("\ni. Total number of employees in Chennai:");
        var chennaiCount = (from emp in empList where emp.City == "Chennai" select emp).Count();
        Console.WriteLine($"Chennai employees: {chennaiCount}");
        // j. Display highest employee id from the list
        Console.WriteLine("\nj. Highest employee ID:");
        var highestId = (from emp in empList select emp.EmployeeID).Max();
        Console.WriteLine($"Highest ID: {highestId}");
        // k. Display total number of employee who have joined after 1/1/2015
        Console.WriteLine("\nk. Total employees who joined after 1/1/2015:");
        var joinedAfter2015Count = (from emp in empList where emp.DOJ > new DateTime(2015, 1, 1) select emp).Count();
        Console.WriteLine($"Joined after 1/1/2015: {joinedAfter2015Count}");
        // l. Display total number of employee whose designation is not "Associate"
        Console.WriteLine("\nl. Total employees whose designation is NOT Associate:");
        var notAssociateCount = (from emp in empList where emp.Title != "Associate" select emp).Count();
        Console.WriteLine($"Not Associate: {notAssociateCount}");
        // m. Display total number of employee based on City
        Console.WriteLine("\nm. Total employees grouped by City:");
        var employeesByCity = from emp in empList group emp by emp.City into cityGroup select new { City = cityGroup.Key, Count = cityGroup.Count() };
        foreach (var group in employeesByCity)
        {
            Console.WriteLine($"{group.City}: {group.Count}");
        }
        // n. Display total number of employee based on city and title
        Console.WriteLine("\nn. Total employees grouped by City and Title:");
        var employeesByCityAndTitle = from emp in empList group emp by new { emp.City, emp.Title } into cityTitleGroup select new { cityTitleGroup.Key.City, cityTitleGroup.Key.Title, Count = cityTitleGroup.Count() };
        foreach (var group in employeesByCityAndTitle)
        {
            Console.WriteLine($"{group.City} - {group.Title}: {group.Count}");
        }
        // o. Display total number of employee who is youngest in the list
        Console.WriteLine("\no. Youngest employee:");
        var youngestEmployee = (from emp in empList orderby emp.DOB descending select emp).First();
        Console.WriteLine(youngestEmployee);
    }
}