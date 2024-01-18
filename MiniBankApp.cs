using System;
using System.Collections.Generic;
using System.Linq;

class BankAccount
{
    public string AccountNumber { get; }
    public double Balance { get; private set; }
    public string Owner { get; }

    private List<string> transactionHistory;

    public BankAccount(string accountNumber, string owner)
    {
        this.AccountNumber = accountNumber;
        this.Balance = 0.0;
        this.Owner = owner;
        this.transactionHistory = new List<string>();
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            this.Balance += amount;
            string transaction = $"Einzahlung: +{amount:C}, Neuer Kontostand: {this.Balance:C}";
            this.transactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine("Ungültiger Betrag für Einzahlung.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= this.Balance)
        {
            this.Balance -= amount;
            string transaction = $"Abhebung: -{amount:C}, Neuer Kontostand: {this.Balance:C}";
            this.transactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine("Ungültiger Betrag für Abhebung oder nicht ausreichendes Guthaben.");
        }
    }

    public void ShowTransactionHistory()
    {
        Console.WriteLine($"Transaktionshistorie für Konto {this.AccountNumber} ({this.Owner}):");
        foreach (var transaction in this.transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}

class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>();

        BankAccount account1 = new BankAccount("3400-1433", "Max Mustermann");
        BankAccount account2 = new BankAccount("3400-1555", "Erika Musterfrau");

        accounts.Add(account1);
        accounts.Add(account2);

        // Suche nach einem Bankkonto
        Console.Write("Geben Sie die Kontonummer ein, um nach einem Konto zu suchen: ");
        string searchAccountNumber = Console.ReadLine();

        BankAccount foundAccount = accounts.FirstOrDefault(account => account.AccountNumber == searchAccountNumber);

        if (foundAccount != null)
        {
            // Einzahlung und Abhebung für das gefundene Konto
            foundAccount.Deposit(1000);
            foundAccount.Withdraw(500);

            // Anzeige des Kontostands und der Transaktionshistorie für das gefundene Konto
            Console.WriteLine($"Kontostand für Konto {foundAccount.AccountNumber} ({foundAccount.Owner}): {foundAccount.Balance:C}");
            foundAccount.ShowTransactionHistory();
        }
        else
        {
            Console.WriteLine("Konto nicht gefunden.");
        }
    }
}
