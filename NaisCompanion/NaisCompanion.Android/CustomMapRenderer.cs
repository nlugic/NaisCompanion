using System;
using System.Collections.Generic;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Android.Widget;
using NaisCompanion;
using NaisCompanion.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace NaisCompanion.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<Pin> customPins;
        List<CustomCircle> customCircles;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                customCircles = formsMap.Circles;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.SetInfoWindowAdapter(this);

            foreach (CustomCircle circle in customCircles)
            {
                var circleOptions = new CircleOptions();
                circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                circleOptions.InvokeRadius(circle.Radius);
                circleOptions.InvokeFillColor(0X22FF0000);
                circleOptions.InvokeStrokeColor(0X22FF0000);
                circleOptions.InvokeStrokeWidth(0);

                NativeMap.AddCircle(circleOptions);
            }
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            if (pin is CustomPin)
            {
                marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                marker.SetTitle(pin.Label);
                marker.SetSnippet(pin.Address);
                marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.marker));
            }
            else if(pin is RewardPin)
            {
                marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                marker.SetTitle(pin.Label);
                marker.SetSnippet(pin.Address);
                marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.reward1));
            }
            return marker;
        }
    }
}