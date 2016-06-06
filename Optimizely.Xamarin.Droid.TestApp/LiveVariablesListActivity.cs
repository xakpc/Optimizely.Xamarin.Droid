using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Com.Optimizely;
using Java.Lang;
using Optimizely.Variable;
using Math = System.Math;
using Object = System.Object;

namespace Optimizely.Xamarin.Droid.TestApp
{
    [Activity(Label = "LiveVariablesActivity", Theme = "@style/AppTheme")]
    public class LiveVariablesListActivity : BaseActivity
    {
        // [OPTIMIZELY] Examples of how to declare live variables (Part 1 of 2)
        private readonly Optimizely.Variable.LiveVariable<Float> _discountVariable 
            = new LiveVariable<Float>(Com.Optimizely.Optimizely.FloatForKey("discountVariable", 0.25f /* default value */));

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityLiveVariables);

            // Create your application here
            var gridview = (GridView) FindViewById(Resource.Id.activity_live_variables_grid_layout);
            gridview.Adapter = new LiveVariablesAdapter(this);

            gridview.ItemClick += Gridview_ItemClick;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // [OPTIMIZELY] Examples of how to use live variable values (Part 2 of 2)
            var discountBannerView = (TextView) FindViewById(Resource.Id.activity_live_variables_discount);
            var optlyDiscount = (int) Math.Round(_discountVariable.Get().DoubleValue()*100);
            var optlyDiscountString = optlyDiscount.ToString();
            var discountBannerText = optlyDiscountString + "% OFF YOUR FIRST ORDER IF YOU SIGN UP BY 9/1";
            discountBannerView.Text = discountBannerText;
        }

        private void Gridview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "" + e.Position,
                       ToastLength.Short).Show();
        }

        public override int MenuId => Resource.Menu.menu_live_variables_list;
    }
}