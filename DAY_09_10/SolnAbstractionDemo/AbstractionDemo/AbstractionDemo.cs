namespace AbstractionDemo
{
    // AbstractionDemo.cs
    // Demonstrates abstraction in C# using abstract classes and interfaces.
    /* ✔️ This demo covers:
	 *		Abstract class (Animal) with abstract and virtual methods.
	 *		Derived classes (Dog, Cat) overriding behavior.
	 *		Interface (IMovable) implemented by unrelated classes (Car, Bird).
	 *		Polymorphism using both abstract base classes and interfaces.
	 *		Example of a class (Bird) that inherits from an abstract class and implements an interface.
	 */

    using System;

    // Abstract class example
    public abstract class Animal
    {
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name;
        }

        // Abstract method must be implemented by subclasses
        public abstract void Speak();

        // Virtual method can be overridden, but has a default implementation
        public virtual void Describe()
        {
            Console.WriteLine($"This is an animal named {Name}.");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void Speak() => Console.WriteLine($"{Name} says: Woof!");

        public override void Describe() =>
            Console.WriteLine($"{Name} is a loyal dog.");
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void Speak() => Console.WriteLine($"{Name} says: Meow!");

        // Uses base implementation of Describe()
    }

    // Interface example
    public interface IMovable
    {
        void Move();
    }

    public class Car : IMovable
    {
        public void Move() => Console.WriteLine("The car drives on the road.");
    }

    public class Bird : Animal, IMovable
    {
        public Bird(string name) : base(name) { }

        public override void Speak() => Console.WriteLine($"{Name} chirps: Tweet!");

        public void Move() => Console.WriteLine($"{Name} flies in the sky.");
    }

    public class AbstractionDemo
    {
        public static void Main()
        {
            Console.WriteLine("=== Abstract Classes Example ===");

            Animal dog = new Dog("Buddy");
            Animal cat = new Cat("Whiskers");

            dog.Describe();
            dog.Speak();

            cat.Describe();
            cat.Speak();

            Console.WriteLine();

            Console.WriteLine("=== Interfaces Example ===");

            IMovable car = new Car();
            IMovable birdAsMovable = new Bird("Tweety");

            car.Move();
            birdAsMovable.Move();

            Console.WriteLine();

            Console.WriteLine("=== Combined Example ===");

            Animal bird = new Bird("Sky");
            bird.Describe();
            bird.Speak();

            // Bird implements IMovable too
            ((IMovable)bird).Move();
        }
    }

}
