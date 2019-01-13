using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace NaisCompanion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
    {
        private MapViewModel viewModel;
        private Plugin.Geolocator.Abstractions.Position CurrentPosition { get; set; }

        public MapPage()
        {
            InitializeComponent();
        }

        public MapPage(Tourist active)
		{
			InitializeComponent();

            BindingContext = viewModel = new MapViewModel(active);
		}

        private async Task<MapPage> InitializeAsync()
        {
            CurrentPosition = await CrossGeolocator.Current.GetPositionAsync();

            map.MoveToRegion(new MapSpan(new Position(CurrentPosition.Latitude, CurrentPosition.Longitude), 0.02, 0.02));
            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

            foreach (TouristLocation tl in viewModel.TouristLocations)
            {
                Pin location = new Pin
                {
                    Address = tl.Name,
                    Label = "You can earn up to " + (tl.VisitedPayment + tl.PostPayment
                        + tl.PhotoPayment).ToString() + " tokens here! Tap to visit!",
                    Position = new Position(tl.Position.Latitude, tl.Position.Longitude),
                    Type = PinType.Place
                };
                location.Clicked += Location_Clicked;
                map.Pins.Add(location);
            }

            foreach (RewardLocation rl in viewModel.RewardLocations)
            {
                Pin reward = new Pin
                {
                    Address = rl.Name,
                    Label = rl.Rewards.Count().ToString() + " rewards for as low as "
                        + (rl.Rewards.Min(r => r.Price)).ToString() + " tokens! Tap to visit!",
                    Position = new Position(rl.Position.Latitude, rl.Position.Longitude),
                    Type = PinType.SavedPin
                };
                reward.Clicked += Reward_Clicked;
                map.Pins.Add(reward);
            }

            return await Task.FromResult<MapPage>(this);
        }

        public static Task<MapPage> CraeateAsync(Tourist active)
        {
            var ret = new MapPage(active);
            return ret.InitializeAsync();
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            // proverimo koji su in range
        }

        private void Location_Clicked(object sender, EventArgs e)
        {
            Pin clicked = sender as Pin;

            Navigation.PushAsync(new TouristLocationDetailView(viewModel.CurrentTourist, viewModel.TouristLocations.Where
            (
                tl => tl.Position.Latitude == clicked.Position.Latitude
                && tl.Position.Longitude == clicked.Position.Longitude).FirstOrDefault())
            );
        }
        
        private void Reward_Clicked(object sender, EventArgs e)
        {
            Pin clicked = sender as Pin;
            Navigation.PushAsync(new RewardLocationDetailView(viewModel.CurrentTourist, viewModel.RewardLocations.Where
            (
                rl => rl.Position.Latitude == clicked.Position.Latitude
                && rl.Position.Longitude == clicked.Position.Longitude).FirstOrDefault())
            );
        }
    }
}