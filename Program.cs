using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
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
            .Fields(
                Field.Symbol,
                Field.RegularMarketPrice,
                Field.RegularMarketPreviousClose,
                Field.RegularMarketOpen,
                Field.FiftyTwoWeekHigh,
                Field.FiftyTwoWeekLow,
                Field.RegularMarketChangePercent,
                Field.RegularMarketDayLow,
                Field.MarketCap,
                Field.PriceToBook,
                Field.LongName
            )
            .QueryAsync();
        // var aapl = securities["AAPL"][Field.RegularMarketPrice]; // or, you could use aapl.RegularMarketPrice directly for typed-value
        Yahoo.IgnoreEmptyRows = true;
        Console.WriteLine(" ");
        Console.WriteLine("\x1b[1m" + securities[ticker][Field.LongName] + "\x1b[0m");

        Console.WriteLine(
            "Previous Day Close: " + securities[ticker][Field.RegularMarketPreviousClose]
        );
        Console.WriteLine("Opening Number: " + securities[ticker][Field.RegularMarketOpen]);
        Console.WriteLine(" ");
        Console.WriteLine("\x1b[1mDAILY VALUES\x1b[0m");
        Console.WriteLine(" ");
        Console.WriteLine("Regular Market Price: " + securities[ticker][Field.RegularMarketPrice]);
        Console.WriteLine("Daily High: " + securities[ticker][Field.RegularMarketDayHigh]);
        Console.WriteLine("Daily Low: " + securities[ticker][Field.RegularMarketDayLow]);
        Console.WriteLine(
            "Daily Percent Chnage: " + securities[ticker][Field.RegularMarketChangePercent]
        );
        Console.WriteLine(" ");
        Console.WriteLine("\x1b[1mHISTORIC VALUES\x1b[0m");
        Console.WriteLine(" ");
        Console.WriteLine("Market Cap: " + securities[ticker][Field.MarketCap]);
        Console.WriteLine("Price/Book Ratio: " + securities[ticker][Field.PriceToBook]);
        Console.WriteLine("Fifty Two Week High: " + securities[ticker][Field.FiftyTwoWeekHigh]);
        Console.WriteLine("Fifty Two Week Low: " + securities[ticker][Field.FiftyTwoWeekLow]);
        Console.WriteLine();
        Console.Write("Track another stock? [Y]/[N]: ");
        var repeat = Console.ReadKey().Key;
        if (repeat == ConsoleKey.Y)
        {
            Console.WriteLine(" ");
            await MainAsync();
        }
        else
        {
            return;
        }
    }

    static void Main()
    {
        Task.WaitAll(MainAsync());
    }
}
