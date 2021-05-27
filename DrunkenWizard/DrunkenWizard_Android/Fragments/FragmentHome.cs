using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_Android.Helper;
using DrunkenWizard_Android.ViewModels;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_SharedProject.WebService.Hubs;
using static Android.Widget.TextView;
using Fragment = Android.Support.V4.App.Fragment;

namespace DrunkenWizard_Android.Fragments
{
    public class FragmentHome : Fragment
    {
        Button btnHost;
        TextView TxtChosenClass;
        Button btnChooseClass;
        ImageView imgRandom;
        TextView btnHostTitle;
        AlertDialog builderChooseClass;
        AlertDialog builderClassDetails;
        BottomSheetBehavior bottomSheetBehavior;
        EditText hostname;
        TextView txtLoading;
        FrameLayout progressframe;
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        //  GameHub gameHub = ServiceContainer.Resolve<GameHub>();
        GameService _GS = ServiceContainer.Resolve<GameService>();
        PlayerHub playerHub = ServiceContainer.Resolve<PlayerHub>();
        FragmentHomeViewModel _fhVM = ServiceContainer.Resolve<FragmentHomeViewModel>();
        TextColorViewModel _tcVM = ServiceContainer.Resolve<TextColorViewModel>();
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        SpannableStringBuilder spanbuilder;
        ProgressBar spinner;
        //ImageView imginfo;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static FragmentHome NewInstance()
        {
            var fraghome = new FragmentHome { Arguments = new Bundle() };
            return fraghome;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragmentHome, null);
            LinearLayout sheet = view.FindViewById<LinearLayout>(Resource.Id.bottom_sheet);
            bottomSheetBehavior = BottomSheetBehavior.From(sheet);
            btnHost = view.FindViewById<Button>(Resource.Id.BtnHost);
            btnHost.Click += BtnHost_Click;
            txtLoading = view.FindViewById<TextView>(Resource.Id.progressTextviewHome);
            progressframe = view.FindViewById<FrameLayout>(Resource.Id.progress_FrameHome);
            imgRandom = view.FindViewById<ImageView>(Resource.Id.imgRandom);
            btnHostTitle = view.FindViewById<TextView>(Resource.Id.txtHostTitle);
            btnHostTitle.Click += BtnHostTitle_Click;
            //imginfo = view.FindViewById<ImageView>(Resource.Id.imginfo);
            //imginfo.Click += Imginfo_Click;
            hostname = view.FindViewById<EditText>(Resource.Id.EditName);
            btnChooseClass = view.FindViewById<Button>(Resource.Id.btnClass);
            btnChooseClass.Click += BtnChooseClass_Click;
            TxtChosenClass = view.FindViewById<TextView>(Resource.Id.txtChosenClass);
            spinner = view.FindViewById<ProgressBar>(Resource.Id.progress_loader);
            spinner.Visibility = ViewStates.Invisible;
            bottomSheetBehavior.PeekHeight = 200;
            bottomSheetBehavior.Hideable = true;
            bottomSheetBehavior.SetBottomSheetCallback(new MyBottomSheetCallBack());
            imgRandom.Click += ImgRandom_Click;
            if (bottomSheetBehavior.State != BottomSheetBehavior.StateCollapsed)
            {
                hostname.RequestFocus();
            }

            FloatingActionButton fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) =>
            {
                if (bottomSheetBehavior.State != BottomSheetBehavior.StateExpanded)
                {
                    bottomSheetBehavior.State = BottomSheetBehavior.StateExpanded;
                }
                else
                {
                    bottomSheetBehavior.State = BottomSheetBehavior.StateCollapsed;
                }
            };

