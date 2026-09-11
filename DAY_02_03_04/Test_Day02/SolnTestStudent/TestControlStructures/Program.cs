namespace TestControlStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Try different control ststements");

            int count = 10;
            int loopTimes;

            Console.WriteLine("How many times you want to execute the loop?");
            loopTimes = int.Parse(Console.ReadLine());

            do
            {
                // stop condition must be updated
                count++;
                Console.WriteLine($"count is : {count}");
            } while (count < loopTimes);

            for (int i=0; i<= loopTimes; i++)
            {
                Console.WriteLine($"count is : {count++}");
            }

        }
    }
}
