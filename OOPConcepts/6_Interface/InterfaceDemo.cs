using System;

namespace OOPConcepts.Interface
{
    // INTERFACE: Contract that defines what a class must do
    // Contains only method signatures (no implementation)
    // Supports multiple inheritance
    
    public interface IAnimal
    {
        // Properties (auto-implemented)
        string Name { get; set; }
        
        // Method signatures (no body)
        void Eat();
        void Sleep();
        void MakeSound();
    }
    
    public interface ISwimmable
    {
        void Swim();
    }
    
    public interface IFlyable
    {
        void Fly();
        int GetMaxAltitude();
    }
    
    // Class implementing single interface
    public class Lion : IAnimal
    {
        public string Name { get; set; }
        
        public Lion(string name)
        {
            Name = name;
        }
        
        public void Eat()
        {
            Console.WriteLine($"{Name} the lion is eating meat");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping in the den");
        }
        
        public void MakeSound()
        {
            Console.WriteLine($"{Name} roars: ROAR!");
        }
    }
    
    // Class implementing multiple interfaces
    public class Duck : IAnimal, ISwimmable, IFlyable
    {
        public string Name { get; set; }
        
        public Duck(string name)
        {
            Name = name;
        }
        
        // IAnimal implementation
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating seeds and insects");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping near the pond");
        }
        
        public void MakeSound()
        {
            Console.WriteLine($"{Name} quacks: Quack! Quack!");
        }
        
        // ISwimmable implementation
        public void Swim()
        {
            Console.WriteLine($"{Name} is swimming in the pond");
        }
        
        // IFlyable implementation
        public void Fly()
        {
            Console.WriteLine($"{Name} is flying");
        }
        
        public int GetMaxAltitude()
        {
            return 1000; // meters
        }
    }
    
    public class Fish : IAnimal, ISwimmable
    {
        public string Name { get; set; }
        
        public Fish(string name)
        {
            Name = name;
        }
        
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating plankton");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} is resting underwater");
        }
        
        public void MakeSound()
        {
            Console.WriteLine($"{Name} makes bubbles");
        }
        
        public void Swim()
        {
            Console.WriteLine($"{Name} is swimming gracefully");
        }
    }
    
    public class InterfaceDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== INTERFACE ===");
            Console.WriteLine("Contract defining what a class must implement");
            Console.WriteLine("Supports multiple inheritance\n");
            
            Lion lion = new Lion("Simba");
            lion.MakeSound();
            lion.Eat();
            lion.Sleep();
            
            Console.WriteLine();
            
            Duck duck = new Duck("Donald");
            duck.MakeSound();
            duck.Eat();
            duck.Swim();
            duck.Fly();
            Console.WriteLine($"Max altitude: {duck.GetMaxAltitude()}m");
            
            Console.WriteLine();
            
            Fish fish = new Fish("Nemo");
            fish.MakeSound();
            fish.Swim();
            
            // Interface as reference type
            Console.WriteLine("\n--- Interface Reference ---");
            ISwimmable[] swimmers = { duck, fish };
            foreach (ISwimmable swimmer in swimmers)
            {
                swimmer.Swim();
            }
        }
    }
}
