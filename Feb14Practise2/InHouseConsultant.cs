using System;

namespace HealthSync
{
    public class InHouseConsultant : Consultant
    {
        public decimal MonthlyStipend { get; set; }

        public InHouseConsultant(string id, string name, decimal stipend)
            : base(id, name)
        {
            if (stipend < 0)
                throw new ArgumentException("Monthly stipend cannot be negative");

            MonthlyStipend = stipend;
        }

        // Override abstract method with In-House specific calculation
        public override decimal CalculateGrossPayout()
        {
            // Formula: MonthlyStipend + Allowances + Bonuses
            decimal allowances = MonthlyStipend * 0.20m; // 20% of stipend
            decimal bonuses = 1000m; // Fixed bonus

            return MonthlyStipend + allowances + bonuses;
        }

        // Uses inherited virtual method (sliding scale TDS)
        // No override needed - uses default behavior

        public override string GetConsultantType()
        {
            return "In-House Consultant";
        }
    }
}
