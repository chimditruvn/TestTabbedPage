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
            MessagingCenter.Send<object, int>(this, "Navigation", MainView.index);// if you want to navigation to the specific page .
            PopupNavigation.Instance.PopAllAsync();
        }

    }
}