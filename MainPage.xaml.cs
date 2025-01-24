using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer _inactivityTimer;

        public MainPage()
        {
            InitializeComponent();

            // عرض رسالة الترحيب كتنبيه
            DisplayWelcomeMessage();

            // تعيين المحتوى الافتراضي إلى لوحة القيادة (Dashboard)
            ContentArea.Content = new DashboardPage().Content;

            // إعداد مؤقت عدم التفاعل
            SetupInactivityTimer();
            // التحقق من انتهاء الجلسة
            CheckSession();
        }

        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("خيارات القائمة", "إلغاء", null, "الخيار الأول", "الخيار الثاني", "الخيار الثالث");
            switch (action)
            {
                case "الخيار الأول":
                    await DisplayAlert("القائمة", "تم اختيار الخيار الأول", "حسنًا");
                    break;
                case "الخيار الثاني":
                    await DisplayAlert("القائمة", "تم اختيار الخيار الثاني", "حسنًا");
                    break;
                case "الخيار الثالث":
                    await DisplayAlert("القائمة", "تم اختيار الخيار الثالث", "حسنًا");
                    break;
                default:
                    break;
            }
        }

        private void SetupInactivityTimer()
        {
            _inactivityTimer = new System.Timers.Timer(20000); // 20 ثانية
            _inactivityTimer.Elapsed += OnInactivityTimeout;
            _inactivityTimer.Start();

            // تسجيل الأحداث لعدة تفاعلات مثل النقر والسحب
            this.Appearing += (s, e) => { ResetInactivityTimer(); };
            this.Disappearing += (s, e) => { _inactivityTimer.Stop(); };
        }

        private async void OnInactivityTimeout(object sender, System.Timers.ElapsedEventArgs e)
        {
            // إغلاق الجلسة عند عدم التفاعل
            SessionManager.IsLoggedIn = false;
            SessionManager.UserEmail = string.Empty;

            // الانتقال إلى صفحة تسجيل الدخول
            Device.BeginInvokeOnMainThread(async () => { await Shell.Current.GoToAsync("//LoginPage"); });
        }

        private void ResetInactivityTimer()
        {
            _inactivityTimer.Stop();
            _inactivityTimer.Start();
        }

        private async void DisplayWelcomeMessage()
        {
            if (!string.IsNullOrEmpty(SessionManager.UserEmail))
            {
                await DisplayAlert("ترحيب", $"مرحبًا بك، {SessionManager.UserEmail}!", "حسنًا");
                await Task.Delay(3000); // انتظر ثلاث ثوانٍ
            }
        }

        private async void CheckSession()
        {
            while (SessionManager.IsLoggedIn)
            {
                await Task.Delay(1000); // التحقق كل ثانية

                if (!SessionManager.IsLoggedIn)
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                }
            }
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            ResetInactivityTimer(); // إعادة ضبط المؤقت
            bool answer = await DisplayAlert("تأكيد الخروج", "هل تريد الخروج من التطبيق؟", "نعم", "لا");
            if (answer)
            {
                // إغلاق الجلسة
                SessionManager.IsLoggedIn = false;
                SessionManager.UserEmail = string.Empty;

                // العودة إلى صفحة تسجيل الدخول بدلاً من إغلاق التطبيق
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }

        async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            ResetInactivityTimer(); // إعادة ضبط المؤقت
            // تحديث المحتوى إلى لوحة القيادة
            ContentArea.Content = new DashboardPage().Content;
        }

        async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            ResetInactivityTimer(); // إعادة ضبط المؤقت
            // تحديث المحتوى إلى صفحة الإعدادات
            ContentArea.Content = new SettingsPage().Content;
        }

        async void OnHelpButtonClicked(object sender, EventArgs e)
        {
            ResetInactivityTimer(); // إعادة ضبط المؤقت
            // تحديث المحتوى إلى صفحة المساعدة
            ContentArea.Content = new HelpPage().Content;
        }

        protected override bool OnBackButtonPressed()
        {
            ShowExitConfirmation();
            return true; // منع السلوك الافتراضي
        }

        private async void ShowExitConfirmation()
        {
            bool answer = await DisplayAlert("تأكيد الخروج", "هل تريد الخروج من التطبيق؟", "نعم", "لا");
            if (answer)
            {
                // إغلاق الجلسة
                SessionManager.IsLoggedIn = false;
                SessionManager.UserEmail = string.Empty;

                // العودة إلى صفحة تسجيل الدخول بدلاً من إغلاق التطبيق
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }
    }
}
