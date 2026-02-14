using System;

namespace HealthSync
{
    public abstract class Consultant
    {
        public string ConsultantId { get; set; }
        public string Name { get; set; }

        protected Consultant(string id, string name)
        {
            if (!ValidateConsultantId(id))
                throw new ArgumentException("Invalid doctor id");

            ConsultantId = id;
            Name = name;
        }

        // Validation: ID must be exactly 6 chars, start with "DR", last 4 must be numeric
        private bool ValidateConsultantId(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 6)
                return false;

            if (!id.StartsWith("DR"))
                return false;

            string numericPart = id.Substring(2);
            return int.TryParse(numericPart, out _);
        }

        // Abstract method - forces subclasses to implement their own calculation
        public abstract decimal CalculateGrossPayout();

        // Virtual method - can be overridden by subclasses
        public virtual decimal CalculateTDS(decimal grossPayout)
        {
            // Default sliding scale for In-House consultants
            if (grossPayout <= 5000)
                return 0.05m; // 5%
            else
                return 0.15m; // 15%
        }

        public decimal CalculateNetPayout()
        {
            decimal gross = CalculateGrossPayout();
            decimal tdsRate = CalculateTDS(gross);
            decimal tdsAmount = gross * tdsRate;
            return gross - tdsAmount;
        }

        public void DisplayPayoutDetails()
        {
            decimal gross = CalculateGrossPayout();
            decimal tdsRate = CalculateTDS(gross);
            decimal net = CalculateNetPayout();

            Console.WriteLine($"\nPayout Details for {Name} ({ConsultantId})");
            Console.WriteLine($"Consultant Type: {GetConsultantType()}");
            Console.WriteLine($"Gross Payout: {gross:F2}");
            Console.WriteLine($"TDS Applied: {tdsRate * 100}%");
            Console.WriteLine($"Net Payout: {net:F2}");
        }

        public abstract string GetConsultantType();
    }
}