            var toolbartitel = Activity.FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Home";
            return view;
        }

        //private void Imginfo_Click(object sender, EventArgs e)
        //{
        //    LayoutInflater li = LayoutInflater.From(Context);
        //    View promptsView = li.Inflate(Resource.Layout.InfoLayout, null);
        //    TextView txtinfo = promptsView.FindViewById<TextView>(Resource.Id.infotext);
        //    txtinfo.Text = "All icons and Logos are created by Delapouite, Faithtoken & Lorc, and can be found on > https://game-icons.net\n\nPlease drink responsibly and with moderation!\n\nCheers " + "&#127867";


        //    builderChooseClass = new AlertDialog.Builder(Context, Android.Resource.Style.ThemeNoTitleBarFullScreen).Create();
        //    builderChooseClass.SetView(promptsView);
        //    builderChooseClass.Show();
        //}

        private void ImgRandom_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(_cVM.ClassList.Count());
            GameClass c = _cVM.ClassList[index];
            spanbuilder = _tcVM.classtextcolor(c.Name);
            TxtChosenClass.Text = "";
            TxtChosenClass.SetText(spanbuilder, BufferType.Spannable);
        }

        private void BtnChooseClass_Click(object sender, EventArgs e)
        {
            LayoutInflater li = LayoutInflater.From(Context);
            View promptsView = li.Inflate(Resource.Layout.ChooseClass, null);
            RecyclerView rcv = promptsView.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            Button close = promptsView.FindViewById<Button>(Resource.Id.btnClose);
            close.Click += Close_Click;
            ChooseClassAdapter adapter = new ChooseClassAdapter(Context);
            adapter.CellClicked += OnItemClick;
            rcv.SetAdapter(adapter);
            AutoFitGridLayoutManager layoutManager = new AutoFitGridLayoutManager(Context, 350);
            rcv.SetLayoutManager(layoutManager);
            builderChooseClass = new AlertDialog.Builder(Context, Android.Resource.Style.ThemeNoTitleBarFullScreen).Create();
            builderChooseClass.SetView(promptsView);
            builderChooseClass.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            builderChooseClass.Dismiss();
        }

        private void OnItemClick(object sender, GameClass e)
        {
            _cVM.SelectedClass = e;
            LayoutInflater li = LayoutInflater.From(Context);
            View promptsView = li.Inflate(Resource.Layout.ClassDetailsChoosingLayout, null);
            builderClassDetails = new AlertDialog.Builder(Context, Resource.Style.AlertDialog_LevelUp).Create();
            builderClassDetails.SetView(promptsView);
            builderClassDetails.Show();
            ImageView imgFragmentClass = promptsView.FindViewById<ImageView>(Resource.Id.imgFragmentClass);
            int resourceId = (int)typeof(Resource.Drawable).GetField(e.Picture).GetValue(null);
            imgFragmentClass.SetImageResource(resourceId);
            TextView txtFragmentClass = promptsView.FindViewById<TextView>(Resource.Id.txtFragmentClass);
            txtFragmentClass.Text = e.Name;
            LinearLayout linearaggressive = promptsView.FindViewById<LinearLayout>(Resource.Id.linearaggressive);
            LinearLayout linearDefensive = promptsView.FindViewById<LinearLayout>(Resource.Id.linearDefensive);
            LinearLayout linearEntertaining = promptsView.FindViewById<LinearLayout>(Resource.Id.linearFun);
            LinearLayout linearSpeed = promptsView.FindViewById<LinearLayout>(Resource.Id.linearSpeed);

            for (int i = 1; i <= e.Aggressive; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearaggressive.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearaggressive.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
            }
            for (int i = 1; i <= e.Defensive; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearDefensive.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearDefensive.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
            }
            for (int i = 1; i <= e.Entertaining; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
            }
            for (int i = 1; i <= e.Speed; i++)
            {

                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearSpeed.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearSpeed.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
            }
            Button btnChooseClass = promptsView.FindViewById<Button>(Resource.Id.btnChooseClass);
            btnChooseClass.Click += BtnChooseClass_Click1;
            Button btnChooseClassCancel = promptsView.FindViewById<Button>(Resource.Id.btnChooseClassCancel);
            btnChooseClassCancel.Click += BtnChooseClassCancel_Click;
        }

        private void BtnChooseClassCancel_Click(object sender, EventArgs e)
        {
            builderClassDetails.Dismiss();
        }

        private void BtnChooseClass_Click1(object sender, EventArgs e)
        {
            spanbuilder = _tcVM.classtextcolor(_cVM.SelectedClass.Name);
            TxtChosenClass.SetText(spanbuilder, BufferType.Spannable);
            builderClassDetails.Dismiss();
            builderChooseClass.Dismiss();
        }

        private void BtnHostTitle_Click(object sender, EventArgs e)
        {
            if (bottomSheetBehavior.State != BottomSheetBehavior.StateExpanded)
            {
                bottomSheetBehavior.State = BottomSheetBehavior.StateExpanded;
            }
            else
            {
                bottomSheetBehavior.State = BottomSheetBehavior.StateCollapsed;
            }
        }

        private async void BtnHost_Click(object sender, EventArgs e)
        {

            //   playerHub.GetExistingPlayers += ReturnedExistingPlayers;
            if (_sqlVM.GetLocalPlayer() != null)
            {
                Toast.MakeText(Context, "Game is already running", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(hostname.Text))
            {
                Toast.MakeText(Context, "You forgot a name", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtChosenClass.Text))
            {
                Toast.MakeText(Context, "Choose a class", ToastLength.Short).Show();
                return;
            }
            bottomSheetBehavior.State = BottomSheetBehavior.StateCollapsed;

            Activity.RunOnUiThread(() =>
                {
                    spinner.Visibility = ViewStates.Visible;
                    txtLoading.Visibility = ViewStates.Visible;
                    progressframe.Visibility = ViewStates.Visible;
                });

            var game = await _GS.CreateGameAsync();

            JoinPlayerDTO playerDTO = new JoinPlayerDTO()
            {
                Name = hostname.Text,
                Level = 0,
                ClassName = TxtChosenClass.Text,
                SlayedBeast = BeastEnum.none,
                IsHost = true,
                LocalPLayer = false,
                GameKey = game.Key,
                PremiumAccount = true
            };

            //Player HostPlayer = new Player
            //{
            //    Name = hostname.Text,
            //    Level = 0,
            //   // GameClass = _fhVM.ClassPicture(TxtChosenClass.Text),
            //    SlayedBeast = BeastEnum.none,
            //    IsHost = true,
            //    LocalPLayer = false,
            //    GameKey = game.Key,
            //    PremiumAccount = true
            //};
            playerHub.ReturnedPlayer += ReturnedPlayer;
            Task.Run(() =>
            {
                try
                {
                    playerHub.JoinGame(playerDTO);
                }
                catch (Exception ex)
                {
                    var f = ex;
                }
            });


            //gameHub.CreateGameReturnedGame += ReturnedGame;
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        gameHub.CreateGame();
            //    }
            //    catch (Exception ex)
            //    {
            //        var f = ex;
            //    }
            //});
        }

        void ReturnedPlayer(object sender, Player player)
        {
            if (player != null)
            {
                playerHub.ReturnedPlayer -= ReturnedPlayer;
                _sqlVM.SavePlayer(player.Id, player.GameKey, player.GameId, player.IsHost);
                Task.Run(() =>
                {
                    var intent = new Intent(Context.ApplicationContext, typeof(CurrentGameActivity))
                         .SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(intent);
                   // playerHub.ExistingPLayers(player.GameKey);

                });

                Activity.RunOnUiThread(() =>
                {
                    spinner.Visibility = ViewStates.Gone;
                    txtLoading.Visibility = ViewStates.Gone;
                    progressframe.Visibility = ViewStates.Gone;
                });


            }
            else
            {
                Activity.RunOnUiThread(() =>
                {
                    spinner.Visibility = ViewStates.Gone;
                    txtLoading.Visibility = ViewStates.Gone;
                    progressframe.Visibility = ViewStates.Gone;
                    Toast.MakeText(Context, "Something went wrong", ToastLength.Short).Show();
                    return;
                });
            }
        }

        //void ReturnedGame(object sender, Game game)
        //{
        //  //  gameHub.CreateGameReturnedGame -= ReturnedGame;
        //    Player HostPlayer = new Player
        //    {
        //        Name = hostname.Text,
        //        Level = 0,
        //        GameClass = _fhVM.ClassPicture(TxtChosenClass.Text),
        //        SlayedBeast = BeastEnum.none,
        //        IsHost = true,
        //        LocalPLayer = false,
        //        GameKey = game.Key,
        //        PremiumAccount = true
        //    };
        //    playerHub.JoinGame(HostPlayer);
        //}

        //void ReturnedExistingPlayers(object sender, List<Player> players)
        //{
        //    if (players != null)
        //    {
        //    _cgVM.PlayerList = players;
        //    playerHub.GetExistingPlayers -= ReturnedExistingPlayers;

        //    Activity.RunOnUiThread(() =>
        //    {
        //            spinner.Visibility = ViewStates.Gone;
        //            txtLoading.Visibility = ViewStates.Gone;
        //            progressframe.Visibility = ViewStates.Gone;


        //        var intent = new Intent(Context.ApplicationContext, typeof(CurrentGameActivity))
        //            .SetFlags(ActivityFlags.ReorderToFront);
        //        StartActivity(intent);
        //    });

        //    }
        //}

    }
}

