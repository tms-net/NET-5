// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using TMS.NET15.CsvService.Models;
using TMS.NET15.CsvService.Services;

Console.WriteLine("Hello, Serialization!");

var random = new Random();
var csvServie = new CsvStoreService(new CsvSerializer());
var products = new List<OrderProduct>();
var order = new Order();

// TODO: Создать заказ с помощью пользователя

for (int i = 0; i < random.Next(5,15); i++)
{
    products.Add(new OrderProduct
    {
        ProductId = Guid.NewGuid().ToString(),
        ProductName = Guid.NewGuid().ToString("N"),
        ProductPrice = Convert.ToDecimal(random.NextDouble() * 1000),
        Quantity = random.Next(2,10)
    });
}

order.Products = products.ToArray();
order.Delivery = new DeliveryInfo
{
    Address = "Minsk",
    Price = 10
};

csvServie.Persist(new [] { order });

foreach (var item in csvServie.Read<OrderProduct>())
{
    Console.WriteLine($"{item.ProductName}: {item.Quantity}");
}



