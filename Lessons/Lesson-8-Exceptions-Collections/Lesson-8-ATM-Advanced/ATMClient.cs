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
        _actions = new Action[] { ViewAccount, ViewHistory, WithdrawMoney, InsertMoney };
    }

    public Action<string, int> modifyingAccount;

    public event Action<string> CardInserted;
    public event Action<int> ViewingAccount;
    public event Action<HistoryViewingEventArgs> ViewingHistory;
    public event Action<AccountModifyingEventArgs> ModifyingAccount;
    public event Action<int> ModifiedAccount;
    public event Action<string> InvalidOperation;

    public void DoRandomActions()
    {
        InsertCard();

        var numberOfActions = _random.Next(5, 10);
        for (int i = 0; i < numberOfActions; i++)
        {
            _actions[_random.Next(4)]();
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

    private void ViewHistory()
    {
        if (ViewingHistory != null)
        {
            var accountHistory = new AccountHistoryStateMachine(this._account);
            try
            {
                while (accountHistory.NextOperation())
                {
                    ViewingHistory.Invoke(accountHistory.CurrentOperationArgs);
                }
            }
            catch (InvalidOperationException ex)
            {
                InvalidOperation?.Invoke(ex.Message);
            }
        }
    }

    private class AccountHistoryStateMachine
    {

        private HistoryViewingEventArgs.HistoryOperation _currentOperation = default;
        private ATMAccount _account;

        public AccountHistoryStateMachine(ATMAccount account)
        {
            this._account = account;
        }

        internal HistoryViewingEventArgs CurrentOperationArgs { get; private set; }

        internal bool NextOperation()
        {
            if (CurrentOperationArgs != null)
            {
                _currentOperation = CurrentOperationArgs.NextOperation;
            }

            if (_currentOperation == HistoryViewingEventArgs.HistoryOperation.Quit)
            {
                return false;
            }

            if (_currentOperation == HistoryViewingEventArgs.HistoryOperation.NotSpecified)
            {
                CurrentOperationArgs = new HistoryViewingEventArgs
                {
                    AllowedOperations = new[] 
                    {
                        HistoryViewingEventArgs.HistoryOperation.TransactionHistory,
                        HistoryViewingEventArgs.HistoryOperation.Quit
                    }
                };
            }

            if (_currentOperation == HistoryViewingEventArgs.HistoryOperation.TransactionHistory)
            {
                var data = "Всего оппераций " + this._account.History.Count.ToString();
                
                for (int i = 0; i < 5; i++)
                {
                    if (i < _account.History.Count)
                    {
                        var operation = _account.History[i];
                        data += "\nОперация номер " + (i + 1).ToString() + "\t\n" + operation.ToString();
                    }
                    
                }
                CurrentOperationArgs.Data = data; // TODO: Заполнить данными о 5 первых операциях
                CurrentOperationArgs.AllowedOperations = new[]
                {
                    HistoryViewingEventArgs.HistoryOperation.NextTransactions, // TODO: Проверить доступна ли операция
                    HistoryViewingEventArgs.HistoryOperation.GoBack,
                    HistoryViewingEventArgs.HistoryOperation.Quit
                };
            }

            if (_currentOperation == HistoryViewingEventArgs.HistoryOperation.NextTransactions)
            {
                CurrentOperationArgs.Data = "next transactions"; // TODO: Заполнить данными о 5 следующих операциях
                CurrentOperationArgs.AllowedOperations = new[]
                {
                    HistoryViewingEventArgs.HistoryOperation.NextTransactions, // TODO: Проверить доступна ли операция
                    HistoryViewingEventArgs.HistoryOperation.GoBack,
                    HistoryViewingEventArgs.HistoryOperation.Quit
                };
            }

            CurrentOperationArgs.CurrentOperation = _currentOperation;

            return true;
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

public class HistoryViewingEventArgs
{
    public string Data { get; internal set; }
    public HistoryOperation[] AllowedOperations { get; internal set; }
    public HistoryOperation CurrentOperation { get; internal set; }
    public HistoryOperation NextOperation { get; set; }

    public enum HistoryOperation
    {
        NotSpecified,
        TransactionHistory,
        NextTransactions,
        GoBack,
        Quit
    }
}