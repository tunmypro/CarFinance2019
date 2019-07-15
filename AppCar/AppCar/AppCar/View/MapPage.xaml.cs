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
        CustomMap customMap = new CustomMap
        {
            MapType = MapType.Street,
            WidthRequest = App.ScreenWidth,
            HeightRequest = App.ScreenHeigth,
            IsShowingUser = true
        };

        public MapPage()
        {
            InitializeComponent();

            Maps();
        }

        private void Maps()
        {
            Position onePosition = new Position(14.0227797, 99.5328115);
            Position twoPosition = new Position(14.0227797, 99.5328300);

            List<Position> listPoint = new List<Position>();
            listPoint.Add(onePosition);
            listPoint.Add(twoPosition);

            var startPin = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(onePosition.Latitude, onePosition.Longitude),
                    Label = "Start",
                    Address = ""
                },
                Id = "Start Point",
                Url = "Test"
            };
            customMap.RouteCoordinates.Clear();
            foreach (var item in listPoint)
            {
                customMap.RouteCoordinates.Add(new Position(item.Latitude, item.Longitude));
            }
            customMap.CustomPins = new List<CustomPin> { startPin };
            Content = customMap;
            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(onePosition, Distance.FromMiles(1.0)));
        }
    }
}