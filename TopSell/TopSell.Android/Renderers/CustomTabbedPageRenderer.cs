using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TopSell.Droid.Renderers;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using static Google.Android.Material.BottomNavigation.BottomNavigationView;
using static Google.Android.Material.Tabs.TabLayout;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace TopSell.Droid.Renderers
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer, IOnTabSelectedListener
    {
        TabbedPage tabbedPage;
        List<Android.Views.View> list = new List<Android.Views.View>();
        public CustomTabbedPageRenderer(Context context) : base(context)
        {
            for (int i = 0; i <= 4; i++)
            {
                Android.Views.View view = LayoutInflater.From(Context).Inflate(Resource.Drawable.MyViewDotRed, null);
                list.Add(view);
            }
        }
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null || e.OldElement != null)
                return;

            MessagingCenter.Subscribe<object, int>(this, "Add", (obj, index) => {
                TabLayout tablayout = (TabLayout)ViewGroup.GetChildAt(1);
                ViewGroup vgroup = (ViewGroup)tablayout.GetChildAt(0);
                for (int i = 0; i < vgroup.ChildCount; i++)
                {
                    if (index == i)
                    {
                        var view = list[i];
                        if (view.Parent != null) break;
                        ViewGroup vvgroup = (ViewGroup)vgroup.GetChildAt(i);
                        MarginLayoutParams layout1 = new MarginLayoutParams(MarginLayoutParams.MatchParent, MarginLayoutParams.MatchParent);
                        layout1.SetMargins(120, -135, 0, 0);
                        vvgroup.AddView(view, layout1);

                        var ll = vvgroup.LayoutParameters as LinearLayout.LayoutParams;
                        ll.SetMargins(0, 30, 0, 0);
                        vvgroup.LayoutParameters = ll;
                    }
                }
            });
            MessagingCenter.Subscribe<object, int>(this, "Remove", (obj, index) => {
                TabLayout tablayout = (TabLayout)ViewGroup.GetChildAt(1);
                ViewGroup vgroup = (ViewGroup)tablayout.GetChildAt(0);
                for (int i = 0; i < vgroup.ChildCount; i++)
                {
                    if (index == i)
                    {
                        var view = list[i];
                        if (view.Parent == null) break;
                        ViewGroup vvgroup = (ViewGroup)vgroup.GetChildAt(i);
                        vvgroup.RemoveView(view);

                        var ll = vvgroup.LayoutParameters as LinearLayout.LayoutParams;
                        ll.SetMargins(0, 0, 0, 0);
                        vvgroup.LayoutParameters = ll;
                    }
                }
            });

            if (e.NewElement != null)
            {
                IEnumerable<View> children = GetAllChildViews(ViewGroup);
                BottomNavigationView bottomNavBar = (BottomNavigationView)children.SingleOrDefault(view => view is BottomNavigationView);
                if (bottomNavBar != null)
                {
                    tabbedPage = e.NewElement;
                    bottomNavBar.NavigationItemSelected += BottomNavBar_NavigationItemSelected;
                    bottomNavBar.Menu.GetItem(0).SetIcon(Resource.Drawable.homeiconselect);
                }
            }
        }
        int previous;
        private void BottomNavBar_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            var current = e.Item.ItemId;
            switch (e.Item.ToString())
            {
                case "Page 1":
                    e.Item.SetIcon(Resource.Drawable.homeiconselect);
                    break;
                case "Page 2":
                    e.Item.SetIcon(Resource.Drawable.manageorderselect);
                    break;
                case "Page 3":
                    e.Item.SetIcon(Resource.Drawable.feedsselect);
                    break;
                case "Page 4":
                    e.Item.SetIcon(Resource.Drawable.moneysselect);
                    break;
                case "Page 5":
                    e.Item.SetIcon(Resource.Drawable.accounticonselect);
                    break;
                default:
                    break;
            }

            var previousView = sender as BottomNavigationView;
            IMenu menu = previousView.Menu;
            var previousItem = menu.GetItem(previous);

            if (previous != current)
            {
                if (previousItem.IsChecked)
                {
                    switch (previousItem.ToString())
                    {
                        case "Page 1":
                            previousItem.SetIcon(Resource.Drawable.homeicon);
                            break;
                        case "Page 2":
                            previousItem.SetIcon(Resource.Drawable.manageorder);
                            break;
                        case "Page 3":
                            previousItem.SetIcon(Resource.Drawable.feeds);
                            break;
                        case "Page 4":
                            previousItem.SetIcon(Resource.Drawable.moneys);
                            break;
                        case "Page 5":
                            previousItem.SetIcon(Resource.Drawable.accounticon);
                            break;
                        default:
                            break;
                    }
                }
            }

            tabbedPage.CurrentPage = tabbedPage.Children[current];
            previous = current;
        }

        private IEnumerable<View> GetAllChildViews(View view)
        {
            if (!(view is ViewGroup group))
                return new List<View> { view };

            List<View> result = new List<View>();
            int childCount = group.ChildCount;

            for (int i = 0; i < childCount; i++)
            {
                View child = group.GetChildAt(i);
                List<View> childList = new List<View> { child };
                childList.AddRange(GetAllChildViews(child));
                result.AddRange(childList);
            }

            return result.Distinct();
        }

    }
}