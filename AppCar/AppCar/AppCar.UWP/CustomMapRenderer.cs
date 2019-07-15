using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using AppCar.UWP;
using AppCar.ViewModel;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly:ExportRenderer(typeof(CustomMap),typeof(CustomMapRenderer))]
namespace AppCar.UWP
{
    public class CustomMapRenderer : MapRenderer
    {
        private CustomMap formsMap = null;
        private MapControl nativeMap;
        List<CustomPin> customPins = new List<CustomPin>();

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                //
            }

            if (e.NewElement != null)
            {
                formsMap = (CustomMap) e.NewElement;
                nativeMap = Control as MapControl;
                var coordinates = new List<BasicGeoposition>();

                foreach (var position in formsMap.RouteCoordinates)
                {
                    coordinates.Add(new BasicGeoposition(){Latitude = position.Latitude,Longitude = position.Longitude});
                }

                if (coordinates.Count != 0)
                {
                    var polyline = new MapPolyline();
                    polyline.StrokeColor = Windows.UI.Color.FromArgb(100, 100, 0, 200);
                    polyline.StrokeThickness = 5;
                    polyline.Path = new Geopath(coordinates);
                    nativeMap.MapElements.Add(polyline);
                }
            }
        }
    }
}
