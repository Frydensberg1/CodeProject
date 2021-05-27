using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.WebService.Hubs;

namespace DrunkenWizard_Android
{
    [Activity(Label = "BossFightActivity")]
    public class BossFightActivity : AppCompatActivity
    {
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        ClassViewModel _classVM = ServiceContainer.Resolve<ClassViewModel>();
        PlayerHub playerHUB = ServiceContainer.Resolve<PlayerHub>();
        PlayerService _ps = ServiceContainer.Resolve<PlayerService>();
        ImageView imgBoss;
        TextView InfoText;
        TextView QuestText;
        TextView Rewardtext;
        CollapsingToolbarLayout collapsingToolBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BossFight);
            imgBoss = FindViewById<ImageView>(Resource.Id.imageViewBoss);
            Random random = new Random();
            int index = random.Next(_bfVM.MonsterList.Count);
            Monster m = _bfVM.MonsterList[index];
            int resourceId = (int)typeof(Resource.Drawable).GetField(m.Picture).GetValue(null);
            imgBoss.SetImageResource(resourceId);
            InfoText = FindViewById<TextView>(Resource.Id.InfoText);
            InfoText.Text = m.Info;
            QuestText = FindViewById<TextView>(Resource.Id.QuestText);
            QuestText.Text = m.Quest;
            Rewardtext = FindViewById<TextView>(Resource.Id.RewardText);
            Rewardtext.Text = m.Reward;
            collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolBar.Title = m.Name;
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.BosswinFab);
            fab.Click += (o, e) =>
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this, Resource.Style.AlertDialogBeast);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Fighting the Mighty beast");
                alert.SetMessage("Did you win?");
                alert.SetIcon(Resource.Drawable.DragonBoss);
                alert.SetButton("Let me out!", (c, ev) =>
                {
                    _bfVM.selectedplayer.Level = _bfVM.selectedplayer.Level - 1;
                    playerHUB.UpdateLevelChange(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.Level);
                    Finish();
                });
                alert.SetButton2("YES", (c, ev) =>
                {
                    switch (m.Name)
                    {
                        case "Orecan":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Orecan;
                            _bfVM.selectedplayer.Level =  _bfVM.selectedplayer.Level + 2;
                            foreach (var item in _cgVM.PlayerList.Where(x => x.Id != _bfVM.selectedplayer.Id))
                            {
                                if (item.Level != 0)
                                {
                                    item.Level = item.Level - 1;
                                    playerHUB.UpdateLevelChange(item.Id, item.Level);
                                }
                            }
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Trexzor":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Trexzor;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Ile":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Ile;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Dracyllis":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Dracyllis;
                            _bfVM.selectedplayer.BoostUsed = false;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Barcyl":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Barcyl;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Zeodrenth":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Zeodrenth;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Dracenic":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Dracenic;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            Finish();
                            break;

                        case "Dracsoris":
                            _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris;
                            _bfVM.selectedplayer.GameClass = _classVM.Dracsoris;
                            playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);
                            _ps.UpdatePlayer(_bfVM.selectedplayer);
                            Finish();
                            break;
                    }
                });
                alert.Show();
            };
            SetupToolbar();
        }
        private void SetupToolbar()
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarBoss);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.Title = "Boss";
                toolbar.NavigationClick += (sender, args) => { Finish(); };
            }
        }
        public override void OnBackPressed()
        {
            Finish();
        }
    }
}