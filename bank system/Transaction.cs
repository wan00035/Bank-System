using System;

// Transaction represents a single transaction performed on an account
public class Transaction
{
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Activity { get; set; }

    public Transaction(double amount, DateTime date, string activity)
    {
        Amount = amount;
        Date = date;
        Activity = activity;
    }
}

