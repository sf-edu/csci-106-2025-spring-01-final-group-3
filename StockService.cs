using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

public class StockService
{
    private static readonly HttpClient http = new HttpClient();

    public async Task<List<StockData>> GetStockData(string symbol)
    {
        string apiUrl = $"https://api.example.com/stock/{symbol}";
        var response = await http.GetFromJsonAsync<List<StockData>>(apiUrl);
        return response ?? new List<StockData>();
    }

    public ISeries[] GenerateChartSeries(List<StockData> data)
    {
        var prices = new LineSeries<decimal>
        {
            Values = data.ConvertAll(d => d.Close),
            Name = "Close Price",
            Fill = null,
            Stroke = new SKPaint { Color = SKColors.Blue, StrokeWidth = 2 }
        };

        return new ISeries[] { prices };
    }
}
