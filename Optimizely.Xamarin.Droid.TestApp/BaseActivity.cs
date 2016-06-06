using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Optimizely.Xamarin.Droid.TestApp
{    
    public abstract class BaseActivity : AppCompatActivity
    {
        public abstract int MenuId { get; }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Inflate the menu; this adds items to the action bar if it is present.
            MenuInflater.Inflate(MenuId, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //        // Handle action bar item clicks here. The action bar will
            //        // automatically handle clicks on the Home/Up button, so long
            //        // as you specify a parent activity in AndroidManifest.xml.
            var id = item.ItemId;

            if (id == Android.Resource.Id.Home)
            {
                OnBackPressed();
                return true;
            }

            //        //noinspection SimplifiableIfStatement
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}