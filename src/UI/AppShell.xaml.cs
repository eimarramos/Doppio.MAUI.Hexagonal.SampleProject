using UI.Views.Menu;
using UI.Views.ShopDetails;

namespace UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("shop_details", typeof(ShopDetailsPage));
            Routing.RegisterRoute("menu", typeof(MenuPage));
        }
    }
}
