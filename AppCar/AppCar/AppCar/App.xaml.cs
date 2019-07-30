using System;
using AppCar.View;
using AppCarFinance;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCar
{
    public partial class App : Application
    {
        public static double ScreenHeight;
        public static double ScreenWidth;
        public App()
        {
            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new InternetCK());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
