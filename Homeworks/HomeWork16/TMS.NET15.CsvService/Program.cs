// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using TMS.NET15.CsvService.Models;
using TMS.NET15.CsvService.Services;

Console.WriteLine("Hello, Serialization!");

var csvServie = new CsvService();
var products = new List<OrderProduct>();

// TODO: Создать заказ с помощью пользователя

csvServie.Persist(products);

foreach (var item in csvServie.Read<OrderProduct>())
{
    Console.WriteLine($"{item.ProductName}: {item.Quantity}");
}



