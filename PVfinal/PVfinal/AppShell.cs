using Xamarin.Forms;
using PVfinal.Views;

namespace PVfinal
{
    public class AppShell : Shell
    {
        public AppShell()
        {
            // Vytváření TabBar a ShellContent
            var tabBar = new TabBar();

            var aboutPageTab = new ShellContent
            {
                Title = "About",
                Content = new AboutPage()
            };
            tabBar.Items.Add(aboutPageTab);

            var mainPageTab = new ShellContent
            {
                Title = "Home",
                Content = new MainPage()
            };
            tabBar.Items.Add(mainPageTab);

            var orderPageTab = new ShellContent
            {
                Title = "Orders",
                Content = new OrderPage()
            };
            tabBar.Items.Add(orderPageTab);

            Items.Add(tabBar);

            // Registrace cest pro navigaci
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        }
    }
}
