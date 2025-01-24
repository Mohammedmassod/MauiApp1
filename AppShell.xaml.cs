namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // التحقق من حالة الجلسة
            if (SessionManager.IsLoggedIn)
            {
                // إذا كانت الجلسة مفتوحة، الانتقال إلى الصفحة الرئيسية
                GoToAsync("//MainPage");
            }
            else
            {
                // إذا لم يكن المستخدم مسجل الدخول، الانتقال إلى صفحة تسجيل الدخول
                GoToAsync("//LoginPage");
            }
        }
    }
}
