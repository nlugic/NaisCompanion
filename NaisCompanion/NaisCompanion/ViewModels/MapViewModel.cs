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
    // BVM mora da ima trenutno ulogovanog tourista
    // opciono bez BVM-a, za svaku stranicu ceo VM
    // MVM ima listu reward i tourist lokacija, kao i trenutnog tourista
    // RLDVM, TLDVM i TDVM imaju po jednu instancu odgovarajuce klase
    public class MapViewModel : BaseViewModel
    {
        public IDataStore<TouristLocation> TouristLocationsDataStore
        {
            get
            {
                return DependencyService.Get<IDataStore<TouristLocation>>() ?? new MockDataStore<TouristLocation>(new List<TouristLocation>
                {
                    new TouristLocation { Id = 1, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 2, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 3, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 4, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 5, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 6, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 7, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 8, Latitude = 50.0, Longitude = 45.0, Radius = 0.00001,
                        Name = "location1", Description = "description1", Tags = new List<string> { "tag1", "tag2", "tag3" },
                        Photos = new List<Image> { new Image { Source = "image1.jpg" }, new Image { Source = "image2.jpg" }, new Image { Source = "image3.jpg" } },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U }
                });
            }
        }

        public ObservableCollection<TouristLocation> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MapViewModel()
        {
            Title = "Map";
            Items = new ObservableCollection<TouristLocation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, TouristLocation>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as TouristLocation;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}