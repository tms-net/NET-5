using System;
using System.Collections.Generic;
using System.Threading;

namespace TMS.ShopSimulator
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

            Console.WriteLine($"{person.Name} вошел в магазин");
        }

        public void Close()
        {
            // TODO: Реализовать гарантированное обслуживание всех клиентов после закрытия
        }

        private void ServeCustomer()
        {
            // TODO: Реализовать логику обслуживания клиента из очереди
            // Использовать свойство клиента для эмуляции времени обслуживания с помощью Thread.Sleep()
        }
    }
}