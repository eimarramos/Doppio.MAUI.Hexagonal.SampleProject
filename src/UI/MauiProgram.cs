using ApplicationLayer;
using CommunityToolkit.Maui;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using UI.ViewModels;
using UI.Views.Cart;
using UI.Views.Home;
using UI.Views.Login;
using UI.Views.Notifications;
using UI.Views.Profile;
using UI.Views.Promotions;
using UI.Views.ShopDetails;

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

            MauiApp app = builder.Build();

            InitialiseDatabase(app);

            return app;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddInfrastructureServices();
            mauiAppBuilder.Services.AddApplicationServices();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
            mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
            mauiAppBuilder.Services.AddSingleton<PromotionsViewModel>();
            mauiAppBuilder.Services.AddSingleton<NotificationsViewModel>();
            mauiAppBuilder.Services.AddSingleton<ProfileViewModel>();
            mauiAppBuilder.Services.AddSingleton<CartViewModel>();
            mauiAppBuilder.Services.AddSingleton<ShopDetailsViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginPage>();
            mauiAppBuilder.Services.AddSingleton<HomePage>();
            mauiAppBuilder.Services.AddSingleton<PromotionsPage>();
            mauiAppBuilder.Services.AddSingleton<NotificationsPage>();
            mauiAppBuilder.Services.AddSingleton<ProfilePage>();
            mauiAppBuilder.Services.AddSingleton<CartPage>();
            mauiAppBuilder.Services.AddSingleton<ShopDetailsPage>();

            return mauiAppBuilder;
        }

        public static void InitialiseDatabase(MauiApp app)
        {
            var databaseInitializer = app.Services.GetRequiredService<DatabaseContextInitializer>();
            databaseInitializer.Initialise();
        }
    }
}
