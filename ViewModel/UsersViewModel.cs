using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public class UsersViewModel
    {
        public ObservableCollection<ChartData> UsersData { get; set; }

        public UsersViewModel()
        {
            UsersData = new ObservableCollection<ChartData>
            {
                new ChartData { Month = "يناير", Value = 500 },
                new ChartData { Month = "فبراير", Value = 700 },
                new ChartData { Month = "مارس", Value = 600 }
                // أضف المزيد من البيانات هنا
            };
        }
    }
}
