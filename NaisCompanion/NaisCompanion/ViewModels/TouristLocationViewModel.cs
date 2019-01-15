using NaisCompanion.Models;
using System;

namespace NaisCompanion.ViewModels
{
    public class TouristLocationViewModel : TouristViewModel
    {
        public TouristLocation Location { get; private set; }

        public string Title { get; private set; }
        public string Tags
        {
            get
            {
                string res = string.Empty;
                for (short i = 0; i < Location.Tags.Count; ++i)
                {
                    res += Location.Tags[i];
                    if (i != Location.Tags.Count - 1)
                        res += ", ";
                }

                return res;
            }
            }
        }



        public TouristLocationViewModel(Tourist current, TouristLocation location)
            :base(current)
        {
            Location = location;
            Title = location.Name;
        }
    }
}
