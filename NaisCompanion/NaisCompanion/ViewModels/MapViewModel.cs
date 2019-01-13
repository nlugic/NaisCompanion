using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using NaisCompanion.Models;
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
                    new TouristLocation { Id = 1, Latitude = 43.319167, Longitude = 21.896111, Radius = 0.00010,
                        Name = "Red Cross Nazi Concentration Camp", Description = "One of the best-preserved Nazi camps in Europe, the deceptively named Red Cross (named after the adjacent train station) held about 30,000 Serbs, Roma, Jews and Partisans during the German occupation of Serbia (1941–45). Harrowing displays tell their stories, and those of the prisoners who attempted to flee in the biggest-ever breakout from a concentration camp. This was a transit camp so few were killed on the premises – they were taken to Bubanj, or on to Auschwitz, Dachau etc.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 30U, MinVisitDuration = 30U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 2, Latitude = 43.3122, Longitude = 21.9238, Radius = 0.00010,
                        Name = "Skull Tower", Description = "The Skull Tower (Ćele Kula) is a monument unique in the world, visited by more than 30.000 people each year. It is the tower made of human skulls, built after the battle for liberation of Nis in 1809. This horrific monument was built as a warning to anyone rising against the Ottoman Empire. Originaly there were 952 skulls built into the tower , today there are 59 skulls remain and they still illustrate all the horror of the original tower.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 15U, MinVisitDuration = 15U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 3, Latitude = 43.3150016, Longitude = 21.8955244, Radius = 0.00001,
                        Name = "Holy Trinity Cathedral", Description = "Second only in size to Belgrade's St Sava Temple, this huge Orthodox cathedral, completely restored after being destroyed in a fire in 2001, was consecrated after the liberation from Turkish rule in 1878. The church is a curious mix of Byzantine, Oriental and Western architectural styles and famous for the iconostasis with 48 paintings by Serbian artist Đorđe Krstić – to say nothing of its elaborate, colourful, floor-to-ceiling paintwork.", Tags = new List<string> { "Historic", "Religious", },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 15U, MinVisitDuration = 15U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 4, Latitude = 43.3225905, Longitude = 21.892538, Radius = 0.00001,
                        Name = "Niš Fortress", Description = "Though its current incarnation was built by the Turks in the 18th century, there have been forts on this site since ancient Roman times. Today it's a sprawling recreational area with restaurants, cafes, market stalls and ample space for moseying, as well as the 16th-century Bali-beg Mosque. The fortress hosts the Nišville International Jazz Festival each August and Nišomnia, featuring rock and electro acts, in September. The city's main pedestrian boulevard, Obrenovićeva, stretches before the citadel.", Tags = new List<string> { "Historic", "Culture", "Landmark" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 50U, MinVisitDuration = 60U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 5, Latitude = 43.3201466, Longitude = 21.8927116, Radius = 0.00001,
                        Name = "Monument to the Liberators of Nis", Description = "The Monument to the Liberators of Niš (1937) with its beauty and size takes the central part of King Milan Square, the central square in Niš. This monument is regarded as one of the most important works of art of the Yugoslavian sculpture art, and its author is AntunAugustunčić, a well-known Croatian and Yugoslavian sculptor. At the top of the monument is a horse rider with a flag that symbolizes the arrival of freedom, and the central part represent StevanSinđelić in the Battle of Čegar and KoleRašić calling people from Niš for uprising.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 2U, MinVisitDuration = 2U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 6, Latitude = 43.3060353, Longitude = 21.8767311, Radius = 0.00001,
                        Name = "Bubanj Memorial Park", Description = "During World War II, German Nazis shot more than ten thousand residents of Nis and Southeast Serbia on Bubanj hill. According to testimonies of witnesses and the records of the War Crimes Committee, which investigated events at Bubanj after the liberation, it is estimated that more than 10.000 people were executed at this location during the war. Describing this horrifying place, the Committee stated that ditches had been found 20 to 50 meters long with human corpses, and there were several rows of victims in most of them, and there had been also evidence of burning victims in some of them. During the retreat, German succeeded to destroy almost all the documents about the concentration camp and the number of executed people at Bubanj", Tags = new List<string> { "Historic", "Monument", "Landmark" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 40U, MinVisitDuration = 60U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 7, Latitude = 43.3084931, Longitude = 21.9461165, Radius = 0.00001,
                        Name = "Mediana", Description = "Mediana was built built between III and the beginning of IV century on the left bank of the Nišava River, beside one of the most important roads, Via militaris. It was located between urban Naissus and thermal springs of Niska Banja and extended over the area of 40 hectares.During the 4th century, overpopulated Naissus, surrounded by walls and towers, ceased to be an attractive place for life for its wealthy citizens, so they spent most of their time in their estates in Mediana.They built there new or restored old villas which served for rest and pleasure.Over time, the villas changed their purpose, and from the places for temporary stay, they became places of luxury life outside the city.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 15U, MinVisitDuration = 15U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 8, Latitude = 43.3179461, Longitude = 21.8953352, Radius = 0.00001,
                        Name = "The Monument of Stevan Sremac and Kalca", Description = "The bronze sculpture depicting the writer, the hunter Kalca, and his loyal companion Capa, his dog, is the work of Ivan Felker, a sculptor from Belgrade. In his novels’’Ivkova slava’’ and ’’Zona Zamfirova’’, Stevan Sremec described virtues, habits, passions and speech of the people from Nis. After these books had been published, written in authentic dialect, Sremac established a new trend in Serbia – writting in the colloquial language.", Tags = new List<string> { "Historic", "Monument", "Culture" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 2U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 9, Latitude = 43.3223311, Longitude = 21.8976115, Radius = 0.00001,
                        Name = "Saban Bajramovic Monument", Description = "A monument to Saban Bajramovic, a well-known Romani composer and singer born in Niš, is located at the top of the amphitheater at the Nišava quay. It is a bronze life-size statue made by Niš sculptor Vlada Ašanin and it was placed there in 2010, on the day of the beginning of the “Nišville Jazz Festival”. About the impact that Saban Bajramovic had on the music world speaks the fact that the American Time magazine put him on the list of the ten most influential blues singers in the world. He left behind more than 700 songs and 20 albums, and the song “Gelem, Gelem” in his interpretation was chosen as the official anthem of all Romani.", Tags = new List<string> { "Historic", "Monument", "Culture" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 2U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 10, Latitude = 43.3181532, Longitude = 21.8912093, Radius = 0.00001,
                        Name = "King Aleksandar Monument", Description = "The original monument to King Aleksandar I Karađorđević was erected in 1939, but it was removed and destroyed at the beginning of Communist rule in 1946. The new monument to King Aleksandar I Karađorđević was erected in 2004 in honor of the ruler who was the creator of the idea of the Kingdom of Serbs, Croats and Slovenes. The monument is the work of Belgrade sculptor Zoran Ivanović", Tags = new List<string> { "Historic", "Monument", "Landmark" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 11, Latitude = 43.3248171, Longitude = 21.8947675, Radius = 0.00001,
                        Name = "Bali-Begova Mosque", Description = "One of the oldest muslim object on Blakan. The location is great because it is located in the very center of the Roman excavations, so the remains of the Roman culture can be seen next to the mosque. ", Tags = new List<string> { "Historic", "Religious", "Landmark" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 5U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 12, Latitude = 43.3661258, Longitude = 21.9334674, Radius = 0.00001,
                        Name = "Cegar Monument", Description = "At the place where the trench of Stevan Sindjelic and his soldiers was located, a monument was erected in the shape of a tower – a symbol of the military fortification (1927). The designer of the monument was Djulijan Djupon, a Russian immigrant from Nis, and a bronze bust of Stevan Sindjelic, which is placed in the tower, was made by Yugoslavian sculptor Slavko Miletic. Today, this monument symbolizes the heroism of Stevan Sinđelić and evokes the memory of the fearless fight for freedom.", Tags = new List<string> { "Historic", "Monument", "Landmark" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 30U, MinVisitDuration = 30U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 13, Latitude = 43.3206326, Longitude = 21.8930495, Radius = 0.00001,
                        Name = "The Symphony Orchestra", Description = "Nis Symphony Orchestra, established in 1953, is one of the most important cultural institutions in Serbia and the only philharmonic orchestra in the country outside Belgrade. The repertoire in cludes works of art from the Baroque to 20th century music, including vocal and instrumental pieces, operas, and chamber music. Nis Symphony Orchestra is the founder and organizer of Nis Classical Music Festival (NIMUS), an event with 35 years of tradition.", Tags = new List<string> { "Culture" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 5U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 14, Latitude = 43.3196633, Longitude = 21.8995759, Radius = 0.00001,
                        Name = "The National Theater", Description = "Nis was one of the first cities to become part of the history of the Serbian theatre. In 1883, the first act was staged in the city to celebrate the wedding anniversary of King Milan and Queen Natalija Obrenovic. The first theatrical group, “Sindjelic”, was founded on 11 March 1887. In the last 111 years, many important names of the Serbian and Yugoslav theatre have appeared on this stage. Since the foundation, over 10,000 plays have been staged, seen by more than 6 million people, in Nis theatre but also in guest appearances in the country and abroad. Nis National Theatre cherishes the national repertoire, but also presents international classic drama and contemporary plays.", Tags = new List<string> { "Culture" },
                        PhotosUri = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" },
                        VisitedPayment = 5U, MinVisitDuration = 5U, PostPayment = 5U, PhotoPayment = 5U },
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