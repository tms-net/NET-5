namespace TMS.NET15.CsvService.Models
{
    public class OrderProduct
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice => ProductPrice * Quantity;
    }
}