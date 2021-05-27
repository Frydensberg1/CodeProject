using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace DrunkenWizard_Android.Fragments
{
    class ExtraRulesFragment : SupportFragment
    {
        TextView txt1;
        TextView txt2;
        string extra = "Every time you increase a level, you will play your personal quote or piece of music over the speaker so everyone can hear that you have increased a level. ";
        string extra2 = "When a boss is beaten, one collects equipment. Level 3 is a cape, level 6 is glasses and level 9 is a black hat. If you are first to level 10 (The Grand Wizard). You get a white hat.";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Extra_Rules_Layout, container, false);
            txt1 = view.FindViewById<TextView>(Resource.Id.Headline);
            txt2 = view.FindViewById<TextView>(Resource.Id.Headline2);
            txt1.Text = extra;
            txt2.Text = extra2;           
            return view;
        }
    }
}