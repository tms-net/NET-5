using System;
using System.Runtime.CompilerServices;

namespace TMS.NET15.Lesson15.AsyncAwait.Wpf
{
    public class Awaitable
    {
        public class Awaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public void GetResult()
            {
            }

            public void OnCompleted(Action continuation)
            {
            }

            public void UnsafeOnCompleted(Action continuation)
            {

            }
        }

        public Awaiter GetAwaiter()
        {
            return null;
        }
    }

}