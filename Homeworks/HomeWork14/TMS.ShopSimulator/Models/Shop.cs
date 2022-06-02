using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET15.ShopSimulator
{
    public abstract class Shop
    {
        public abstract void Open();
        public abstract void Close();
        public abstract void Enter(Person person);
    }
}
