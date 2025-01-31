using UI.Views.Cart;
using UI.Views.Home;
using UI.Views.Login;
using UI.Views.Menu;
using UI.Views.Notifications;
using UI.Views.Profile;
using UI.Views.Promotions;
using UI.Views.ShopDetails;

namespace UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("shop_details", typeof(ShopDetailsPage));
            Routing.RegisterRoute("menu", typeof(MenuPage));
            Routing.RegisterRoute("promotions", typeof(PromotionsPage));
            Routing.RegisterRoute("cart", typeof(CartPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("notifications", typeof(NotificationsPage));
            Routing.RegisterRoute("profile", typeof(ProfilePage));
        }
    }
}
