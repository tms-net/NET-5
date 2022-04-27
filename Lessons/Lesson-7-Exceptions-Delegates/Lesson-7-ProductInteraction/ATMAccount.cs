public class ATMAccount
{
    public string CardNumber { get; }

    public ATMAccount(string cardNumber)
    {
        CardNumber = cardNumber;
    }

    internal void WithdrawMoney(int amount)
    {
        throw new NotImplementedException();
    }
}