// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? size1;
            int size;
            while (true)
            {
                Console.WriteLine("Введите размер массива");
                size1 = Console.ReadLine();
                int.TryParse(size1, out size);
                if (size > 0)
                {
                    Console.Clear();
                    break;
                }
                else if (size1 == "exit")
                {
                    System.Environment.Exit(0);
                }
            }
            Product[] product = new Product[size];
            Product product1 = new Product();
            for (int i = 0; i < product.Length; i++)
            {
                product1.create();
                product[i] = new Product();
                product[i].Name = product1.Name;
                product[i].Cost = product1.Cost;
                Console.Clear();
            }
            for (int i = 0; i < product.Length; i++)
            {
                Console.Write($"{product[i].Name} ");
                Console.WriteLine($"по {product[i].Cost} руб\n");
            }
            Console.ReadLine();
                }
            }

        
    class Product
    {
        public string? Name;
        public string? Cost;

        public Product()
        {
            Name = "Ничего";
            Cost = "Ybxtuj";
        }
        public Product(string Name, string Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }
        public void create()
        {
            Console.WriteLine("Введите имя продукта");
            Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость продукта");
            Cost = Console.ReadLine();

        }
    }
}
