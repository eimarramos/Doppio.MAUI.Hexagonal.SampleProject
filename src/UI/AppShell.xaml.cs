using UI.Views.Home;
using UI.Views.ShopDetails;

namespace UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("shop_details", typeof(ShopDetailsPage));
        }
    }
}
