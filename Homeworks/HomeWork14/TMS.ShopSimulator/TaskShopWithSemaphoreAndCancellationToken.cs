using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.ShopSimulator
{
    public class TaskShopWithSemaphoreAndCancellationToken
    {
        private bool _isOpened;
        private int _cashierCount;
        private SemaphoreSlim _semaphore;
        private List<Task> _tasks;
        private CancellationTokenSource _cancellation;

        public TaskShopWithSemaphoreAndCancellationToken(int cashierCount)
        {
            _semaphore = new SemaphoreSlim(0, cashierCount);
            _cashierCount = cashierCount;
            _tasks = new List<Task>();
            _cancellation = new CancellationTokenSource();
        }

        public void Open()
        {
            _isOpened = true;
            _semaphore.Release(_cashierCount);
            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cashierCount} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (_isOpened)
            {
                // Используем очередь пула потоков вместо своей очереди
                _tasks.Add(Task.Run(() => ServeCustomer(person, _cancellation.Token)));

                Console.WriteLine($"{person.Name} вошел в магазин");
            }
        }

        public void Close()
        {
            _isOpened = false;

            Console.WriteLine("Обслуживание после закрытия");

            _cancellation.CancelAfter(TimeSpan.FromSeconds(30));
            Task.WaitAll(_tasks.ToArray());

            Console.WriteLine("Полное закрытия");
        }

        private void ServeCustomer(Person person, CancellationToken cancellationToken)
        {
            _semaphore.Wait();

            try
            {
                Task.Delay(person.ProcessingTime, cancellationToken).Wait();

                // Подумать как можно понять номер кассира
                Console.WriteLine($"Клиент {person.Name} был обслужен кассиром НЕИЗВЕСТНЫЙ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Клиент {person.Name} был обслужен с ошибкой: {ex.Message}");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}