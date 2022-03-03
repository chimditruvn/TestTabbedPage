using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopSell.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAlertLogin : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAlertLogin()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            statusbar.SetStatusBarColor(Color.FromHex("ffffff"));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            statusbar.SetStatusBarColor(Color.FromHex("ffffff"));
        }

        private void close_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync();

            //var tab = (TabbedPage)Application.Current.MainPage;
            //tab.CurrentPage = tab.Children[0];

            var mainPage = this.Parent as TabbedPage;
            mainPage.CurrentPage = mainPage.Children[4];
        }

    }
}