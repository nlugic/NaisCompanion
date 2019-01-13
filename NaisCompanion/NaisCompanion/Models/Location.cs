using System;
using System.Collections.Generic;
using System.Text;

namespace NaisCompanion.Models
{
    public class Location
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }

        public Location() { }
    }
}
