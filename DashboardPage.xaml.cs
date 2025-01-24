using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class DashboardPage : ContentPage
    {
        public ObservableCollection<ChartData> SalesData { get; set; }

        public DashboardPage()
        {
            InitializeComponent();
            LoadChart();
        }

        private void LoadChart()
        {
            SalesData = new ObservableCollection<ChartData>
            {
                new ChartData { Month = "يناير", Value = 200 },
                new ChartData { Month = "فبراير", Value = 400 },
                new ChartData { Month = "مارس", Value = 300 }
            };

            // تعيين البيانات إلى ColumnSeries
            var columnSeries = new Syncfusion.Maui.Charts.ColumnSeries
            {
                ItemsSource = SalesData,
                XBindingPath = "Month",
                YBindingPath = "Value"
            };

            salesChartView.Series.Add(columnSeries);
        }
    }

    public class ChartData
    {
        public string Month { get; set; }
        public double Value { get; set; }
    }
}
