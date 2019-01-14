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
using Plugin.Geolocator.Abstractions;

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
          
            map.MoveToRegion(new MapSpan(new Xamarin.Forms.Maps.Position(CurrentPosition.Latitude, CurrentPosition.Longitude), 0.02, 0.02));

            foreach (TouristLocation tl in viewModel.TouristLocations)
            {
                Pin location = new CustomPin
                {
                    Address = tl.Name,
                    Label = "You can earn up to " + (tl.VisitedPayment + tl.PostPayment
                        + tl.PhotoPayment).ToString() + " tokens here! Tap to visit!",
                    Position = new Xamarin.Forms.Maps.Position(tl.Position.Latitude, tl.Position.Longitude),
                    Type = PinType.Place
                };
                CustomCircle circle = new CustomCircle
                {
                    Position = new Xamarin.Forms.Maps.Position(tl.Position.Latitude, tl.Position.Longitude),
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
                    Position = new Xamarin.Forms.Maps.Position(rl.Position.Latitude, rl.Position.Longitude),
                    Type = PinType.Place
                };
                reward.Clicked += Reward_Clicked;
                map.Pins.Add(reward);
            }

            if (CrossGeolocator.Current.IsListening)
                return await Task.FromResult(this);
            bool x = await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 15), 0, true, null);
            CrossGeolocator.Current.PositionChanged += PositionChanged;

            return await Task.FromResult(this);
        }

        public static Task<MapPage> CraeateAsync(Tourist active)
        {
            MapPage ret = new MapPage(active);
            return ret.InitializeAsync();
        }

        #region EventListeners
        private async void PositionChanged(object sender, PositionEventArgs e)
        {
            foreach (TouristLocation touristLocation in viewModel.TouristLocations)
            {
                var m = e.Position;

                if (Distance(m.Latitude, m.Longitude, touristLocation.Position.Latitude, touristLocation.Position.Longitude) < (touristLocation.Position.Radius*0.001))
                {
                    if (!CrossGeolocator.Current.IsListening)
                        return;

                    await CrossGeolocator.Current.StopListeningAsync();

                    CrossGeolocator.Current.PositionChanged -= PositionChanged;

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
        #endregion

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (CrossGeolocator.Current.IsListening)
                return;

            bool x = await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 15), 0, true, null);
            CrossGeolocator.Current.PositionChanged += PositionChanged;
        }

        private double Distance(double lat1, double lon1, double lat2, double lon2, char unit='K')
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                return (dist);
            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}