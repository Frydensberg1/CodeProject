using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_Android.Fragments.SpellsFragments;
using DrunkenWizard_Android.ViewModels;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using static Android.Widget.TextView;
using AlertDialog = Android.App.AlertDialog;

namespace DrunkenWizard_Android.Activities
{
    [Activity(Theme = "@style/Theme.AppCompat.Dialog")]
    public class SpellFragments_Activity : AppCompatActivity
    {
        private TabLayout tabLayout;
        private ViewPager viewPager;
        protected ProgressDialog _progress;
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        ClassViewModel _classVM = ServiceContainer.Resolve<ClassViewModel>();
        TextColorViewModel _tcVM = ServiceContainer.Resolve<TextColorViewModel>();
        TextView btnClose;
        Android.App.AlertDialog builder;
        TextView btnQuestion;
        private int[] tabIcons = {
           Resource.Drawable.DruidLogo_tsp,
            Resource.Drawable.ClericLogo_tsp,
            Resource.Drawable.IllusionistLogo_tsp,
            Resource.Drawable.WarlockLogo_tsp,
            Resource.Drawable.PyromancerLogo_tsp,
            Resource.Drawable.NecromancerLogo_tsp,
            Resource.Drawable.DistruptedSorcerer_tsp,
            Resource.Drawable.TimeMage_tsp,
            Resource.Drawable.Shaman_tsp,
            Resource.Drawable.Alchemist_tsp,
            Resource.Drawable.Elementalist_tsp,
            Resource.Drawable.Witch_tsp,
            Resource.Drawable.Summoner_tsp,
            Resource.Drawable.DragonBoss
    };
        List<GameClass> listclasses = new List<GameClass>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            foreach (var item in _classVM.ClassList)
            {
                listclasses.Add(item);
            }
           
            listclasses.Add(_classVM.Dracsoris);
            SupportRequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Fragment_Spells);
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabs_SpellFragment);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager_SpellFragment);
            viewPager.OffscreenPageLimit = 13;
            SetUpViewPager(viewPager);
            tabLayout.SetTabTextColors(Color.ParseColor("#FFFFFF"), Color.ParseColor("#1f82dd"));
            tabLayout.SetupWithViewPager(viewPager);
            btnClose = FindViewById<TextView>(Resource.Id.btnBack_Tabs);
            btnClose.Click += BtnClose_Click;
            btnQuestion = FindViewById<TextView>(Resource.Id.btnQuestion);
            btnQuestion.Click += BtnQuestion_Click;
            setuptabicon();
            int index = listclasses.FindIndex(a => a.Name == _cgVM.SelectedPlayer.GameClass.Name);
            var data = tabLayout.GetTabAt(index);
            data.Select();
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            builder = new AlertDialog.Builder(this, Resource.Style.AlertDialog_LevelUp).Create();
            LayoutInflater inflater = LayoutInflater.From(this);
            View promptview = inflater.Inflate(Resource.Layout.SpellTypesLayout, null);
            TextView txtMultiple = promptview.FindViewById<TextView>(Resource.Id.Multiple); 
            TextView txtMultipleMeaning = promptview.FindViewById<TextView>(Resource.Id.txtMultipleMeaning);
            TextView txtReaction = promptview.FindViewById<TextView>(Resource.Id.Reaction);
            TextView txtReactionMeaning = promptview.FindViewById<TextView>(Resource.Id.txtReactionMeaning);
            TextView txtPassive = promptview.FindViewById<TextView>(Resource.Id.Passive);
            TextView txtPassiveMeaning = promptview.FindViewById<TextView>(Resource.Id.txtPassiveMeaning);
            TextView txtFirst = promptview.FindViewById<TextView>(Resource.Id.First);
            TextView txtFirstMeaning = promptview.FindViewById<TextView>(Resource.Id.txtFirstMeaning);
            var MultipleColor = _tcVM.GetColoredText(Color.White, "Multiple");
            var ReactionColor = _tcVM.GetColoredText(Color.White, "Reaction");
            var PassiveColor = _tcVM.GetColoredText(Color.White, "Passive");
            var FirstColor = _tcVM.GetColoredText(Color.White, "First");
            txtMultiple.SetText(MultipleColor, BufferType.Spannable);
            txtMultipleMeaning.Text = "You can use this spell twice during your current level.";
            txtReaction.SetText(ReactionColor, BufferType.Spannable);
            txtReactionMeaning.Text = "Spell Only applies while you are at that level.";
            txtPassive.SetText(PassiveColor, BufferType.Spannable);
            txtPassiveMeaning.Text = "Spell applies throughout the game.";
            txtFirst.SetText(FirstColor, BufferType.Spannable);
            txtFirstMeaning.Text = "If you are the first person to reach that level a speciel effect will take place.";


            builder.SetView(promptview);
            builder.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void setuptabicon()
        {
            tabLayout.GetTabAt(0).SetIcon(tabIcons[0]);
            tabLayout.GetTabAt(1).SetIcon(tabIcons[1]);
            tabLayout.GetTabAt(2).SetIcon(tabIcons[2]);
            tabLayout.GetTabAt(3).SetIcon(tabIcons[3]);
            tabLayout.GetTabAt(4).SetIcon(tabIcons[4]);
            tabLayout.GetTabAt(5).SetIcon(tabIcons[5]);
            tabLayout.GetTabAt(6).SetIcon(tabIcons[6]);
            tabLayout.GetTabAt(7).SetIcon(tabIcons[7]);
            tabLayout.GetTabAt(8).SetIcon(tabIcons[8]);
            tabLayout.GetTabAt(9).SetIcon(tabIcons[9]);
            tabLayout.GetTabAt(10).SetIcon(tabIcons[10]);
            tabLayout.GetTabAt(11).SetIcon(tabIcons[11]);
            tabLayout.GetTabAt(12).SetIcon(tabIcons[12]);
            tabLayout.GetTabAt(13).SetIcon(tabIcons[13]);
        }
        private void SetUpViewPager(ViewPager viewpager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            foreach (var item in listclasses)
            {
                adapter.AddFragment(new PyromancerFragment(item), item.Name);
            }
            viewPager.Adapter = adapter;
        }


        protected void UpdateHUD(string message)
        {
            RunOnUiThread(() =>
            {
                if (_progress != null && _progress.IsShowing)
                {
                    _progress.SetTitle(message);
                    return;
                }

                _progress = new ProgressDialog(this);
                _progress.SetTitle(message);
                _progress.SetCancelable(false);
                _progress.SetCanceledOnTouchOutside(false);
                _progress.Show();
            });
        }
        protected void HideHUD()
        {
            RunOnUiThread(() =>
            {
                if (_progress == null)
                    return;
                _progress.Dismiss();
            });
        }
    }
}