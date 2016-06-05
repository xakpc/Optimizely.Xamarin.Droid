//
//  MainActivity
//  TutorialApp
//
//  This Optimizely Tutorial app will teach you how to use Optimizely's iOS SDK's
//  3 key features:
//     - Visual Editor
//     - Live Variables
//     - Code Blocks
//
//  Created by Pam Ongchin on 10/19/15.
//  Copyright (c) 2015 Optimizely. All rights reserved.
//


using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Optimizely.Integration;

namespace Optimizely.Xamarin.Droid.TestApp
{
    [Activity(Label = "Optimizely.Xamarin.Droid.TestApp", MainLauncher = true, Icon = "@drawable/icon")]
    [IntentFilter(
        new[] {"android.intent.action.VIEW"},
        Categories = new[] {"android.intent.category.DEFAULT", "android.intent.category.BROWSABLE"},
        DataScheme = TODO)]
    public class MainActivity : Activity
    {
        private string returning_customer = "true";
        private string tag = "OPTLY";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            const string fontPath = "fonts/Gotham-Light.otf";

            var welcomeTitle = FindViewById<TextView>(Resource.Id.textView);

            var tf = Typeface.CreateFromAsset(Assets, fontPath);

            welcomeTitle.SetTypeface(tf, TypefaceStyle.Normal);

            var welcomeText = FindViewById<TextView>(Resource.Id.welcome_text);
            welcomeText.SetTypeface(tf, TypefaceStyle.Normal);


            // Below are instructions for initial setup, lines marked as optional
            // are options, lines marked as required are required
            // Throughout the code, you can search for [OPTIMIZELY] to find reference code
            // related to Optimizely
            // All lines that say [OPTIMIZELY] (REQUIRED) are necessary for you to
            // get started!

            // [OPTIMIZELY] (OPTIONAL) Add this line of code to debug issues.  Please note that this line of code
            // should not be included when your app is in production
            Com.Optimizely.Optimizely.SetVerboseLogging(true);

            // [OPTIMIZELY] (OPTIONAL) Example Custom Tag
            // If you have information about your users on the client side in your app, based on those
            // values you can set the value of the custom tag.
            // These values should be set prior to startOptimizely or before refreshExperiments is called.
            // For the refreshExperiments example, you can go to the CodeBlocksActivity.java file.
            returning_customer = "true";
            Com.Optimizely.Optimizely.SetCustomTag("returning_customer", returning_customer);

            // [OPTIMIZELY] (OPTIONAL) Customize how often the datafile is downloaded (By default network calls are made every 2 minutes)
            // Optimizely.setDataFileDownloadInterval(120);

            // [OPTIMIZELY] (REQUIRED) Replace this line with your API token, and don't forget to go to
            // your AndroidManifest.xml (e.g. it should look like optly123456, replace 123456 with your project id)
            // Replace <YOUR_API_TOKEN> with your API Token from your Optimizely Dashboard
            // optimizely.com/dashboard.  It should look like: "AAMseu0A6cJKXYL7RiH_TgxkvTRMOCvS~123456"


            Com.Optimizely.Optimizely.StartOptimizelyWithAPIToken(TODO,
                Application);

            // [OPTIMIZELY] (OPTIONAL) Register the plugin for the integration you would like to use
            // For information, refer to: http://developers.optimizely.com/android/reference/index.html#analytics-integrations
            // Optimizely.registerPlugin(new Optimizely<ANALYTICS_PROVIDER>Integration());
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Inflate the menu; this adds items to the action bar if it is present.
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //        // Handle action bar item clicks here. The action bar will
            //        // automatically handle clicks on the Home/Up button, so long
            //        // as you specify a parent activity in AndroidManifest.xml.
            var id = item.ItemId;

            //        //noinspection SimplifiableIfStatement
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public void goToMainScreen(View view)
        {
            var intent = new Intent(this, typeof(LandingTableActivity));
            StartActivity(intent);
        }

        // [OPTIMIZELY] (OPTIONAL) The following listeners will trigger when certain events happen in the SDK
        // such as when an experiment is running.  To learn more, you can refer to the following article:
        // https://help.optimizely.com/hc/en-us/articles/205014107-How-Optimizely-s-SDKs-Work-SDK-Order-of-execution-experiment-activation-and-goals

        private class MyDefaultOptimizelyEventListener : DefaultOptimizelyEventListener
        {
            private readonly string tag = "OPTLY";

            public override void OnOptimizelyStarted()
            {
                Log.Info(tag, "Optimizely started.");
            }

            public override void OnOptimizelyFailedToStart(string errorMessage)
            {
                Log.Info(tag, "Failed to start");
            }

            public override void OnOptimizelyExperimentViewed(OptimizelyExperimentData experimentState)
            {
                Log.Info(tag, "Experiment Viewed");
            }

            public override void OnOptimizelyEditorEnabled()
            {
                Log.Info(tag, "Optimizely is ready to connect to the editor.");
            }

            public override void OnOptimizelyDataFileLoaded()
            {
                Log.Info(tag, "Optimizely experiment data file loaded.");
            }

            public override void OnGoalTriggered(string description,
                IList<OptimizelyExperimentData> affectedExperiments)
            {
                Log.Info(tag, "Goal Triggered");
            }

            public override void OnMessage(string source, string messageType, Bundle payload)
            {
                Log.Info(tag, "Received message");
            }
        }
    }
}