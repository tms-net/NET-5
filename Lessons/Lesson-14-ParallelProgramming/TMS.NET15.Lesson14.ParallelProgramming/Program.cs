using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.Lesson14.ParallelProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = new string[] { "H", "e", "l", "l", "o" };

            // Используйте большое количество элементов, чтобы увидеть сколько потоков нужно для выполнения операций
            //var hello = new string[] { "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "H", "e", "l", "l", "o" };

            Console.WriteLine($"Task Count: {hello.Length}"); // количестао задач, которые нужно выполнить параллельно

            Console.WriteLine($"Processors: {Environment.ProcessorCount}"); // Количество ядер/процессоров в системе

            Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}"); // Начальное количество потоков в пуле процессов

            // Задайте максимальное количество потоков для обработки задач
            //ThreadPool.SetMaxThreads(1000, 100);

            ThreadPool.GetAvailableThreads(out var workerThreadCount, out var completionPortThreads);

            Console.WriteLine($"Worker Threads: {workerThreadCount}"); // Максимальное количество потоков, обслуживающих рабочие задачи

            Console.WriteLine($"Completion Port Threads: {completionPortThreads}"); // Максимальное количество потоков, обслуживающих рабочие задачи ввода/вывода  

            // [1,2] -> internet -> [] I/O = Input/Output

            // Применяем разные подходы для выполнения параллельных задач
            for (int i = 0; i < hello.Length; i++)
            {
                var letter = hello[i];

                //new Thread(() => Console.WriteLine(letter.ToUpper())).Start();

                ThreadPool.QueueUserWorkItem((state) =>
                {
                    // Если сэмулировать блокировку потока, то их количество для выполнения такого же числа задач увеличится
                    // Thread.Sleap(1000)

                    Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");
                    Console.WriteLine(state.ToUpper());
                },
                letter,
                false);
            }

            Console.WriteLine($"Testing large number of parallel operations");
            for (int i = 0; i < 100000; i++)
            {
                // Оцените скорость работы при использовании 2-х подходов для выполнения большого количества параллельных операций
                
                //ThreadPool.QueueUserWorkItem((state) => { Thread.Sleep(100); });
                //var thread = new Thread(() => { Thread.Sleep(100); });
                //thread.Start();
            }

            // worker/processors [1,2] -> [1:"H", 2:"e"] -> [1:"l", 2:"l"] -> [2:"o"]

            // (1,2,3,4,5,6,7)

            // Ожидаем завершения выполнения параллельных задач
            Thread.Sleep(2000);

            // Проверяем количество потоков, необходимых для их выполнения
            Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

            Console.WriteLine("Exploring other parallelization options");

            Console.WriteLine("Exploring PLINQ");

            // Выполняем задачу с помощью PLINQ
            var parallel = hello.AsParallel()
                //.WithDegreeOfParallelism(3) // Попробуйте задать степень параллелизма
                .Select((letter) => letter.ToUpper());

            var hello2 = parallel.ToArray();

            Console.WriteLine(string.Join("", hello2));

            // Параметр параллелизма для выполняемых операций
            // MaxDegreeOfParallelism = 3
            // [1,2,3] [4,5,6] [7,8,9,10]

            Console.WriteLine("Exploring Parallel");

            // Выполняем CPU intensive операции параллельно
            var keyPairs = new string[20];

            var sw = new Stopwatch();
            sw.Start();

            //for (int i = 0; i < keyPairs.Length; i++) // выполнение на одном потоке
            var result = Parallel.For(0, keyPairs.Length, // выполнение на разных потоках/ядрах
                new ParallelOptions
                {
                    // При выполнении таких операций не имеет смысла разбивать задачи на количество частей, большее чем число процессоров
                    // Попробуйте увеличить степень параллелизма и оценить результат
                    // Попробуйте также уменьшить степень параллелизма и оценить результат
                    MaxDegreeOfParallelism = Environment.ProcessorCount // 10 // 2
                },
                i => keyPairs[i] = RSA.Create().ToXmlString(true));

            sw.Stop();

            // Оцените время выполнения
            Console.WriteLine($"Calculated {keyPairs.Length} key pairs in {sw.ElapsedMilliseconds} ms");

            // Оцените количество потоков, необходимых для выполнения задач 
            Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

            // Что мы изучили:

            // Thread -> создание потоков и запуск асинхронных операций на них
            // ThreadPool -> Постановка задач в очередь для выполнения пулом потоков

            // Parallel -> удобный параметризуемый запуск параллльных операций/задач и результат
            // PLINQ -> параллельная работа с множествами и объединение результата

            // TPL (Task Parallel Library) ->
            //  Полный контроль за выполением асинхронной/параллельной задачи
            //  Комбинирование задач и получения их результата
            //  Возможность получить исключение из другого потока

            var task = Task.Run(() =>
            {
                Thread.Sleep(100);
                throw null;
            });

            // Отслеживаем статус задачи

            Console.WriteLine($"Status: {task.Status}");

            Thread.Sleep(1000);

            Console.WriteLine($"Status: {task.Status}");

            Console.WriteLine($"Error: {task.Exception.Message}");

            try
            {
                // Работа с TPL

                //var task2 = Task.WhenAll(task, task, task);
                //task2 = Task.WhenAny(new[] { task, task, task });

                //var taskWithResult = Task.Run(() => "Task");

                var hello3 = hello
                    .Select((letter) => Task.Run(() => letter.ToUpper()))
                    .Select(t => t.Result)
                    .ToArray();

                Console.WriteLine(string.Join("", hello3));

                task.Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
