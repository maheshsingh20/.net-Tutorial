using System;
using OOPConcepts.ClassesAndObjects;
using OOPConcepts.Encapsulation;
using OOPConcepts.Inheritance;
using OOPConcepts.Polymorphism;
using OOPConcepts.Abstraction;
using OOPConcepts.Interface;
using OOPConcepts.StaticMembers;
using OOPConcepts.Properties;
using OOPConcepts.Constructors;
using OOPConcepts.MethodOverriding;
using OOPConcepts.AccessModifiers;
using OOPConcepts.SealedClass;

namespace OOPConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║  OBJECT-ORIENTED PROGRAMMING CONCEPTS     ║");
            Console.WriteLine("║  Complete Guide with Examples             ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            
            // 1. Classes and Objects
            BasicClassDemo.Run();
            
            // 2. Encapsulation
            EncapsulationDemo.Run();
            
            // 3. Inheritance
            InheritanceDemo.Run();
            
            // 4. Polymorphism
            PolymorphismDemo.Run();
            
            // 5. Abstraction
            AbstractionDemo.Run();
            
            // 6. Interface
            InterfaceDemo.Run();
            
            // 7. Static Members
            StaticDemo.Run();
            
            // 8. Properties
            PropertiesDemo.Run();
            
            // 9. Constructors
            ConstructorDemo.Run();
            
            // 10. Method Overriding
            MethodOverridingDemo.Run();
            
            // 11. Access Modifiers
            AccessModifiersDemo.Run();
            
            // 12. Sealed Class
            SealedDemo.Run();
            
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║  ALL OOP CONCEPTS DEMONSTRATED!           ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
        }
    }
}
