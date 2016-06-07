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
    [Activity(Label = "CodeBlockActivity2", Theme = "@style/AppTheme")]
    public class CodeBlocksActivity2 : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ActivityCodeBlocks2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);


            var btn = FindViewById<Button>(Resource.Id.sign_in_2);
            btn.Click += (sender, args) => GoToVisualEditor();
        }

        public void GoToVisualEditor()
        {
            var intent = new Intent(this, typeof(VisualEditorActivity));
            StartActivity(intent);
        }

        public override int MenuId => Resource.Menu.menu_code_blocks_activity2;
    }
}