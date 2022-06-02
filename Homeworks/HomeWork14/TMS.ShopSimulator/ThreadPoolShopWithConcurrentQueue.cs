using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.ShopSimulator
{
    public class ThreadPoolShopWithConcurrentQueue
    {
        private int _cashierCount;
        private ConcurrentQueue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isOpened;
        private int _closedCashiers;

        public ThreadPoolShopWithConcurrentQueue(int cashierCount)
        {
            _peopleQueue = new ConcurrentQueue<Person>();
            _cashierCount = cashierCount;
        }

        public void Open()
        {
            _isOpened = true;
            for (int i = 0; i < _cashierCount; i++)
            {
                ThreadPool.QueueUserWorkItem(cashier => ServeCustomer(cashier), i);
            }

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cashierCount} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (_isOpened)
            {
                _peopleQueue.Enqueue(person);

                Console.WriteLine($"{person.Name} вошел в магазин");
            }
        }

        public void Close()
        {
            _isOpened = false;

            Console.WriteLine("Обслуживание после закрытия");

            while (_peopleQueue.Count > 0)
            {
                Console.WriteLine($"Все еще людей в очереди: {_peopleQueue.Count}");
                Thread.Sleep(100);
            }

            var closeTimer = Stopwatch.StartNew();
            while(_cashierCount > 0)
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

        private void ServeCustomer(object cashier)
        {
            Console.WriteLine($"Кассир {cashier} начинает работу");

            while (_isOpened || _peopleQueue.Count > 0)
            {
                if (_peopleQueue.TryDequeue(out var person))
                {
                    Thread.Sleep(person.ProcessingTime);

                    Console.WriteLine($"Клиент {person.Name} был обслужен кассиром {cashier}");
                }
                else
                {
                    Console.WriteLine($"Кассир {cashier} курит");
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine($"Кассир {cashier} заканчивает работу");

            Interlocked.Decrement(ref _cashierCount);
        }
    }
}