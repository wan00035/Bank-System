using System;
using BankingSystem;

namespace Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();

            CheckingAccount checkingAccount = new CheckingAccount();
            SavingAccount savingAccount = new SavingAccount();

            int selection;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Select one of the following activities:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Account Activity Enquiry");
                Console.WriteLine("5. Balance Enquiry");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your selection (1 to 6): ");
                selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        // Deposit
                        Console.WriteLine("Select account (1 - Checking Account, 2 - Saving Account):");
                        int accountSelection = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Enter Amount:");
                        double depositAmount = double.Parse(Console.ReadLine());

                        if (accountSelection == 1)
                        {
                            checkingAccount.Deposit(depositAmount);
                            Console.WriteLine($"Deposit complete, account current balance: ${checkingAccount.Balance}");
                        }
                        else if (accountSelection == 2)
                        {
                            savingAccount.Deposit(depositAmount);
                            Console.WriteLine($"Deposit complete, account current balance: ${savingAccount.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid account selection.");
                        }
                        break;
                    case 2:
                        // Withdraw
                        Console.WriteLine("Select account (1 - Checking Account, 2 - Saving Account):");
                        accountSelection = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Amount:");
                        double withdrawAmount = double.Parse(Console.ReadLine());

                        if (accountSelection == 1)
                        {
                            if (checkingAccount.Withdraw(withdrawAmount))
                            {
                                Console.WriteLine($"Withdraw completed, account current balance: ${checkingAccount.Balance}");
                            }
                            else
                            {
                                Console.WriteLine($"Exceed the daily max withdraw amount ${CheckingAccount.DailyWithdrawLimit}");
                            }
                        }
                        else if (accountSelection == 2)
                        {
                            if (savingAccount.Withdraw(withdrawAmount))
                            {
                                Console.WriteLine($"Withdraw completed, account current balance: ${savingAccount.Balance}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient fund, account current balance: $" + savingAccount.Balance);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid account selection.");
                        }
                        break;
                    case 3:
                        // Transfer
                        Console.WriteLine("Select account (1 - from Checking to saving , 2 -from saving to checking):");
                        accountSelection = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Amount:");
                        double transferAmount = double.Parse(Console.ReadLine());

                        if (accountSelection == 1)
                        {
                            if (checkingAccount.Transfer(savingAccount, transferAmount))
                            {
                                Console.WriteLine("Transfer completed");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient fund, account current balance: $" + checkingAccount.Balance);
                            }
                        }
                        else if (accountSelection == 2)
                        {
                            if (savingAccount.Transfer(checkingAccount, transferAmount))
                            {
                                Console.WriteLine("Transfer completed");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient fund, account current balance: $" + savingAccount.Balance);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid account selection.");
                        }
                        break;

                    case 4:
                        // Account Activity Enquiry
                        Console.WriteLine("Checking Account:");
                        Console.WriteLine("Amount\t\tDate\t\tActivity");
                        foreach (Transaction transaction in checkingAccount.Transactions)
                        {
                            Console.WriteLine($"{transaction.Amount}\t\t{transaction.Date.ToShortDateString()}\t\t{transaction.Activity}");
                        }
                        Console.WriteLine("\nSaving Account:");
                        Console.WriteLine("Amount\t\tDate\t\tActivity");
                        foreach (Transaction transaction in savingAccount.Transactions)
                        {
                            Console.WriteLine($"{transaction.Amount}\t\t{transaction.Date.ToShortDateString()}\t\t{transaction.Activity}");
                        }
                        break;

                    case 5:
                        // Balance Enquiry
                        Console.WriteLine("Current balance:");
                        Console.WriteLine("Account                        Balance");
                        Console.WriteLine("—————————         —————————");
                        Console.WriteLine($"Checking                       ${checkingAccount.Balance}");
                        Console.WriteLine($"Saving                         ${savingAccount.Balance}");
                        break;

                    case 6:
                        Console.WriteLine("Thank you for using Algonquin Banking System!");
                        break;

                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            } while (selection != 6);
        }
    }
}
