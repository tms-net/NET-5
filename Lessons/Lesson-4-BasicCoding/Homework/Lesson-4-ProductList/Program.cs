// See https://aka.ms/new-console-template for more information
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Console.WriteLine("Домашнее задание. Создать список продуктов.");

Console.WriteLine("-------------------------------------------");
Console.WriteLine("Введите количество продуктов:");
var prodNumber = int.Parse(Console.ReadLine());

// TODO: Создать коллекцию или массив с нужным типом и количеством элементов
for (int i = 0; i < prodNumber; i++)
{
    Console.WriteLine("Введите данные продукта:");

    // TODO: Создать объеки продукта Заполнить аттрибуты продукта с помощью вворда пользователя
}

// TODO: Вывести введенные данные (опционально)

/// <summary>
/// Класс, описывающий продукт.
/// TODO: Описать аттрибуты и поведение  с помощью членов класса
/// </summary>
public class Product
{

}