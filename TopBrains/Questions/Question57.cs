using System;

namespace TopBrains.Questions
{
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message) : base(message)
        {
        }
    }
    
    public class RobotHazardAuditor
    {
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            // Validate arm precision
            if (armPrecision < 0.0 || armPrecision > 1.0)
            {
                throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
            }
            
            // Validate worker density
            if (workerDensity < 1 || workerDensity > 20)
            {
                throw new RobotSafetyException("Error: Worker density must be 1-20");
            }
            
            // Validate machinery state and get risk factor
            double machineRiskFactor;
            switch (machineryState)
            {
                case "Worn":
                    machineRiskFactor = 1.3;
                    break;
                case "Faulty":
                    machineRiskFactor = 2.0;
                    break;
                case "Critical":
                    machineRiskFactor = 3.0;
                    break;
                default:
                    throw new RobotSafetyException("Error: Unsupported machinery state");
            }
            
            // Calculate hazard risk
            double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
            return hazardRisk;
        }
    }
    
    public class Question57
    {
        public static void Main(string[] args)
        {
            RobotHazardAuditor auditor = new RobotHazardAuditor();
            
            try
            {
                Console.Write("Enter Arm Precision (0.0 - 1.0):");
                double armPrecision = double.Parse(Console.ReadLine());
                
                Console.Write("Enter Worker Density (1 - 20):");
                int workerDensity = int.Parse(Console.ReadLine());
                
                Console.Write("Enter Machinery State (Worn/Faulty/Critical):");
                string machineryState = Console.ReadLine();
                
                double risk = auditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
                Console.WriteLine($"Robot Hazard Risk Score: {risk}");
            }
            catch (RobotSafetyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}