using Microsoft.Maui.Storage;
using System;
using System.Threading.Tasks;

public static class SessionManager
{
    private static DateTime _sessionStartTime;
    private static int _sessionDurationMinutes = 3;

    public static bool IsLoggedIn
    {
        get => Preferences.Get(nameof(IsLoggedIn), false);
        set
        {
            Preferences.Set(nameof(IsLoggedIn), value);
            if (value)
            {
                //StartSessionTimer();
            }
        }
    }

    public static string UserEmail
    {
        get => Preferences.Get(nameof(UserEmail), string.Empty);
        set => Preferences.Set(nameof(UserEmail), value);
    }

    //private static void StartSessionTimer()
    //{
    //    _sessionStartTime = DateTime.Now;

    //    // استخدم Device.StartTimer لضمان عمل المؤقت حتى في الخلفية
    //    Device.StartTimer(TimeSpan.FromMinutes(_sessionDurationMinutes), () =>
    //    {
    //        EndSession();
    //        return false; // إيقاف المؤقت بعد انتهاء الجلسة
    //    });
    //}

    private static void EndSession()
    {
        IsLoggedIn = false;
        UserEmail = string.Empty;

        // يمكنك إضافة أي إجراءات إضافية هنا عند انتهاء الجلسة، مثل عرض رسالة
    }
}
