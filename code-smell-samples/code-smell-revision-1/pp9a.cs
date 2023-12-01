using System;
using System.Collections.Generic;
using System.Linq;

public class ProfitCalculator
{
    private TransactionRepository repo = new TransactionRepository();

    public int AnnualProfit(int year)
    {
        return Enumerable.Range(1, 12).Sum(month => MonthlyProfit(year, month));
    }

    public int MonthlyProfit(int year, int month)
    {

        return Enumerable.Range(1, 31).Sum(day => DailyProfit(year, month, day));
    }

    public int DailyProfit(int year, int month, int day)
    {
        var transactions = repo.Find(new { Year = year, Month = month, Day = day });
        return transactions.Sum(TransactionProfit);
    }

    private int TransactionProfit(Transaction transaction)
    {
        return (int)Math.Round(transaction.Price - transaction.Cost);
    }
}

public class Transaction
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public double Price { get; set; }
    public double Cost { get; set; }
}

public class TransactionRepository
{
    private List<Transaction> transactions = new List<Transaction>();

    public void Reset()
    {
        transactions.Clear();
    }

    public void SaveTransactions(IEnumerable<Transaction> transactionsToAdd)
    {
        transactions.AddRange(transactionsToAdd);
    }

    public IEnumerable<Transaction> Find(object criteria)
    {
        return transactions.Where(t =>
            t.Year == ((dynamic)criteria).Year &&
            t.Month == ((dynamic)criteria).Month &&
            t.Day == ((dynamic)criteria).Day);
    }
}

