using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace TopSell.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView
    {
        public static int index { get; set; }
        public MainView(int index)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //CurrentPage = Children[0];
            MessagingCenter.Subscribe<Object, int>(this, "Navigation", (arg, idx) =>
            {
                // idx: the index of pages in tabbed that you want to navigate
                CurrentPage = this.Children[idx];

            });
        }
        void SetPage(int index)
        {
            CurrentPage = Children[index];
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<object, int>(this, "Add", 2);
        }
        private async void PopupAlertLogin()
        {
            await PopupNavigation.Instance.PushAsync(new PopupAlertLogin());
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if (CurrentPage is Page5)
            {
                PopupAlertLogin();
            }
            else
            {
                index = Children.IndexOf(CurrentPage);

            }
            //else if (CurrentPage is ExplorePage)
            //{
            //}
        }
    }
}