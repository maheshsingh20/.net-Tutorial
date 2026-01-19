using System;

namespace OOPConcepts.Inheritance
{
    // INHERITANCE: Creating new classes from existing classes
    // Child class inherits properties and methods from parent class
    // Promotes code reusability and establishes relationships
    
    // BASE CLASS (Parent/Super class)
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        // Virtual method: Can be overridden in derived classes
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} makes a sound");
        }
        
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} is eating");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }
    }
    
    // DERIVED CLASS (Child/Sub class) - inherits from Animal
    public class Dog : Animal
    {
        public string Breed { get; set; }
        
        // Constructor calling base class constructor
        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }
        
        // OVERRIDE: Providing specific implementation
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} barks: Woof! Woof!");
        }
        
        // New method specific to Dog
        public void Fetch()
        {
            Console.WriteLine($"{Name} is fetching the ball");
        }
    }
    
    public class Cat : Animal
    {
        public bool IsIndoor { get; set; }
        
        public Cat(string name, int age, bool isIndoor) : base(name, age)
        {
            IsIndoor = isIndoor;
        }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} meows: Meow! Meow!");
        }
        
        public void Scratch()
        {
            Console.WriteLine($"{Name} is scratching");
        }
    }
    
    // MULTI-LEVEL INHERITANCE
    public class Bird : Animal
    {
        public double WingSpan { get; set; }
        
        public Bird(string name, int age, double wingSpan) : base(name, age)
        {
            WingSpan = wingSpan;
        }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} chirps: Tweet! Tweet!");
        }
        
        public virtual void Fly()
        {
            Console.WriteLine($"{Name} is flying");
        }
    }
    
    public class Eagle : Bird
    {
        public Eagle(string name, int age, double wingSpan) : base(name, age, wingSpan)
        {
        }
        
        public override void Fly()
        {
            Console.WriteLine($"{Name} soars high in the sky!");
        }
        
        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting for prey");
        }
    }
    
    public class InheritanceDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== INHERITANCE ===");
            Console.WriteLine("Child class inherits from parent class");
            Console.WriteLine("Types: Single, Multi-level, Hierarchical\n");
            
            // Creating objects of derived classes
            Dog dog = new Dog("Buddy", 3, "Golden Retriever");
            dog.MakeSound();    // Overridden method
            dog.Eat();          // Inherited method
            dog.Sleep();        // Inherited method
            dog.Fetch();        // Dog-specific method
            Console.WriteLine($"Breed: {dog.Breed}\n");
            
            Cat cat = new Cat("Whiskers", 2, true);
            cat.MakeSound();
            cat.Scratch();
            Console.WriteLine($"Indoor cat: {cat.IsIndoor}\n");
            
            // Multi-level inheritance
            Eagle eagle = new Eagle("Sky", 5, 2.5);
            eagle.MakeSound();
            eagle.Fly();
            eagle.Hunt();
            
            // Polymorphism with inheritance
            Console.WriteLine("\n--- Polymorphism Example ---");
            Animal[] animals = { dog, cat, eagle };
            foreach (Animal animal in animals)
            {
                animal.MakeSound();  // Calls appropriate overridden method
            }
        }
    }
}
