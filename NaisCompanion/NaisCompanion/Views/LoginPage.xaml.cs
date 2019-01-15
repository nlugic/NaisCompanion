using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using System;
using System.Linq;
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

            Tourist current =  viewModel.TouristDataStore.Where(t => t.Username == viewModel.UserName).FirstOrDefault();
            if (current != null)
                await DisplayAlert("Error", "Username '" + viewModel.UserName + "' is already taken.", "Ok");
            else
            {
                Tourist registered = new Tourist
                {
                    Username = viewModel.UserName,
                    Timeout = viewModel.Timeout
                };
                viewModel.TouristDataStore.Add(registered);

                Navigation.InsertPageBefore(await MapPage.CreateAsync(registered), this);
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

            Tourist current = viewModel.TouristDataStore.Where(t => t.Username == viewModel.UserName).FirstOrDefault();
            if (current == null)
                await DisplayAlert("Error", "Username '" + viewModel.UserName + "' is not found.", "Ok");
            else
            {
                Navigation.InsertPageBefore(await MapPage.CreateAsync(current), this);
                await Navigation.PopAsync().ConfigureAwait(false);
            }

            return await Task.FromResult(true);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.UserName = e.NewTextValue;
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            viewModel.Timeout = (int)Math.Round(e.NewValue);
            lblTimeout.Text = "Duration of your visit: " + viewModel.Timeout.ToString() + " days";
        }
    }
}