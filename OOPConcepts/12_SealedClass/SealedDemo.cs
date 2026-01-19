using System;

namespace OOPConcepts.SealedClass
{
    // SEALED CLASS: Cannot be inherited
    // Used to prevent further derivation
    // Improves performance (no virtual method lookups)
    
    public class Vehicle
    {
        public string Brand { get; set; }
        
        public virtual void Start()
        {
            Console.WriteLine("Vehicle starting...");
        }
    }
    
    // SEALED CLASS: Cannot be inherited further
    public sealed class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        
        public override void Start()
        {
            Console.WriteLine("Car engine started");
        }
        
        public void Drive()
        {
            Console.WriteLine("Car is driving");
        }
    }
    
    // ERROR: Cannot inherit from sealed class
    // public class SportsCar : Car { }  // Compilation error!
    
    // SEALED METHOD: Cannot be overridden further
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal sound");
        }
    }
    
    public class Dog : Animal
    {
        // SEALED OVERRIDE: This method cannot be overridden in derived classes
        public sealed override void MakeSound()
        {
            Console.WriteLine("Dog barks: Woof!");
        }
    }
    
    public class Puppy : Dog
    {
        // ERROR: Cannot override sealed method
        // public override void MakeSound() { }  // Compilation error!
        
        public void Play()
        {
            Console.WriteLine("Puppy is playing");
        }
    }
    
    public class SealedDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== SEALED CLASS & METHODS ===");
            Console.WriteLine("Prevents inheritance and method overriding\n");
            
            Console.WriteLine("--- Sealed Class ---");
            Car car = new Car { Brand = "Toyota", NumberOfDoors = 4 };
            car.Start();
            car.Drive();
            Console.WriteLine("Note: Car class cannot be inherited further");
            
            Console.WriteLine("\n--- Sealed Method ---");
            Dog dog = new Dog();
            dog.MakeSound();
            
            Puppy puppy = new Puppy();
            puppy.MakeSound();  // Calls sealed method from Dog
            puppy.Play();
            Console.WriteLine("Note: MakeSound() cannot be overridden in Puppy");
        }
    }
}
