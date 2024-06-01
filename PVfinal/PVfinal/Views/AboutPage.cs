using Xamarin.Forms;

namespace PVfinal.Views
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            // Vytváření StackLayoutu
            var layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Přidání Label do Layoutu
            var label = new Label
            {
                Text = "Welcome to Xamarin.Forms!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            layout.Children.Add(label);

            // Nastavení hlavního obsahu stránky
            Content = layout;
        }
    }
}
