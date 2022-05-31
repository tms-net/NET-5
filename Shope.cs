using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
            public class Shop
    {
            private Thread[] _cahierThreads;
            private Queue<Person> _peopleQueue; // Эмуляция очереди клиентов
        
        public Shop(int cahierCount)
            {
                _peopleQueue = new Queue<Person>();
                _cahierThreads = new Thread[cahierCount];

                for (int i = 0; i < cahierCount; i++)
                {
                    _cahierThreads[i] = new Thread(ServeCustomer);
                }
            }

            public void Open()
            {
                Array.ForEach(_cahierThreads, thread => thread.Start());

                Console.WriteLine($"Добро пожаловать, вас обслуживает {_cahierThreads.Length} касс(ы)");
            }

            public void Enter(Person person)
            {
            // TODO: Реализовать логику постановки клиента в очередь
            _peopleQueue.Enqueue(person);
            Console.WriteLine($"{person.Name} вошел в магазин");
            }

            public void Close()
            {
            Console.WriteLine("Обслуживание после закрытия");
            while (_peopleQueue.Count > 0)
            {
                new Thread(ServeCustomer).Start();
            }
            if (_peopleQueue.Count == 0)
            {
                Console.WriteLine("Очередь пуста");
            }
                // TODO: Реализовать гарантированное обслуживание всех клиентов после закрытия
            }
            private void ServeCustomer()
            {
            Thread.Sleep(1000);
            if (_peopleQueue.Count > 0)
            {
                var person = _peopleQueue.Dequeue();
                Console.WriteLine($"Клиент {person.Name} был обслужен");
            }
            // TODO: Реализовать логику обслуживания клиента из очереди
            // Использовать свойство клиента для эмуляции времени обслуживания с помощью Thread.Sleep()
        }
    }
    
}
