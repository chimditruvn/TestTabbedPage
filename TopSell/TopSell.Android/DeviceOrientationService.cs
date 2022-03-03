using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopSell.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceOrientationService))]
namespace TopSell.Droid
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
    }
}