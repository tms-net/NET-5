using System;
using System.Collections.Generic;
using System.Linq;
using static HistoryViewingEventArgs;

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
            _actions[_random.Next(3)]();
        }

        ViewHistory();
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
                    
                    if (!accountHistory.CurrentOperationArgs.IsValid())
                    {
                        throw new InvalidOperationException();
                    }
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
        private const int MaxHistoryOperations = 2;

        private readonly ATMAccount _account;

        private HistoryViewingEventArgs.HistoryOperation _currentOperation = default;
        private int _currentOperationListPageIndex = -1;

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
                _currentOperationListPageIndex = -1;
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

                var allowedOperations = new List<HistoryOperation>
                    {
                        HistoryViewingEventArgs.HistoryOperation.GoBack,
                        HistoryViewingEventArgs.HistoryOperation.Quit
                    };

                if (this._account.History.Count > MaxHistoryOperations)
                {
                    allowedOperations.Insert(0, HistoryViewingEventArgs.HistoryOperation.NextTransactions);
                    _currentOperationListPageIndex = 1;
                }

                #region UI flow
                // [1,2,3]

                // list -> операция 1
                // next -> операция 2
                // next -> операция 3
                // back, quit
                #endregion

                for (int i = 0; i < MaxHistoryOperations; i++)
                {
                    if (i < _account.History.Count)
                    {
                        var operation = _account.History[i];
                        data += "\nОперация номер " + (i + 1).ToString() + "\t\n" + operation.ToString();
                    }
                    
                }
                CurrentOperationArgs.Data = data;
                CurrentOperationArgs.AllowedOperations = allowedOperations.ToArray();
            }

            if (_currentOperation == HistoryViewingEventArgs.HistoryOperation.NextTransactions)
            {
                var data = "";
                var allowedOperations = new List<HistoryOperation>
                {
                    HistoryViewingEventArgs.HistoryOperation.GoBack,
                    HistoryViewingEventArgs.HistoryOperation.Quit
                };

                #region Paging example
                // items per page: 2 (Max)
                // page number
                //  [1,2, 3,4, 5] -> pageCount -> 5 % 2 = 1
                //i: 0,1  2,3, 4

                // 0:Max -> page 0 -> (pageIndex * Max: (pageIndex + 1) * Max - 1) -> (0 : 1)
                // 2:3   -> page 1 -> (pageIndex * Max: ???) -> (2 : 3)
                // 4     -> page 2 -> (pageIndex * Max: ???) -> (4 : 5)
                #endregion

                int pageIndex = this._currentOperationListPageIndex;

                int pageCount = _account.History.Count / MaxHistoryOperations; // 5 / 2 = 2

                if (pageIndex < pageCount)
                {

                    if (_account.History.Count % MaxHistoryOperations > 0)
                    {
                        pageCount++;
                    }

                    #region Operator examples
                    // i *= 2 -> i = i * 2

                    // i = 0;
                    // var j = i++; // j = 0; i = 1;
                    // var j = ++i; // j =  1; i = 1;

                    // page count: 2
                    // [1,2] 
                    // page 0 -> [0:0]
                    // page 1 -> [1:1]
                    #endregion

                    data = "Страница " + (pageIndex + 1) + ". Всего страниц " + pageCount;
                    for (int i = pageIndex * MaxHistoryOperations; i <= (pageIndex + 1) * MaxHistoryOperations - 1; i++)
                    {
                        if (i < _account.History.Count)
                        {
                            var operation = _account.History[i];
                            data += "\nОперация номер " + (i + 1).ToString() + "\t\n" + operation.ToString();
                        }
                    }

                    this._currentOperationListPageIndex++;

                    if (pageIndex < pageCount - 1)
                    {
                        allowedOperations.Insert(0, HistoryViewingEventArgs.HistoryOperation.NextTransactions);
                    }
                }
                else
                {
                    data = "Неверная страница"; 
                }
                CurrentOperationArgs.Data = data;
                CurrentOperationArgs.AllowedOperations = allowedOperations.ToArray();

            }

            if (_currentOperation == HistoryViewingEventArgs.HistoryOperation.GoBack)
            {
               
                var allowedOperations = new List<HistoryOperation>
                {
                    HistoryViewingEventArgs.HistoryOperation.NextTransactions,
                    HistoryViewingEventArgs.HistoryOperation.GoBack,
                    HistoryViewingEventArgs.HistoryOperation.Quit
                };
                int listCount = this._currentOperationListPageIndex - 2;

                int pageCount = _account.History.Count / MaxHistoryOperations; // 5 / 2 = 2

                if (_account.History.Count % MaxHistoryOperations > 0)
                {
                    pageCount++;
                }
                var data = "Страница " + (listCount+1) + ". Всего страниц " + pageCount;
                for (int i = listCount + listCount; i <= listCount * 2 + 1; i++)
                {
                    if (i < _account.History.Count)
                    {
                        var operation = _account.History[i];
                        data += "\nОперация номер " + (i + 1).ToString() + "\t\n" + operation.ToString();
                    }
                }
                CurrentOperationArgs.Data = data;
                CurrentOperationArgs.AllowedOperations = allowedOperations.ToArray();
                this._currentOperationListPageIndex--;
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

    internal bool IsValid() => AllowedOperations.Contains(NextOperation);

    public enum HistoryOperation
    {
        NotSpecified,
        TransactionHistory,
        NextTransactions,
        GoBack,
        Quit
    }
}