using System;

namespace QuickMartTraders
{
    public class SaleTransaction
    {
        // Basic transaction details
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }
        
        // Profit/Loss calculations
        public string ProfitOrLossStatus { get; set; }
        public decimal ProfitOrLossAmount { get; set; }
        public decimal ProfitMarginPercent { get; set; }

        // Keep track of the latest transaction
        public static SaleTransaction LastTransaction;
        public static bool HasLastTransaction = false;

        public static void CreateNewTransaction()
        {
            Console.Write("Enter Invoice No: ");
            string invoiceNo = Console.ReadLine();
            
            if (string.IsNullOrEmpty(invoiceNo))
            {
                Console.WriteLine("Invoice number cannot be blank!");
                return;
            }

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            string itemName = Console.ReadLine();

            // Get quantity from user
            Console.Write("Enter Quantity: ");
            string qtyInput = Console.ReadLine();
            int quantity;
            if (!int.TryParse(qtyInput, out quantity) || quantity <= 0)
            {
                Console.WriteLine("Quantity must be a positive number!");
                return;
            }

            // Get purchase amount
            Console.Write("Enter Purchase Amount (total): ");
            string purchaseInput = Console.ReadLine();
            decimal purchaseAmount;
            if (!decimal.TryParse(purchaseInput, out purchaseAmount) || purchaseAmount <= 0)
            {
                Console.WriteLine("Purchase amount must be greater than zero!");
                return;
            }

            // Get selling amount
            Console.Write("Enter Selling Amount (total): ");
            string sellingInput = Console.ReadLine();
            decimal sellingAmount;
            if (!decimal.TryParse(sellingInput, out sellingAmount) || sellingAmount < 0)
            {
                Console.WriteLine("Selling amount cannot be negative!");
                return;
            }

            // Figure out if we made profit or loss
            string status;
            decimal profitLossAmount;
            
            if (sellingAmount > purchaseAmount)
            {
                status = "PROFIT";
                profitLossAmount = sellingAmount - purchaseAmount;
            }
            else if (sellingAmount < purchaseAmount)
            {
                status = "LOSS";
                profitLossAmount = purchaseAmount - sellingAmount;
            }
            else
            {
                status = "BREAK-EVEN";
                profitLossAmount = 0;
            }

            decimal marginPercent = (profitLossAmount / purchaseAmount) * 100;

            // Store the transaction data
            LastTransaction = new SaleTransaction();
            LastTransaction.InvoiceNo = invoiceNo;
            LastTransaction.CustomerName = customerName;
            LastTransaction.ItemName = itemName;
            LastTransaction.Quantity = quantity;
            LastTransaction.PurchaseAmount = purchaseAmount;
            LastTransaction.SellingAmount = sellingAmount;
            LastTransaction.ProfitOrLossStatus = status;
            LastTransaction.ProfitOrLossAmount = profitLossAmount;
            LastTransaction.ProfitMarginPercent = marginPercent;

            HasLastTransaction = true;

            Console.WriteLine("Transaction saved successfully.");
            Console.WriteLine("Status: " + status);
            Console.WriteLine("Profit/Loss Amount: " + profitLossAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + marginPercent.ToString("F2"));
        }

        public static void ViewLastTransaction()
        {
            if (!HasLastTransaction || LastTransaction == null)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Console.WriteLine("-------------- Last Transaction --------------");
            Console.WriteLine("InvoiceNo: " + LastTransaction.InvoiceNo);
            Console.WriteLine("Customer: " + LastTransaction.CustomerName);
            Console.WriteLine("Item: " + LastTransaction.ItemName);
            Console.WriteLine("Quantity: " + LastTransaction.Quantity);
            Console.WriteLine("Purchase Amount: " + LastTransaction.PurchaseAmount.ToString("F2"));
            Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount.ToString("F2"));
            Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
            Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + LastTransaction.ProfitMarginPercent.ToString("F2"));
            Console.WriteLine("--------------------------------------------");
        }

        public static void CalculateProfitLoss()
        {
            if (!HasLastTransaction || LastTransaction == null)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            // Recalculate the profit/loss numbers
            string newStatus;
            decimal newProfitLoss;

            if (LastTransaction.SellingAmount > LastTransaction.PurchaseAmount)
            {
                newStatus = "PROFIT";
                newProfitLoss = LastTransaction.SellingAmount - LastTransaction.PurchaseAmount;
            }
            else if (LastTransaction.SellingAmount < LastTransaction.PurchaseAmount)
            {
                newStatus = "LOSS";
                newProfitLoss = LastTransaction.PurchaseAmount - LastTransaction.SellingAmount;
            }
            else
            {
                newStatus = "BREAK-EVEN";
                newProfitLoss = 0;
            }

            decimal newMargin = (newProfitLoss / LastTransaction.PurchaseAmount) * 100;

            // Update the stored values
            LastTransaction.ProfitOrLossStatus = newStatus;
            LastTransaction.ProfitOrLossAmount = newProfitLoss;
            LastTransaction.ProfitMarginPercent = newMargin;

            // Show the results
            Console.WriteLine("Profit/Loss Calculation Results:");
            Console.WriteLine("Status: " + newStatus);
            Console.WriteLine("Profit/Loss Amount: " + newProfitLoss.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + newMargin.ToString("F2"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    SaleTransaction.CreateNewTransaction();
                }
                else if (choice == "2")
                {
                    SaleTransaction.ViewLastTransaction();
                }
                else if (choice == "3")
                {
                    SaleTransaction.CalculateProfitLoss();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Thank you. Application closed normally.");
                    continueRunning = false;
                }
                else
                {
                    Console.WriteLine("That's not a valid option. Please choose 1, 2, 3, or 4.");
                }

                if (continueRunning)
                {
                    Console.WriteLine("------------------------------------------------------");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
        }
    }
}