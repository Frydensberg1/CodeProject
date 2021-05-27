using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Activities
{
    [Activity(Label = "DragonsDetailActivity")]
    public class DragonsDetailActivity : AppCompatActivity
    {
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();
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
            int resourceId = (int)typeof(Resource.Drawable).GetField(_bfVM.SelectedDragon.Picture).GetValue(null);
            imgBoss.SetImageResource(resourceId);
            InfoText = FindViewById<TextView>(Resource.Id.InfoText);
            InfoText.Text = _bfVM.SelectedDragon.Info;
            QuestText = FindViewById<TextView>(Resource.Id.QuestText);
            QuestText.Text = _bfVM.SelectedDragon.Quest;
            Rewardtext = FindViewById<TextView>(Resource.Id.RewardText);
            Rewardtext.Text = _bfVM.SelectedDragon.Reward;
            collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolBar.Title = _bfVM.SelectedDragon.Name;
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.BosswinFab);
            fab.Visibility = Android.Views.ViewStates.Gone;
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
    }
}