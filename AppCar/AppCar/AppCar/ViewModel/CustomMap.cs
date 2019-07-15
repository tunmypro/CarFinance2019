﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace AppCar.ViewModel
{
    public class CustomMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }

        public List<CustomPin> CustomPins { get; set; }

        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}
