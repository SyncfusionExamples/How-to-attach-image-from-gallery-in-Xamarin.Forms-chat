using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingStarted
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttachmentPopupView : CustomGrid
	{
		public AttachmentPopupView ()
		{
			InitializeComponent ();
            this.icon1.Source = ImageSource.FromResource("GettingStarted.Document.png");
            this.icon2.Source = ImageSource.FromResource("GettingStarted.Payment.png");
            this.icon3.Source = ImageSource.FromResource("GettingStarted.Gallery.png");
            this.icon4.Source = ImageSource.FromResource("GettingStarted.Audio.png");
            this.icon5.Source = ImageSource.FromResource("GettingStarted.Location.png");
            this.icon6.Source = ImageSource.FromResource("GettingStarted.Contact.png");
        }

        private async void OpenGalleryTapped(object sender, EventArgs args)
        {
            await DependencyService.Get<IImageChooser>().StartImageChooser();
            if (DependencyService.Get<IImageChooser>().GetImage() != null)
            {
                this.ViewModel.Messages.Add(new ImageMessage()
                {
                    Aspect = Xamarin.Forms.Aspect.AspectFill,
                    Source = ImageSource.FromStream(() => DependencyService.Get<IImageChooser>().GetImage()),
                    Author = this.ViewModel.CurrentUser
                });
            }
            else if (this.ViewModel.attachmentPopup.IsOpen)
            {
                    this.ViewModel.attachmentPopup.Dismiss();
            }
        }
    }
}