using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // إعداد Syncfusion
            builder.ConfigureSyncfusionCore();
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf0x1RHxbf1x1ZFZMYlxbQHBPIiBoS35Rc0ViW3tfdXZVQmZfU0B+");
            return builder.Build();
        }
    }
}
