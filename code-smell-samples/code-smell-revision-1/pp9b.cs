using System.Collections.Generic;
using Xunit;

public class ProfitCalculationTests
{
    private readonly ProfitCalculator _profitCalculator;
    private readonly TransactionRepository _repository;

    public ProfitCalculationTests()
    {
        _profitCalculator = new ProfitCalculator();
        _repository = new TransactionRepository();

        // The ProfitCalculator will use the same repository instance
        _profitCalculator.repo = _repository;
    }

    [Fact]
    public void ComputesAnnualProfit()
    {
        _repository.SaveTransactions(new List<Transaction>
            {
                new Transaction { Year = 2016, Month = 3, Day = 14, Price = 55.44, Cost = 80.30 },
                new Transaction { Year = 2016, Month = 6, Day = 20, Price = 9.33, Cost = 4.00 },
                new Transaction { Year = 2016, Month = 12, Day = 31, Price = 112.48, Cost = 100.24 },
                // Bad year:
                new Transaction { Year = 2015, Month = 3, Day = 14, Price = 999, Cost = 0 }
            });

        var result = _profitCalculator.AnnualProfit(2016);

        Assert.Equal(-8, result);

        _repository.Reset();
    }

    [Fact]
    public void ComputesMonthlyProfit()
    {
        _repository.SaveTransactions(new List<Transaction>
            {
                new Transaction { Year = 2016, Month = 5, Day = 1, Price = 108.99, Cost = 70.45 },
                new Transaction { Year = 2016, Month = 5, Day = 15, Price = 208.13, Cost = 133.55 },
                new Transaction { Year = 2016, Month = 5, Day = 31, Price = 90.00, Cost = 80.03 },
                // Bad month:
                new Transaction { Year = 2016, Month = 6, Day = 14, Price = 999, Cost = 0 }
            });

        var result = _profitCalculator.MonthlyProfit(2016, 5);

        Assert.Equal(124, result);

        _repository.Reset();
    }

    [Fact]
    public void ComputesDailyProfit()
    {
        _repository.SaveTransactions(new List<Transaction>
            {
                new Transaction { Year = 2016, Month = 5, Day = 12, Price = 19.44, Cost = 18.11 },
                new Transaction { Year = 2016, Month = 5, Day = 12, Price = 21.40, Cost = 22.01 },
                new Transaction { Year = 2016, Month = 5, Day = 12, Price = 998.10, Cost = 907.20 },
                // Bad day:
                new Transaction { Year = 2016, Month = 5, Day = 1, Price = 999, Cost = 0 }
            });

        var result = _profitCalculator.DailyProfit(2016, 5, 12);

        Assert.Equal(91, result);

        _repository.Reset();
    }

    [Fact]
    public void ComputesTransactionProfit()
    {
        var transaction = new Transaction { Price = 33.22, Cost = 20.11 };

        var result = _profitCalculator.TransactionProfit(transaction);

        Assert.Equal(13, result);
    }
}
