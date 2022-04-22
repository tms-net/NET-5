// See https://aka.ms/new-console-template for more information
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Console.WriteLine("Домашнее задание. Создать список продуктов.");

Console.WriteLine("-------------------------------------------");
Console.WriteLine("Введите количество продуктов:");
var prodNumber = int.Parse(Console.ReadLine());

// TODO: Создать коллекцию или массив с нужным типом и количеством элементов
// Пример: var products = new Product[3] // строчка создаст массив для 3-х объектов типа Product;
for (int i = 0; i < prodNumber; i++)
{
    Console.WriteLine("Введите тип продукта:");

    // TODO: Создать объеки соответствующего типа продукта 
    // Заполнить все нужные аттрибуты соответствуюзего типа с помощью вворда пользователя
}

// TODO: Использовать интерфейс, реализующий продукт (опционально)

/// <summary>
/// Класс, описывающий продукт.
/// TODO: Описать аттрибуты и поведение  с помощью членов класса
/// </summary>
public abstract class Product
{

}

/// <summary>
/// Класс, описывающий специфический продукт.
/// TODO: Дополнить аттрибуты и поведение базового класса
/// </summary>
public class SportProduct : Product
{

}