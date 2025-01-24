using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public class ProfitsViewModel
    {
        public ObservableCollection<ChartData> ProfitsData { get; set; }

        public ProfitsViewModel()
        {
            ProfitsData = new ObservableCollection<ChartData>
            {
                new ChartData { Month = "يناير", Value = 150 },
                new ChartData { Month = "فبراير", Value = 200 },
                new ChartData { Month = "مارس", Value = 250 }
                // أضف المزيد من البيانات هنا
            };
        }
    }
}
