using System;

namespace MediSureClinic
{
    public class PatientBill
    {
        // Patient and billing information
        public string BillId { get; set; }
        public string PatientName { get; set; }
        public bool HasInsurance { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal LabCharges { get; set; }
        public decimal MedicineCharges { get; set; }
        
        // Calculated amounts
        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPayable { get; set; }

        // Store the most recent bill in memory
        public static PatientBill LastBill;
        public static bool HasLastBill = false;

        public static void CreateNewBill()
        {
            Console.Write("Enter Bill Id: ");
            string billId = Console.ReadLine();
            
            if (string.IsNullOrEmpty(billId))
            {
                Console.WriteLine("Error: Bill ID is required!");
                return;
            }

            Console.Write("Enter Patient Name: ");
            string patientName = Console.ReadLine();

            Console.Write("Is the patient insured? (Y/N): ");
            string insuranceResponse = Console.ReadLine();
            bool hasInsurance = (insuranceResponse == "Y" || insuranceResponse == "y");

            // Get consultation fee
            Console.Write("Enter Consultation Fee: ");
            string consultationInput = Console.ReadLine();
            if (!decimal.TryParse(consultationInput, out decimal consultationFee) || consultationFee <= 0)
            {
                Console.WriteLine("Invalid consultation fee! Must be greater than 0.");
                return;
            }

            // Get lab charges
            Console.Write("Enter Lab Charges: ");
            string labInput = Console.ReadLine();
            if (!decimal.TryParse(labInput, out decimal labCharges) || labCharges < 0)
            {
                Console.WriteLine("Invalid lab charges! Must be 0 or positive.");
                return;
            }

            // Get medicine charges
            Console.Write("Enter Medicine Charges: ");
            string medicineInput = Console.ReadLine();
            if (!decimal.TryParse(medicineInput, out decimal medicineCharges) || medicineCharges < 0)
            {
                Console.WriteLine("Invalid medicine charges! Must be 0 or positive.");
                return;
            }

            // Do the math for billing
            decimal totalAmount = consultationFee + labCharges + medicineCharges;
            decimal discount = 0;
            if (hasInsurance)
            {
                discount = totalAmount * 0.10m; // 10% discount for insured patients
            }
            decimal amountToPay = totalAmount - discount;

            // Save this bill
            LastBill = new PatientBill();
            LastBill.BillId = billId;
            LastBill.PatientName = patientName;
            LastBill.HasInsurance = hasInsurance;
            LastBill.ConsultationFee = consultationFee;
            LastBill.LabCharges = labCharges;
            LastBill.MedicineCharges = medicineCharges;
            LastBill.GrossAmount = totalAmount;
            LastBill.DiscountAmount = discount;
            LastBill.FinalPayable = amountToPay;

            HasLastBill = true;

            Console.WriteLine("Bill created successfully.");
            Console.WriteLine("Gross Amount: " + totalAmount.ToString("F2"));
            Console.WriteLine("Discount Amount: " + discount.ToString("F2"));
            Console.WriteLine("Final Payable: " + amountToPay.ToString("F2"));
        }

        public static void ViewLastBill()
        {
            if (!HasLastBill || LastBill == null)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
                return;
            }

            Console.WriteLine("----------- Last Bill -----------");
            Console.WriteLine("BillId: " + LastBill.BillId);
            Console.WriteLine("Patient: " + LastBill.PatientName);
            Console.WriteLine("Insured: " + (LastBill.HasInsurance ? "Yes" : "No"));
            Console.WriteLine("Consultation Fee: " + LastBill.ConsultationFee.ToString("F2"));
            Console.WriteLine("Lab Charges: " + LastBill.LabCharges.ToString("F2"));
            Console.WriteLine("Medicine Charges: " + LastBill.MedicineCharges.ToString("F2"));
            Console.WriteLine("Gross Amount: " + LastBill.GrossAmount.ToString("F2"));
            Console.WriteLine("Discount Amount: " + LastBill.DiscountAmount.ToString("F2"));
            Console.WriteLine("Final Payable: " + LastBill.FinalPayable.ToString("F2"));
            Console.WriteLine("--------------------------------");
        }

        public static void ClearLastBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                ShowMenu();
                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    PatientBill.CreateNewBill();
                }
                else if (userChoice == "2")
                {
                    PatientBill.ViewLastBill();
                }
                else if (userChoice == "3")
                {
                    PatientBill.ClearLastBill();
                }
                else if (userChoice == "4")
                {
                    Console.WriteLine("Thank you. Application closed normally.");
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 4.");
                }

                if (keepRunning)
                {
                    Console.WriteLine("------------------------------------------------------------");
                }
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
        }
    }
}