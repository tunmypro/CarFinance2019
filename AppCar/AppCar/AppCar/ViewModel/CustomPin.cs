using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace AppCar.ViewModel
{
    public class CustomPin : Pin
    {
        public string Id { get; set; }

        public string Url { get; set; }
    }
}
