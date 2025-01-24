//using static Android.Webkit.ConsoleMessage;

namespace MauiApp1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                messageLabel.Text = "الرجاء إدخال البريد الإلكتروني وكلمة المرور.";
            }
            else
            {
                // اضف منطق التحقق من تسجيل الدخول هنا
                // مثال بسيط:
                if (email == "user@example.com" && password == "password")
                {
                    // فتح الجلسة
                    SessionManager.IsLoggedIn = true;
                    SessionManager.UserEmail = email;

                    messageLabel.TextColor = Colors.Green;
                    messageLabel.Text = "تم تسجيل الدخول بنجاح!";

                    // الانتقال إلى الصفحة الرئيسية (MainPage)
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    messageLabel.TextColor = Colors.Red;
                    messageLabel.Text = "البريد الإلكتروني أو كلمة المرور غير صحيحة.";
                }
            }
        }
    }
}
