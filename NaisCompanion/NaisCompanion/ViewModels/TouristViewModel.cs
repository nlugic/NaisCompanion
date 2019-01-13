using NaisCompanion.Models;

namespace NaisCompanion.ViewModels
{
    public class TouristViewModel
    {
        public Tourist CurrentTourist { get; private set; }

        public TouristViewModel(Tourist current) { CurrentTourist = current; }
    }
}
