using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace TMS.NET15.ShopSimulator
{
    public class ThreadShopWithConcurrentQueue
    {
        private Thread[] _cahierThreads;
        private ConcurrentQueue<Person> _peopleQueue; // Эмуляция очереди клиентов
        private bool _isOpened;

        public ThreadShopWithConcurrentQueue(int cashierCount)
        {
            _peopleQueue = new ConcurrentQueue<Person>();
            _cahierThreads = new Thread[cashierCount];

            for (int i = 0; i < cashierCount; i++)
            {
                _cahierThreads[i] = new Thread(ServeCustomer);
                //_cahierThreads[i].IsBackground = true;
            }
        }

        public void Open()
        {
            _isOpened = true;
            for (int i = 0; i < _cahierThreads.Length; i++)
            {
                _cahierThreads[i].Start(i);
            }

            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (!_isOpened)
            {
                throw new InvalidOperationException();
            }

            _peopleQueue.Enqueue(person);

            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            _isOpened = false;

            Console.WriteLine("Обслуживание после закрытия");

            for (int i = 0; i < _cahierThreads.Length; i++)
            {
                Console.WriteLine($"Ждем кассира {i}");

                if (!_cahierThreads[i].Join(10 * 1000))
                {
                    Console.WriteLine($"Прерываем кассира {i}");
                    _cahierThreads[i].Interrupt();
                }
            }
        }

        private void ServeCustomer(object cashier)
        {
            while(_isOpened || !_peopleQueue.IsEmpty)
            {
                if (_peopleQueue.TryDequeue(out var person))
                {
                    Thread.Sleep(person.ProcessingTime);
                    Console.WriteLine($"Клиент {person.Name} обслужен кассиром {cashier}");
                }
                else
                {
                    Console.WriteLine($"Кассир {cashier} курит");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
