// See https://aka.ms/new-console-template for more information
using System;
namespace MyApp
{
    public interface ITry<T>
    {
        public bool Try(T a);
    }
    internal class Program
    {
        public delegate T inByn<T, K>(K a);
        public static double FromDol(int a) => a * 0.3;
        public static double FromEur(int a) => a * 0.4;


        static void Main(string[] args)
        {
            inByn<double, int> byn, Byn;
            byn = FromDol;
            Byn = FromEur;
            string? size1, size2, size3, choice1;
            int size, size_2,size_3, choice;
            

                while (true)
                {
                Console.WriteLine("Введите 1 для создания собственного продукта");
                Console.WriteLine("Введите 2 для создания Овоща");
                Console.WriteLine("Введите 3 для создания Кросовок");
                    choice1 = Console.ReadLine();
                    if (!int.TryParse(choice1, out choice))
                    {
                        Console.WriteLine("Повторите ввод");
                    }
                    else break;
                }
                switch (choice)
                {
                    case 1:
                        {
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
                            product[i].Type = product1.Type;
                            Console.Clear();
                        }
                        for (int i = 0; i < product.Length; i++)
                        {
                            Console.WriteLine($"Тип продукта {product[i].Type}");
                            Console.Write($"{product[i].Name} ");
                            Console.WriteLine($"по {product[i].Cost} руб");
                            Console.WriteLine($"стоимость {product[i].Name} в Долларах {byn.Invoke(product[i].Cost)}");
                            Console.WriteLine($"стоимость {product[i].Name} в Евро {Byn.Invoke(product[i].Cost)}\n");
                        }
                        Console.ReadLine();
                        break;
                        }
                    case 2:
                        {
                        while (true)
                        {
                            Console.WriteLine("Введите размер массива");
                            size2 = Console.ReadLine();
                            int.TryParse(size2, out size_2);
                            if (size_2 > 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (size2 == "exit")
                            {
                                System.Environment.Exit(0);
                            }
                        }
                        Vegetable[] vegetable = new Vegetable[size_2];
                        Vegetable vegetable1 = new Vegetable();
                        for (int i = 0; i < vegetable.Length; i++)
                        {
                            vegetable1.create();
                            vegetable[i] = new Vegetable();
                            vegetable[i].Name = vegetable1.Name;
                            vegetable[i].Cost = vegetable1.Cost;
                            vegetable[i].Size = vegetable1.Size;
                            vegetable[i].Taste = vegetable1.Taste;
                            Console.Clear();
                                                       //System.Threading.Thread.Sleep(2000);
                            //Console.Clear();
                        }
                        for (int i = 0; i < vegetable.Length; i++)
                        {
                            Console.Write($"{vegetable[i].Name}");
                            Console.WriteLine($"по {vegetable[i].Cost} руб");
                            Console.WriteLine($"Кол-во {vegetable[i].Size}");
                            if (vegetable1.Try(vegetable[i].Taste) == true)
                            {
                                Console.Write($"Овщь свеж и готов к употреблению\n");
                            }
                            else Console.Write($"Мы заменим ваш испорченный овощь на свежий\n");
                            Console.WriteLine($"стоимость {vegetable[i].Name} в Долларах {byn.Invoke(vegetable[i].Cost)}");
                            Console.WriteLine($"стоимость {vegetable[i].Name} в Евро {Byn.Invoke(vegetable[i].Cost)}\n");
                        }
                        Console.ReadLine();    
                        break;
                        }
                    case 3:
                        {
                        while (true)
                        {
                            Console.WriteLine("Введите размер массива");
                            size3 = Console.ReadLine();
                            int.TryParse(size3, out size_3);
                            if (size_3 > 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (size3 == "exit")
                            {
                                System.Environment.Exit(0);
                            }
                        }
                        Sneakers[] sneakers = new Sneakers[size_3];
                        Sneakers Sneakers1 = new Sneakers();
                        for (int i = 0; i < sneakers.Length; i++)
                        {
                            Sneakers1.create();
                            sneakers[i] = new Sneakers();
                            sneakers[i].Name = Sneakers1.Name;
                            sneakers[i].Cost = Sneakers1.Cost;
                            sneakers[i].Size = Sneakers1.Size;
                            sneakers[i].Comfortable = Sneakers1.Comfortable;
                            Console.Clear();
                          
                        }
                        for (int i = 0; i < sneakers.Length; i++)
                        {
                            Console.Write($"{sneakers[i].Name}");
                            Console.WriteLine($"по {sneakers[i].Cost} руб");
                            Console.WriteLine($"Кол-во {sneakers[i].Size}");
                            if (Sneakers1.Try(sneakers[i].Comfortable))
                            {
                                Console.Write($"Кросовки удобные и их можно носить\n");
                            }
                            else Console.Write($"Мы заменим вам кросовки на более удобные\n");
                            Console.WriteLine($"стоимость {sneakers[i].Name} в Долларах {byn.Invoke(sneakers[i].Cost)}");
                            Console.WriteLine($"стоимость {sneakers[i].Name} в Евро {Byn.Invoke(sneakers[i].Cost)}\n");
                        }
                        Console.ReadLine();
                        break;
                        }
                    default:
                        {
                            Console.WriteLine("Не верно введены данные");
                            break;
                        }
                }
        }
    }


class Product
    {
        private string? _name;
        private int _cost;
        private int _size;
        private string? _type;
        public int Size { get { return _size; } set { _size = value; } }
        public string? Name { get { return _name; } set { _name = value; } }
        public int Cost { get { return _cost; } set { _cost = value; } }
        public string? Type { get { return _type; } set { _type = value; } }
        public Product()
        {
            Name = "Ничего";
            Cost = 0;
            Size = 0;
            Type = "None";
        }
        public Product(string Name, int Cost, int Size)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Size = Size;
        }
        public Product(string Name, int Cost,int Size,string Type)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Size = Size;
            this.Type = Type;
        }
        public  virtual void create()
        {
            string? cost1, size1;
            Console.WriteLine("Введите тип продукта");
            Type = Console.ReadLine();
            Console.WriteLine("Введите имя продукта");
            Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость продукта");
            while (true) { cost1 = Console.ReadLine(); 
                if (!int.TryParse(cost1, out _cost)) {
                    Console.WriteLine("Повторите ввод"); 
                } else  break;  
            }
            Console.WriteLine("Введите Кол-во продукта");
            while (true)
            {
                size1 = Console.ReadLine();
                if (!int.TryParse(size1, out _size))
                {
                    Console.WriteLine("Повторите ввод");
                }
                else break;
            }
        }
        
    }
    class Vegetable : Product, ITry<int>
    {
        private int _taste;
        public int Taste { get { return _taste; } set { _taste = value; } }
        public Vegetable()
        {
            Taste = 0;
        }
        public Vegetable(string Name, int Cost, int Size, int Taste):base(Name, Cost, Size)
        {
            this.Taste = Taste;
        }

        public bool Try(int a)
        {
            if (a >= 7)
            {
                return true;
            }
            else return false;

        }
        public override void create()
        {
            string? cost1, size1,taste1;
            Console.WriteLine("Введите название Овоща");
            Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость Овоща");
            cost1 = Console.ReadLine();
            Cost = int.Parse(cost1);
            Console.WriteLine("Введите Кол-во Овощей");
            size1 = Console.ReadLine();
            Size = int.Parse(size1);
            Console.WriteLine("На сколько свежие это овощи 0-10");
            while (true) {
                taste1 = Console.ReadLine();
                Taste = int.Parse(taste1);
                if (!(Taste < 0 && Taste > 10))
                {
                    break;
                }
                else Console.WriteLine("Повторите ввод");
            }

        }
    }
    class Sneakers : Product, ITry<string>
    {
        private string? _comfortable;
        public string? Comfortable { get { return _comfortable; } set { _comfortable = value; } }
        public Sneakers()
        {
            Comfortable = "None";
        }
        public Sneakers(string Name, int Cost, int Size, string Comfortable) : base(Name, Cost, Size)
        {
            this.Comfortable = Comfortable;
        }
        public bool Try(string? a)
        {
            if (a == "Да")
            {
                return true;
            }
            else return false;

        }
        public override void create()
        {
            string? cost1, size1;
            Console.WriteLine("Введите название кросовок");
            Name = Console.ReadLine();
            Console.WriteLine("Введите стоимость кросовок");
            cost1 = Console.ReadLine();
            Cost = int.Parse(cost1);
            Console.WriteLine("Введите Кол-во кросовок");
            size1 = Console.ReadLine();
            Size = int.Parse(size1);
            Console.WriteLine("Удобные ли это кросовки?");
            Comfortable = Console.ReadLine();
        }
    }
}