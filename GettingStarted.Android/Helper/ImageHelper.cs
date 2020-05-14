using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GettingStarted.Droid
{
    public static class ImageHelper
    {
        internal static readonly int PickImageId = 1000;
        internal static Android.Net.Uri uri = null;
        internal static Context context;
        internal static bool returnedFromImageActivity = false;
        internal static Stream stream = null;
    }
}