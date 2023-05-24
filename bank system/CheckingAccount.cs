using System;
using BankingSystem;


// CheckingAccount represents a checking account in a bank
public class CheckingAccount : Account
{
    public const double DailyWithdrawLimit = 300;
    private double DailyWithdrawAmount { get; set; }
    private DateTime LastWithdrawDate { get; set; }

    public CheckingAccount()
    {
        DailyWithdrawAmount = 0;
        LastWithdrawDate = DateTime.MinValue;
    }

    // Overrides the Withdraw function of the base Account class to consider a daily withdraw limit
    public override bool Withdraw(double amount)
    {
        DateTime today = DateTime.Today;

        if (LastWithdrawDate != today)
        {
            LastWithdrawDate = today;
            DailyWithdrawAmount = 0;
        }

        if (DailyWithdrawAmount + amount <= DailyWithdrawLimit)
        {
            if (base.Withdraw(amount))
            {
                DailyWithdrawAmount += amount;
                return true;
            }
        }

        return false;
    }
}