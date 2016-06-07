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
using Com.Optimizely.CodeBlocks;

namespace Optimizely.Xamarin.Droid.TestApp
{
    [Activity(Label = "CodeBlocksActivity", Theme = "@style/AppTheme")]
    public class CodeBlocksActivity : BaseActivity
    {
        // [OPTIMIZELY] Example how to declare a code block (Part 1 of 2)
        private static OptimizelyCodeBlock onboardingFlow = Com.Optimizely.Optimizely.CodeBlock("CheckoutFlow")
            .WithBranchNames("addOnboarding");

        private static String returning_customer = "true";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ActivityCodeBlocks);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var btn = FindViewById<Button>(Resource.Id.sign_in_2);
            btn.Click += (sender, args) => GoToVisualEditor();
        }

        public override int MenuId => Resource.Menu.menu_code_blocks;

        private class DefCodeBranch : DefaultCodeBranch
        {
            private readonly Context _context;

            public DefCodeBranch(Context context)
            {
                _context = context;
            }

            public override void Execute()
            {
                Intent signUpIntent = new Intent(_context, typeof(VisualEditorActivity));
                _context.StartActivity(signUpIntent);
            }
        }

        public class SecondCodeBranch : CodeBranch
        {
            private readonly Context _context;

            public SecondCodeBranch(Context context)
            {
                _context = context;
            }

            public override void Execute()
            {
                Intent signUpIntent = new Intent(_context, typeof(CodeBlocksActivity2));
                _context.StartActivity(signUpIntent);
            }
        }

        public void GoToVisualEditor()
        {
            // [OPTIMIZELY] (OPTIONAL) Example Custom Tag
            // If you have information about your users on the client side in your app, based on those
            // values you can set the value of the custom tag.
            // These values should be set prior to startOptimizely or before refreshExperiments is called.
            returning_customer = "true";

            Com.Optimizely.Optimizely.SetCustomTag("returning_customer", returning_customer);
            Com.Optimizely.Optimizely.RefreshExperiments();


            // [OPTIMIZELY] Example how to declare a code block (Part 2 of 2)
            onboardingFlow.Execute(new DefCodeBranch(this), new SecondCodeBranch(this));

            // [OPTIMIZELY] Example track event
            Com.Optimizely.Optimizely.TrackEvent("signed_up");

            // [OPTIMIZELY] Example revenue call which registers a $2 purchase
            // revenue = price * 100
            const int revenue = 2*100;
            Com.Optimizely.Optimizely.TrackRevenueWithDescription(revenue, "purchase_made");
        }
    }
}