using System;
using System.Collections.Generic;

public static class StockReport
{
    public static string GenerateSummary(List<StockData> data)
    {
        if (data.Count < 2) return "Insufficient data.";

        var latest = data[^1];
        var previous = data[^2];
        var change = latest.Close - previous.Close;
        var percent = change / previous.Close * 100;

        return $@"
Stock Summary for {latest.Date:yyyy-MM-dd}:
------------------------------------------
Open:   {latest.Open}
Close:  {latest.Close}
High:   {latest.High}
Low:    {latest.Low}
Volume: {latest.Volume}
Change: {change:F2} ({percent:F2}%)
";
    }
}
