// See https://aka.ms/new-console-template for more information
using Lesson_11_CofeeMachine;
using System;

Console.WriteLine("Hello, %Username%!");

var espresso = new Drink("Espresso");
espresso.gramsOfCoffee = 8;
espresso.gramsOfWater = 30;
espresso.gramsOfMilk = 0;

var americano = new Drink("Americano")
{
    gramsOfCoffee = 8,
    gramsOfWater = 150,
};

var cappuccino = new Drink("Cappuccino");
cappuccino.gramsOfCoffee = 10;
cappuccino.gramsOfWater = 30;
cappuccino.gramsOfMilk = 200;

var drinks = new Drink[]
{
    espresso, americano, cappuccino
};

var cofeeMachine = new CoffeeMachine(drinks);

cofeeMachine.AddWater(100);
cofeeMachine.AddCoffee(500);
cofeeMachine.AddMilk(300);

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


while (true)
{
    var index = 0;
    foreach (var drink in cofeeMachine.GetAvailableDrinks())
    {
        Console.WriteLine(++index + " - " + drink);
        // 1 - espresso
        // 2 - americano   
        // 3 - cappuccino   
    }

    string userDrink = Console.ReadLine();

    if (userDrink == "exit")
    {
        break;
    }

    cofeeMachine.PrepareDrink(userDrink);
}

