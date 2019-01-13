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
	public partial class MapPage : ContentPage
    {
        private MapViewModel viewModel;

        public MapPage (Tourist active)
		{
			InitializeComponent ();

            BindingContext = viewModel = new MapViewModel(active);
		}
	}
}