using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Runtime;
using System.Threading.Tasks;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_Android.Fragments;
using DrunkenWizard_SharedProject.WebService.Hubs;

namespace DrunkenWizard_Android
{
    [Activity(Label = "", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainActivity : AppCompatActivity
    {
        Android.Support.V7.App.AlertDialog builder;
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        IMenuItem previousItem;
        GameService _GS = ServiceContainer.Resolve<GameService>();
        PlayerHub playerHub = ServiceContainer.Resolve<PlayerHub>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        ProgressBar loader;
        private View _infoView;
        TextView progressTextview;
        FrameLayout progressframe;
        bool IsRunning;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            SetupToolbar();
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            View headerView = navigationView.GetHeaderView(0);
            loader = FindViewById<ProgressBar>(Resource.Id.progress_loaderMain);
            loader.Visibility = ViewStates.Gone;
            progressTextview = FindViewById<TextView>(Resource.Id.progressTextview);
            progressTextview.Visibility = ViewStates.Gone;
            progressframe = FindViewById<FrameLayout>(Resource.Id.progress_Frame);
            progressframe.Visibility = ViewStates.Gone;

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                if (previousItem != null)
                    previousItem.SetChecked(false);
                navigationView.SetCheckedItem(e.MenuItem.ItemId);
                previousItem = e.MenuItem;
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home:
                        ListItemClicked(0);
                        break;
                    case Resource.Id.nav_rules:
                        ListItemClicked(1);
                        break;
                    case Resource.Id.nav_Classes:
                        ListItemClicked(2);
                        break;
                    case Resource.Id.nav_Dragons:
                        ListItemClicked(3);
                        break;
                    case Resource.Id.nav_JoinGame:
                        ListItemClicked(4);
                        break;
                    case Resource.Id.nav_currentgame:

                        var player = _sqlVM.GetLocalPlayer();
                        if (player == null)
                        {
                            Toast.MakeText(this, "No games are running at the moment", ToastLength.Long).Show();
                        }
                        else
                        {
                            if (_GS.GetGame(player.GameKey.ToString()) == null)
                            {
                                Toast.MakeText(this, "Due to updates, your last game has been deleted", ToastLength.Long).Show();
                                _sqlVM.Delete(player);
                                return;
                            }

                            Task.Run(() =>
                            {
                                int data = player.GameKey;
                                RunOnUiThread(() =>
                                {
                                    loader.Visibility = ViewStates.Visible;
                                    progressTextview.Visibility = ViewStates.Visible;
                                    progressframe.Visibility = ViewStates.Visible;
                                });

                                if (data != 0)
                                {
                                RunOnUiThread(() =>
                                {
                                    loader.Visibility = ViewStates.Gone;
                                    progressTextview.Visibility = ViewStates.Gone;
                                    progressframe.Visibility = ViewStates.Gone;
                                    var intent = new Intent(this, typeof(CurrentGameActivity));
                                    StartActivity(intent);
                                });

                                }
                                else
                                {
                                    Toast.MakeText(this, "No games are running at the moment", ToastLength.Long).Show();
                                }
                            });
                        }
                        break;

                   
                }
                drawerLayout.CloseDrawers();
            };

            if (savedInstanceState == null)
            {
                navigationView.SetCheckedItem(Resource.Id.nav_home);
                ListItemClicked(0);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.InfoMenu, menu);
            var item = menu.FindItem(Resource.Id.action_info);
            var documentView = MenuItemCompat.GetActionView(item);
            _infoView = documentView.JavaCast<View>();
            return true;
        }

        private void SetupToolbar()
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            var toolbartitel = FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Home";
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
        }



        int oldPosition = -1;
        private void ListItemClicked(int position)
        {
            oldPosition = position;
            Android.Support.V4.App.Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = FragmentHome.NewInstance();

                    break;
                case 1:
                    fragment = FragmentRules.NewInstance();
                    replaceFragment(fragment, true);
                    break;

                case 2:
                    fragment = FragmentClasses.NewInstance();
                    replaceFragment(fragment, true);
                    break;
                case 3:
                    fragment = DragonsFragment.NewInstance();
                    replaceFragment(fragment, true);
                    break;
                case 4:
                    fragment = FragmentJoinGame.NewInstance();
                    replaceFragment(fragment, true);
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;

                case Resource.Id.action_info:
                    LayoutInflater li = LayoutInflater.From(this);
                    View promptsView = li.Inflate(Resource.Layout.LicensInfo, null);
                    TextView txtlicense = promptsView.FindViewById<TextView>(Resource.Id.txtLicense);
                    txtlicense.Text = "All icons and Logos are created by Delapouite, Faithtoken & Lorc, and can be found on > https://game-icons.net\n\nPlease drink responsibly and with moderation!\n\nCheers";

                    builder = new Android.Support.V7.App.AlertDialog.Builder(this).Create();
                    builder.SetView(promptsView);

                    builder.Show();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (isNavDrawerOpen())
            {
                drawerLayout.CloseDrawers();
            }
            else
            {
                var currentFragment = SupportFragmentManager.FindFragmentById(Resource.Id.content_frame);
                if (currentFragment != null)
                {
                    var fm = SupportFragmentManager;
                    if (SupportFragmentManager.BackStackEntryCount >= 0)
                    {
                        Fragment f = SupportFragmentManager.FindFragmentById(Resource.Id.content_frame);

                        if (f is FragmentHome)
                        {
                            Finish();
                        }
                        else
                        {
                            for (int i = 0; i < fm.BackStackEntryCount; ++i)
                            {
                                fm.PopBackStack();
                            }
                        }
                    }
                }
                else
                {
                    Finish();
                }
            }
        }

        bool isNavDrawerOpen()
        {
            return drawerLayout != null && drawerLayout.IsDrawerOpen(Android.Support.V4.View.GravityCompat.Start);
        }

        public void replaceFragment(Fragment fragment, bool addToBackStack)
        {
            var transaction = SupportFragmentManager
                    .BeginTransaction();

            if (addToBackStack)
            {
                transaction.AddToBackStack(null);
            }
            else
            {
                SupportFragmentManager.PopBackStack();
            }
            transaction.Replace(Resource.Id.content_frame, fragment);
            transaction.Commit();
            SupportFragmentManager.ExecutePendingTransactions();
        }
    }
}



