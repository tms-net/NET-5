/// <summary>
/// Класс для эмуляции поведения пользователя банкомата.
/// </summary>
public class ATMClient
{
    private readonly Random _random;
    private readonly Action[] _actions;

    private ATMAccount _account;

    public ATMClient()
    {
        _random = new Random();
        _actions = new[] { ViewAccount, WithdrawMoney, InsertMoney };
    }

    public event Action<string> CardInserted;
    public event Action<int> ViewingAccount;
    public event Action<(int, string)> ModifyingAccount;

    public void DoRandomActions()
    {
        InsertCard();

        var numberOfActions = _random.Next(10);
        for (int i = 0; i < numberOfActions; i++)
        {
            _actions[_random.Next(3)]();
        }
    }

    private void InsertCard()
    {
        _account = new ATMAccount(Guid.NewGuid().ToString());

        CardInserted?.Invoke(_account.CardNumber);
    }

    private void ViewAccount()
    {
        // TODO: Использовать событие ViewingAccount для возможности просмотра балланса пользователем.
    }

    private void WithdrawMoney()
    {
        _account.WithdrawMoney(_random.Next(100));

        // TODO: Создать событие для связи с интерфейсом пользователя, чтобы отобразить балланс после снятия
    }

    private void InsertMoney()
    {
        var insertArguments = (amount: 0, card: _account.CardNumber);

        ModifyingAccount?.Invoke(insertArguments);

        // TODO: реализовать получение нужного количества денег от пользователя
        // TODOL реализовать возможноить изменения балланса.
    }
}