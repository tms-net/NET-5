using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TMS.NET15.ShopSimulator;

namespace TMS.ShopSimulator
{
    class Program
    {
        static void MainProgram(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var random = new Random();
            //var shop = new ThreadShopWithQueue(3);
            //var shop = new ThreadShopWithConcurrentQueue(3);
            //var shop = new ThreadPoolShopWithConcurrentQueue(3);
            //var shop = new ThreadPoolShopWithSemaphore(3);
            //var shop = new TaskShopWithSemaphoreAndCancellationToken(3);
            var shop = new TaskShopWithDistributionAndContinuation(3);

            Task.Run(() =>
            {
                while (true)
                {
                    shop.Enter(new Person(1000, random.Next(100, 1000)));
                    Thread.Sleep(500);
                }
            });

            Task.Delay(500).ContinueWith(t => shop.Enter(new Person(1000*60*3, -100)));

            shop.Open();

            for (int i = 0; i < 30; i++)
            {
                var person = new Person(random.Next(100, 1000), i + 1);
                shop.Enter(person);

                Thread.Sleep(100);
            }

            shop.Close();
        }
    }
}
