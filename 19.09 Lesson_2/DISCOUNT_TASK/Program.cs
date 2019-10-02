using System;

namespace DISCOUNT_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal price;
            decimal discount;
            decimal discounted_price;

            price = 10000m;
            discount = 0;

            if (price >= 500m)
            {
                discount = 7;
            }
            else if (price >= 400m)
            {
                discount = 2;
            }
            else if (price >= 300m)
            {
                discount = 3;
            }
            else
            {
                discount = 0;
            }
            Console.WriteLine("Your discount: " + discount + "%.\nDiscounted price: " + (discounted_price = price - (price / 100) * discount) + "hrn");
            Console.ReadKey();
        }
    }
}
