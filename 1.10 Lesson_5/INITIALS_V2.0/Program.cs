using System;

namespace INITIALS_V2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string info, last_name, name, surname;
            //last_name = info.Substring(0, indexOfFirstGap);
            int indexOsLastGap, indexOfFirstGap;
            string[][] infoArr = new string[3][];
            infoArr[0] = new string[3];
            infoArr[1] = new string[3];
            infoArr[2] = new string[3];


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\tInput info about person #" + (i + 1) + ":");
                info = Convert.ToString(Console.ReadLine());
                indexOsLastGap = info.LastIndexOf(" ");
                indexOfFirstGap = info.IndexOf(" ");
                last_name = info.Substring(0, indexOfFirstGap);
                name = info.Substring(indexOfFirstGap + 1, indexOsLastGap - indexOfFirstGap);
                surname = info.Substring(indexOsLastGap + 1, info.Length - 1 - indexOsLastGap);
                Console.WriteLine("Last name: " + last_name + "\nName: " + name + "\nSurname: " + surname);
            }
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(last_name);
                }
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.WriteLine(infoArr[i][j] + " ");
            //    }
            //}
            Console.ReadKey();
        }
    }
}
