using Android.App;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Android.Runtime;
using Android.Content;
using Android.Util;

namespace GPS
{
    [Activity(Label = "GPS", MainLauncher = true)]
    public class MainActivity : Activity, ILocationListener
    {
        TextView tvlatitude;
        TextView tvlongitude;
        LocationManager locationManager;
        string Provider;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            locationManager = GetSystemService(Context.LocationService) as LocationManager;
            Provider = LocationManager.GpsProvider;

            tvlatitude = FindViewById<TextView>(Resource.Id.tvLatitude);
            tvlongitude = FindViewById<TextView>(Resource.Id.tvLongitude);

            locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 3000, 1, this);

            Location a = locationManager.GetLastKnownLocation(Provider);

        }


        public void OnLocationChanged(Location location)
        {
            Log.Debug("OnLocationChanged", location.Latitude.ToString() + " " + location.Longitude.ToString());
        }

        public void OnProviderDisabled(string provider)
        {
            throw new System.NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new System.NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new System.NotImplementedException();
        }

    }
}

