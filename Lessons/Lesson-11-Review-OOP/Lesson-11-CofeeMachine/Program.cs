// See https://aka.ms/new-console-template for more information
using Lesson_11_CofeeMachine;
using System;

Console.WriteLine("Hello, %Username%!");

//var coffeeMachine = new CoffeeMachine();

Console.WriteLine("Выберите напиток:");
Console.WriteLine("1 - Espresso");
Console.WriteLine("2 - Americano");
Console.WriteLine("3 - Cappuccino");
//foreach (var drinks in CoffeeMachine.drink)
//{
//    Console.WriteLine(drinks);
//}
//foreach (var drink in coffeeMachine.GetAvailableDrinks()) 
//{
//    Console.WriteLine(drink);
//}
string userDrink = Console.ReadLine();

// TODO: Обработать выбор пользователя и использовать объект CoffeeMachine
// для приготовления напитка, вывести информацию о приготовленном напитке.


CoffeeMachine espresso = new CoffeeMachine();
{
    espresso.name = "Espresso";
    espresso.gramsOfCoffee = 8;
    espresso.gramsOfWater = 30;
    espresso.gramsOfMilk = 0;
}

CoffeeMachine americano = new CoffeeMachine();
{
    americano.name = "Americano";
    americano.gramsOfCoffee = 8;
    americano.gramsOfWater = 150;
    americano.gramsOfMilk = 0;
}
CoffeeMachine cappuccino = new CoffeeMachine();
{
    cappuccino.name = "Cappuccino";
    cappuccino.gramsOfCoffee = 10;
    cappuccino.gramsOfWater = 30;
    cappuccino.gramsOfMilk = 200;
}

switch (userDrink)
{
    case "1":
        espresso.GetInfo();
        break;
    case "2":
        americano.GetInfo();
        break;
    case "3":
        cappuccino.GetInfo();
        break;
    default:
        Console.WriteLine("Нет такого напитка");
        break;
}
