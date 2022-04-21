// See https://aka.ms/new-console-template for more information
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


Console.WriteLine("Домашнее задание. Создать список продуктов.");

Console.WriteLine("-------------------------------------------");
Console.WriteLine("Введите количество продуктов:");
var prodNumber = int.Parse(Console.ReadLine());
// Создание массива продуктов
var products = new Product[prodNumber];
// Заполнение аттрибутов продуктов с помощью ввода пользователя

for (int i = 0; i < prodNumber; i++)

{
    products[i] = new Product();
    Console.WriteLine("Введите название продукта:");
    products[i].ProductName = Console.ReadLine();
    Console.WriteLine("Введите цену продукта:");
    products[i].Price = double.Parse(Console.ReadLine());
    Console.WriteLine("Введите вес продукта:");
    products[i].Weight = double.Parse(Console.ReadLine());
    Console.WriteLine("Введите производителя продукта:");
    products[i].Producer = Console.ReadLine();


}

// Вывод введённых продуктов, вывод цены за 1 кг
Console.WriteLine("Ваши продукты");
for (int i = 0; i < prodNumber; i++)
{

    products[i].Show();
    products[i].CalculatePriceOfOneKg();


}


/// Класс, описывающий продукт.
public class Product
{
    public string ProductName = "";
    public double Price;
    public double Weight;
    public string Producer = "";
    public void Show()
    {
        Console.WriteLine($"Продукт {ProductName} Цена {Price} Вес {Weight} Производитель {Producer}");
    }
    public void CalculatePriceOfOneKg()
    {
        Console.WriteLine("Цена за килограмм:{0}", Math.Round(Price / Weight, 2));

    }

}