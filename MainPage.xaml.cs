namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // تعيين المحتوى الافتراضي إلى لوحة القيادة (Dashboard)
            ContentArea.Content = new DashboardPage().Content;
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            // إعادة المستخدم إلى صفحة تسجيل الدخول
            await Navigation.PushAsync(new LoginPage());
        }

        void OnHomeButtonClicked(object sender, EventArgs e)
        {
            // تحديث المحتوى إلى لوحة القيادة
            ContentArea.Content = new DashboardPage().Content;
        }

        void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            // تحديث المحتوى إلى صفحة الإعدادات
            ContentArea.Content = new SettingsPage().Content;
        }

        void OnHelpButtonClicked(object sender, EventArgs e)
        {
            // تحديث المحتوى إلى صفحة المساعدة
            ContentArea.Content = new HelpPage().Content;
        }
    }
}
