﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace NaisCompanion
{
    public class CustomMap : Map
    {
        public List<Pin> CustomPins { get; set; }
        public List<CustomCircle> Circles { get; set; }

        public CustomMap() : base()
        {
            Circles = new List<CustomCircle>();
        }
    }

}
