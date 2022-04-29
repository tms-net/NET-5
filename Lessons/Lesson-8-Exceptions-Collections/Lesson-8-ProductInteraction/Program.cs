using System.Collections;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Console.WriteLine("Hello, %Username%! Put your card into ATM!");

string myCardNumber = null;

// Создание объекта, симулирующего действия пользователя
var client = new ATMClient();

client.InvalidOperation += message => Console.WriteLine($"Ошибка проведения операции: {message}");
client.ModifiedAccount += ballance => Console.WriteLine($"Ваша новый балланс: {ballance}");
client.ViewingAccount += ballance => Console.WriteLine($"Ваша балланс: {ballance}");

client.ModifyingAccount += args =>
{
    Console.WriteLine($"Введите кол-во денег для карточки {args.CardNumber}:");

    args.Amount = int.Parse(Console.ReadLine());
};

client.CardInserted += cardNumber =>
{
    myCardNumber = cardNumber;
    Console.WriteLine($"{cardNumber}.");
};

try
{
    client.DoRandomActions();
}
catch(Exception ex)
{
    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
}

Console.WriteLine($"Goodbye, you card {myCardNumber} was released!");