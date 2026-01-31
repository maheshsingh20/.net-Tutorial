using System;
using System.Collections.Generic;

namespace Practise3
{
    class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
        
        static void Main(string[] args)
        {
            BikeUtility bikeUtility = new BikeUtility();
            
            while (true)
            {
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the model");
                        string model = Console.ReadLine();
                        Console.Write("Enter the brand");
                        string brand = Console.ReadLine();
                        Console.Write("Enter the price per day");
                        int pricePerDay = int.Parse(Console.ReadLine());
                        
                        bikeUtility.AddBikeDetails(model, brand, pricePerDay);
                        Console.WriteLine("Bike details added successfully");
                        break;
                        
                    case "2":
                        var groupedBikes = bikeUtility.GroupBikesByBrand();
                        foreach (var brandGroup in groupedBikes)
                        {
                            Console.WriteLine(brandGroup.Key);
                            foreach (var bike in brandGroup.Value)
                            {
                                Console.WriteLine(bike.Model);
                            }
                        }
                        break;
                        
                    case "3":
                        return;
                        
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}