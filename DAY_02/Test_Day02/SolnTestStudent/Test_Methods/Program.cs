using System.ComponentModel;

namespace Test_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declarations
            string name;
            int cCode;
            string cName;

            Console.WriteLine("Hello, We are going to demonstrate usage of different types of methods in Console application!");
            DisplayName();
            Console.WriteLine("=====WE ARE IN THE MAIN PROGRAM=======");
            name = Console.ReadLine();
            DisplayNamewithParameters(name);

            Console.WriteLine("=====EXAMPLE WITH RETURN TYPE=======");

            int resultAddition = AddNumbers(7, 8);
            Console.WriteLine($" MAIN Addition of 7 + 8 is : {resultAddition}");
            AddNumbers(7, 8);

            Console.WriteLine("Enter Course details");
            Console.WriteLine("Enter Course ID");
            cCode =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course Name");
            cName = Console.ReadLine();

            CourseDetail( cCode, cName);
        }

    


        // Example of method which does not return and we don't pass arguments
        static void DisplayName()
        {
            Console.WriteLine("=====INSIDE METHOD WITHOUT PARAMETERS=======");
            Console.WriteLine("Enter you name:\t");
            string stuName = Console.ReadLine();
            Console.WriteLine($"Student Name is : {stuName}");
        }

        // Example of method which does not return and we pass arguments
        static void DisplayNamewithParameters(string abc)
        {
            //Console.WriteLine("Enter you name:\t");
            //string stuName = Console.ReadLine();
            Console.WriteLine("=====INSIDE METHOD WITH PARAMETERS=======");
            Console.WriteLine($"Student Name is : {abc}");
        }

        // Example methods with return type

        static int AddNumbers(int a, int b) {

            int c = a + b;
            Console.WriteLine($" WITHIN METHOD Addition of 7 + 8 is :{c}");

            return c;
        }

        static void CourseDetail(int code, string courseName)
        {

            
            Console.WriteLine($" Course Code is :{code}");
            Console.WriteLine($" Course Name is :{courseName}");
            
        }
    }
}

