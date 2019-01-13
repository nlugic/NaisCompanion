using System.Collections.Generic;

namespace NaisCompanion.Models
{
    public class TouristLocation
    {
        public int Id { get; set; }
        public Location Position { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public List<string> PhotosUri { get; set; }
        public uint VisitedPayment { get; set; }
        public uint MinVisitDuration { get; set; }
        public uint PostPayment { get; set; }
        public uint PhotoPayment { get; set; }

        public TouristLocation() { }
    }
}