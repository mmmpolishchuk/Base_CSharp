using System;

namespace GUESS_NUMBER_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            int number;
            int user_number;
            int counter = 5;
            int i = 1;

            number = ran.Next(1, 101);
            while (counter != 0)
            {
                Console.Write("Try #" + i + "\tInput your number: ");
                user_number = Convert.ToInt32(Console.ReadLine());

                if (user_number == number)
                {
                    Console.WriteLine("===It's true! You won!!!===");
                    break;
                }
                else if (user_number < number)
                {
                    Console.WriteLine("Wrong! My number is bigger!");
                }
                else
                {
                    Console.WriteLine("Wrong! My number is less!");
                }
                --counter;
                ++i;

                if (user_number != number && counter == 0)
                {
                    Console.WriteLine("==============================");
                    Console.WriteLine("\tYou lost!!!\n    (My number was " + number + ")");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
