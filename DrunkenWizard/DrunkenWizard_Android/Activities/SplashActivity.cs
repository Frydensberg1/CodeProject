using System.Threading;
using Android.App;
using Android.OS;
using DrunkenWizard_Android.Activities;

namespace DrunkenWizard_Android
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          //  SetContentView(Resource.Layout.SplashScreenLayout);
            //Thread.Sleep(1200);         
            StartActivity(typeof(MainActivity));
        }
        public override void OnBackPressed() { Finish(); }
    }
}
