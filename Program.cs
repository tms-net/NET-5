using System;

namespace s
{
    class Program
    {
        static void Main(string[] args)
        {
            Name name = new Name();

            Console.WriteLine("Введите name:");
            name.name_value = Console.ReadLine();

            Price price = new Price();

            Console.WriteLine("Введите price:");
            price.price_value = int.Parse(Console.ReadLine());

            Count count = new Count();

            Console.WriteLine("Введите count:");
            count.count_value = int.Parse(Console.ReadLine());

            void ShowProduct()
            {
                Console.WriteLine($"Имя: {name.name_value}  цена: {price.price_value}  Кол-во: {count.count_value}");
            }
            
            ShowProduct();


            ReklamaInfo obj = new ReklamaInfo(reklama: "Здесь могла быть ваша реклама");
            obj.WriteReklamaInfo();
        }



    }
    interface IReklama
        {
            void WriteReklama();
        }


    class ReklamaInfo : IReklama
    {
        string reklama;

        public ReklamaInfo(string reklama)
        {
            this.reklama = reklama;
        }

        void IReklama.WriteReklama()
            {
                Console.WriteLine(reklama);
            }

        public void WriteReklamaInfo()
            {
            ReklamaInfo obj = new ReklamaInfo(reklama);

            IReklama link1 = (IReklama)obj;
            link1.WriteReklama();
             }
    }






    public class Price
    {
        public int price;
        public int price_value
        {
            get { return price; }
            set
            {
                if (value > 0)
                {

                    price = value;
                    Console.WriteLine("Значение записано");
                }
                else
                {
                    throw new Exception("Цена должна быть больше нуля");
                }
            }
        }
    }

    public class Name
    {
        public string name;
        public string name_value
        {
            get { return name; }
            set
            {
                if (value != "")
                {
                    name = value;
                    Console.WriteLine("Значение записано");

                }
                else
                {
                    throw new Exception("Введите имя");
                }
            }
        }
    }
    public class Count
    {
        public int count;
        public int count_value
        {
            get { return count; }
            set
            {
                if (value >= 0)
                {
                    count = value;
                    Console.WriteLine("Значение записано");

                }
                else
                {
                    throw new Exception("Введите количество");
                }
            }
        }
    }
}