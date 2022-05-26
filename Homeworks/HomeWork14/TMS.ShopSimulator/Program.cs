using System;
using System.Diagnostics;
using System.Threading;

namespace TMS.ShopSimulator
{
    class Program
    {
	    static int AvailableThreads
	    {
		    get
		    {
			    ThreadPool.GetAvailableThreads(out int availableThreads, out _);
			    return availableThreads;
		    }
	    }

	    static int MaxThreads
	    {
		    get
		    {
			    ThreadPool.GetMaxThreads(out int maxThreads, out _);
			    return maxThreads;
		    }
	    }

        static void Main(string[] args)
        {
        }
    }
}
