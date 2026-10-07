using System.Runtime.InteropServices;

namespace LinqBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ BASICS!");

            List<int> marks = new() { 78, 23, 65, 55, 95, 88 };

            // publish marks greater than 80
            List<int> result = new();

            foreach (int mark in marks)
            {

                if (mark > 80)
                {
                    result.Add(mark);
                }


            }
            foreach (int r in result)
            {

                Console.WriteLine($"marks greater than 80 : {r}");

            }


            /// LINQ version
            /// shorter and clearer

            var resultLINQ = marks.Where(m => m >= 80); // described what you want 

            foreach(int r in resultLINQ)
            { 
                Console.WriteLine($"LINQ marks greater than 80 : {r}"); 
            }

            // LINQ more useful when working with objects
            
        }

       
    }
}
