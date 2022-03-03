using System.ComponentModel;
using TopSell.ViewModels;
using Xamarin.Forms;

namespace TopSell.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}