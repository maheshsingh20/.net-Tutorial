namespace GenericsPractice.Problem2
{
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }

        public override string ToString()
        {
            return $"{Name} (ID: {StudentId}, Semester: {Semester}, {Specialization})";
        }
    }
}
