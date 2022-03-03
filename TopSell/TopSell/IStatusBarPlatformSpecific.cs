using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TopSell
{
    public interface IStatusBarPlatformSpecific
    {
        void SetStatusBarColor(Color color);
    }
}
