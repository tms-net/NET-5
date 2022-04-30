using System;

public class ATMAccount
{
    private const int MaxAmount = 100;

    // TODO: Создать возможность сохранять проведенные операции

    // TODO: Создать возможность получить проведенные операции

    public string CardNumber { get; }
    public int Ballance { get; private set; }

    public ATMAccount(string cardNumber)
    {     
        CardNumber = cardNumber;
        Ballance = 100;
    }

    public void WithdrawMoney(int amount)
    {
        // TODO: Записать операцию
        if (Ballance < amount)
        {
            throw new InvalidOperationException("Недостаточно средств");
        }

        Ballance -= amount;
    }

    public void AddMoney(int amount)
    {
        // TODO: Записать операцию
        if (amount > MaxAmount)
        {
            throw new InvalidOperationException("Превышен лимит пополнения");
        }

        Ballance += amount;
    }
}