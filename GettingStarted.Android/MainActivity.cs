using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Syncfusion.XForms.Android.PopupLayout;
using Android.Content;
using Android.Provider;
using Android.Database;
using Xamarin.Forms;

namespace GettingStarted.Droid
{
    [Activity(Label = "GettingStarted", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SfPopupLayoutRenderer.Init();
            LoadApplication(new App());
            ImageHelper.context = this;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == ImageHelper.PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                ImageHelper.uri = data.Data;
                //var a = GetPathToImage(data.Data);
            }
            base.OnActivityResult(requestCode, resultCode, data);
            ImageHelper.returnedFromImageActivity = true;
        }
    }
}