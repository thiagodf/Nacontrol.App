using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace NaControl.App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NaControlMaps : ContentPage
    {
        public NaControlMaps()
        {
            InitializeComponent();
            map.IsShowingUser = true;
            var pin1 = new Pin();
            pin1.Label = "Grupo 1";
            pin1.Type = PinType.Place;
            pin1.Address = "Endereço do grupo";
            pin1.Position = new Position(-15.879781, -48.085416);
            map.Pins.Add(pin1);

            var pin2 = new Pin();
            pin2.Label = "Grupo 2";
            pin2.Type = PinType.Place;
            pin2.Address = "Endereço do grupo";
            pin2.Position = new Position(-15.862350, -48.089209);
            map.Pins.Add(pin2);

            var pin3 = new Pin();
            pin3.Label = "Grupo 3";
            pin3.Type = PinType.Place;
            pin3.Address = "Endereço do grupo";
            pin3.Position = new Position(-15.873331, -48.100726);
            map.Pins.Add(pin3);

            
            //var zoomLevel = 9; // between 1 and 18
            //var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
            //map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));

            getPosition();
        }

        public async void getPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(100));
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
        }
    }
}