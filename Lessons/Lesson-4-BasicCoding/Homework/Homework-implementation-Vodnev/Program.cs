Console.Write("Введите количество продуктов: ");
int prodNumber = 0;
try
{
    prodNumber = int.Parse(Console.ReadLine());
}
catch (Exception)
{
    Console.WriteLine("Ошибка, введены некорректные данные");
    System.Environment.Exit(0);
}

var products = new Product[prodNumber];

try
{
    
    string name_input;
    double price_input;
    double weigth_input;
    for (int i = 0; i < products.Length; i++)
    {
        Console.Write($"Введите имя продукта #{i + 1}: ");
        name_input = Console.ReadLine();

        Console.Write($"Введите цену продукта #{i + 1} (в бел.руб.): ");
        price_input = double.Parse(Console.ReadLine());

        Console.Write($"Введите вес продукта #{i + 1} (в кг): ");
        weigth_input = double.Parse(Console.ReadLine());

        products[i] = new Product(name_input, price_input, weigth_input);
    }
}
catch (Exception)
{
    Console.WriteLine("Ошибка, введены некорректные данные");
    System.Environment.Exit(0);
}

Console.WriteLine("\n================= Вывод информации о продуктах: ================\n");

int номер_продукта = 0;
foreach (Product product in products)
{
    ++номер_продукта;
    product.Print(номер_продукта);
}

class Product
{
    private string name;
    private double price;
    private double weight;

    public Product(string name = "<нет данных>", double price = -1, double weight = -1)
    {
        this.name = name;
        this.price = price;
        this.weight = weight;
    }

    public void Print(int номер_продукта)
    {
        Console.WriteLine($"---Информация о продукте #{номер_продукта}: \nИмя: {name} \nЦена: {price} бел.руб. \nВес: {weight} кг");
    }
}