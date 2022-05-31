using System;
using System.Diagnostics;
using System.Threading;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var shop = new Shop(3);

            shop.Open();

            for (int i = 0; i < 10; i++)
            {
                var person = new Person(10, i + 1);
                shop.Enter(person);

                Thread.Sleep(100);
            }

            shop.Close();
        }
    }
}