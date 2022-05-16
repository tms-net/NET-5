Console.Write("Количество товаров: ");
//создание массива типа Product
int qtyProduct = int.Parse(Console.ReadLine());
Product[] productArray = new Product [qtyProduct];

for (int i = 0; i < productArray.Length; i++)
{
    int equationIndex = i + 1;
    productArray[i] = new Product();

    Console.Write($"Название товара №{equationIndex}: Name {equationIndex}") ;
    productArray[i].name = "Name" + equationIndex; 
    Console.WriteLine();//Console.ReadLine();
    Console.Write($"Цена товара №{equationIndex}    : ");
    productArray[i].price = 10 + equationIndex; 
    Console.WriteLine();//int.Parse(Console.ReadLine());
    Console.Write($"Тип товара №{equationIndex}     : Type {equationIndex}");
    productArray[i].type = "Type" + equationIndex;
    Console.WriteLine();//Console.ReadLine();
    Console.WriteLine("----------------------------------------------");
}
Print();

    void Print()
{
    for (int i = 0; i < productArray.Length; i++)
    {
        int equationIndex = i + 1;
        Product product = productArray[i];
        Console.WriteLine("----------------------------------------------");
        Console.Write($"Название №{equationIndex}: {product.name}\n" +
                      $"    Цена №{equationIndex}: {product.price}\n" +
                      $"     Тип №{equationIndex}: {product.type}\n");
    }
}


public class Product
{
    public string name = "Nothing";
    public int price = 0;
    public string type = "For All";

}
