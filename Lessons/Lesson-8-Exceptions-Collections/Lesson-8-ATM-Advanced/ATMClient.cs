using System;

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
        _actions = new Action[] { ViewAccount, WithdrawMoney, InsertMoney };
    }

    public Action<string, int> modifyingAccount;

    public event Action<string> CardInserted;
    public event Action<int> ViewingAccount;
    public event Action<AccountModifyingEventArgs> ModifyingAccount;
    public event Action<int> ModifiedAccount;
    public event Action<string> InvalidOperation;

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
        ViewingAccount?.Invoke(_account.Ballance);
    }

    private void WithdrawMoney()
    {
        try
        {
            _account.WithdrawMoney(_random.Next(100));
        }
        catch(InvalidOperationException ex)
        {
            InvalidOperation?.Invoke(ex.Message);
        }

        ModifiedAccount?.Invoke(_account.Ballance);
    }

    private void InsertMoney()
    {
        if (ModifyingAccount != null)
        {
            try
            {
                var eventArgs = new AccountModifyingEventArgs(_account.CardNumber);
                
                ModifyingAccount.Invoke(eventArgs);

                _account.AddMoney(eventArgs.Amount);

                ModifiedAccount?.Invoke(_account.Ballance);
            }
            catch (InvalidOperationException ex)
            {
                InvalidOperation?.Invoke(ex.Message);
            }
        }
    }

    public class AccountModifyingEventArgs
    {
        public AccountModifyingEventArgs(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        public int Amount { get; set; }
        public string CardNumber { get; }
    }
}