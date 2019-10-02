using System;

namespace NUMBER_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int counterThird = 0;
            int sum = 0;

            Console.Write("Input a number: ");
            int numeric = Convert.ToInt32(Console.ReadLine());

            while (numeric > 0)
            {
                if ((numeric % 10) % 3 == 0)
                {
                    counterThird++;
                }
                if ((numeric % 10) % 2 == 0)
                {
                    sum += numeric % 10;
                }
                counter++;
                numeric = numeric / 10;
            }

            Console.WriteLine("1) Number of digits: " + counter);
            Console.WriteLine("2) Sum of even digits: " + sum);
            Console.WriteLine("3) Amount of digits that divided by 3: " + counterThird);

            Console.ReadKey();
        }
    }
}
