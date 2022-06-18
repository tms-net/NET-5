using TMS.NET15.CsvService.Services;

namespace TMS.NET15.CsvService.Models
{
    public class OrderProduct
    {
        [HeaderName("Price, $")]
        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        [Order(100)]
        public decimal TotalPrice => ProductPrice * Quantity;

        [Ignore]
        public string ProductId { get; set; }

        [HeaderName("\"Name\"")]
        [Order(-100)]
        public string ProductName { get; set; }

    }
}