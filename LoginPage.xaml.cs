using Microsoft.Maui.Controls;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class LoginPage : ContentPage
    {
        private bool isPasswordVisible = false;

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

                    // تفريغ حقول الإدخال
                    emailEntry.Text = string.Empty;
                    passwordEntry.Text = string.Empty;
                    OnPasswordEntryTextChanged(passwordEntry, null); // لتحديث الأيقونات

                    // الانتقال إلى الصفحة الرئيسية (MainPage)
                    await Shell.Current.GoToAsync("//MainPage");

                    // إخفاء الرسالة بعد 3 ثوانٍ
                    await Task.Delay(3000);
                    messageLabel.Text = string.Empty;
                }
                else
                {
                    messageLabel.TextColor = Colors.Red;
                    messageLabel.Text = "البريد الإلكتروني أو كلمة المرور غير صحيحة.";
                }
            }
        }

        private async void OnFingerprintLoginClicked(object sender, EventArgs e)
        {
            var result = await AuthenticateWithFingerprintAsync();
            if (result.Authenticated)
            {
                messageLabel.TextColor = Colors.Green;
                messageLabel.Text = "تسجيل الدخول ببصمة الإصبع ناجح!";
                // قم بتنفيذ عملية تسجيل الدخول الناجحة هنا
                SessionManager.IsLoggedIn = true;
                SessionManager.UserEmail = "user@example.com"; // تغيير البريد الإلكتروني وفقًا لما يناسبك

                // تفريغ حقول الإدخال
                emailEntry.Text = string.Empty;
                passwordEntry.Text = string.Empty;
                OnPasswordEntryTextChanged(passwordEntry, null); // لتحديث الأيقونات

                // الانتقال إلى الصفحة الرئيسية (MainPage)
                await Shell.Current.GoToAsync("//MainPage");

                // إخفاء الرسالة بعد 3 ثوانٍ
                await Task.Delay(3000);
                messageLabel.Text = string.Empty;
            }
            else
            {
                messageLabel.TextColor = Colors.Red;
                messageLabel.Text = "فشل في تسجيل الدخول ببصمة الإصبع!";
            }
        }

        private async Task<FingerprintAuthenticationResult> AuthenticateWithFingerprintAsync()
        {
            var availability = await CrossFingerprint.Current.IsAvailableAsync();
            if (!availability)
            {
                return new FingerprintAuthenticationResult { Status = FingerprintAuthenticationResultStatus.Failed };
            }

            var result = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("تسجيل الدخول ببصمة الإصبع", "ضع إصبعك على المستشعر للتحقق"));
            return result;
        }

        private void OnTogglePasswordVisibilityClicked(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                passwordEntry.IsPassword = false;
                togglePasswordVisibilityButton.Source = "Resources/Images/eye_open.png";
            }
            else
            {
                passwordEntry.IsPassword = true;
                togglePasswordVisibilityButton.Source = "Resources/Images/eye_closed.png";
            }
        }

        private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                // إظهار أيقونة البصمة وإخفاء أيقونة العين
                togglePasswordVisibilityButton.IsVisible = false;
                fingerprintButton.IsVisible = true;
            }
            else
            {
                // إخفاء أيقونة البصمة وإظهار أيقونة العين
                togglePasswordVisibilityButton.IsVisible = true;
                fingerprintButton.IsVisible = false;
            }
        }
    }
}
