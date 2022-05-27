using System;
using System.Diagnostics;
using System.Threading;

namespace TMS.ShopSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var shop = new Shop(3);

            shop.Open();

            for (int i = 0; i < 100; i++)
            {
                var person = new Person(random.Next(100, 1000), i + 1);
                shop.Enter(person);

                Thread.Sleep(100);
            }

            shop.Close();
        }
    }
}
