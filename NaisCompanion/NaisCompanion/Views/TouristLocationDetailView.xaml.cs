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