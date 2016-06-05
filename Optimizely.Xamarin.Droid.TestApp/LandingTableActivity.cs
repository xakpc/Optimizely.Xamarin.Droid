using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Optimizely.Xamarin.Droid.TestApp
{
    [Activity(Label = "LandingTableActivity")]
    public class LandingTableActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LandingTable);
            // Create your application here
        }
    }
}