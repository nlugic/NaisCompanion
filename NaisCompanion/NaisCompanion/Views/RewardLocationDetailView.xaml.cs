using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaisCompanion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RewardLocationDetailView : ContentPage
	{
        private RewardLocationViewModel viewModel;

		public RewardLocationDetailView(Tourist current, RewardLocation location)
		{
			InitializeComponent();

            BindingContext = viewModel = new RewardLocationViewModel(current, location);
		}

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            int id = (sender as Button).TabIndex;
            Reward rew = viewModel.Location.Rewards.Where(r => r.Id == id).FirstOrDefault();

            if (rew.Price > viewModel.CurrentTourist.Tokens)
            {
                DisplayAlert("Error", "You don't have enough tokens to redeem that reward!", "Ok");
                return;
            }

            viewModel.CurrentTourist.Tokens -= rew.Price;
            DisplayAlert("Info", "You redeemed " + rew.Name + " successfully!", "Ok");
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri((sender as Label).Text));
        }
    }
}