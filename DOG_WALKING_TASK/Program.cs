using System;
using System.Threading;

namespace DOG_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            char temp;
            char aid = '+';
            char boom = '*';
            char[] road = new char[10] { '@', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            int sebek = 0;
            int Aid = rnd.Next(1, 10);
            int Boom = rnd.Next(1, 10);
            int hp = 100, i;

            while (Aid == Boom)
            {
                Aid = rnd.Next(1, 10);
            }
            road[Boom] = boom;
            road[Aid] = aid;
            Console.Write("Walking road : ");
            for (i = 0; i < road.Length; i++)
            {
                Console.Write(road[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Press 'A' to go right, or 'D' to go left: ");
            while (hp > 0 && road[sebek] <= road[9])
            {
                char control = Convert.ToChar(Console.ReadLine());
                if (control == 'd' | control == 'D' | control == 'в' | control == 'В')
                {
                    if (road[sebek + 1] == '*')
                    {
                        hp = hp - 45;
                        if (hp <= 0)
                        {
                            Console.WriteLine("Ooops, it's bomb! You lose!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ooops, it's bomb! You lost 40 hp.");

                            road[sebek + 1] = road[sebek];
                            road[sebek] = '_';
                            sebek++;
                        }
                        Console.WriteLine("Now you have " + hp + " hp.");
                    }
                    else if (road[sebek + 1] == '+')
                    {
                        hp = hp + 35;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                        Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                        Console.WriteLine("Now you have " + hp + " hp.");
                        road[sebek + 1] = road[sebek];
                        road[sebek] = '_';
                        sebek++;
                    }
                    else
                    {
                        hp = hp - 5;
                        Console.WriteLine("Now you have " + hp + " hp.");
                        temp = road[sebek];
                        road[sebek] = road[sebek + 1];
                        road[sebek + 1] = temp;
                        sebek++;
                    }
                    for (i = 0; i < road.Length; i++)
                    {
                        Console.Write(road[i]);
                    }
                    Console.WriteLine();
                }
                else if (control == 'a' || control == 'A' || control == 'ф' || control == 'Ф')
                {
                    if (sebek == 0)
                    {
                        Console.WriteLine("ERROR. You can't go left from that place.");
                    }
                    else
                    {
                        hp = hp - 5;
                        temp = road[sebek];
                        road[sebek] = road[sebek - 1];
                        road[sebek - 1] = temp;
                        sebek--;
                        Console.WriteLine("Now you have " + hp + " hp.");
                    }
                    for (i = 0; i < road.Length; i++)
                    {
                        Console.Write(road[i] + "\r");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Uncorrect button. Try again!");
                }
                if (road[9] == '@')
                {
                    Console.WriteLine("You win!");
                    break;
                }
                if (hp <= 0)
                {
                    Console.WriteLine("You lose!");
                }
            }
            Console.ReadKey();
        }
    }
}


