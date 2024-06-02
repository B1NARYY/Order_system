using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.Text;
using System;

namespace PVfinal.Droid
{
    [Activity(Label = "PVfinal", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Registrace kódování
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Jednoduchý testovací kód
            try
            {
                var encoding = Encoding.GetEncoding(1250);
                var testString = "Testovací řetězec";
                var bytes = encoding.GetBytes(testString);
                var decodedString = encoding.GetString(bytes);
                Console.WriteLine(decodedString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
