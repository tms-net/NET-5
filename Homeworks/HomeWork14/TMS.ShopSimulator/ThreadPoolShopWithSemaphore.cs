using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.ShopSimulator
{
    public class ThreadPoolShopWithSemaphore
    {
        private bool _isOpened;
        private int _cashierCount;
        private int _peopleCount;
        private SemaphoreSlim _semaphore;

        // [1,2,3,4,5,6,7] - очередь (есть в ThreadPool.QueueUserWorkItem)

        // [1,2,3] - кассиры

        // одновременно выполняет 3 потока

        // [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,10] - ThreadPool

        public ThreadPoolShopWithSemaphore(int cashierCount)
        {
            _semaphore = new SemaphoreSlim(cashierCount);
            _cashierCount = cashierCount;
        }

        public void Open()
        {
            _isOpened = true;
            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cashierCount} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (_isOpened)
            {
                Interlocked.Increment(ref _peopleCount);

                // Используем очередь пула потоков вместо своей очереди
                ThreadPool.QueueUserWorkItem(ServeCustomer, person);

                Console.WriteLine($"{person.Name} вошел в магазин");
            }
        }

        public void Close()
        {
            _isOpened = false;

            Console.WriteLine("Обслуживание после закрытия");

            var closeTimer = Stopwatch.StartNew();
            while(_peopleCount > 0)
            {
                Console.WriteLine($"Время после последнего клиента: {closeTimer.Elapsed.TotalSeconds}");
                Thread.Sleep(200);

                if (closeTimer.Elapsed.TotalSeconds > 30)
                {
                    Console.WriteLine($"Принудительное закрытие после {closeTimer.Elapsed.TotalSeconds} секунд");
                    closeTimer.Stop();
                    break;
                }
            }

            Console.WriteLine("Полное закрытия");
        }

        private void ServeCustomer(object personObj)
        {
            _semaphore.Wait();

            var person = (Person)personObj;

            Thread.Sleep(person.ProcessingTime);

            // Подумать как можно понять номер кассира
            Console.WriteLine($"Клиент {person.Name} был обслужен кассиром НЕИЗВЕСТНЫЙ");

            Interlocked.Decrement(ref _peopleCount);

            _semaphore.Release();
        }
    }
}