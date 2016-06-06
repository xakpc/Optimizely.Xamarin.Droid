using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Optimizely.Xamarin.Droid.TestApp
{
    [Activity(Label = "VisualEditorActivity", Theme = "@style/AppTheme")]
    public class VisualEditorActivity : BaseActivity
    {
        public override int MenuId => Resource.Menu.menu_visual_editor;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VisualEditor);

            // Create your application here
            var signInView = FindViewById<View>(Resource.Id.activity_visual_editor);

            // [OPTIMIZELY] Below is an example of if you want to tag
            // views manually http://developers.optimizely.com/android/reference/index.html#tag-your-views
            var takeToWidgets =
                signInView.FindViewById<Button>(Resource.Id.take_to_widgets);
            Com.Optimizely.Optimizely.SetOptimizelyId("Widgets", takeToWidgets);
        }
    }
}