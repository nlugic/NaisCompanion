using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaisCompanion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TouristLocationDetailView : ContentPage
	{
        private TouristLocationViewModel viewModel;

		public TouristLocationDetailView(Tourist current, TouristLocation location)
		{
			InitializeComponent();

            BindingContext = viewModel = new TouristLocationViewModel(current, location);
        }

        private void BtnAddPost_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edComment.Text))
            {
                DisplayAlert("Error", "You have to type in something to post!", "Ok");
                return;
            }

            viewModel.Location.Comments.Add(new Comment
            {
                Text = edComment.Text,
                Author = viewModel.CurrentTourist.Username,
                UploadedDate = DateTime.Now.ToString("dd.MM.yyyy. HH:mm")
            });

            TouristLocationDetailView newPage = new TouristLocationDetailView(viewModel.CurrentTourist, viewModel.Location);
            Navigation.InsertPageBefore(newPage, this);
            Navigation.PopAsync();
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

            TouristLocationDetailView newPage = new TouristLocationDetailView(viewModel.CurrentTourist, viewModel.Location);
            Navigation.InsertPageBefore(newPage, this);
            await Navigation.PopAsync();
        }
    }
}