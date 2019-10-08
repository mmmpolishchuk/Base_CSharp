using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            char temp;
            int i;
            int sebek_x = 0;
            int sebek_y = 0;
            int hp = 100;
            char aid = '+';
            char boom = '*';
            char[][] road = new char[10][];

            for (i = 0; i < road.Length; i++)
            {
                road[i] = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            }
            road[sebek_x][sebek_y] = '@';

            for (i = 0; i < road.Length; i++)
            {
                int Aid = rnd.Next(1, 10);
                int Boom = rnd.Next(1, 10);
                while (Aid == Boom)
                {
                    Aid = rnd.Next(1, 10);
                }
                road[i][Boom] = boom;
                road[i][Aid] = aid;

            }
            Console.WriteLine("Walking road : ");
            for (i = 0; i < road.Length; i++)
            {
                Console.WriteLine(road[i]);
            }
            Console.WriteLine();
            Console.WriteLine("You can control moving of dog. Press 'A' to go right,'D' to go left, 'W' - go forward, 'S' - go back: ");
            while (hp > 0 && road[9][9] != '@')
            {
                char control = Convert.ToChar(Console.ReadLine());

                if (control == 'd' | control == 'D' | control == 'в' | control == 'В')
                {
                    Console.Clear();
                    if (road[sebek_x][9] == '@')
                    {
                        hp = hp - 5;
                        temp = road[sebek_x][9];
                        road[sebek_x][9] = road[sebek_x][0];
                        road[sebek_x][0] = temp;
                        sebek_y = 0;
                        Console.WriteLine("Now you have " + hp + " hp.");
                    }
                    else
                    {
                        if (road[sebek_x][sebek_y + 1] == '*')
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

                                road[sebek_x][sebek_y + 1] = road[sebek_x][sebek_y];
                                road[sebek_x][sebek_y] = '_';
                                sebek_y++;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[sebek_x][sebek_y + 1] == '+')
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[sebek_x][sebek_y + 1] = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = '_';
                            sebek_y++;
                        }
                        else
                        {
                            hp = hp - 5;
                            Console.WriteLine("Now you have " + hp + " hp.");
                            temp = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = road[sebek_x][sebek_y + 1];
                            road[sebek_x][sebek_y + 1] = temp;
                            sebek_y++;
                        }
                    }
                    for (i = 0; i < road.Length; i++)
                    {
                        Console.WriteLine(road[i]);
                    }
                }
                else if (control == 'a' || control == 'A' || control == 'ф' || control == 'Ф')
                {
                    Console.Clear();
                    if (road[sebek_x][0] == '@')
                    {
                        if (road[sebek_x][9] == '*')      //якщо останній елемент масиву - бомба
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
                                //temp = road[sebek_x][9];
                                road[sebek_x][9] = road[sebek_x][0];
                                road[sebek_x][0] = '_';
                                sebek_y = 9;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[sebek_x][9] == '+')    //якщо останній елемент масиву - аптечка
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[sebek_x][9] = road[sebek_x][0];
                            road[sebek_x][0] = '_';
                            sebek_y = 9;
                        }
                        else
                        {
                            hp = hp - 5;
                            temp = road[sebek_x][0];
                            road[sebek_x][0] = road[sebek_x][9];
                            road[sebek_x][9] = temp;
                            sebek_y = 9;
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                    }
                    else
                    {
                        if (road[sebek_x][sebek_y - 1] == '*')
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
                                road[sebek_x][sebek_y - 1] = road[sebek_x][sebek_y];
                                road[sebek_x][sebek_y] = '_';
                                sebek_y--;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[sebek_x][sebek_y - 1] == '+')
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[sebek_x][sebek_y - 1] = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = '_';
                            sebek_y--;
                        }
                        else
                        {
                            hp = hp - 5;
                            Console.WriteLine("Now you have " + hp + " hp.");
                            temp = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = road[sebek_x][sebek_y - 1];
                            road[sebek_x][sebek_y - 1] = temp;
                            sebek_y--;
                        }
                    }
                    for (i = 0; i < road.Length; i++)
                    {
                        Console.WriteLine(road[i]);
                    }

                }
                else if (control == 'w' || control == 'W' || control == 'ц' || control == 'Ц')
                {
                    Console.Clear();
                    if (road[0][sebek_y] == '@')
                    {
                        if (road[9][sebek_y] == '*')      //якщо останній елемент стовпця - бомба
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

                                road[9][sebek_y] = road[0][sebek_y];
                                road[0][sebek_y] = '_';
                                sebek_x = 9;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[9][sebek_y] == '+')    //якщо останній елемент стовпця - аптечка
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[9][sebek_y] = road[0][sebek_y];
                            road[0][sebek_y] = '_';
                            sebek_x = 9;
                        }
                        else
                        {
                            hp = hp - 5;
                            temp = road[0][sebek_y];
                            road[0][sebek_y] = road[9][sebek_y];
                            road[9][sebek_y] = temp;
                            sebek_x = 9;
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                    }
                    else
                    {
                        if (road[sebek_x - 1][sebek_y] == '*')
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
                                road[sebek_x - 1][sebek_y] = road[sebek_x][sebek_y];
                                road[sebek_x][sebek_y] = '_';
                                sebek_x--;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[sebek_x - 1][sebek_y] == '+')
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[sebek_x - 1][sebek_y] = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = '_';
                            sebek_x--;
                        }
                        else
                        {
                            hp = hp - 5;
                            Console.WriteLine("Now you have " + hp + " hp.");
                            temp = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = road[sebek_x - 1][sebek_y];
                            road[sebek_x - 1][sebek_y] = temp;
                            sebek_x--;
                        }
                    }
                    for (i = 0; i < road.Length; i++)
                    {
                        Console.WriteLine(road[i]);
                    }
                    Console.WriteLine();
                }
                else if (control == 's' || control == 'S' || control == 'ы' || control == 'Ы' || control == 'і' || control == 'І')
                {
                    Console.Clear();
                    if (road[9][sebek_y] == '@')
                    {
                        if (road[0][sebek_y] == '*')      //якщо останній елемент стовпця - бомба
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

                                road[0][sebek_y] = road[9][sebek_y];
                                road[9][sebek_y] = '_';
                                sebek_x = 9;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[0][sebek_y] == '+')    //якщо останній елемент стовпця - аптечка
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[0][sebek_y] = road[9][sebek_y];
                            road[9][sebek_y] = '_';
                            sebek_x = 9;
                        }
                        else
                        {
                            hp = hp - 5;
                            temp = road[9][sebek_y];
                            road[9][sebek_y] = road[0][sebek_y];
                            road[0][sebek_y] = temp;
                            sebek_x = 0;
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                    }
                    else
                    {
                        if (road[sebek_x + 1][sebek_y] == '*')
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
                                road[sebek_x + 1][sebek_y] = road[sebek_x][sebek_y];
                                road[sebek_x][sebek_y] = '_';
                                sebek_x++;
                            }
                            Console.WriteLine("Now you have " + hp + " hp.");
                        }
                        else if (road[sebek_x + 1][sebek_y] == '+')
                        {
                            hp = hp + 35;
                            if (hp >= 100)
                            {
                                hp = 100;
                            }
                            Console.WriteLine("Yeah! It's kit! You have +40 hp.");
                            Console.WriteLine("Now you have " + hp + " hp.");
                            road[sebek_x + 1][sebek_y] = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = '_';
                            sebek_x++;
                        }
                        else
                        {
                            hp = hp - 5;
                            Console.WriteLine("Now you have " + hp + " hp.");
                            temp = road[sebek_x][sebek_y];
                            road[sebek_x][sebek_y] = road[sebek_x + 1][sebek_y];
                            road[sebek_x + 1][sebek_y] = temp;
                            sebek_x++;
                        }
                    }
                    for (i = 0; i < road.Length; i++)
                    {
                        Console.WriteLine(road[i]);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Uncorrect button. Try again!");
                }
                if (road[9][9] == '@')
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





