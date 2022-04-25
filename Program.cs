using System;
namespace Sinks;
class Sink


{

    public string Title;
    public int Length;
    public int Width;
    public int Depth;
    public void Print()
    {
        Console.WriteLine($"Название мойки {Title}");
        Console.WriteLine($"Длина мойки {Length}");
        Console.WriteLine($"Ширина мойки {Width}");
        Console.WriteLine($"Глубина мойки {Depth}");


    }

}
class MainClass
{
    public static void Main(string[] args)
    {

        {
            Sink[] sinks = new Sink[20];
            int number = 0;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Введите название мойки или завершить");
                string title = Console.ReadLine();
                if (title == "завершить") break;
                Console.WriteLine("Введите длину мойки");
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите ширину мойки");
                int width = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите глубину мойки");
                int depth = int.Parse(Console.ReadLine());
                Sink sink = new Sink
                {
                    Title = title,
                    Length = length,
                    Width = width,
                    Depth = depth
                };
                sinks[i] = sink;
                number = i;
            }

            for (int i = 0; i <= number; i++)
            {
                sinks[i].Print();
            }
            Console.ReadKey();

        }

    }
}





 

