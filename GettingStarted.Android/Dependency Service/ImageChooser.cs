using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GettingStarted.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(ImageChooser))]
namespace GettingStarted.Droid
{
    class ImageChooser : IImageChooser
    {
        Intent Intent;

        public Stream GetImage()
        {
            if(ImageHelper.uri == null)
            {
                return null;
            }
            return (ImageHelper.context as MainActivity).ContentResolver.OpenInputStream(ImageHelper.uri);
        }

        public Task<bool> StartImageChooser()
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            ImageHelper.uri = null;
            (ImageHelper.context as MainActivity).StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), ImageHelper.PickImageId);

            return Task.Run(() => CheckIfImageChooserActivityIsExited());

        }

        private bool CheckIfImageChooserActivityIsExited()
        {
            while (!ImageHelper.returnedFromImageActivity)
            {

            }
            ImageHelper.returnedFromImageActivity = false;
            return true;
        }

    }
}