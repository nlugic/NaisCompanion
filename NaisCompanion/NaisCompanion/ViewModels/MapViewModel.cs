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
                    new TouristLocation { Id = 1, Latitude = 43.319167, Longitude = 21.896111, Radius = 0.00010,
                        Name = "Red Cross Nazi Concentration Camp", Description = "One of the best-preserved Nazi camps in Europe, the deceptively named Red Cross (named after the adjacent train station) held about 30,000 Serbs, Roma, Jews and Partisans during the German occupation of Serbia (1941–45). Harrowing displays tell their stories, and those of the prisoners who attempted to flee in the biggest-ever breakout from a concentration camp. This was a transit camp so few were killed on the premises – they were taken to Bubanj, or on to Auschwitz, Dachau etc.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> { "https://media-cdn.tripadvisor.com/media/photo-s/02/2b/e9/d6/view-over-compound-from.jpg",
                                                       "https://ak.jogurucdn.com/media/image/p25/place-2015-07-31-6-Redcrossnaziconcentrationcampfefe578cc8bdc18b05b871c6ab165217.jpg",
                                                       "http://www.kathmanduandbeyond.com/wp-content/uploads/2017/05/Crveni-Krst-Red-Cross-Concentration-Camp-Nis-Serbia-6.jpg",
                                                       "https://i1.wp.com/followthesisters.com/wp-content/uploads/2016/03/The-monument-of-the-soviet-army-in-front-of-the-concentration-camp-in-Nis.jpg"
                                                     },
                        VisitedPayment = 30U, MinVisitDuration = 30U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 2, Latitude = 43.3122, Longitude = 21.9238, Radius = 0.00010,
                        Name = "Skull Tower", Description = "The Skull Tower (Ćele Kula) is a monument unique in the world, visited by more than 30.000 people each year. It is the tower made of human skulls, built after the battle for liberation of Nis in 1809. This horrific monument was built as a warning to anyone rising against the Ottoman Empire. Originaly there were 952 skulls built into the tower , today there are 59 skulls remain and they still illustrate all the horror of the original tower.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> { "https://st3.depositphotos.com/3933163/18204/i/1600/depositphotos_182048426-stock-photo-building-with-skull-tower-in.jpg",
                                                       "https://image.shutterstock.com/z/stock-photo-skull-tower-nis-serbia-195552968.jpg",
                                                       "https://www.timetravelturtle.com/wp-content/uploads/2013/07/Serbia-2013-401_new.jpg",
                                                       "https://upload.wikimedia.org/wikipedia/commons/e/ed/%C4%86ele-kula_-_Stevan_Sin%C4%91eli%C4%87_skull.JPG"
                                                     },
                        VisitedPayment = 15U, MinVisitDuration = 15U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 3, Latitude = 43.3150016, Longitude = 21.8955244, Radius = 0.00001,
                        Name = "Holy Trinity Cathedral", Description = "Second only in size to Belgrade's St Sava Temple, this huge Orthodox cathedral, completely restored after being destroyed in a fire in 2001, was consecrated after the liberation from Turkish rule in 1878. The church is a curious mix of Byzantine, Oriental and Western architectural styles and famous for the iconostasis with 48 paintings by Serbian artist Đorđe Krstić – to say nothing of its elaborate, colourful, floor-to-ceiling paintwork.", Tags = new List<string> { "Historic", "Religious", },
                        PhotosUri = new List<string> {  "https://ak.jogurucdn.com/media/image/p25/place-2015-07-31-5-Holytrinitycathedral6ef60e8fb8165df3d97013453dca736c.jpg",
                                                        "https://c1.staticflickr.com/7/6097/6226715829_d0e8a52bf9_b.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/4/47/Saborna_crkva_u_Nisu3.jpg",
                                                        "https://c1.staticflickr.com/7/6170/6175560217_a506313475_b.jpg"
                                                     },
                        VisitedPayment = 15U, MinVisitDuration = 15U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 4, Latitude = 43.3225905, Longitude = 21.892538, Radius = 0.00001,
                        Name = "Niš Fortress", Description = "Though its current incarnation was built by the Turks in the 18th century, there have been forts on this site since ancient Roman times. Today it's a sprawling recreational area with restaurants, cafes, market stalls and ample space for moseying, as well as the 16th-century Bali-beg Mosque. The fortress hosts the Nišville International Jazz Festival each August and Nišomnia, featuring rock and electro acts, in September. The city's main pedestrian boulevard, Obrenovićeva, stretches before the citadel.", Tags = new List<string> { "Historic", "Culture", "Landmark" },
                        PhotosUri = new List<string> {  "https://cdn.thecrazytourist.com/wp-content/uploads/2018/02/ccimage-shutterstock_741397042.jpg",
                                                        "http://www.avanturista.co/en/wp-content/uploads/sites/5/2017/05/Crop-Ruins-in-Nis-Fortress.jpg",
                                                        "https://media2.trover.com/T/58d63e80f2b7d3078000c161/fixedw_large_4x.jpg",
                                                        "https://previews.123rf.com/images/andreyshevchenko/andreyshevchenko1511/andreyshevchenko151100139/48183595-summer-theater-in-nis-fortress-serbia.jpg"
                                                     },
                        VisitedPayment = 50U, MinVisitDuration = 60U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 5, Latitude = 43.3201466, Longitude = 21.8927116, Radius = 0.00001,
                        Name = "Monument to the Liberators of Niš", Description = "The Monument to the Liberators of Niš (1937) with its beauty and size takes the central part of King Milan Square, the central square in Niš. This monument is regarded as one of the most important works of art of the Yugoslavian sculpture art, and its author is AntunAugustunčić, a well-known Croatian and Yugoslavian sculptor. At the top of the monument is a horse rider with a flag that symbolizes the arrival of freedom, and the central part represent StevanSinđelić in the Battle of Čegar and KoleRašić calling people from Niš for uprising.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> {  "https://upload.wikimedia.org/wikipedia/commons/6/60/Monument_to_Liberators_-_Nish.jpg",
                                                        "https://scontent-frt3-2.cdninstagram.com/vp/372354342d9c50808d120ed2e8cb51d9/5C7FC1C1/t51.2885-15/e35/44230424_306976493242987_7434175780457807872_n.jpg"
                                                     },
                        VisitedPayment = 2U, MinVisitDuration = 2U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 6, Latitude = 43.3060353, Longitude = 21.8767311, Radius = 0.00001,
                        Name = "Bubanj Memorial Park", Description = "During World War II, German Nazis shot more than ten thousand residents of Nis and Southeast Serbia on Bubanj hill. According to testimonies of witnesses and the records of the War Crimes Committee, which investigated events at Bubanj after the liberation, it is estimated that more than 10.000 people were executed at this location during the war. Describing this horrifying place, the Committee stated that ditches had been found 20 to 50 meters long with human corpses, and there were several rows of victims in most of them, and there had been also evidence of burning victims in some of them. During the retreat, German succeeded to destroy almost all the documents about the concentration camp and the number of executed people at Bubanj", Tags = new List<string> { "Historic", "Monument", "Landmark" },
                        PhotosUri = new List<string> {  "http://visitnis.com/wp-content/uploads/2017/09/spomenik-bubanj-bubanj-memorial-site-1170x521.jpg",
                                                        "https://assets.atlasobscura.com/media/W1siZiIsInVwbG9hZHMvcGxhY2VfaW1hZ2VzL2M4ZGZmNzk3ZDM4YTFmZDY1MF9CdWJhbmotUGVzbmljZV9zYV9hbWZpdGVhdHJhXzIuanBnIl0sWyJwIiwidGh1bWIiLCJ4MzkwPiJdLFsicCIsImNvbnZlcnQiLCItcXVhbGl0eSA4MSAtYXV0by1vcmllbnQiXV0/Bubanj-Pesnice_sa_amfiteatra_2.jpg",
                                                        "http://www.monumentalism.net/wp-content/uploads/2018/07/RS-Nis-Bubanj-1.jpg"
                                                     },
                        VisitedPayment = 40U, MinVisitDuration = 60U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 7, Latitude = 43.3084931, Longitude = 21.9461165, Radius = 0.00001,
                        Name = "Mediana", Description = "Mediana was built built between III and the beginning of IV century on the left bank of the Nišava River, beside one of the most important roads, Via militaris. It was located between urban Naissus and thermal springs of Niska Banja and extended over the area of 40 hectares.During the 4th century, overpopulated Naissus, surrounded by walls and towers, ceased to be an attractive place for life for its wealthy citizens, so they spent most of their time in their estates in Mediana.They built there new or restored old villas which served for rest and pleasure.Over time, the villas changed their purpose, and from the places for temporary stay, they became places of luxury life outside the city.", Tags = new List<string> { "Historic", "Monument" },
                        PhotosUri = new List<string> {
                                                        "http://visitnis.com/wp-content/uploads/2017/09/arheolosko-nalaziste-medijana-archeological-sites-mediana.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Medijana1.JPG/1200px-Medijana1.JPG",
                                                        "http://www.panacomp.net/wp-content/uploads/2015/09/featured-mediana2-dragan-miletic-photo.jpg",
                                                        "https://www.andrey-andreev.com/wp-content/uploads/2016/11/IMGP4564.jpg"
                                                     },
                        VisitedPayment = 15U, MinVisitDuration = 15U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 8, Latitude = 43.3179461, Longitude = 21.8953352, Radius = 0.00001,
                        Name = "The Monument of Stevan Sremac and Kalca", Description = "The bronze sculpture depicting the writer, the hunter Kalca, and his loyal companion Capa, his dog, is the work of Ivan Felker, a sculptor from Belgrade. In his novels’’Ivkova slava’’ and ’’Zona Zamfirova’’, Stevan Sremec described virtues, habits, passions and speech of the people from Nis. After these books had been published, written in authentic dialect, Sremac established a new trend in Serbia – writting in the colloquial language.", Tags = new List<string> { "Historic", "Monument", "Culture" },
                        PhotosUri = new List<string> {
                                                        "https://pbs.twimg.com/media/DVsCLJqXUAAn2Kr.jpg",
                                                        "https://scontent-atl3-1.cdninstagram.com/vp/7f9382310508ad39aace0e88474adecd/5C735E35/t51.2885-15/e35/43915028_2200408133362759_3303969747302340926_n.jpg"
                                                     },
                        VisitedPayment = 5U, MinVisitDuration = 2U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 9, Latitude = 43.3223311, Longitude = 21.8976115, Radius = 0.00001,
                        Name = "Saban Bajramovic Monument", Description = "A monument to Saban Bajramovic, a well-known Romani composer and singer born in Niš, is located at the top of the amphitheater at the Nišava quay. It is a bronze life-size statue made by Niš sculptor Vlada Ašanin and it was placed there in 2010, on the day of the beginning of the “Nišville Jazz Festival”. About the impact that Saban Bajramovic had on the music world speaks the fact that the American Time magazine put him on the list of the ten most influential blues singers in the world. He left behind more than 700 songs and 20 albums, and the song “Gelem, Gelem” in his interpretation was chosen as the official anthem of all Romani.", Tags = new List<string> { "Historic", "Monument", "Culture" },
                        PhotosUri = new List<string> {
                                                        "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/%C5%A0aban_Bajramovi%C4%87.IMG_3786.jpg/2448px-%C5%A0aban_Bajramovi%C4%87.IMG_3786.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/%C5%A0aban_Bajramovi%C4%87.IMG_3785.jpg/2448px-%C5%A0aban_Bajramovi%C4%87.IMG_3785.jpg"          
                                                     },
                        VisitedPayment = 5U, MinVisitDuration = 2U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 10, Latitude = 43.3181532, Longitude = 21.8912093, Radius = 0.00001,
                        Name = "King Aleksandar Monument", Description = "The original monument to King Aleksandar I Karađorđević was erected in 1939, but it was removed and destroyed at the beginning of Communist rule in 1946. The new monument to King Aleksandar I Karađorđević was erected in 2004 in honor of the ruler who was the creator of the idea of the Kingdom of Serbs, Croats and Slovenes. The monument is the work of Belgrade sculptor Zoran Ivanović", Tags = new List<string> { "Historic", "Monument", "Landmark" },
                        PhotosUri = new List<string> {
                                                        "http://wheretoserbia.com/wp-content/uploads/2018/08/King-Aleksandar-The-Unifier-Monument-in-Ni%C5%A1.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/1/1f/Trg_KA-Konjanik.jpg",
                                                        "https://3.bp.blogspot.com/-rJaIjeee9T0/V9Ny_sq2QAI/AAAAAAAALAU/nu1JCXD82j8WNLYmeOz0ao2e9nl0YoMdQCLcB/s1600/king_alexander_of_yugoslavia_assassination_1934.jpg"
                                                     },
                        VisitedPayment = 5U, MinVisitDuration = 10U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 11, Latitude = 43.3248171, Longitude = 21.8947675, Radius = 0.00001,
                        Name = "Bali-Begova Mosque", Description = "One of the oldest muslim object on Blakan. The location is great because it is located in the very center of the Roman excavations, so the remains of the Roman culture can be seen next to the mosque. ", Tags = new List<string> { "Historic", "Religious", "Landmark" },
                        PhotosUri = new List<string> {
                                                        "https://upload.wikimedia.org/wikipedia/commons/b/bf/Bali_begova_dzamija_0542.JPG",
                                                        "https://i.pinimg.com/originals/20/45/d5/2045d54550a135bfbd332cebee1b9615.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/7/7a/Bali_begova_dzamija1.jpg"
                                                     },
                        VisitedPayment = 5U, MinVisitDuration = 5U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 12, Latitude = 43.3661258, Longitude = 21.9334674, Radius = 0.00001,
                        Name = "Cegar Monument", Description = "At the place where the trench of Stevan Sindjelic and his soldiers was located, a monument was erected in the shape of a tower – a symbol of the military fortification (1927). The designer of the monument was Djulijan Djupon, a Russian immigrant from Nis, and a bronze bust of Stevan Sindjelic, which is placed in the tower, was made by Yugoslavian sculptor Slavko Miletic. Today, this monument symbolizes the heroism of Stevan Sinđelić and evokes the memory of the fearless fight for freedom.", Tags = new List<string> { "Historic", "Monument", "Landmark" },
                        PhotosUri = new List<string> {
                                                        "http://media.discoversoutheastserbia.com/2016/10/spomenik-na-cegru-3.jpg",
                                                        "https://tripedia.info/wp-content/uploads/2017/07/800px-Spomenik_na_brdu_Cegar.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/0/03/%C4%8Cegar.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/6/6c/%C4%8Cegar%2C_bista_Stevana_Sin%C4%91eli%C4%87a.jpg"
                                                     },
                        VisitedPayment = 30U, MinVisitDuration = 30U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 13, Latitude = 43.3206326, Longitude = 21.8930495, Radius = 0.00001,
                        Name = "The Symphony Orchestra", Description = "Nis Symphony Orchestra, established in 1953, is one of the most important cultural institutions in Serbia and the only philharmonic orchestra in the country outside Belgrade. The repertoire in cludes works of art from the Baroque to 20th century music, including vocal and instrumental pieces, operas, and chamber music. Nis Symphony Orchestra is the founder and organizer of Nis Classical Music Festival (NIMUS), an event with 35 years of tradition.", Tags = new List<string> { "Culture" },
                        PhotosUri = new List<string> {
                                                        "http://visitnis.com/wp-content/uploads/2017/09/simfonijski-orkerstar-nis-thesymphony-orchestra-nis-1170x521.jpg",
                                                        "http://www.artf.ni.ac.rs/eng/wp-content/uploads/sites/5/2016/08/DSC0201_resize.jpg",
                                                        "http://visitnis.com/wp-content/uploads/2017/09/main.jpg"
                                                     },
                        VisitedPayment = 5U, MinVisitDuration = 5U, PostPayment = 5U, PhotoPayment = 5U },
                    new TouristLocation { Id = 14, Latitude = 43.3196633, Longitude = 21.8995759, Radius = 0.00001,
                        Name = "The National Theater", Description = "Nis was one of the first cities to become part of the history of the Serbian theatre. In 1883, the first act was staged in the city to celebrate the wedding anniversary of King Milan and Queen Natalija Obrenovic. The first theatrical group, “Sindjelic”, was founded on 11 March 1887. In the last 111 years, many important names of the Serbian and Yugoslav theatre have appeared on this stage. Since the foundation, over 10,000 plays have been staged, seen by more than 6 million people, in Nis theatre but also in guest appearances in the country and abroad. Nis National Theatre cherishes the national repertoire, but also presents international classic drama and contemporary plays.", Tags = new List<string> { "Culture" },
                        PhotosUri = new List<string> {
                                                        "http://visitnis.com/wp-content/uploads/2018/01/narodno-pozoriste-nis-the-national-theater-nis-1170x521.jpg",
                                                        "https://upload.wikimedia.org/wikipedia/commons/f/fb/Narodno_pozoriste_Nis.jpg"
                                                     },
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
                    new RewardLocation { Id = 1, Latitude = 43.3188315, Longitude = 21.8931294, Radius = 0.00001,
                        Name = "Stambolija House", Description = "As in every trip to a distant destination that you visit for the first time - the first step was not easy, and the final point, covered in mist, seemed somehow uncertain and far. It was the mornig fog, not as thick as pea soup, but more like cloth cut into strips, it covered the street of Nikola Pašić in the center of Niš and hugged the old Stambolijski’s house. It seemed the perfect scenery for our first entry into the facility, one and a half century old, not in an enviable condition, somewhat dilapidated, like an old man with a cane on the wooden bench sitting in front of it and watching passers-by on the street. It was exactly the man we expected to see in front of it, Todor Stanković Stambolija, in a white shirt of coarse fabric with colorful wide belt around his waist, pulling the watch on a chain from his pocket vest and wondering if it is time for the morning coffee.", Tags = new List<string> { "Food", "Party" },
                        Url = "http://www.restoranstambolijski.rs",
                        PhotosUri = new List<string> {
                            "http://www.niscafe.com/v2/wp-content/uploads/2015/04/kuca_stambolijskih.jpg",
                            "http://visitnis.com/wp-content/uploads/2017/12/21765662-1538870289468345-8766451466295668455-o-1170x520.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 1, Name = "Mini Voucher", Description = "Voucher 300 din.", Price = 50, ThumbnailUri = "https://upload.wikimedia.org/wikipedia/commons/f/f1/Logo_for_300_Entertainment.png" },
                            new Reward { Id = 2, Name = "Big Voucher", Description = "Voucher 700 din.", Price = 100, ThumbnailUri = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/NC_700.svg/600px-NC_700.svg.png" },
                            new Reward { Id = 3, Name = "Extra Voucher", Description = "Voucher 1000 din.", Price = 150, ThumbnailUri = "https://storage.googleapis.com/opensea-prod.appspot.com/0x323a3e1693e7a0959f65972f3bf2dfcb93239dfe/1000.png" }
                        }
                    },
                    new RewardLocation { Id = 2, Latitude = 43.3179402, Longitude = 21.8946318, Radius = 0.00001,
                        Name = "Cezar Fast Food", Description = "Food at Cezar Fast Food restaurants is carefully prepared, and as the right hosts we only choose the best ingredients and we try to have a diverse range of products. It’s important for us to maintain the quality and safety of our products, so we constantly take care of all the raw materials that we use and therefore the final product that we serve to you. What makes our products special is a unique way of preparation and special recipes, and that all our doughs are additivesfree.", Tags = new List<string> { "Food" },
                        Url = "https://www.cezar.rs",
                        PhotosUri = new List<string> {
                            "https://www.cezar.rs/Theme/Cezar/images/Logo/cezar-logo-share.jpg",
                            "http://www.kudanaklopu.com/test_knk/wp-content/uploads/2014/10/0345-nis-brza-hrana-cezar.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 4, Name = "Small pizza discount", Description = "Discount on all small pizzas", Price = 30, ThumbnailUri = "http://venicciitalian.com/wp-content/uploads/2016/07/cheese_pizza.jpg" },
                            new Reward { Id = 5, Name = "Gratis pizza", Description = "Gratis Margarita or Capricciosa pizza", Price = 60, ThumbnailUri = "http://papamarios.com/wp-content/uploads/2014/03/2_small_pizzas.jpg" }
                        }
                    },
                    new RewardLocation { Id = 3, Latitude = 43.3225167, Longitude = 21.901961, Radius = 0.00001,
                        Name = "Nislijska Mehana", Description = "Kafana “Nišlijska Mehana” is located in the very center of Niš and started to work on the 8th of March 1996. Already that summer it gained high popularity among locals of Niš and till now has the status of most visited kafana in Niš.", Tags = new List<string> { "Food", "Party" },
                        Url = "https://www.mojakafana.com/Kafane/Nis/Nislijska-mehana.lt.html",
                        PhotosUri = new List<string> {
                            "http://www.kudanaklopu.com/test_knk/wp-content/uploads/2014/10/555-nis-kafana-Ni%C5%A1lijska-mehana.jpg",
                            "http://www.serbiatour.rs/img_gdeizaci/40_img_gdeizaci_foto_4.jpg",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmDAWeYEzpVfq_z2tDI2RHHAgS1cxjVHS0n5dxuH-iorPyD5xl"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 6, Name = "Drink Voucher", Description = "A bottle of white wine.", Price = 70, ThumbnailUri = "https://www.bastabalkana.com/wp-content/uploads/2014/02/Najbolja-srpska-vina-Top-10-koje-srpsko-vino-kupiti-Svb-Rose-vinarija-Budimir.jpg" },
                            new Reward { Id = 7, Name = "Food Voucher", Description = "A discount of 20% for the speciality of the day.", Price = 100, ThumbnailUri = "https://i.pinimg.com/236x/02/3f/da/023fdae11ea1aff21598392eb3498403--dana-seafood.jpg" }
                        }
                    },
                    new RewardLocation { Id = 4, Latitude = 43.3159257, Longitude = 21.9069236, Radius = 0.00001,
                        Name = "Sports Center Cair", Description = "The sports centre was completely reconstructed in 2011 as it was previously seen unfit to host the group stage of 2012 European Men's Handball Championship. The reconstruction has been done according to highest European standards and criteria submitted by EHF, currently making Čair the most modern sporting hall in Serbia. It is fully equipped to host the biggest sports events. It satisfies high standards of sports federations referring to provision of the unhampered communication between the organizers, spectators, sportsmen and media.", Tags = new List<string> { "Sport" },
                        Url = "http://sccair.rs/",
                        PhotosUri = new List<string> {
                            "http://sccair.rs/wp-content/uploads/2018/02/Gradski-stadion-Cair-sl1.jpg",
                            "https://www.mojaekipa.com/wp-content/uploads/2017/04/cair-768x512.jpg",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7Fltdg40-hLK9nCbmHJanQAtkXc9ljJibQD69VOiQ7e427ApY"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 8, Name = "Bowling Voucher", Description = "1h of free bowling", Price = 70, ThumbnailUri = "http://d21gd0ap5v1ndt.cloudfront.net/web02/unoh/images/Bowling/bowling-a-strike.jpg" },
                            new Reward { Id = 9, Name = "Pool Voucher", Description = "1h voucher for pool", Price = 70, ThumbnailUri = "https://www.juznevesti.com/uploads/assets/2017/07/04/73631/1280x0_Bazen-cair.jpg" },
                            new Reward { Id = 10, Name = "Gym Voucher", Description = "1h vocuher for gym", Price = 70, ThumbnailUri = "http://www.rslhealthclub.com.au/acquatic-centre/Gym/gym_weights_edited.jpg" }
                        }
                    },
                    new RewardLocation { Id = 5, Latitude = 43.3450757, Longitude = 21.8564247, Radius = 0.00001,
                        Name = "Warzone Paintball", Description = "Paintball Club WARZONE was founded in 2007 in Niš and more than eleven years we are very successful in dealing with this sport, as evidenced by numerous unforgettable adrenaline experiences. Paintball is the most interesting extreme sport that has been playing in the natural environment in the last 20 years, all over the world. The game is based on the adrenaline and entertainment among the players.", Tags = new List<string> { "Sport" },
                        Url = "http://www.paintballnis.com",
                        PhotosUri = new List<string> {
                            "http://urbanwarzonepaintball.com/wp-content/uploads/2013/09/soldier-at-ammo-depot.jpg",
                            "http://www.paintballnis.com/Pictures/Slider2.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 11, Name = "Player Voucher", Description = "1h playing voucher for 1 player", Price = 80, ThumbnailUri = "https://previews.123rf.com/images/pandavector/pandavector1701/pandavector170100135/68574468-paintball-player-icon-in-cartoon-style-isolated-on-white-background-paintball-symbol-stock-vector-il.jpg" },
                            new Reward { Id = 12, Name = "Gratis Ammo", Description = "Extra 50 balls for 2 players", Price = 40, ThumbnailUri = "https://images-na.ssl-images-amazon.com/images/I/41VhBQrWnUL._SX466_.jpg" }
                        }
                    },
                    new RewardLocation { Id = 6, Latitude = 43.3157261, Longitude = 21.8918194, Radius = 0.00001,
                        Name = "Eco Bike Tour", Description = "We are a group of young and educated enthusiasts, driven by the love of nature, sport, culture, history and tourism. Niš is our hometown and we believe that it has a lot to offer. However, this great tourism potential has not been used to its maximum and this is something that we want to change. Another thing that we believe in is ecology. This is why we have decided to open this agency. Our goal is to offer to all tourists something brand new in this region – sightseeing on a bike! Accompanied by our charming guides, equipped with comfortable bicycles and all the necessary accessories, our friends and customers can get ready for one unforgettable experience!We are happy to call all the eager people to join us now – let’s cycle together around this beautiful city and meet all its wonderful places.", Tags = new List<string> { "Sport" },
                        Url = "http://ecobikenis.com",
                        PhotosUri = new List<string> {
                            "https://media-cdn.tripadvisor.com/media/photo-s/10/55/f8/e1/bubanj-memorial-park.jpg",
                            "https://media-cdn.tripadvisor.com/media/photo-s/13/35/20/8c/nis-fortress.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 13, Name = "Mini Voucher", Description = "1h free bike", Price = 40, ThumbnailUri = "http://www.bikesdirect.com/products/dawes/images/sst_steel_green_2100.jpg" },
                            new Reward { Id = 14, Name = "Maxi Voucher", Description = "Free big tour", Price = 150, ThumbnailUri = "https://backroads-web.s3.amazonaws.com/images/search/thumbnail/san-juan-islands-bike-tour.jpg" }
                        }
                    },
                    new RewardLocation { Id = 7, Latitude = 43.3190069, Longitude = 21.8928873, Radius = 0.00001,
                        Name = "Vilin grad", Description = "Cinema", Tags = new List<string> { "Cinema" },
                        Url = "http://www.vilingrad.rs",
                        PhotosUri = new List<string> {
                            "https://niskevesti.rs/wp-content/uploads/2016/12/vilin-grad.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 15, Name = "Gratis ticket", Description = "Gratis ticket for films at 20:00h", Price = 80, ThumbnailUri = "https://st2.depositphotos.com/1575949/7417/v/950/depositphotos_74173295-stockillustratie-gratis-ticket-rode-stempel-tekst.jpg" },
                            new Reward { Id = 16, Name = "Gratis drink", Description = "Gratis drink for bought ticket", Price = 40, ThumbnailUri = "https://gjerrigknark.com/bilder/600/11442-fa_helt_gratis_cocacola_classi.jpg" }
                        }
                    },
                    new RewardLocation { Id = 8, Latitude = 43.3215697, Longitude = 21.8934774, Radius = 0.00001,
                        Name = "Feedback", Description = "This venue is famous for the best alternative programme in Niš, starting from live acts, all kinds of gigs, via DJ shows, including art exhibitions, book readings, fashion shows and birthday bashes. Here you can have a great time, broaden your horizons, hear the most current and fresh music as well as worldly renounced artists. Remember, anything that happens in Feedback – stays in Feedback.", Tags = new List<string> { "Club", "Party" },
                        Url = "http://klubfeedback.com",
                        PhotosUri = new List<string> {
                            "https://i.ytimg.com/vi/YwRqPzvZ-nY/maxresdefault.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 15, Name = "Gratis ticket", Description = "Gratis ticket for Friday concerts", Price = 80, ThumbnailUri = "https://st2.depositphotos.com/1575949/7417/v/950/depositphotos_74173295-stockillustratie-gratis-ticket-rode-stempel-tekst.jpg" },
                            new Reward { Id = 16, Name = "Gratis drink", Description = "Gratis drink for bought ticket", Price = 40, ThumbnailUri = "https://i0.wp.com/www.bestglutenfreebeers.com/wp-content/uploads/2017/08/a.jpg?fit=800%2C800" }                       }
                    },
                    new RewardLocation { Id = 9, Latitude = 43.3180765, Longitude = 21.9000772, Radius = 0.00001,
                        Name = "Berta", Description = "Famous and lauded that beer sausages are concerned and now resolved to further expand the offer in the form of a separate meal!", Tags = new List<string> { "Food", "Party" },
                        Url = "https://www.facebook.com/pivnica.berta",
                        PhotosUri = new List<string> {
                            "https://media-cdn.tripadvisor.com/media/photo-s/11/3d/ff/ac/20171111-135625-largejpg.jpg",
                            "https://media-cdn.tripadvisor.com/media/photo-s/10/4e/42/c5/the-most-beautiful-and.jpg"
                        },
                        Rewards = new List<Reward> {
                            new Reward { Id = 1, Name = "L Voucher", Description = "Gratis drink", Price = 40, ThumbnailUri = "https://i0.wp.com/www.bestglutenfreebeers.com/wp-content/uploads/2017/08/a.jpg?fit=800%2C800" },
                            new Reward { Id = 1, Name = "XL Voucher", Description = "Three gratis drinks", Price = 80, ThumbnailUri = "https://i1.wp.com/www.bestglutenfreebeers.com/wp-content/uploads/2017/08/DEZCUvYXoAIomhk.png?fit=1024%2C512" },
                            new Reward { Id = 1, Name = "XXL Voucher", Description = "Gratis beer and French fries", Price = 120, ThumbnailUri = "http://www.beerstyle.rs/images/06beerstyle/pivo_pomfrit_beerstyle_6.JPG" },
                        }
                    }
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