using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Graphics;
using Android.Support.V4.View;
using DrunkenWizard_Android.Interfaces;
using DrunkenWizard_Android.Adapters;

namespace DrunkenWizard_Android.Fragments
{
    class Fragments_Spells_Game : Fragment, IBackButtonListener
    {
        private TabLayout tabLayout;
        private ViewPager viewPager;    
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static Fragments_Spells_Game NewInstance()
        {
            var fragspells = new Fragments_Spells_Game { Arguments = new Bundle() };
            return fragspells;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Fragment_Spells, null);
            tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs_SpellFragment);
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager_SpellFragment);
            viewPager.OffscreenPageLimit = 4;
            SetUpViewPager(viewPager);
            tabLayout.SetTabTextColors(Color.ParseColor("#FFFFFF"), Color.ParseColor("#1f82dd"));
            tabLayout.SetupWithViewPager(viewPager);

            return view;
        }

        private void SetUpViewPager(ViewPager viewpager)
        {
            TabAdapter adapter = new TabAdapter(ChildFragmentManager);
            viewPager.Adapter = adapter;
        }
     
        public void OnBackPressed()
        {
            Activity.SupportFragmentManager.PopBackStack();
        }
    }
}