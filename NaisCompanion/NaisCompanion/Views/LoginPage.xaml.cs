using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NaisCompanion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private LoginViewModel viewModel;

		public LoginPage()
		{
			InitializeComponent();

            BindingContext = viewModel = new LoginViewModel
            (
                new Command(async () => await BeginTour()),
                new Command(async () => await ContinueTour())
            );
        }

        private async Task<bool> BeginTour()
        {
            if (string.IsNullOrWhiteSpace(viewModel.UserName))
            {
                await DisplayAlert("Error", "You have to enter a username!", "Ok");
                return await Task.FromResult(false);
            }

            Tourist current = await viewModel.TouristDataStore.GetTouristAsync(viewModel.UserName);
            if (current != null)
                await DisplayAlert("Error", "Username '" + viewModel.UserName + "' is already taken.", "Ok");
            else
            {
                Tourist registered = new Tourist
                {
                    Username = viewModel.UserName,
                    Timeout = viewModel.Timeout
                };
                await viewModel.TouristDataStore.AddItemAsync(registered);

                Navigation.InsertPageBefore(new MainPage(registered), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }

            return await Task.FromResult(true);
        }

        private async Task<bool> ContinueTour()
        {
            if (string.IsNullOrWhiteSpace(viewModel.UserName))
            {
                await DisplayAlert("Error", "You have to enter a username!", "Ok");
                return await Task.FromResult(false);
            }

            Tourist current = await viewModel.TouristDataStore.GetTouristAsync(viewModel.UserName);
            if (current == null)
                await DisplayAlert("Error", "Username '" + viewModel.UserName + "' is not found.", "Ok");
            else
            {
                Navigation.InsertPageBefore(new MainPage(current), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }

            return await Task.FromResult(true);
        }
    }
}