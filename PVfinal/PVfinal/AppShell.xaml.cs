using PVfinal.ViewModels;
using PVfinal.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PVfinal
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));

            // Vytvoření nového TabBar
            var tabBar = new TabBar();

            // Přidání ShellContent pro MainPage
            var mainPageTab = new ShellContent
            {
                Title = "Home",
                Route = "main",  // Volitelné: Specifikovat cestu pro lepší referenci
                ContentTemplate = new DataTemplate(typeof(MainPage))
            };
            tabBar.Items.Add(mainPageTab);

            // Přidání ShellContent pro OrderPage
            var orderPageTab = new ShellContent
            {
                Title = "Orders",
                Route = "orders",
                ContentTemplate = new DataTemplate(typeof(OrderPage))
            };
            tabBar.Items.Add(orderPageTab);

            // Přidání TabBaru do Shell
            Items.Add(tabBar);
        }

    }
}
