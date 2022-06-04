using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.ShopSimulator
{
    internal class AsyncAwait
    {
        static Random _random = new Random();

        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine($"Threads before: {ThreadPool.ThreadCount}");

            var tasks = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                tasks[i] = Task.Run(() => SimpleMethod1());

                //tasks[i] = Task.Run(() => SimpleMethod2());
            }

            var wait = Task.WhenAll(tasks);

            Thread.Sleep(300);

            Console.WriteLine($"Threads between: {ThreadPool.ThreadCount}");

            Thread.Sleep(300);

            Console.WriteLine($"Threads between: {ThreadPool.ThreadCount}");

            wait.Wait();

            Console.WriteLine($"Threads after: {ThreadPool.ThreadCount}");
        }

        private static async Task Download1(string url)
        {
            await Task.Delay(100);

            //textBlock = "Downloaded";
        }

        private static void Download2(string url)
        {
            Task.Delay(100).Wait();

            //textBlock = "Downloaded";
        }

        private static async Task SimpleMethod1()
        {
            await Task.Delay(_random.Next(200, 1000));

            Console.WriteLine("Второй этап");

        }

        private static void SimpleMethod2()
        {
            Task.Delay(_random.Next(200, 1000)).Wait();

            Console.WriteLine("Второй этап");
        }
    }
}
