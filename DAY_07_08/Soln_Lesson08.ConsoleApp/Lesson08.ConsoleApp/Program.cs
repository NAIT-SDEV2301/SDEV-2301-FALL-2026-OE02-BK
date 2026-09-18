namespace Lesson08.ConsoleApp
{
    // InheritanceDemo_Guided.cs
    // Guided exercise: Practice inheritance, polymorphism, and composition in C#.

    using System;
    using System.Collections.Generic;

    // TODO: Create an abstract base class called Shape
    // - Add a public property Color (string)
    // - Add a constructor that sets Color
    // - Add an abstract method GetArea() that returns double
    // - Add a virtual method Describe() that prints "This is a {Color} shape."

    // base class

    public abstract class Shape
    {
        // - Add a public property Color (string)
        public string Color { get; set; } // auto implemented property 

        // - Add a constructor that sets Color

        public Shape(string color)
        {
            Color = color;
        }

        // - Add an abstract method GetArea() that returns double

        public abstract double GetArea(); // implementation details are added by derived classes

        // - Add a virtual method Describe() that prints "This is a {Color} shape."

        public virtual void Describe()
        {
            Console.WriteLine($" This is a {Color} shape.");

        }
    }


    // TODO: Create a Circle class that inherits from Shape
    // - Add a property Radius (double)
    // - Add a constructor that takes color and radius, and calls base(color)
    // - Override GetArea() to return π * r^2
    // - Override Describe() to print "This is a {Color} circle with radius {Radius}."



    // TODO: Create a Circle class that inherits from Shape

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string color, double radius) : base(color)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"This is a {Color} circle with radius {Radius}.");

        }

    }

    // Derived class: Rectangle
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(string color, double length, double width) : base(color)
        {
            Length = length;
            Width = width;
        }

        public override double GetArea() => Length * Width;

        public override void Describe()
        {
            Console.WriteLine($"This is a {Color} rectangle {Length} x {Width}.");
        }
    }


    // TODO: Create a Rectangle class that inherits from Shape
    // - Add properties Length and Width (double)
    // - Add a constructor that takes color, length, width and calls base(color)
    // - Override GetArea() to return length * width
    // - Override Describe() to print "This is a {Color} rectangle {Length} x {Width}."


    // TODO: Create an Engine class with a Start() method that prints "Engine starting..."

    // TODO: Create a Car class that uses composition
    // - It should "have an" Engine (create an Engine field/property)
    // - Add a Drive() method that calls Engine.Start() and prints "The car is driving..."


    public class InheritanceDemo_Guided
    {
        public static void Main()
        {
            Console.WriteLine("=== Inheritance and Polymorphism Guided Exercise ===");

            // TODO: Create a List<Shape> with one Circle and one Rectangle
            // - Use polymorphism to loop through and call Describe() and GetArea() on each


            Console.WriteLine("=== Composition Example ===");

            // TODO: Create a Car object and call Drive()
        }
    }

}