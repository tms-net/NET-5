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
            operation.Result = ResultType.Good;
        }
        catch (Exception)
        {
            operation.Result = ResultType.Bad;
            throw;
        }
        finally
        {
            operation.Type = OperationType.WithDrow;
            operation.Ballance = Ballance;
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
            operation.Result = ResultType.Good;
        }
        catch (Exception)
        {
            operation.Result = ResultType.Bad;
            throw;
        }
        finally
        {
            operation.Type = OperationType.WithDrow;
            operation.Ballance = Ballance;
            History.Add(operation);
        }
    }
}
public class Operation
{
    public OperationType Type { get; set; }
    public int Ballance { get; set; }
    public ResultType Result { get; set; }
    public override string ToString()
    {
        string data; 
        data = "" + this.Ballance +" "+ this.Result + " " + this.Type;
        return data;
     
    }

}

public enum OperationType
{
    Add,
    WithDrow
}
public enum ResultType
{
    Good,
    Bad
}