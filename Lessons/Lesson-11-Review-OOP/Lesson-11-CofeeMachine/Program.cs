using Lesson_11_CofeeMachine;
using System;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Console.WriteLine("Hello, %Username%!");



var espresso = new Drink();
espresso.name = "Espresso";
espresso.gramsOfCoffee = 8;
espresso.gramsOfWater = 30;
espresso.gramsOfMilk = 0;

var americano = new Drink
{
    name = "Americano",
    gramsOfCoffee = 8,
    gramsOfWater = 150,
};

var cappuccino = new Drink();
cappuccino.name = "Cappuccino";
cappuccino.gramsOfCoffee = 10;
cappuccino.gramsOfWater = 30;
cappuccino.gramsOfMilk = 200;

var drinks = new Drink[]
{
    espresso, americano, cappuccino
};

var cofeeMachine = new CoffeeMachine(drinks);

//var coffeeMachine = new CoffeeMachine();

Console.WriteLine("Выберите напиток:");

//Console.WriteLine("1 - Espresso");
//Console.WriteLine("2 - Americano");
//Console.WriteLine("3 - Cappuccino");

//foreach (var drinks in CoffeeMachine.drink)
//{
//    Console.WriteLine(drinks);
//}
//foreach (var drink in coffeeMachine.GetAvailableDrinks()) 
//{
//    Console.WriteLine(drink);
//}


var index = 0;
foreach (var drink in cofeeMachine.GetAvailableDrinks())
{
    Console.WriteLine(++index + " - " + drink);
    // 1 - espresso
    // 2 - americano   
    // 3 - cappuccino   
}

string userDrink = Console.ReadLine();

cofeeMachine.PrepareDrink(userDrink);

//switch (userDrink)
//{
//    case "1":
//        espresso.GetInfo();
//        break;
//    case "2":
//        americano.GetInfo();
//        break;
//    case "3":
//        cappuccino.GetInfo();
//        break;
//    default:
//        Console.WriteLine("Нет такого напитка");
//        break;
//}