using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Math;
using Optimizely.Variable;

namespace Optimizely.Xamarin.Droid.TestApp
{
    public class LiveVariablesAdapter : BaseAdapter
    {
        // [OPTIMIZELY] Examples of how to declare live variables (Part 1 of 2)
        private static readonly LiveVariable<Float> discountVariable =
            new LiveVariable<Float>(Com.Optimizely.Optimizely.FloatForKey("discountVariable", 0.25f /* default value */));

        private static readonly LiveVariable<Integer> numberOfItems =
            new LiveVariable<Integer>(Com.Optimizely.Optimizely.IntegerForKey("numberOfItems", 4 /* default value */));

        private readonly Context context;

        private readonly string[] itemNameArray =
        {
            "Standard Widget", "Standard Widget Pack", "Deluxe Widget",
            "Deluxe Widget Pack", "Premium Widget", "Premium Widget Pack"
        };

        private readonly string[] msrpArray = {"3.99", "6.99", "9.99", "12.99", "15.99", "18.99"};

        // references to our images
        private readonly int[] mThumbIds =
        {
            Resource.Drawable.gear1, Resource.Drawable.gear2,
            Resource.Drawable.gear3, Resource.Drawable.gear4,
            Resource.Drawable.gear5, Resource.Drawable.gear6
        };

        //String[] itemNameArray = context.getResources().getStringArray(R.array.item_name_array);

        public LiveVariablesAdapter(Context c)
        {
            context = c;
        }


        public override int Count
        {
            get
            {
                if (numberOfItems.Get().IntValue() <= 6)
                    // [OPTIMIZELY] Examples of how to use live variable values (Part 2 of 2)
                    return numberOfItems.Get().IntValue();
                return mThumbIds.Length;
            }
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 1;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
            View gridView;

            if (convertView == null)
            {
                gridView = new View(context);
                // get layout from mobile.xml
                gridView = inflater.Inflate(Resource.Layout.ActivityLiveVariablesItem, null);

                // set image based on selected text
                var imageView = (ImageView) gridView
                    .FindViewById(Resource.Id.product_image_view);

                var nameView = (TextView) gridView.FindViewById(Resource.Id.text_view_name);
                nameView.Text = itemNameArray[position];

                var msrpView = (TextView) gridView.FindViewById(Resource.Id.test_view_msrp);
                msrpView.Text = msrpArray[position];
                var discount = 0.25;

                var saleView = (TextView) gridView.FindViewById(Resource.Id.text_view_sales_price);

                // [OPTIMIZELY] Examples of how to use live variable values (Part 2 of 2)
                saleView.Text =
                    ((1.0f - discountVariable.Get().FloatValue())*float.Parse(msrpArray[position])).ToString("F2");
                imageView.SetImageResource(mThumbIds[position]);
            }
            else
            {
                gridView = convertView;
            }

            return gridView;
        }
    }
}