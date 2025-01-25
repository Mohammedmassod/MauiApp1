﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Fingerprint; // تأكد من إضافة هذا الاستخدام

namespace MauiApp1
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // تعيين معالج النشاط الحالي
            CrossFingerprint.SetCurrentActivityResolver(() => this);
        }
    }
}
