using NaisCompanion.Models;
using NaisCompanion.ViewModels;
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
	}
}