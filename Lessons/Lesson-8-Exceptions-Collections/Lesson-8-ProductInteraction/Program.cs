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

client.ViewingHistory += args =>
{
    (string command, string title, string name) GetOperationInfo(HistoryViewingEventArgs.HistoryOperation operation) => operation switch
    {
        HistoryViewingEventArgs.HistoryOperation.NotSpecified => ("", "Добро пожаловать", ""),
        HistoryViewingEventArgs.HistoryOperation.TransactionHistory => ("list", "История транзакций:", "посмотреть историю"),
        HistoryViewingEventArgs.HistoryOperation.NextTransactions => ("next", "", "следующие транзакции"),
        HistoryViewingEventArgs.HistoryOperation.GoBack => ("back", "", "назад"),
        HistoryViewingEventArgs.HistoryOperation.Quit => ("quit", "", "выйти"),
        _ => throw new NotSupportedException("Операция не поддерживается")
    };

    var currentOperationInfo = GetOperationInfo(args.CurrentOperation);

    if (!string.IsNullOrEmpty(currentOperationInfo.title))
    {
        Console.WriteLine(currentOperationInfo.title);
    }

    if (!string.IsNullOrEmpty(args.Data))
    {
        Console.WriteLine(string.Join("\n", args.Data));
    }

    Console.WriteLine($"\tВыберите операцию:");
    foreach (var operation in args.AllowedOperations)
    {
        var operationInfo = GetOperationInfo(operation);
        Console.WriteLine($"\t{operationInfo.command}: {operationInfo.name}");
    }
    
    args.NextOperation = Console.ReadLine() switch
    {
        "list" => HistoryViewingEventArgs.HistoryOperation.TransactionHistory,
        "next" => HistoryViewingEventArgs.HistoryOperation.NextTransactions,
        "back" => HistoryViewingEventArgs.HistoryOperation.GoBack,
        "quit" => HistoryViewingEventArgs.HistoryOperation.Quit,
        _ => throw new InvalidOperationException()
    };
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