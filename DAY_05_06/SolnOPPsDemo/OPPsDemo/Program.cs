using System.Security.Cryptography.X509Certificates;

namespace OPPsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //Declarations
           //
           
            string inputVar;
            string vName;
            int vAge;


            Console.WriteLine("Enter name ");
            vName = Console.ReadLine();

            Console.WriteLine("Enter age ");
            inputVar = Console.ReadLine();
            vAge = int.Parse(inputVar);

            Student stu1 = new Student(vName, vAge);            
            Console.WriteLine("Demo OPPs Concepts , Fields, properties, methods, constructor, encapsulation");

            // Display Student record

            Console.WriteLine($"Student 1 name is: {stu1.Name}");
            Console.WriteLine($"Student 1 age is: {stu1.Age}");
        }
    }
}
