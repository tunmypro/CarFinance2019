using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AppCar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        public MapPage()
        {
            InitializeComponent();

            var customMap = new CustomMap
            {
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(14.022281, 99.533101),
                Label = "สาขา เมืองกาญ",
                Address = "ทดสอบ",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(14.022281, 99.533101), Distance.FromKilometers(1.0)));

            Content = customMap;
        }
    }
}