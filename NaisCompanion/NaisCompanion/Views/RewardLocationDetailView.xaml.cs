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
	public partial class RewardLocationDetailView : ContentPage
	{
        private RewardLocationViewModel viewModel;

		public RewardLocationDetailView(Tourist current, RewardLocation location)
		{
			InitializeComponent();

            BindingContext = viewModel = new RewardLocationViewModel(current, location);
		}
	}
}