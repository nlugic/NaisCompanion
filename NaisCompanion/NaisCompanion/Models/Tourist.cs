using System;
using System.Collections.Generic;
using System.Text;

namespace NaisCompanion.Models
{
    public class Tourist
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public uint Tokens { get; set; }
        public int Timeout { get; set; }
        public List<TouristLocation> Visited { get; set; } = new List<TouristLocation>();

        public Tourist() { }
    }
}
