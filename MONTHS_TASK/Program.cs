using System;

namespace MONTHS_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[] month = new int[13];

            for (i = 1; i <= 12; i++)
                Console.WriteLine("Month " + i + ": " + ((i == 2 ? 28 : (i <= 6 && i % 2 == 0 || i > 7 && i % 2 != 0 ? 30 : 31)))); ;

            Console.ReadKey();
        }
    }
}