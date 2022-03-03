using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TopSell.Droid.DepencencyServices;
using TopSell.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ClipboardService))]
namespace TopSell.Droid.DepencencyServices
{
    public class ClipboardService : IClipboardService
    {
        public void CopyToClipboard(string text)
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText("Android Clipboard", text);
            clipboardManager.PrimaryClip = clip;
        }
    }
}