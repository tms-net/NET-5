Console.WriteLine("Введите количество продуктов:");
int prodNumber = int.Parse(Console.ReadLine());

List<Product> productList = new List<Product>();

for (int i = 0; i < prodNumber; i++)
{
    int equationIndex = i + 1;
    Console.WriteLine($"Название товара №{equationIndex}: ");
    string productName = Console.ReadLine();
    Console.WriteLine($"Цена товара №{equationIndex}: ");
    int productPrice = int.Parse(Console.ReadLine());
    Console.WriteLine($"Тип товара №{equationIndex}: ");
    string productType = Console.ReadLine();

    Console.WriteLine($"Введите категорию товара: 1-sport, 2-food, 3-hardware");
    string productCategory = Console.ReadLine();

    Product prod;

    switch (productCategory)
    {
        case "1":
            prod = new SportProduct();
            break;
        case "2":
            prod = new FoodProduct();
            break;
        case "3":
            prod = new HardwareProduct();
            break;
        default:
            prod = new Product();
            Console.WriteLine("Товар без категории");
            break;

    }

    prod.name = productName;
    prod.price = productPrice;
    prod.type = productType;

    productList.Add(prod);

}




Console.WriteLine("Показать список товаров? (ДА):");
string switchPrint = Console.ReadLine();
if (switchPrint.ToUpper() == "ДА")
{
    Print();
}

void Print()
{
    foreach (SportProduct product in productList)
    {
        Console.WriteLine("Спорт: ----------------------------------------");
        Console.Write($"Название: {product.name}\n" +
                      $"    Цена: {product.price}\n" +
                      $"     Тип: {product.type}\n");
    }
    foreach (FoodProduct product in productList)
    {
        Console.WriteLine("Продукты: ----------------------------------------");
        Console.Write($"Название: {product.name}\n" +
                      $"    Цена: {product.price}\n" +
                      $"     Тип: {product.type}\n");
    }
    foreach (HardwareProduct product in productList)
    {
        Console.WriteLine("Строительные: ----------------------------------------");
        Console.Write($"Название: {product.name}\n" +
                      $"    Цена: {product.price}\n" +
                      $"     Тип: {product.type}\n");
    }
}
public class Product
{
    public string name = "Nothing";
    public int price = 0;
    public string type = "For All";

}
public class SportProduct : Product
{
    public int discount = 3;
}
public class FoodProduct : Product
{
    public int discount = 12;
}

public class HardwareProduct : Product
{
    public int discount = 8;
}