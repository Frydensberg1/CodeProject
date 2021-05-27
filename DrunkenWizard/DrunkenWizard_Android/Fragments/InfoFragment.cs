using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace DrunkenWizard_Android.Fragments
{
    public class InfoFragment : SupportFragment
    {
        TextView txt1;
        TextView txt2;
        string information = "Drunken Wizard is about being the first to get to level 10, and thereby claiming the title as a Drunk Wizard. To achieve this one must be lucky, a bit tactically smart, and ready to drink!";
        string information2 = "The game is a turn based game, where you alternating roll a die, and based on the outcome different things will occur. All players choose a Class. Every class has different spells and different rolling spells. But they have in common that when you hit a 6 you level up.  When you reach level 3, 6 and 9, you must fight against a boss.";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.InforFragmentLayout, container, false);
            txt1 = view.FindViewById<TextView>(Resource.Id.Headline);
            txt2 = view.FindViewById<TextView>(Resource.Id.Headline2);
            txt1.Text = information;
            txt2.Text = information2;
            return view;
        }
    }
}