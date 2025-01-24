using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.ViewModel
{
    public class SalesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChartData> salesData;
        public ObservableCollection<ChartData> SalesData
        {
            get { return salesData; }
            set
            {
                salesData = value;
                OnPropertyChanged(nameof(SalesData));
            }
        }

        public SalesViewModel()
        {
            SalesData = new ObservableCollection<ChartData>
            {
                new ChartData { Month = "يناير", Value = 200 },
                new ChartData { Month = "فبراير", Value = 400 },
                new ChartData { Month = "مارس", Value = 300 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ChartData
    {
        public string Month { get; set; }
        public double Value { get; set; }
    }
}
