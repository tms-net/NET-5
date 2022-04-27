// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, %Username%! Put your card into ATM!");

string cardNumber = null;

// Создание объекта, симулирующего действия пользователя
var client = new ATMClient();

client.DoRandomActions();

Console.WriteLine($"Goodbye, you card {cardNumber} was released!");




