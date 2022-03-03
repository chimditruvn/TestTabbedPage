using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using TopSell.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(ChangeStatusbarIOS))]
namespace TopSell.iOS
{
    public class ChangeStatusbarIOS : IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color)
        {

            UIView statusBar = new UIView(UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame);
            //statusBar.BackgroundColor = UIColor.Yellow;

            statusBar.BackgroundColor = color.AddLuminosity(0).ToUIColor();
            UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);
        }
    }
}