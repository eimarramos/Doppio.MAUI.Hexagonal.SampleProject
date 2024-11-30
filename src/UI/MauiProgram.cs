using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UI.ViewModels;
using UI.Views.Home;
using UI.Views.Login;
using UI.Views.Promotions;

namespace UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
                    fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                    fonts.AddFont("MuseoModerno-Medium.ttf", "MuseoModernoMedium");
                })
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews(); ;

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            return app;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {


            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
            mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
            mauiAppBuilder.Services.AddSingleton<PromotionsViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginPage>();
            mauiAppBuilder.Services.AddSingleton<HomePage>();
            mauiAppBuilder.Services.AddSingleton<PromotionsPage>();

            return mauiAppBuilder;
        }
    }
}
