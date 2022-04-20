// See https://aka.ms/new-console-template for more information
using System;
namespace MyApp 
{
    internal class Program
    {
        public delegate double inByn(int a);
        static public double fromDol(int a) => a * 0.3;
        static public double fromEur(int a) => a * 0.4; 
        static void Main(string[] args)
        {
            inByn byn,Byn;
            byn = fromDol;
            Byn = fromEur;  
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
            Product a = new Product();
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
                Console.WriteLine($"по {product[i].Cost} руб");
                Console.WriteLine($"стоимость {product[i].Name} в Долларах {byn(product[i].Cost)}");
                Console.WriteLine($"стоимость {product[i].Name} в Евро {Byn(product[i].Cost)}\n");
            }
            Console.ReadLine();
                }
            }

        
    class Product
    {
        public string? Name;
        public int Cost;

        public Product()
        {
            Name = "Ничего";
            Cost = 0;
        }
        public Product(string Name, int Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }
        public void create()
        {
            string? name;
            Console.WriteLine("Введите имя продукта");
            Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость продукта");
            int.TryParse(name = Console.ReadLine(), out Cost);
        }
    }
}
