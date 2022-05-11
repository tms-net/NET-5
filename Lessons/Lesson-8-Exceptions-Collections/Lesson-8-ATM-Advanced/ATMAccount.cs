using System;
using System.Collections.Generic;

public class ATMAccount
{
    private const int MaxAmount = 100;
    public List<Operation> History { get; } = new List<Operation> ();
    public string CardNumber { get; }
    public int Ballance { get; private set; }
    public ATMAccount(string cardNumber)
    {
        CardNumber = cardNumber;
        Ballance = 100;
    }
    public void WithdrawMoney(int amount)
    {
        var operation = new Operation();
        try
        {
            if (Ballance < amount)
            {
                throw new InvalidOperationException("Недостаточно средств");
            }
            Ballance -= amount;
            operation.Result = OperationResult.Success;
        }
        catch (Exception)
        {
            operation.Result = OperationResult.Failure;
            throw;
        }
        finally
        {
            operation.Type = OperationType.Withdraw;
            operation.Balance = Ballance;
            History.Add(operation);
        }
    }
    public void AddMoney(int amount)
    {
        var operation = new Operation();
       
        try
        {
            if (amount > MaxAmount)
            {
                throw new InvalidOperationException("Превышен лимит пополнения");
            }

            Ballance += amount;
            operation.Result = OperationResult.Success;
        }
        catch (Exception)
        {
            operation.Result = OperationResult.Failure;
            throw;
        }
        finally
        {
            operation.Type = OperationType.Withdraw;
            operation.Balance = Ballance;
            History.Add(operation);
        }
    }
}
public class Operation
{
    public OperationType Type { get; set; }
    public int Balance { get; set; }
    public OperationResult Result { get; set; }
    public override string ToString()
    {
        return string.Format(
            "Балланс после операции: {0}, Тип операции: {1}, Результат: {2}",
            Balance, Type, Result);
    }
}

public enum OperationType
{
    Add,
    Withdraw
}
public enum OperationResult
{
    Success,
    Failure
}