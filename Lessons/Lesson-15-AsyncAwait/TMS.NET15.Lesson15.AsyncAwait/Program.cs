using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMS.NET15.Lesson15.AsyncAwait
{
	class Program
	{
        // Rename to Main in order to run as console app
		static void MainOld(string[] args)
        {
            Console.WriteLine("Hello world!");
            int i = 1;
            while (true)
            {
                new Thread(obj =>
                {
                    while (true) Thread.Sleep(100);
                }).Start();
                Console.WriteLine($"{i++}: {Process.GetCurrentProcess().PagedMemorySize64 / 2048}MB");
            }
        }  
	}
}

