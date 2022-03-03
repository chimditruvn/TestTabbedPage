using System;
using TopSell.Services;
using TopSell.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopSell
{
    public partial class App : Application
    {

        public static string AppName = "TopSell";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new Test();

            App.Current.MainPage = new NavigationPage(new MainView(0));

            Sharpnado.Tabs.Initializer.Initialize(false, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
