using Syncfusion.XForms.Chat;
using Syncfusion.XForms.PopupLayout;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GettingStarted
{
    public partial class MainPage : ContentPage
    {
        private SfPopupLayout popup;

        public MainPage()
        {
            InitializeComponent();
            // Uncomment the below line to hook the event.
            //this.sfChat.ImageTapped += sfChat_ImageTapped;
        }

        private void sfChat_ImageTapped(object sender, ImageTappedEventArgs e)
        {
            popup = new SfPopupLayout();
            popup.PopupView.ShowHeader = false;

            DataTemplate bodyTemplateView = new DataTemplate(() =>
            {
                var imageView = new Image();
                imageView.BackgroundColor = Color.Black;
                imageView.Source = e.Message.Source;
                imageView.Margin = new Thickness(0, 20, 0, 20);
                return imageView;
            });

            DataTemplate footerTemplateView = new DataTemplate(() =>
            {
                var backButton = new Button();
                backButton.Text = "Go back to chat";
                backButton.Clicked += BackButton_Clicked;
                return backButton;
            });

            popup.PopupView.ContentTemplate = bodyTemplateView;
            popup.PopupView.FooterTemplate = footerTemplateView;
            popup.Show(true);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            popup.Dismiss();
        }
    }
}
