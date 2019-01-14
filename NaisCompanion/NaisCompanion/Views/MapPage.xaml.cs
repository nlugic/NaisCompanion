using NaisCompanion.Models;
using NaisCompanion.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using System.Collections.Generic;

namespace NaisCompanion.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
    {
        const int EARTH_RADIUS_KM = 6371;

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
                Pin location = new CustomPin
                {
                    Address = tl.Name,
                    Label = "You can earn up to " + (tl.VisitedPayment + tl.PostPayment
                        + tl.PhotoPayment).ToString() + " tokens here! Tap to visit!",
                    Position = new Position(tl.Position.Latitude, tl.Position.Longitude),
                    Type = PinType.Place
                };
                CustomCircle circle = new CustomCircle
                {
                    Position = new Position(tl.Position.Latitude, tl.Position.Longitude),
                    Radius = tl.Position.Radius
                };
                location.Clicked += Location_Clicked;
                map.Pins.Add(location);
                map.Circles.Add(circle);
            }

            foreach (RewardLocation rl in viewModel.RewardLocations)
            {
                Pin reward = new RewardPin
                {
                    Address = rl.Name,
                    Label = rl.Rewards.Count().ToString() + " rewards for as low as "
                        + (rl.Rewards.Min(r => r.Price)).ToString() + " tokens! Tap to visit!",
                    Position = new Position(rl.Position.Latitude, rl.Position.Longitude),
                    Type = PinType.Place
                };
                reward.Clicked += Reward_Clicked;
                map.Pins.Add(reward);
            }

            return await Task.FromResult(this);
        }

        public static Task<MapPage> CraeateAsync(Tourist active)
        {
            MapPage ret = new MapPage(active);
            return ret.InitializeAsync();
        }

        private async void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            foreach(TouristLocation touristLocation in viewModel.TouristLocations)
            {
                var m = e.Position;

                if(IsInRegion(e.Position, touristLocation.Position))
                //if(DistanceBetweenPoints(e.Position, touristLocation.Position))                        
                {
                    string question = "Would you like to enter  " + touristLocation.Name + "?";
                    string action = await DisplayActionSheet(question, "Cancel", null, "Enter");

                    await Navigation.PushAsync(new TouristLocationDetailView(viewModel.CurrentTourist, viewModel.TouristLocations.Where
                    (
                        tl => tl.Position.Latitude == touristLocation.Position.Latitude
                        && tl.Position.Longitude == touristLocation.Position.Longitude).FirstOrDefault())
                    ).ConfigureAwait(true);
                }
            }

            return;
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

        private bool IsInRegion(Plugin.Geolocator.Abstractions.Position current, Location goalPosition)
        {
            if (current.Latitude >= goalPosition.Latitude - goalPosition.Radius && current.Latitude <= goalPosition.Latitude + goalPosition.Radius
                && current.Longitude >= goalPosition.Longitude - goalPosition.Radius && current.Longitude <= goalPosition.Longitude + goalPosition.Radius)
                return true;
            else
                return false;
        }

        private Distance DistanceBetweenPoints(Position p1, Position p2)
        {
            double latitude1 = DegreesToRadians(p1.Latitude);
            double latitude2 = DegreesToRadians(p2.Latitude);
            double longitude1 = DegreesToRadians(p1.Longitude);
            double longitude2 = DegreesToRadians(p2.Longitude);

            double distance = Math.Sin((latitude2 - latitude1) / 2.0);
            distance *= distance;

            double intermediate = Math.Sin((longitude2 - longitude1) / 2.0);
            intermediate *= intermediate;

            distance = distance + Math.Cos(latitude1) * Math.Cos(latitude2) * intermediate;
            distance = 2 * EARTH_RADIUS_KM * Math.Atan2(Math.Sqrt(distance), Math.Sqrt(1 - distance));

            return Distance.FromKilometers(distance);
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}