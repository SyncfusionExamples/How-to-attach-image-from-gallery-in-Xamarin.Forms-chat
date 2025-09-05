# How-to-attach-image-from-gallery-in-Xamarin.Forms-chat
This project explains how to attach an image from the gallery to the chat as a message by tapping the attachment button at the bottom in Xamarin.Forms chat

## Sample

```xaml
        <sfchat:SfChat x:Name="sfChat" 
                       StickyTimeBreak="False"
                       MessageShape="DualTearDrop"
                       ShowOutgoingMessageAvatar="True"
                       ShowIncomingMessageAvatar="True"
                       Messages="{Binding Messages}"
                       ImageTappedCommand="{Binding ImageCommand}"
                       CurrentUser="{Binding CurrentUser}"
                       IncomingMessageTimestampFormat="hh:mm tt"
                       ShowAttachmentButton="True"
                       AttachmentButtonCommand="{Binding AttachmentCommand}"
                       AttachmentButtonCommandParameter="{x:Reference sfChat}"
                       OutgoingMessageTimestampFormat="hh:mm tt" >
        </sfchat:SfChat>

ViewModel:

        public ImageMessageViewModel()
        {
            ...
            ImageCommand = new Command(ImageTapped);
            AttachmentCommand = new Command(AttachmentButtonTapped);
        }

        public ICommand ImageCommand
        {
            get;
            set;
        }

        public ICommand AttachmentCommand
        {
            get;
            set;
        }

        private void ImageTapped(object args)
        {
            imagePopup = new SfPopupLayout();
            imagePopup.PopupView.ShowHeader = false;
            imagePopup.PopupView.ShowFooter = false;
            imagePopup.PopupView.AnimationMode = AnimationMode.Zoom;
            imagePopup.PopupView.PopupStyle.BorderThickness = 0;

            DataTemplate bodyTemplateView = new DataTemplate(() =>
            {
                imageView.BackgroundColor = Color.Black;
                imageView.Source = (args as ImageTappedEventArgs).Message.Source;
                return imageView;
            });

            imagePopup.PopupView.ContentTemplate = bodyTemplateView;
            imagePopup.Show(true);
        }

        private void AttachmentButtonTapped(object args)
        {
            AttachmentPopupView popupTemplate = new AttachmentPopupView();
            popupTemplate.ViewModel = this;

            attachmentPopup = new SfPopupLayout();
            attachmentPopup.PopupView.ShowHeader = false;
            attachmentPopup.PopupView.ShowFooter = false;
            attachmentPopup.PopupView.AnimationMode = AnimationMode.Fade;
            attachmentPopup.PopupView.PopupStyle.BorderThickness = 0;
            attachmentPopup.PopupView.PopupStyle.CornerRadius = 45;
            attachmentPopup.PopupView.WidthRequest = ((args as SfChat).Editor.Parent.Parent as View).Width;
            attachmentPopup.PopupView.HeightRequest = 170;

            DataTemplate bodyTemplateView = new DataTemplate(() =>
            {
                return popupTemplate;
            });

            attachmentPopup.PopupView.ContentTemplate = bodyTemplateView;
            attachmentPopup.ShowRelativeToView((args as SfChat).Editor.Parent.Parent as View, RelativePosition.AlignTop, absoluteY: -5);
        }

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for Xamarin](https://help.syncfusion.com/xamarin/system-requirements)

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

