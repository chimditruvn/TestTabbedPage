using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using TopSell.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(MyTabDotRenderer))]
namespace TopSell.iOS
{
    internal class MyTabDotRenderer : TabbedRenderer
    {
        private bool _initialized;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            //TabBar.ClipsToBounds = true;
            //TabBar.TintColor = UIColor.Gray;
            TabBar.BarTintColor = UIColor.White;
            TabBar.BackgroundColor = UIColor.White;
            TabBar.Translucent = false;

            MessagingCenter.Subscribe<object, int>(this, "Add", (obj, index) => {
                TabBar.addItemBadge(index);
            });
            MessagingCenter.Subscribe<object, int>(this, "Remove", (obj, index) => {
                TabBar.removeItemBadge(index);
            });
        }

        public override void ViewWillAppear(bool animated)
        {
            if (!_initialized)
            {
                if (TabBar?.Items == null)
                    return;

                foreach (var item in TabBar.Items)
                {
                    item.Image = ScalingImageToSize(item.Image, new CGSize(23, 23)); // set the size here as you want 
                }

                var tabs = Element as TabbedPage;

                if (tabs != null)
                {
                    for (int i = 0; i < TabBar.Items.Length; i++)
                    {
                        UpdateItem(TabBar.Items[i], tabs.Children[i].Icon, tabs.Children[i].StyleId);
                    }
                }

                _initialized = true;
            }

            base.ViewWillAppear(animated);
        }
        private void UpdateItem(UITabBarItem item, string icon, string badgeValue)
        {
            if (item == null) return;

            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                //change icon select
                if (icon.EndsWith(".png"))
                    icon = icon.Replace(".png", "_selected.png");
                else
                    icon += "_selected";

                item.Image = item.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysOriginal);

                item.SelectedImage = UIImage.FromBundle(icon);
                item.SelectedImage.AccessibilityIdentifier = icon;
                item.SelectedImage = ScalingImageToSize(item.SelectedImage, new CGSize(23, 23)); // set the size here as you want 
                //change icon select


                UITabBarAppearance app = new UITabBarAppearance();
                app.ConfigureWithOpaqueBackground();
                app.BackgroundColor = UIColor.Clear;

                app.StackedLayoutAppearance.Normal.TitleTextAttributes = new UIStringAttributes() { Font = UIFont.FromName("Roboto Medium", 12), ForegroundColor = Color.FromHex("#393f57").ToUIColor() };
                app.StackedLayoutAppearance.Selected.TitleTextAttributes = new UIStringAttributes() { Font = UIFont.FromName("Roboto Medium", 12), ForegroundColor = Color.FromHex("#00AA13").ToUIColor() };
                item.StandardAppearance = app;

                if (UIDevice.CurrentDevice.CheckSystemVersion(15, 0))
                {
                    item.ScrollEdgeAppearance = item.StandardAppearance;
                }
            }

        }
        public UIImage ScalingImageToSize(UIImage sourceImage, CGSize newSize)
        {

            if (UIScreen.MainScreen.Scale == 2.0) //@2x iPhone 6 7 8 
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 2.0f);
            }


            else if (UIScreen.MainScreen.Scale == 3.0) //@3x iPhone 6p 7p 8p...
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 3.0f);
            }

            else
            {
                UIGraphics.BeginImageContext(newSize);
            }

            sourceImage.Draw(new CGRect(0, 0, newSize.Width, newSize.Height));

            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            return newImage;

        }
    }

    public static class TabbarExtensions
    {

        readonly static int tabBarItemTag = 9999;
        public static void addItemBadge(this UITabBar tabbar, int index)
        {
            if (tabbar.Items != null && tabbar.Items.Length == 0) return;

            if (index >= tabbar.Items.Length) return;

            removeItemBadge(tabbar, index);

            var badgeView = new UIView();
            badgeView.Tag = tabBarItemTag + index;
            badgeView.Layer.CornerRadius = 3;
            badgeView.BackgroundColor = UIColor.Red;

            var tabFrame = tabbar.Frame;
            var percentX = (index + 0.56) / tabbar.Items.Length;
            var x = percentX * tabFrame.Width;
            var y = tabFrame.Height * 0.1;
            badgeView.Frame = new CoreGraphics.CGRect(x, y, 7, 7);
            tabbar.AddSubview(badgeView);
        }

        public static bool removeItemBadge(this UITabBar tabbar, int index)
        {
            foreach (var subView in tabbar.Subviews)
            {
                if (subView.Tag == tabBarItemTag + index)
                {
                    subView.RemoveFromSuperview();
                    return true;
                }
            }

            return false;
        }
    }
}