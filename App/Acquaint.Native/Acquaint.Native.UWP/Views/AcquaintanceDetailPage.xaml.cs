using Acquaint.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Acquaint.Native.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AcquaintanceDetailPage : Page
    {
        public AcquaintanceDetailPage()
        {
            this.InitializeComponent();
            map.Loaded += OnMapLoaded;
        }

        private async void OnMapLoaded(object sender, RoutedEventArgs e)
        {
            var hintPoint = new Geopoint(new BasicGeoposition()
                {
                    //Geopoint for Seattle 
                    Latitude = 47.604,
                    Longitude = -122.329
                });

            MapLocationFinderResult result =
                  await MapLocationFinder.FindLocationsAsync(
                                    Item.AddressString,
                                    hintPoint,
                                    3);

            var latitude = result.Locations[0].Point.Position.Latitude;
            var longitude = result.Locations[0].Point.Position.Longitude;

            var center = new Geopoint(new BasicGeoposition()
            {
                //Geopoint for Seattle 
                Latitude = latitude,
                Longitude = longitude
            });

            map.Center = center;
            map.ZoomLevel = 12;

            MapIcon mapIcon = new MapIcon();
            mapIcon.Location = center;
            mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/PinPoint.png"));
            mapIcon.ZIndex = 0;

            map.MapElements.Add(mapIcon);
        }

        public Acquaintance Item
        {
            get; set;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var item = e.Parameter as Acquaintance;
            Item = item;
        }

        private void OnBack(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
