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
    Console.WriteLine("Введите производителя продукта:");
    products[i].Producer = Console.ReadLine();
    Console.WriteLine("Введите цену продукта:");
    products[i].Price = double.Parse(Console.ReadLine());
    Console.WriteLine("Введите вес продукта:");
    products[i].Weight = double.Parse(Console.ReadLine());
 


}

// расчёт цены за один  кг, вывод информациии о  всех продуктах
Console.WriteLine("Ваши продукты");
for (int i = 0; i < prodNumber; i++)
{

   
    products[i].CalculatePriceOfOneKg();
    products[i].Show();


}


/// Класс, описывающий продукт.
public class Product
{
    public string ProductName = "";
    public double Price;
    public double Weight;
    public string Producer = "";
    public double PriceOfOneKg;
    public void Show()
    {
        Console.WriteLine($"{ProductName} \"{Producer}\" Цена {Price:0.00} Вес {Weight:0.00} Цена за 1 кг {PriceOfOneKg:0.00}");
    }
   
    //расчёт цены за один кг
    public void CalculatePriceOfOneKg()
    {
        PriceOfOneKg= Math.Round(Price / Weight, 2);

    }

    
}