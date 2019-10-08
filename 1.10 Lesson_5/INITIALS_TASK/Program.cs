using System;
using System.Text;

namespace INITIALS_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tInput info about somebody: ");
            string str = Convert.ToString(Console.ReadLine());

            char[] seps = { ' ' };
            string[] parts = str.Split(seps);

            Console.WriteLine("\tPersonal initials:");
            for (int i = 0; i < parts.Length; i++)
            {
                StringBuilder firstLetter = new StringBuilder(parts[i]);
                firstLetter[0] = Char.ToUpper(firstLetter[0]);

                if (i == 0)
                {
                    Console.Write(firstLetter[0] + parts[i].Substring(1, parts[i].Length - 1) + " ");
                }
                else
                {
                    Console.Write(firstLetter[0] + ". ");
                }
            }
            //smorzhevskiy nazarii valentinovich
            //polishchuk mykhailo mykhailovich
            Console.ReadKey();
        }
    }
}
