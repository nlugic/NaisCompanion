using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NaisCompanion.Models
{
    public class RewardLocation : IBaseModel
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public List<Image> Photos { get; set; } // koji image?
        public List<Reward> Rewards { get; set; }

        public RewardLocation() { }
    }
}
