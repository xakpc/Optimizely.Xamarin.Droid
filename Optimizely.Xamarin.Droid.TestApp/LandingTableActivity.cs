using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Optimizely.Xamarin.Droid.TestApp
{
    [Activity(Label = "LandingTableActivity", Theme = "@style/AppTheme")]
    public class LandingTableActivity : BaseActivity
    {
        private IList<string> _variationTypes;
        private SingleVariationTypeAdapter _variationTypesAdapter;
        private ListView _variationTypesListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LandingTable);

            _variationTypesListView = FindViewById<ListView>(Resource.Id.variationTypes);
            _variationTypes = new List<string>();

            var values = new[] {"Visual Editor", "Live Variables", "Code Blocks"};

            _variationTypesAdapter = new SingleVariationTypeAdapter(this, values);
            _variationTypesListView.Adapter = _variationTypesAdapter;

            _variationTypesListView.ItemClick += VariationTypesListView_ItemClick;

        }

        private void VariationTypesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = null;
            switch (e.Position)
            {
                case 0:
                    intent = new Intent(this, typeof(VisualEditorActivity));
                    break;
                case 1:
                    intent = new Intent(this, typeof(LiveVariablesListActivity));
                    break;
                case 2:
                    intent = new Intent(this, typeof(CodeBlocksActivity));
                    break;
            }

            if (intent != null)
                StartActivity(intent);
        }

        public override int MenuId => Resource.Menu.menu_landing_table;
    }

}
