// See https://aka.ms/new-console-template for more information
using Lesson_11_CofeeMachine;
using System;

Console.WriteLine("Hello, %Username%!");

var cofeeMachine = new CofeeMachine();

Console.WriteLine("Выберите напиток:");

foreach (var drink in cofeeMachine.GetAvailableDrinks()) 
{
    Console.WriteLine(drink);
}

// TODO: Обработать выбор пользователя и использовать объект CofeeMachine
// для приготовления напитка, вывести информацию о приготовленном напитке.


