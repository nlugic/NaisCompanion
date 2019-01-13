using NaisCompanion.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NaisCompanion.ViewModels
{
    public class TouristLocationViewModel : TouristViewModel
    {
        public TouristLocation Location { get; private set; }

        public string Tags
        {
            get { return (from s in Location?.Tags select s).FirstOrDefault(); }
        }

        public TouristLocationViewModel(Tourist current, TouristLocation location)
            :base(current)
        {
            Location = location;
            Title = location.Name;
        }
    }
}
