using System;

public class ATMAccount
{
    private const int MaxAmount = 100;

    // Should have history of operations

    public string CardNumber { get; }
    public int Ballance { get; private set; }

    public ATMAccount(string cardNumber)
    {     
        CardNumber = cardNumber;
        Ballance = 100;
    }

    public void WithdrawMoney(int amount)
    {
        if (Ballance < amount)
        {
            throw new InvalidOperationException("Недостаточно средств");
        }

        Ballance -= amount;
    }

    public void AddMoney(int amount)
    {
        if (amount > MaxAmount)
        {
            throw new InvalidOperationException("Превышен лимит пополнения");
        }

        Ballance += amount;
    }
}