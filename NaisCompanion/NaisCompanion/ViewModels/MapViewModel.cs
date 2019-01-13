using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NaisCompanion.Models;
using NaisCompanion.Views;
using NaisCompanion.Services;
using System.Collections.Generic;

namespace NaisCompanion.ViewModels
{
    // ZA MAPU
    // RLDVM, TLDVM i TDVM imaju po jednu instancu odgovarajuce klase
    public class MapViewModel : TouristViewModel
    {
        public IDataStore<TouristLocation> TouristLocationsDataStore
        {
            get
            {
                return DependencyService.Get<IDataStore<TouristLocation>>() ?? new MockDataStore<TouristLocation>(new List<TouristLocation>
                {
                    new TouristLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 2, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 3, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 4, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 5, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 6, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 7, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 8, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U }
                });
            }
        }

        public IDataStore<RewardLocation> RewardLocationsDataStore
        {
            get
            {
                return DependencyService.Get<IDataStore<RewardLocation>>() ?? new MockDataStore<RewardLocation>(new List<RewardLocation>
                {
                    new RewardLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Url = "www.example.com", PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        Rewards = new List<Reward> { new Reward { Id = 1, Name = "Reward 1", Description = "Description 1", Price = 40, ThumbnailUri = "imager.jpg" } } },
                    new RewardLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Url = "www.example.com", PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        Rewards = new List<Reward> { new Reward { Id = 1, Name = "Reward 1", Description = "Description 1", Price = 40, ThumbnailUri = "imager.jpg" } } },
                    new RewardLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Url = "www.example.com", PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        Rewards = new List<Reward> { new Reward { Id = 1, Name = "Reward 1", Description = "Description 1", Price = 40, ThumbnailUri = "imager.jpg" } } },
                    new RewardLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Url = "www.example.com", PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        Rewards = new List<Reward> { new Reward { Id = 1, Name = "Reward 1", Description = "Description 1", Price = 40, ThumbnailUri = "imager.jpg" } } },
                    new RewardLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Url = "www.example.com", PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        Rewards = new List<Reward> { new Reward { Id = 1, Name = "Reward 1", Description = "Description 1", Price = 40, ThumbnailUri = "imager.jpg" } } }
                });
            }
        }

        public ObservableCollection<TouristLocation> TouristLocations { get; set; }
        public Command LoadTouristLocationsCommand { get; set; }
        public ObservableCollection<RewardLocation> RewardLocations { get; set; }
        public Command LoadRewardLocationsCommand { get; set; }

        public MapViewModel(Tourist currentTourist)
            :base(currentTourist)
        {
            Title = "Tour of Niš";
            TouristLocations = new ObservableCollection<TouristLocation>();
            LoadTouristLocationsCommand = new Command(async () => await ExecuteLoadTouristLocationsCommand());
            RewardLocations = new ObservableCollection<RewardLocation>();
            LoadRewardLocationsCommand = new Command(async () => await ExecuteLoadRewardLocationsCommand());
        }

        private async Task ExecuteLoadTouristLocationsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                TouristLocations.Clear();
                IEnumerable<TouristLocation> items = await TouristLocationsDataStore.GetItemsAsync(true);
                foreach (TouristLocation item in items)
                    TouristLocations.Add(item);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { IsBusy = false; }
        }

        private async Task ExecuteLoadRewardLocationsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RewardLocations.Clear();
                IEnumerable<RewardLocation> items = await RewardLocationsDataStore.GetItemsAsync(true);
                foreach (RewardLocation item in items)
                    RewardLocations.Add(item);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { IsBusy = false; }
        }
    }
}