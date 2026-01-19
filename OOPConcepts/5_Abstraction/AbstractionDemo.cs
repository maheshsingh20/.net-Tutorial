using System;

namespace OOPConcepts.Abstraction
{
    // ABSTRACTION: Hiding complex implementation, showing only essential features
    // Achieved through: 1) Abstract classes  2) Interfaces
    
    // === ABSTRACT CLASS ===
    // Cannot be instantiated, can have abstract and concrete methods
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        
        public Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
        
        // Abstract method: No implementation, must be overridden
        public abstract void Start();
        public abstract void Stop();
        public abstract double CalculateFuelEfficiency();
        
        // Concrete method: Has implementation, can be inherited
        public void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Brand} {Model}");
        }
    }
    
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        
        public Car(string brand, string model, int doors) : base(brand, model)
        {
            NumberOfDoors = doors;
        }
        
        // Must implement all abstract methods
        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} car engine started");
        }
        
        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} car engine stopped");
        }
        
        public override double CalculateFuelEfficiency()
        {
            return 15.5; // km per liter
        }
    }
    
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        
        public Motorcycle(string brand, string model, bool sidecar) : base(brand, model)
        {
            HasSidecar = sidecar;
        }
        
        public override void Start()
        {
            Console.WriteLine($"{Brand} {Model} motorcycle kick-started");
        }
        
        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} motorcycle stopped");
        }
        
        public override double CalculateFuelEfficiency()
        {
            return 35.0; // km per liter
        }
    }
    
    // === INTERFACE ===
    // Pure abstraction: Only method signatures, no implementation
    // A class can implement multiple interfaces
    
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }
    
    public interface IRecordable
    {
        void StartRecording();
        void StopRecording();
    }
    
    // Class implementing multiple interfaces
    public class MediaPlayer : IPlayable, IRecordable
    {
        private bool isPlaying;
        private bool isRecording;
        
        public void Play()
        {
            isPlaying = true;
            Console.WriteLine("Media playing...");
        }
        
        public void Pause()
        {
            Console.WriteLine("Media paused");
        }
        
        public void Stop()
        {
            isPlaying = false;
            Console.WriteLine("Media stopped");
        }
        
        public void StartRecording()
        {
            isRecording = true;
            Console.WriteLine("Recording started");
        }
        
        public void StopRecording()
        {
            isRecording = false;
            Console.WriteLine("Recording stopped");
        }
    }
    
    public class AbstractionDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== ABSTRACTION ===");
            Console.WriteLine("Hiding complexity, showing only essential features\n");
            
            // Abstract class example
            Console.WriteLine("--- Abstract Class ---");
            // Vehicle vehicle = new Vehicle(); // ERROR: Cannot instantiate
            
            Car car = new Car("Toyota", "Camry", 4);
            car.DisplayInfo();
            car.Start();
            Console.WriteLine($"Fuel Efficiency: {car.CalculateFuelEfficiency()} km/l");
            car.Stop();
            
            Console.WriteLine();
            
            Motorcycle bike = new Motorcycle("Harley", "Davidson", false);
            bike.DisplayInfo();
            bike.Start();
            Console.WriteLine($"Fuel Efficiency: {bike.CalculateFuelEfficiency()} km/l");
            bike.Stop();
            
            // Interface example
            Console.WriteLine("\n--- Interface ---");
            MediaPlayer player = new MediaPlayer();
            player.Play();
            player.Pause();
            player.StartRecording();
            player.StopRecording();
            player.Stop();
        }
    }
}
