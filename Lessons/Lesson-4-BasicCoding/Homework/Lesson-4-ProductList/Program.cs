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

//roduct product = null;
for (int i = 0; i < prodNumber; i++)

{
    Console.WriteLine("Введите тип продукта(спортивный,лекарство,косметика:");
    var input = Console.ReadLine();
    if (input == "лекарство")
        products[i] = new Medicine();
    else if (input == "спортивный")
        products[i] = new Sport();
    else if (input == "косметика")
        products[i] = new Cosmetic();
    Console.WriteLine("Введите название продукта:");
    products[i].ProductName = Console.ReadLine();
    Console.WriteLine("Введите цену продукта:");
    products[i].Price = double.Parse(Console.ReadLine());

}


// TODO: Использовать интерфейс, реализующий продукт (опционально)

//  вывод информациии о продуктах
Console.WriteLine("Ваши продукты");
for (int i = 0; i < prodNumber; i++)
{
    products[i].Show();
}
public interface IDisposable 
{
    void Dispose();
}

/// Класс, описывающий продукт.
public abstract class Product
{
    public string ProductName = "";
    public double Price;
 
    protected virtual string GetStorageConditions()
    {
        return "Отсутствуют особые условия хранения";
     }
    public void Show()
    {
        Console.WriteLine($"Продукт: {ProductName}");
        Console.WriteLine(GetStorageConditions());
        Console.WriteLine($"Цена {Price:0.00}");
    }
   

    
}

public class Medicine : Product, IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    protected override string GetStorageConditions() 
    {
        return "Хранить при температуре от 8 до 15 °С в недоступном для детей месте. ";
    }

}

public class Cosmetic : Product
{
    protected override string GetStorageConditions()
    {
        return "Хранить при температуре от 5 до 25 °С.";
    }
}

public class Sport : Product
{
    protected override string GetStorageConditions()
    {
        var storageConditions = base.GetStorageConditions();
        return "Это спортивный товар и у него "+storageConditions;
    }
}

 