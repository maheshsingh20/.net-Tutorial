using System;

namespace OOPConcepts.ClassesAndObjects
{
    // CLASS: Blueprint or template for creating objects
    // Contains data (fields/properties) and behavior (methods)
    public class Person
    {
        // FIELDS: Variables that store data (private by convention)
        private string name;
        private int age;
        
        // PROPERTIES: Provide controlled access to fields
        // Get accessor: retrieves the value
        // Set accessor: assigns the value
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        // Auto-implemented property (shorthand)
        public string Email { get; set; }
        
        // Read-only property (only get accessor)
        public int Age
        {
            get { return age; }
        }
        
        // CONSTRUCTOR: Special method called when object is created
        // Default constructor (no parameters)
        public Person()
        {
            name = "Unknown";
            age = 0;
            Email = "not@provided.com";
        }
        
        // Parameterized constructor
        public Person(string name, int age)
        {
            this.name = name;  // 'this' refers to current object
            this.age = age;
        }
        
        // Constructor overloading (multiple constructors)
        public Person(string name, int age, string email) : this(name, age)
        {
            this.Email = email;
        }
        
        // METHODS: Functions that define behavior
        public void Introduce()
        {
            Console.WriteLine($"Hi, I'm {name}, {age} years old.");
        }
        
        public void SetAge(int newAge)
        {
            if (newAge > 0 && newAge < 150)
            {
                age = newAge;
            }
        }
        
        public void CelebrateBirthday()
        {
            age++;
            Console.WriteLine($"Happy Birthday! Now {age} years old.");
        }
    }
    
    public class BasicClassDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n=== CLASSES AND OBJECTS ===");
            Console.WriteLine("Class: Blueprint for creating objects");
            Console.WriteLine("Object: Instance of a class\n");
            
            // Creating objects (instances of Person class)
            Person person1 = new Person();
            person1.Name = "Alice";
            person1.SetAge(25);
            person1.Introduce();
            
            Person person2 = new Person("Bob", 30);
            person2.Introduce();
            
            Person person3 = new Person("Charlie", 35, "charlie@email.com");
            person3.Introduce();
            Console.WriteLine($"Email: {person3.Email}");
            
            person2.CelebrateBirthday();
        }
    }
}
