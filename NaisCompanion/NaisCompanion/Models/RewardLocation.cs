﻿using System.Collections.Generic;

namespace NaisCompanion.Models
{
    public class RewardLocation
    {
        public int Id { get; set; }
        public Location Position { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public List<string> PhotosUri { get; set; }
        public List<Reward> Rewards { get; set; }

        public RewardLocation() { }
    }
}
