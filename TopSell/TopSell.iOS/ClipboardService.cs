using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UIKit;
using TopSell.iOS.Services;
using TopSell.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ClipboardService))]
namespace TopSell.iOS.Services
{
    public class ClipboardService : IClipboardService
    {
        public void CopyToClipboard(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;
        }
    }
}