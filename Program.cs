using YahooFinanceApi;

class Program
{
    static async Task MainAsync()
    {
        Console.WriteLine("Welcome to the Stock Tracker!");
        Console.WriteLine("");
        Console.Write("To get started, enter the stock you would like to track: ");
        var ticker = Console.ReadLine().ToUpper();
        // You could query multiple symbols with multiple fields through the following steps:
        var securities = await Yahoo
            .Symbols(ticker)
            .Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh)
            .QueryAsync();
        // var aapl = securities["AAPL"][Field.RegularMarketPrice]; // or, you could use aapl.RegularMarketPrice directly for typed-value
        Console.WriteLine(securities[ticker][Field.FiftyTwoWeekHigh]);
    }

    static void Main()
    {
        Task.WaitAll(MainAsync());
    }
}
