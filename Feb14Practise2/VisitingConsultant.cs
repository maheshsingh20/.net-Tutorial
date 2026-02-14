using System;

namespace HealthSync
{
    public class VisitingConsultant : Consultant
    {
        public int ConsultationsCount { get; set; }
        public decimal RatePerVisit { get; set; }

        public VisitingConsultant(string id, string name, int consultations, decimal rate)
            : base(id, name)
        {
            if (consultations < 0)
                throw new ArgumentException("Consultations count cannot be negative");

            if (rate < 0)
                throw new ArgumentException("Rate per visit cannot be negative");

            ConsultationsCount = consultations;
            RatePerVisit = rate;
        }

        // Override abstract method with Visiting specific calculation
        public override decimal CalculateGrossPayout()
        {
            // Formula: ConsultationsCount × RatePerVisit
            return ConsultationsCount * RatePerVisit;
        }

        // Override virtual method to apply flat 10% TDS
        public override decimal CalculateTDS(decimal grossPayout)
        {
            // Flat 10% for all visiting consultants
            return 0.10m;
        }

        public override string GetConsultantType()
        {
            return "Visiting Consultant";
        }
    }
}
