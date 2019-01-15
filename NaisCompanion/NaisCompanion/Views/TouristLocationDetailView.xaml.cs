using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaisCompanion.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TouristLocationDetailView : ContentPage
    {
        private TouristLocationViewModel viewModel;
        private Timer Timer;

        public TouristLocationDetailView(Tourist current, TouristLocation location)
        {
            InitializeComponent();

            BindingContext = viewModel = new TouristLocationViewModel(current, location);

            Timer = new Timer();

            ColectedTokens colected = viewModel.CurrentTourist.ColectedTokensCollection.Where(x => x.LocationId == viewModel.Location.Id).FirstOrDefault();
            if (colected == null || !colected.VisitedTokens)
            {
                Timer.Interval = 60000 * viewModel.Location.MinVisitDuration;
                Timer.Elapsed += CollectTokens;
                Timer.Start();
            }
        }

        private async void CollectTokens(object sender, ElapsedEventArgs e)
        {
            Timer.Stop();

            viewModel.CurrentTourist.Tokens += viewModel.Location.VisitedPayment;
            ColectedTokens colected = viewModel.CurrentTourist.ColectedTokensCollection.Where(x => x.LocationId == viewModel.Location.Id).FirstOrDefault();
            if (colected != null && !colected.VisitedTokens)
                colected.VisitedTokens = true;
            else if (colected == null)
                viewModel.CurrentTourist.ColectedTokensCollection.Add(new ColectedTokens()
                {
                    LocationId = viewModel.Location.Id,
                    VisitedTokens = true,
                });

            Timer.Elapsed -= CollectTokens;
            string message = "You earned " + viewModel.Location.PhotoPayment.ToString() + " tokens for visting this location ";
            Device.BeginInvokeOnMainThread(() => { DisplayAlert("Congratulations", message, "Ok"); });
            return;
        }

        private async void BtnAddPost_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edComment.Text))
            {
                await DisplayAlert("Error", "You have to type in something to post!", "Ok");
                return;
            }

            ColectedTokens collected = viewModel.CurrentTourist.ColectedTokensCollection.Where(x => x.LocationId == viewModel.Location.Id).FirstOrDefault();
            if (collected != null && !collected.PostTokens)
            {
                viewModel.CurrentTourist.Tokens += viewModel.Location.PostPayment;
                collected.PostTokens = true;
                await DisplayAlert("Congratulations", "You earned " + viewModel.Location.PhotoPayment.ToString() + " tokens for adding a post ", "Ok");
            }
            else if (collected == null)
            {
                viewModel.CurrentTourist.Tokens += viewModel.Location.PostPayment;
                viewModel.CurrentTourist.ColectedTokensCollection.Add(new ColectedTokens()
                {
                    LocationId = viewModel.Location.Id,
                    PostTokens = true,
                });
                await DisplayAlert("Congratulations", "You earned " + viewModel.Location.PhotoPayment.ToString() + " tokens for adding a post ", "Ok");
            }

            viewModel.Location.Comments.Add(new Comment
            {
                Text = edComment.Text,
                Author = viewModel.CurrentTourist.Username,
                UploadedDate = DateTime.Now.ToString("dd.MM.yyyy. HH:mm")
            });

            TouristLocationDetailView newPage = new TouristLocationDetailView(viewModel.CurrentTourist, viewModel.Location);
            Navigation.InsertPageBefore(newPage, this);
            await Navigation.PopAsync();
        }

        private async void BtnAddPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No camera available.", "Ok");
                return;
            }

            MediaFile photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { MaxWidthHeight = 600 });

            if (photo != null)
                viewModel.Location.UploadedPhotos.Add(new ImagePost
                {
                    Photo = ImageSource.FromStream(() => photo.GetStream()),
                    Author = viewModel.CurrentTourist.Username,
                    UploadedDate = DateTime.Now.ToString("dd.MM.yyyy. HH:mm")
                });

            ColectedTokens colected = viewModel.CurrentTourist.ColectedTokensCollection.Where(x => x.LocationId == viewModel.Location.Id).FirstOrDefault();
            if (colected != null && !colected.PhotoTokens)
            {
                viewModel.CurrentTourist.Tokens += viewModel.Location.PhotoPayment;
                colected.PhotoTokens = true;
                await DisplayAlert("Congratulations", "You earned " + viewModel.Location.PhotoPayment.ToString() + " tokens for taking a photo ", "Ok");
            }
            else
            {
                viewModel.CurrentTourist.Tokens += viewModel.Location.PhotoPayment;
                viewModel.CurrentTourist.ColectedTokensCollection.Add(new ColectedTokens()
                {
                    LocationId = viewModel.Location.Id,
                    PhotoTokens = true,
                });
                await DisplayAlert("Congratulations", "You earned " + viewModel.Location.PhotoPayment.ToString() + " tokens for taking a photo ", "Ok");
            }

            TouristLocationDetailView newPage = new TouristLocationDetailView(viewModel.CurrentTourist, viewModel.Location);
            Navigation.InsertPageBefore(newPage, this);
            await Navigation.PopAsync();
        }
    }
}