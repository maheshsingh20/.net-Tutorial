using System;

namespace HealthSync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HealthSync Advanced Billing System v1.0");
            Console.WriteLine("Machine Masters - Medical Payroll\n");

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Process In-House Consultant");
                Console.WriteLine("2. Process Visiting Consultant");
                Console.WriteLine("3. Run All Test Scenarios");
                Console.WriteLine("0. Exit");

                Console.Write("\nYour choice: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            ProcessInHouseConsultant();
                            break;
                        case "2":
                            ProcessVisitingConsultant();
                            break;
                        case "3":
                            RunAllScenarios();
                            break;
                        case "0":
                            Console.WriteLine("\nThank you for using HealthSync Billing System!");
                            return;
                        default:
                            Console.WriteLine("\nInvalid choice. Please try again.");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\nERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nUnexpected Error: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ProcessInHouseConsultant()
        {
            Console.WriteLine("\nIn-House Consultant Processing");

            Console.Write("Enter Consultant ID (e.g., DR2001): ");
            string id = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Monthly Stipend: ");
            decimal stipend = decimal.Parse(Console.ReadLine());

            var consultant = new InHouseConsultant(id, name, stipend);
            consultant.DisplayPayoutDetails();
        }

        static void ProcessVisitingConsultant()
        {
            Console.WriteLine("\nVisiting Consultant Processing");

            Console.Write("Enter Consultant ID (e.g., DR8005): ");
            string id = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Number of Consultations: ");
            int consultations = int.Parse(Console.ReadLine());

            Console.Write("Enter Rate Per Visit: ");
            decimal rate = decimal.Parse(Console.ReadLine());

            var consultant = new VisitingConsultant(id, name, consultations, rate);
            consultant.DisplayPayoutDetails();
        }

        static void RunAllScenarios()
        {
            Console.WriteLine("\nRunning All Test Scenarios\n");

            // Scenario 1: In-House Consultant (High Earner)
            Console.WriteLine("Scenario 1: In-House Consultant (High Earner)");
            Console.WriteLine("Input: ID: DR2001, Stipend: 10000");
            try
            {
                var consultant1 = new InHouseConsultant("DR2001", "Dr. Sarah Johnson", 10000);
                consultant1.DisplayPayoutDetails();
                Console.WriteLine("Expected: Gross: 13000.00 | TDS: 15% | Net: 11050.00");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Scenario 2: Visiting Consultant
            Console.WriteLine("\nScenario 2: Visiting Consultant");
            Console.WriteLine("Input: ID: DR8005, 10 Visits @ 600");
            try
            {
                var consultant2 = new VisitingConsultant("DR8005", "Dr. Michael Chen", 10, 600);
                consultant2.DisplayPayoutDetails();
                Console.WriteLine("Expected: Gross: 6000.00 | TDS: 10% | Net: 5400.00");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Scenario 3: Validation Failure
            Console.WriteLine("\nScenario 3: Validation Failure");
            Console.WriteLine("Input: ID: MD1001");
            try
            {
                var consultant3 = new InHouseConsultant("MD1001", "Dr. Invalid", 5000);
                consultant3.DisplayPayoutDetails();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Expected: Invalid doctor id (Process terminates)");
            }

            // Additional Scenario 4: In-House Low Earner (5% TDS)
            Console.WriteLine("\nScenario 4: In-House Consultant (Low Earner - 5% TDS)");
            Console.WriteLine("Input: ID: DR3001, Stipend: 3000");
            try
            {
                var consultant4 = new InHouseConsultant("DR3001", "Dr. Emily Brown", 3000);
                consultant4.DisplayPayoutDetails();
                Console.WriteLine("Expected: Gross: 4600.00 | TDS: 5% | Net: 4370.00");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Additional Scenario 5: Edge Case - Exactly 5000 threshold
            Console.WriteLine("\nScenario 5: In-House Consultant (At Threshold)");
            Console.WriteLine("Input: ID: DR4001, Stipend: 3333.33");
            try
            {
                var consultant5 = new InHouseConsultant("DR4001", "Dr. James Wilson", 3333.33m);
                consultant5.DisplayPayoutDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Additional Scenario 6: Multiple validation failures
            Console.WriteLine("\nScenario 6: Various Validation Failures");
            
            Console.WriteLine("\nTest 6a: ID too short");
            try
            {
                var test1 = new InHouseConsultant("DR123", "Test", 5000);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.WriteLine("\nTest 6b: ID wrong prefix");
            try
            {
                var test2 = new InHouseConsultant("AB1234", "Test", 5000);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.WriteLine("\nTest 6c: ID non-numeric suffix");
            try
            {
                var test3 = new InHouseConsultant("DRABC1", "Test", 5000);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
