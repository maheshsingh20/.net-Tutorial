namespace Feb27MeetingProblem
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public required string City { get; set; }

        public override string ToString()
        {
            return $"ID: {EmployeeID}, Name: {FirstName} {LastName}, Title: {Title}, " +
                   $"DOB: {DOB:dd/MM/yyyy}, DOJ: {DOJ:dd/MM/yyyy}, City: {City}";
        }
    }
}
