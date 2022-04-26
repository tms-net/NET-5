using Vuvod;


Vuvuda [] Products = new Vuvuda[15];
var namB = 0;
var namC = 0;
for (int i = 0; i < 15; i++)
{
    Console.WriteLine("Введите название товара или для завершения введите 999");
    string proN = Console.ReadLine();
    if ( proN == "999")
    {
        break;
    }
    Console.WriteLine("Введите цвет товара");
    string proC = Console.ReadLine();
    Console.WriteLine("Введите отличительную особбеность ");
    string proY = Console.ReadLine();
    var prod = new Vuvuda { pron = proN, proc = proC, proy = proY};
    Products [i]= prod;
    namB=i; // количество записей
    namC = namB + 1; // количество итог запись
    Console.WriteLine("Всего позиций " +  namC);
}
while (true)
{
    Console.WriteLine("Введите позицию для просмотра");
    var v = Console.ReadLine();
    int b;
    if (int.TryParse(v, out b))
    {
        Products[b - 1].MMM();

    }
    else 
    {
        break;
    }
    
}
for (int i = 0; i <namB ; i++)
    {
        Products[i].MMM();
        
    }





