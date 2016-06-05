using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Optimizely.Xamarin.Droid.TestApp
{

    [Activity(Label = "Optimizely.Xamarin.Droid.TestApp", MainLauncher = true, Icon = "@drawable/icon")]
    [IntentFilter(
        new[]{ "android.intent.action.VIEW" }, 
        Categories = new[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" },
        DataScheme = TODO)]
    public class MainActivity : Activity
    {
        private int _count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = $"{_count++} clicks!"; };

            Com.Optimizely.Optimizely.StartOptimizelyWithAPIToken(TODO, Application);
        }
    }
}

