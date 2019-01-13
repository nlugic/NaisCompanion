using NaisCompanion.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NaisCompanion.ViewModels
{
    public class RewardLocationViewModel : TouristViewModel
    {
        public RewardLocation Location { get; private set; }

        public string Title { get; private set; }
        public string Tags
        {
            get { return (from s in Location?.Tags select s).FirstOrDefault(); }
        }

        public RewardLocationViewModel(Tourist current, RewardLocation location)
            :base(current)
        {
            Location = location;
            Title = location.Name;
        }
    }
}
