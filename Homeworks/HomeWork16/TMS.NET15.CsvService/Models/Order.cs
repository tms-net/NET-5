using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET15.CsvService.Models
{
    public class Order
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public DeliveryInfo Delivery { get; set; }

        public OrderProduct[] Products { get; set; }

        public decimal TotalPrice => Products?.Sum(p => p.TotalPrice) ?? 0;
    }
}
