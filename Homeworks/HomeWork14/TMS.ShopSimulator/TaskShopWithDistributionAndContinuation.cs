using System;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.ShopSimulator
{
    public class TaskShopWithDistributionAndContinuation : IDisposable
    {
        private bool _isOpened;
        private Task[] _cashierTasks;
        private Random _random;
        private CancellationTokenSource _cancellation;
        private Task _lastTask;
        private bool disposedValue;

        public TaskShopWithDistributionAndContinuation(int cashierCount)
        {
            _cashierTasks = new Task[cashierCount];
            _random = new Random();
            _cancellation = new CancellationTokenSource();
        }

        public void Open()
        {
            for (int i = 0; i < _cashierTasks.Length; i++)
            {
                _cashierTasks[i] = Task.CompletedTask;
                _lastTask = Task.CompletedTask;
            }
            _isOpened = true;
            Console.WriteLine($"Добро пожаловать, вас обслуживает {_cashierTasks.Length} касс(ы)");
        }

        public void Enter(Person person)
        {
            if (_isOpened)
            {
                // Используем равномерное распределение для выбора кассира
                Interlocked.Exchange(
                    ref _cashierTasks[_random.Next(0, _cashierTasks.Length)],
                    Task.WhenAny(_cashierTasks)
                        .ContinueWith(task =>
                        //ServeCustomer(person, _cancellation.Token)
                        //Task.Run(() =>
                        {
                            var newTask = ServeCustomer(person, _cancellation.Token);

                            Interlocked.Exchange(ref _lastTask, Task.WhenAll(_lastTask, newTask));

                            return newTask;
                        })
                    //);
                        .Unwrap());

                Console.WriteLine($"{person.Name} вошел в магазин");
            }
        }

        public void Close()
        {
            _isOpened = false;

            Console.WriteLine("Обслуживание после закрытия");

            _cancellation.CancelAfter(TimeSpan.FromSeconds(30));
            _lastTask.Wait();

            Console.WriteLine("Полное закрытия");
        }

        private async Task<double> ServeCustomer(Person person, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(person.ProcessingTime, cancellationToken);

                Console.WriteLine($"Клиент {person.Name} был обслужен кассиром НЕИЗВЕСТНЫЙ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Клиент {person.Name} был обслужен с ошибкой: {ex.Message}");
            }

            return _random.NextDouble() * 100;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _cancellation.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~TaskShopWithDistributionAndContinuation()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}