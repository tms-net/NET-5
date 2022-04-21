using System;
using System.Collections.Generic;

namespace УчетПродуктовТорговойКомпании
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Введите количество товаров: ");
            var objectCount = int.Parse(Console.ReadLine());
            var list = new List<Product>();
            for(int i = 0; i < objectCount; i++)
            {
                Console.WriteLine("Введите занчение для товора " + (i+1));
                list.Add(new Product(Console.ReadLine(), int.Parse(Console.ReadLine())));
            }
            Console.WriteLine("Товары: ");
            
            foreach(var item in list)
            {
                Console.WriteLine(String.Format("Имя: {0}, Цена: {1}", item.name, item.price));
                
            }
        }
        public class Product
        {
            public string name;
            public int price;

            public Product(string name, int price)
            {
                this.price = price;
                this.name = name;
            }
        }
        

    }
        

}
   

