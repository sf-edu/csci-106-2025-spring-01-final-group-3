using System;
using System.Threading.Tasks;
using System.Timers;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore;
using System.Windows.Forms;
"///"
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http.Headers;

class Program
{
    static StockService stockService = new StockService();
    static CartesianChart chart = new CartesianChart();
    static Timer timer;

    [STAThread]
    static async Task Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Form form = new Form() { Width = 800, Height = 600 };
        chart.Dock = DockStyle.Fill;
        form.Controls.Add(chart);

        await LoadAndRender("AAPL");

        timer = new Timer(60000);
        timer.Elapsed += async (sender, e) => await LoadAndRender("AAPL");
        timer.Start();

        Application.Run(form);
    }

    static async Task LoadAndRender(string symbol)
    {
        var stockData = await stockService.GetStockData(symbol);
        chart.Series = stockService.GenerateChartSeries(stockData);

        Console.Clear();
        Console.WriteLine(StockReport.GenerateSummary(stockData));
    }
}
