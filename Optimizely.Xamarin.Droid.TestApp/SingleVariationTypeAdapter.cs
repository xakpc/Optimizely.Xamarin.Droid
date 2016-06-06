using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace Optimizely.Xamarin.Droid.TestApp
{
    public class SingleVariationTypeAdapter : ArrayAdapter<string>
    {
        private readonly Context _context;
        private readonly string[] _values;

        public SingleVariationTypeAdapter(Context context, string[] values) : base(context, -1, values)
        {
            _context = context;
            _values = values;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = (LayoutInflater)_context
                .GetSystemService(Context.LayoutInflaterService);
            var rowView = inflater.Inflate(Resource.Layout.LandingTableItem, parent, false);
            var textView = rowView.FindViewById<TextView>(Resource.Id.firstLine);
            var secondLineTextView = rowView.FindViewById< TextView>(Resource.Id.secondLine);
            var imageView = rowView.FindViewById<ImageView>(Resource.Id.icon);
            textView.Text = _values[position];

            const string fontPath1 = "fonts/Gotham-Bold.otf";
            const string fontPath2 = "fonts/Gotham-Light.otf";


            var tf1 = Typeface.CreateFromAsset(_context.Assets, fontPath1);
            textView.Typeface = tf1;

            var tf2 = Typeface.CreateFromAsset(_context.Assets, fontPath2);
            secondLineTextView.Typeface = tf2;

            // change the icon for Windows and iPhone
            var s = _values[position];
            if (s.StartsWith("Visual Editor"))
            {
                imageView.SetImageResource(Resource.Drawable.visual_editor_icon);
                secondLineTextView.SetText(Resource.String.visual_editor_desc);
            }
            else if (s.StartsWith("Live Variables"))
            {
                imageView.SetImageResource(Resource.Drawable.live_variables_icon);
                secondLineTextView.SetText(Resource.String.live_variables_desc);
            }
            else if (s.StartsWith("Code Blocks"))
            {
                imageView.SetImageResource(Resource.Drawable.code_blocks_icon);
                secondLineTextView.SetText(Resource.String.code_blocks_desc);
            }

            return rowView;
        }


    }
}