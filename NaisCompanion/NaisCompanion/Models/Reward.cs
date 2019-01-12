using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NaisCompanion.Models
{
    public class Reward : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; }
        public Image Thumbnail { get; set; }

        public Reward() { }
    }
}
