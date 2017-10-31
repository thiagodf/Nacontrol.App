using NaControl.App.Model;
using NaControl.App.Services;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace NaControl.App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NaControlMaps : ContentPage
    {
        GroupService groupService;
        List<Group> groups;

        public NaControlMaps()
        {
            InitializeComponent();
            groupService = new GroupService();
            refreshData();
            //map.IsShowingUser = true;

            for (int i = 0; i < groups.Count; i++)
            {
                var pin = new Pin();
                pin.Type = PinType.Place;
                pin.Icon = BitmapDescriptorFactory.FromBundle("pinIcon1.png");

                pin.Label = groups[i].Name;
                if ( groups[i].Address!=null)
                {
                    pin.Address = groups[i].Address.Addresses;
                    string latitude = groups[i].Address.Latitude.ToString();
                    string longitude = groups[i].Address.Longitude.ToString();
                    if(latitude.Contains(","))
                        latitude = latitude.Replace(",", ".");
                    if(longitude.Contains(","))
                        longitude = longitude.Replace(",",".");

                    pin.Position = new Position(Double.Parse(latitude, CultureInfo.InvariantCulture),Double.Parse(longitude, CultureInfo.InvariantCulture));
                    map.Pins.Add(pin);
                }
            }
            
           getPosition();
        }

        public async void refreshData()
        {
            groups = await groupService.GetGroupsAsync();
        }

        public async void getPosition()
        {

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                {
                    var position = await locator.GetPositionAsync();
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
                }
            }
            catch (Exception ex)
            {
            }

            //try
            //{
            //    var locator = CrossGeolocator.Current;
            //    locator.DesiredAccuracy = 50;
            //    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(100));
            //    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            //}
            //catch(Exception ex)
            //{

            //}
        }
    }
}