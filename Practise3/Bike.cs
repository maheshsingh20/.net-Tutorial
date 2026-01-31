namespace Practise3
{
    public class Bike
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int PricePerDay { get; set; }
        public Bike(string model, string brand, int pricePerDay)
        {
            Model = model;
            Brand = brand;
            PricePerDay = pricePerDay;
        }
    }
}