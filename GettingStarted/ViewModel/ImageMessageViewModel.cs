using Syncfusion.XForms.Chat;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GettingStarted
{
    public class ImageMessageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> messages;
        SfPopupLayout imagePopup;
        internal SfPopupLayout attachmentPopup;
        Image imageView;

        /// <summary>
        /// current user of chat.
        /// </summary>
        private Author currentUser;

        public ImageMessageViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "Nancy", Avatar = "People_Circle16.png" };
            this.GenerateMessages();
            ImageCommand = new Command(ImageTapped);
            AttachmentCommand = new Command(AttachmentButtonTapped);
            this.Messages.CollectionChanged += Messages_CollectionChanged;
            imageView = new Image();
        }

        private void Messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (attachmentPopup.IsOpen)
            {
                attachmentPopup.Dismiss();
            }
        }

        #region Command

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

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets the group message conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the current author.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        #endregion

        #region Messages Generation
        private void GenerateMessages()
        {
            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });


            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });


            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image1.jpg",
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.AspectFit,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });

            this.Messages.Add(new ImageMessage()
            {
                Text = "Hi",
                Aspect = Xamarin.Forms.Aspect.Fill,
                Source = "Image3.jpg",
                Author = this.CurrentUser,
            });
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
