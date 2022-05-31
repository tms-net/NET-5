using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
  
        public class Person
        {
            public Person(int processingTime, int personId)
            {
                ProcessingTime = processingTime;
                Name = $"Person-{personId}";
            }

            public int ProcessingTime { get; }
            public string Name { get; }
        }
    
}
