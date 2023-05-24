using System;
using BankingSystem;

// SavingAccount represents a savings account in a bank
public class SavingAccount : Account
{
    public const double InterestRate = 0.03;


    // Overrides the Deposit function of the base Account class to add interest
    public override void Deposit(double amount)
    {
        base.Deposit(amount);
        double interest = amount * InterestRate;
        Balance += interest;
        Transactions.Add(new Transaction(interest, DateTime.Now, "DEPOSIT: Interest"));
    }

    public override bool Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Transactions.Add(new Transaction(amount, DateTime.Now, "WITHDRAW"));
            Balance -= PenaltyAmount;
            Transactions.Add(new Transaction(PenaltyAmount, DateTime.Now, "Penalty"));
            return true;
        }
        return false;
    }

}
