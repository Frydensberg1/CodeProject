using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Graphics;
using Android.Support.V4.View;
using DrunkenWizard_Android.Interfaces;
using DrunkenWizard_Android.Adapters;
using Android.Widget;

namespace DrunkenWizard_Android.Fragments
{
    public class FragmentRules : Fragment, IBackButtonListener
    {
        private TabLayout tabLayout;
        private ViewPager viewPager;
        private int[] tabIcons = {
            Resource.Mipmap.InfoFragment,
            Resource.Mipmap.GamePlay,
            Resource.Mipmap.Class_Spells,
            Resource.Mipmap.Symbols
    };
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentRules NewInstance()
        {
            var fragrules = new FragmentRules { Arguments = new Bundle() };
            return fragrules;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FragmentRules, null);
            tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabs);
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.OffscreenPageLimit = 4;
            SetUpViewPager(viewPager);
            tabLayout.SetTabTextColors(Color.ParseColor("#FFFFFF"), Color.ParseColor("#1f82dd"));
            tabLayout.SetupWithViewPager(viewPager);
            setupTabIcons();
            var toolbartitel = Activity.FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Rules";
            return view;
        }

        private void SetUpViewPager(ViewPager viewpager)
        {
            TabAdapter adapter = new TabAdapter(ChildFragmentManager);
            adapter.AddFragment(new InfoFragment(), "Info");
            adapter.AddFragment(new GamePlayFragment(), "GamePlay");
            adapter.AddFragment(new Class_SpellsFragment(), "Class/Spells");
            adapter.AddFragment(new SymbolsFragment(), "FAQ");

            viewPager.Adapter = adapter;
        }
        private void setupTabIcons()
        {
            tabLayout.GetTabAt(0).SetIcon(tabIcons[0]);
            tabLayout.GetTabAt(1).SetIcon(tabIcons[1]);
            tabLayout.GetTabAt(2).SetIcon(tabIcons[2]);
            tabLayout.GetTabAt(3).SetIcon(tabIcons[3]);
        }
        public void OnBackPressed()
        {
            Activity.SupportFragmentManager.PopBackStack();
        }
    }
}
