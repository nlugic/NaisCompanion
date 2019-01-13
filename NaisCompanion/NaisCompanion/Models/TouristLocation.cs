using System.Collections.Generic;

namespace NaisCompanion.Models
{
    public class TouristLocation : IBaseModel
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
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