using System;
using System.Collections.Generic;

namespace BankingSystem
{
    // Account is a base class representing a bank account
    public abstract class Account
    {
        public double Balance { get; protected set; }
        public List<Transaction> Transactions { get; }
        public static double PenaltyAmount { get; } = 10;

        public Account()
        {
            Transactions = new List<Transaction>();
        }

        // Virtual function for depositing money into the account
        public virtual void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction(amount, DateTime.Now, "DEPOSIT"));
        }

        // Virtual function for withdrawing money from the account
        public virtual bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Transactions.Add(new Transaction(amount, DateTime.Now, "WITHDRAW"));
                return true;
            }
            return false;
        }

        // Virtual function for withdrawing money from the account
        public virtual bool Transfer(Account destination, double amount)
        {

            if (Balance >= amount)
            {
                Balance -= amount;
                if (this is SavingAccount && destination is CheckingAccount)
                {
                    Balance -= PenaltyAmount;
                    Transactions.Add(new Transaction(PenaltyAmount, DateTime.Now, "Penalty"));
                }
                Transactions.Add(new Transaction(amount, DateTime.Now, "TRANSFER: Transfer out"));
                destination.Balance += amount;
                destination.Transactions.Add(new Transaction(amount, DateTime.Now, "TRANSFER: Transfer in"));
                return true;
            }
            return false;
        }



    }




    



    

}