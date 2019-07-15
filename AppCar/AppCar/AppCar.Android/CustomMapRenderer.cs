using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppCar.Droid;
using AppCar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace AppCar.Droid
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        private GoogleMap map;
        private List<Position> routeCoordinates;
        private CustomMap formMap = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                //
            }

            if (e.NewElement != null)
            {
                formMap = (CustomMap) e.NewElement;
                routeCoordinates = formMap.RouteCoordinates;

                ((MapView)Control).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            if (routeCoordinates.Count != 0)
            {
                map = googleMap;
                var polylineOption = new PolylineOptions();
                polylineOption.InvokeColor(0x66ff0000);
                polylineOption.InvokeWidth(15f);

                foreach (var position in routeCoordinates)
                {
                    polylineOption.Add(new LatLng(position.Latitude, position.Longitude));
                }

                map.AddPolyline(polylineOption);
            }
        }
    }
}