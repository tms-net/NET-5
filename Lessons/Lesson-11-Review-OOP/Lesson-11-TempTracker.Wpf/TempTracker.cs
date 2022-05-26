using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_TempTracker.Wpf
{
    public class TempTracker
    {
        private readonly List<int> _values;

        public TempTracker()
        {
            _values = new List<int>();
        }

        public void Insert(int val)
        {
            _values.Add(val);
        }

        public int GetMax()
        {
            return _values.Max();
        }

        public int GetMin()
        {
            return _values.Min();
        }


        public double GetMean()
        {
            return _values.Average();
        }
    }
}
