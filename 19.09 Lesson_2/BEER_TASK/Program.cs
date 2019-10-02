using System;

namespace BEER_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal finance = 7m;

            decimal leffe = 60m;
            decimal bud = 45m;
            decimal stella = 30m;
            decimal chernihivske = 20m;
            decimal obolon = 7m;

            Console.WriteLine("Your finance: " + finance + "hrn.");
            Console.WriteLine("========Menu========\nLeffe = 60hrn;\nBud = 45hrn;\nStella = 30hrn;\nChernihivske = 20hrn;\nObolon = 7hrn.");
            Console.WriteLine("====================");
            if (finance >= 60)
            {
                Console.WriteLine("Available beer for your finance: Leffe" + ". \nChange: " + (finance - leffe) + "hrn");
            }
            else if (finance >= 45)
            {
                Console.WriteLine("Available beer for your finance: Bud" + ". \nChange: " + (finance - bud) + "hrn");
            }
            else if (finance >= 30)
            {
                Console.WriteLine("Available beer for your finance: Stella" + ". \nChange: " + (finance - stella) + "hrn");
            }
            else if (finance >= 20)
            {
                Console.WriteLine("Available beer for your finance: Chernihivske" + ". \nChange: " + (finance - chernihivske) + "hrn");
            }
            else if (finance >= 7)
            {
                Console.WriteLine("Available beer for your finance: Obolon" + ". \nChange: " + (finance - obolon) + "hrn");
            }
            else
            {
                Console.WriteLine("You need more money!");
            }
            Console.ReadKey();
        }
    }
}
