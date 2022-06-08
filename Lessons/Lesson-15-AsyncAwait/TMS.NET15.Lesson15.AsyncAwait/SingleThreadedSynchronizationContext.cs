using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.Lesson15.AsyncAwait
{
    internal class SingleThreadSynchronizationContext : SynchronizationContext
    {
        /// <summary>The queue of work items.</summary>
        private readonly BlockingCollection<KeyValuePair<SendOrPostCallback, object>> m_queue = new();
        /// <summary>The processing thread.</summary>
        private readonly Thread m_thread;

        public SingleThreadSynchronizationContext()
            : this(new BlockingCollection<KeyValuePair<SendOrPostCallback, object>>(), Thread.CurrentThread)
        {

        }

        public SingleThreadSynchronizationContext(BlockingCollection<KeyValuePair<SendOrPostCallback, object>> queue, Thread currentThread)
        {
            m_queue = queue;
            m_thread = currentThread;
        }

        /// <summary>Dispatches an asynchronous message to the synchronization context.</summary>
        /// <param name="d">The System.Threading.SendOrPostCallback delegate to call.</param>
        /// <param name="state">The object passed to the delegate.</param>
        public override void Post(SendOrPostCallback d, object state)
        {
            if (d == null) throw new ArgumentNullException("d");
            this.m_queue.Add(new KeyValuePair<SendOrPostCallback, object>(d, state));

            var s = "" + "";

            var s2 = s.Insert(0, "new");
        }

        /// <summary>Not supported.</summary>
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException("Synchronously sending is not supported.");
        }

        public override SynchronizationContext CreateCopy()
        {
            return new SingleThreadSynchronizationContext(this.m_queue, this.m_thread);
        }

        /// <summary>Runs an loop to process all queued work items.</summary>
        public void RunOnCurrentThread()
        {
            foreach (var workItem in this.m_queue.GetConsumingEnumerable())
                workItem.Key(workItem.Value);
        }

        /// <summary>Notifies the context that no more work will arrive.</summary>
        public void Complete() { this.m_queue.CompleteAdding(); }

        private const int OperationDuration = 1000;

		static async Task<int> Main(string[] args)
		{
            var context = new SingleThreadSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);

            var runAllTask = RunAllTasks();

            long l;
            int i = 0;

            l = i;

            object obj = "";

            string str = (string) obj;

            object o = 4;

            var int1 = (int) o;

            #region SECRET
            runAllTask.ContinueWith(t => context.Complete());
            context.RunOnCurrentThread();
			#endregion SECRET

			await runAllTask;
            return 0;
		}

		private static async Task RunAllTasks()
		{
			Console.WriteLine($"Main 1: {Thread.CurrentThread.ManagedThreadId}");
			await DoOperationAsync(1);

			Console.WriteLine($"Main 2: {Thread.CurrentThread.ManagedThreadId}");
			await DoOperationAsync(2);

			Console.WriteLine($"Main 3: {Thread.CurrentThread.ManagedThreadId}");
			await DoOperationAsync(3);

        }

        private static async Task DoOperationAsync(int num)
        {
	        await Task.Delay(OperationDuration);
	        Console.WriteLine($"DoOperationAsync {num}: {Thread.CurrentThread.ManagedThreadId}");
		}
    }
}
