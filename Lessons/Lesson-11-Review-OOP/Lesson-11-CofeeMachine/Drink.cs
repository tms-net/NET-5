using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11_CofeeMachine
{
    public class Drink
    {
        public Drink(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public int gramsOfCoffee = 0;
        public int gramsOfWater = 0;
        public int gramsOfMilk = 0;

        public decimal price;

        // 12.40
    }
}
