using System.Text.RegularExpressions;

namespace MauiApp1;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage()
    {
        InitializeComponent();
    }

    private async void OnCreateAccountButtonClicked(object sender, EventArgs e)
    {
        bool hasError = false;

        // إعادة ضبط الأخطاء
        ResetErrors();

        // التحقق من الاسم الكامل
        if (string.IsNullOrWhiteSpace(fullNameEntry.Text))
        {
            nameErrorLabel.Text = "يرجى إدخال الاسم الكامل.";
            NameFrame.BorderColor = Colors.Red;
            hasError = true;
        }

        // التحقق من البريد الإلكتروني
        if (string.IsNullOrWhiteSpace(emailEntry.Text) || !IsValidEmail(emailEntry.Text))
        {
            emailErrorLabel.Text = "يرجى إدخال بريد إلكتروني صحيح.";
            EmailFrame.BorderColor = Colors.Red;
            hasError = true;
        }

        // التحقق من كلمة المرور
        if (string.IsNullOrWhiteSpace(passwordEntry.Text) || passwordEntry.Text.Length < 6)
        {
            passwordErrorLabel.Text = "يجب أن تكون كلمة المرور 6 أحرف على الأقل.";
            PasswordFrame.BorderColor = Colors.Red;
            hasError = true;
        }

        // التحقق من تأكيد كلمة المرور
        if (confirmPasswordEntry.Text != passwordEntry.Text)
        {
            confirmPasswordErrorLabel.Text = "كلمات المرور غير متطابقة.";
            ConfirmPasswordFrame.BorderColor = Colors.Red;
            hasError = true;
        }

        if (hasError)
        {
            return;
        }

        // إذا لم يكن هناك خطأ، إكمال عملية التسجيل
        await DisplayAlert("نجاح", "تم إنشاء الحساب بنجاح!", "موافق");
        passwordEntry.Text = string.Empty;
        fullNameEntry.Text = string.Empty;
        emailEntry.Text = string.Empty;
        confirmPasswordEntry.Text = string.Empty;

        await Shell.Current.GoToAsync("//LoginPage");
    }

    // دالة إعادة تعيين الأخطاء
    private void ResetErrors()
    {
        nameErrorLabel.Text = "";
        emailErrorLabel.Text = "";
        passwordErrorLabel.Text = "";
        confirmPasswordErrorLabel.Text = "";

        NameFrame.BorderColor = Colors.Gray;
        EmailFrame.BorderColor = Colors.Gray;
        PasswordFrame.BorderColor = Colors.Gray;
        ConfirmPasswordFrame.BorderColor = Colors.Gray;
    }

    // دالة التحقق من البريد الإلكتروني
    private bool IsValidEmail(string email)
    {
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex);
    }
    private async void OnBackToLoginButtonClicked(object sender, EventArgs e)
    {
        // الانتقال إلى صفحة تسجيل الدخول باستخدام Shell
        await Shell.Current.GoToAsync("//LoginPage");
    }
}