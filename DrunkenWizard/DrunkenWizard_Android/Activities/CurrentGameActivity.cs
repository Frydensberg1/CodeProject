using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using AlertDialog = Android.App.AlertDialog;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Graphics;
using static Android.Widget.TextView;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Support.V4.View;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_Android.ViewModels;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_Android.Activities;
using DrunkenWizard_SharedProject.WebService.Hubs;
using DrunkenWizard_SharedProject.DTO;
using Android.Runtime;
using DrunkenWizard_SharedProject.Enums;
using System.Threading.Tasks;

namespace DrunkenWizard_Android
{
    [Activity(Label = "CurrentGameActivity")]
    public class CurrentGameActivity : AppCompatActivity
    {
        FragmentHomeViewModel _fhVM = ServiceContainer.Resolve<FragmentHomeViewModel>();
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        PlayerService _PS = ServiceContainer.Resolve<PlayerService>();
        TextColorViewModel _tcVM = ServiceContainer.Resolve<TextColorViewModel>();
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();
        GameService _GS = ServiceContainer.Resolve<GameService>();
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        //  GameHub gameHUB = ServiceContainer.Resolve<GameHub>();
        PlayerHub playerHUB = ServiceContainer.Resolve<PlayerHub>();
        RecyclerView rcvCurrentGame;
        CurrentGameRecyclerAdapter adapter;
        RecyclerView.LayoutManager mLayoutManager;
        FloatingActionButton btnAddPlayer;
        Button btnAddPlayerName;
        ImageView imgRandom;
        TextView txtChooseclass;
        AlertDialog builderChangeClass;
        EditText txtPlayerName;
        TextView txtLevelUp;
        AlertDialog builder;
        Button btnEnd;
        SpannableStringBuilder spanbuilder;
        Toast toast;
        View ToastView;
        LayoutInflater Toastinf;
        Button GameKey;
        TextView txtnewhost;
        LinearLayoutManager layoutManagerClass;
        RecyclerView rcvClass;
        Player localplayer;
        TextView NameofPlayer;
        RelativeLayout LinearImageView;
        TextView txtLevel1_1;
        TextView txtLevel2_2;
        TextView txtLevel3_3;
        TextView txtLevel4_4;
        TextView txtLevel5_5;
        TextView txtLevel6_6;
        TextView txtLevel7_7;
        TextView txtLevel8_8;
        TextView txtLevel9_9;
        TextView txtLevel10_10;
        TextView txtSecondTextview1;
        TextView txtSecondTextview2;
        TextView txtSecondTextview3;
        TextView txtSecondTextview4;
        TextView txtSecondTextview5;
        TextView txtSecondTextview6;
        TextView txtSecondTextview7;
        TextView txtSecondTextview8;
        TextView txtSecondTextview9;
        TextView txtSecondTextview10;
        Button buttonSpell1;
        Button buttonSpell2;
        Button buttonSpell3;
        Button buttonSpell4;
        Button buttonSpell5;
        Button buttonSpell6;
        Button buttonSpell7;
        Button buttonSpell8;
        Button buttonSpell9;
        Button buttonSpell10;
        View Spell1Container;
        View Spell2Container;
        View Spell3Container;
        View Spell4Container;
        View Spell5Container;
        View Spell6Container;
        View Spell7Container;
        View Spell8Container;
        View Spell9Container;
        View Spell10Container;
        Button Close;
        ProgressBar loader;
        TextView progressTextview;
        FrameLayout progressframe;
        private MorphAnimation morphAnimationSpell1;
        private MorphAnimation morphAnimationSpell2;
        private MorphAnimation morphAnimationSpell3;
        private MorphAnimation morphAnimationSpell4;
        private MorphAnimation morphAnimationSpell5;
        private MorphAnimation morphAnimationSpell6;
        private MorphAnimation morphAnimationSpell7;
        private MorphAnimation morphAnimationSpell8;
        private MorphAnimation morphAnimationSpell9;
        private MorphAnimation morphAnimationSpell10;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CurrentGameLayout);
            SetupToolbar();
            SetupLayout();
        }

        void SetupLayout()
        {
            rcvCurrentGame = FindViewById<RecyclerView>(Resource.Id.rcvCurrentGame);
            GameKey = FindViewById<Button>(Resource.Id.btnGameKey);
            btnAddPlayer = FindViewById<FloatingActionButton>(Resource.Id.AddPlayerFab);
            btnEnd = FindViewById<Button>(Resource.Id.btnEnd);
            adapter = new CurrentGameRecyclerAdapter(this);
            adapter.MinusClicked += MinusClickedEvent;
            adapter.PlusClicked += PlusClickedEvent;
            adapter.BossClicked += BossClickedEvent;
            adapter.DragonHeadClicked += DragonHeadClickedEvent;
            adapter.MenuClicked += MenuClicked;
            adapter.RollingSpellsClicked += RollingSpellsClicked;
            adapter.CircleImageClicked += CirkelImageClicked;
            mLayoutManager = new LinearLayoutManager(this);
            rcvCurrentGame.SetLayoutManager(mLayoutManager);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvCurrentGame.Context, DividerItemDecoration.Vertical);
            rcvCurrentGame.AddItemDecoration(dividerItemDecoration);
            localplayer = _sqlVM.GetLocalPlayer();
            GameKey.Text = "Key: " + localplayer.GameKey;
            rcvCurrentGame.SetAdapter(adapter);
            btnAddPlayer.Click += BtnAddPlayer;
            btnEnd.Click += BtnLeave_Click;
            loader = FindViewById<ProgressBar>(Resource.Id.progress_loader_CurrentGame);
            loader.Visibility = ViewStates.Visible;
            //  playerHub.GetExistingPlayers += ReturnedExistingPlayers;
            progressTextview = FindViewById<TextView>(Resource.Id.progressTextviewCurrentGame);
            progressframe = FindViewById<FrameLayout>(Resource.Id.progress_CurrentGame);
            progressTextview.Visibility = ViewStates.Visible;
            progressframe.Visibility = ViewStates.Visible;
            toast = new Toast(this);
            Toastinf = LayoutInflater.From(this);
            ToastView = Toastinf.Inflate(Resource.Layout.Toast_TxtLevelUp, null);
            txtLevelUp = ToastView.FindViewById<TextView>(Resource.Id.txtMessage);
            toast.View = ToastView;
            toast.Duration = ToastLength.Short;
            toast.SetGravity(GravityFlags.Center, 0, 0);
            playerHUB.GetExistingPlayers += ReturnedExistingPlayers;
            playerHUB.ReturnedUpdateHost += ReturnedIshost;
            playerHUB.ReturnedUpdateLevel += ReturnedUpdateLevel;
            playerHUB.ReturnedUpdateBoostPlayer += ReturnedUpdateBoost;
            playerHUB.ReturnedUpdateGameClass += ReturnedUpdateGameClass;
            playerHUB.ReturnedUpdateSlayedBeast += ReturnedUpdateSlayedBeast;
            playerHUB.Reconnecting += Reconnecting;
            playerHUB.Reconnected += Reconnected;
            playerHUB.ReturnedDeletedPlayer += ReturnedDeletedPlayer;
            Task.Run(() =>
            {
                playerHUB.ExistingPLayers(localplayer.GameKey);
            });
        }

        public void updateadapter()
        {
            RunOnUiThread(() =>
            {
                adapter.NotifyDataSetChanged();
            });
        }

        private void BtnLeave_Click(object sender, EventArgs e)
        {
            if (_cgVM.PlayerList == null)
            {
                if (_sqlVM.GetLocalPlayer() != null)
                {
                    _sqlVM.Delete(localplayer);
                    Finish();
                }
            }
            else
            {
                if (_sqlVM.GetLocalPlayer().IsHost == true && _cgVM.PlayerList.Where(x => x.LocalPLayer == false).ToList().Count > 1)
                {
                    LayoutInflater li = LayoutInflater.From(this);
                    View promptsView = li.Inflate(Resource.Layout.LeavingGameHost, null);
                    builder = new AlertDialog.Builder(this).Create();
                    RecyclerView rcvnewhost = promptsView.FindViewById<RecyclerView>(Resource.Id.recyclerHost);
                    NewHostAdapter hostadapter = new NewHostAdapter(this);
                    hostadapter.CellClicked += newhostcellclick;
                    layoutManagerClass = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
                    rcvnewhost.SetLayoutManager(layoutManagerClass);
                    DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvnewhost.Context, DividerItemDecoration.Vertical);
                    rcvnewhost.AddItemDecoration(dividerItemDecoration);
                    rcvnewhost.SetAdapter(hostadapter);
                    txtnewhost = promptsView.FindViewById<TextView>(Resource.Id.nameofplayer);
                    Button btnLeave = promptsView.FindViewById<Button>(Resource.Id.btnLeaveHost);
                    Button btnCancel = promptsView.FindViewById<Button>(Resource.Id.btnCancelHost);
                    btnLeave.Click += BtnLeave_Click1;
                    btnCancel.Click += BtnCancel_Click;
                    builder.SetView(promptsView);
                    builder.Show();
                }
                else
                {
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this, Resource.Style.AlertDialog);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Leving Game");
                    alert.SetMessage("Are you sure?");
                    alert.SetButton("CANCEL", (c, ev) =>
                    {
                        return;
                    });
                    alert.SetButton2("YES", (c, ev) =>
                    {
                        if (_cgVM.PlayerList.Count == 1)
                        {
                            _GS.DeleteGame(_sqlVM.GetLocalPlayer().GameKey);
                        }
                        else
                        {
                            playerHUB.Leavegame(_sqlVM.GetLocalPlayer().Id);
                        }
                        _sqlVM.Delete(_sqlVM.GetLocalPlayer());
                        playerHUB.GetExistingPlayers -= ReturnedExistingPlayers;
                        playerHUB.ReturnedUpdateHost -= ReturnedIshost;
                        playerHUB.ReturnedUpdateLevel -= ReturnedUpdateLevel;
                        playerHUB.ReturnedUpdateBoostPlayer -= ReturnedUpdateBoost;
                        playerHUB.ReturnedUpdateGameClass -= ReturnedUpdateGameClass;
                        playerHUB.ReturnedUpdateSlayedBeast -= ReturnedUpdateSlayedBeast;
                        playerHUB.ReturnedDeletedPlayer -= ReturnedDeletedPlayer;
                        Finish();
                    });
                    alert.Show();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            builder.Dismiss();
        }

        private void BtnLeave_Click1(object sender, EventArgs e)
        {
            if (txtnewhost.Text == "")
            {
                Toast.MakeText(this, "Choose a new host", ToastLength.Long).Show();
                return;
            }
            var localplayer = _sqlVM.GetLocalPlayer();
            if (_cgVM.PlayerList.Where(x => x.LocalPLayer == false).ToList().Count == 1)
            {
                _GS.DeleteGame(localplayer.GameKey);
            }
            else
            {
                var newhost = _cgVM.PlayerList.FirstOrDefault(x => x.Name == txtnewhost.Text);
                if (newhost.LocalPLayer == true)
                {
                    Toast.MakeText(this, "You cannot make a local player host", ToastLength.Long).Show();
                    return;
                }
                if (newhost.Id != localplayer.Id)
                {
                    newhost.IsHost = true;
                    playerHUB.ReturnedUpdateHost -= ReturnedIshost;
                    playerHUB.UpdateHost(newhost.Id, newhost.IsHost);
                    //_PS.UpdatePlayer(newhost);
                    playerHUB.Leavegame(localplayer.Id);
                }
                else
                {
                    Toast.MakeText(this, "You cannot make yourself host", ToastLength.Long).Show();
                    return;
                }
            }

            _sqlVM.Delete(_sqlVM.GetLocalPlayer());
            playerHUB.GetExistingPlayers -= ReturnedExistingPlayers;
            playerHUB.ReturnedUpdateHost -= ReturnedIshost;
            playerHUB.ReturnedUpdateLevel -= ReturnedUpdateLevel;
            playerHUB.ReturnedUpdateBoostPlayer -= ReturnedUpdateBoost;
            playerHUB.ReturnedUpdateGameClass -= ReturnedUpdateGameClass;
            playerHUB.ReturnedUpdateSlayedBeast -= ReturnedUpdateSlayedBeast;
            playerHUB.ReturnedDeletedPlayer -= ReturnedDeletedPlayer;
            Finish();
        }

        private void newhostcellclick(object sender, Player e)
        {
            txtnewhost.Text = e.Name;
        }
        private void SetupToolbar()
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarb);
            var toolbartitel = FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Current Game";
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
                //  SupportActionBar.Title = "Current Game";
                toolbar.NavigationClick += (sender, args) => { Finish(); };
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.InfoMenu, menu);
            var item = menu.FindItem(Resource.Id.action_info);
            var documentView = MenuItemCompat.GetActionView(item);
            var view = documentView.JavaCast<View>();
            return true;
        }
        private void BtnAddPlayer(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeText(this, "Only the host can add another player.", ToastLength.Long).Show();
                return;
            }
            LayoutInflater li = LayoutInflater.From(this);
            View promptsView = li.Inflate(Resource.Layout.PlayerNames, null);
            builder = new AlertDialog.Builder(this).Create();
            builder.SetView(promptsView);
            builder.Show();
            btnAddPlayerName = promptsView.FindViewById<Button>(Resource.Id.btnAdd);
            btnAddPlayerName.Click += BtnAddPlayerName_Click;
            rcvClass = promptsView.FindViewById<RecyclerView>(Resource.Id.recycleAddPlayer);
            HorizontalClassAdapter adapter = new HorizontalClassAdapter(this);
            layoutManagerClass = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            rcvClass.SetLayoutManager(layoutManagerClass);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvClass.Context, DividerItemDecoration.Horizontal);
            rcvClass.AddItemDecoration(dividerItemDecoration);
            rcvClass.SetAdapter(adapter);
            adapter.CellClicked += CellClicked;
            adapter.CellClicked_CenterItem += CellClickedCenterItem;
            txtChooseclass = promptsView.FindViewById<TextView>(Resource.Id.txtChosenClassPlayer);
            txtPlayerName = promptsView.FindViewById<EditText>(Resource.Id.edit);
            imgRandom = promptsView.FindViewById<ImageView>(Resource.Id.imgRandom);
            imgRandom.Click += ImgRandom_Click;
        }

        private void CellClicked(object sender, GameClass e)
        {
            spanbuilder = new SpannableStringBuilder();
            spanbuilder = _tcVM.classtextcolor(e.Name);
            txtChooseclass.SetText(spanbuilder, BufferType.Spannable);
        }

        private void CellClickedCenterItem(object sender, View e)
        {
            scrollToCenter(e);
        }

        private void scrollToCenter(View v)
        {
            int itemToScroll = rcvClass.GetChildAdapterPosition(v);
            int centerOfScreen = rcvClass.Width / 2 - v.Width / 2;
            layoutManagerClass.ScrollToPositionWithOffset(itemToScroll, centerOfScreen);
        }

        private void Changeclass_Click(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeText(this, "Only the host may change a players class.", ToastLength.Long).Show();
                return;
            }

            if (_cgVM.SelectedPlayer.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris)
            {
                Toast.MakeText(this, "You can't change Dracsoris to another class", ToastLength.Long).Show();
                return;
            }
            LayoutInflater liClass = LayoutInflater.From(this);
            View promptsView = liClass.Inflate(Resource.Layout.ChooseClass, null);
            Button btnClose = promptsView.FindViewById<Button>(Resource.Id.btnClose);
            btnClose.Click += BtnClose_Click;
            RecyclerView rcv = promptsView.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            ChooseClassAdapter adapter = new ChooseClassAdapter(this);
            adapter.CellClicked += OnItemClickChange;
            rcv.SetAdapter(adapter);
            AutoFitGridLayoutManager layoutManager = new AutoFitGridLayoutManager(this, 425);
            rcv.SetLayoutManager(layoutManager);
            builderChangeClass = new AlertDialog.Builder(this, Android.Resource.Style.ThemeBlackNoTitleBarFullScreen).Create();
            builderChangeClass.SetView(promptsView);
            builderChangeClass.Show();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            builderChangeClass.Dismiss();
        }

        private void OnItemClickChange(object sender, GameClass e)
        {
            if (_cgVM.SelectedPlayer.PremiumAccount == false && e.PremiumClass == true)
            {
                Toast.MakeText(this, "This Class requires Premium Version", ToastLength.Long).Show();
                return;
            }
            _cgVM.SelectedPlayer.GameClass = e;
            playerHUB.UpdateChangeGameClass(_cgVM.SelectedPlayer.Id, e.Name);
            builderChangeClass.Dismiss();
            builder.Dismiss();
        }
        private void FightBoss_Click(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeText(this, "You can fight dragons after level 5, but only on the host's phone.", ToastLength.Long).Show();
                return;
            }

            if (_cgVM.SelectedPlayer.Level < 5)
            {
                Toast.MakeText(this, "You have to be level 5 to enter", ToastLength.Long).Show();
                return;
            }
            if (_cgVM.SelectedPlayer.SlayedBeast != DrunkenWizard_SharedProject.Enums.BeastEnum.none)
            {
                Toast.MakeText(this, "You already fought a mighty beast", ToastLength.Long).Show();
                return;
            }

            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this, Resource.Style.AlertDialog_Boss);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Fighting Mighty Magic Beast");
            alert.SetMessage("If you dont complete it, you decrease a level. Are you sure?");
            alert.SetIcon(Resource.Drawable.DeathWhite);
            alert.SetButton("Im too afraid", (c, ev) =>
            {
                return;
            });
            alert.SetButton2("Bring it on!", (c, ev) =>
            {
                _bfVM.selectedplayer = _cgVM.SelectedPlayer;
                var intent = new Intent(this, typeof(BossFightActivity))
                .SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(intent);
                builder.Dismiss();
            });
            alert.Show();
        }
        private void Deleteplayer_Click(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeText(this, "Only the host of the game can delete a player.", ToastLength.Long).Show();
                return;
            }
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this, Resource.Style.AlertDialog_Delete);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Deleting Player");
            alert.SetMessage("Are you sure?");

            alert.SetButton("CANCEL", (c, ev) =>
            {
                return;
            });
            alert.SetButton2("YES", (c, ev) =>
            {
                if (_cgVM.SelectedPlayer.IsHost == true)
                {
                    Toast.MakeText(this, "You can't delete the host of the game.", ToastLength.Long).Show();
                }
                else
                {
                    playerHUB.RemovePlayer(_cgVM.SelectedPlayer.Id);
                }
                builder.Dismiss();
            });
            alert.Show();
        }
        private void BtnAddPlayerName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlayerName.Text))
            {
                Toast.MakeText(this, "Add a name", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtChooseclass.Text))
            {
                Toast.MakeText(this, "Choose a class", ToastLength.Short).Show();
                return;
            }

            JoinPlayerDTO joinplayerdto = new JoinPlayerDTO
            {
                Name = txtPlayerName.Text,
                Level = 0,
                SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.none,
                IsHost = false,
                BoostUsed = false,
                LocalPLayer = true,
                GameKey = localplayer.GameKey,
                PremiumAccount = true,
                ClassName = txtChooseclass.Text

            };

            playerHUB.AddPlayerLocal(joinplayerdto);
            builder.Dismiss();
            adapter.NotifyDataSetChanged();
        }
        private void ImgRandom_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(_cVM.ClassList.Count());
            GameClass c = _cVM.ClassList[index];
            spanbuilder = _tcVM.classtextcolor(c.Name);
            txtChooseclass.Text = "";
            txtChooseclass.SetText(spanbuilder, BufferType.Spannable);
        }
        protected override void OnResume()
        {
            base.OnResume();
            {
                if (builder != null)
                {
                    builder.Dismiss();
                }
                if (adapter != null)
                {
                    adapter.NotifyDataSetChanged();
                }
            }
        }

        public override void OnBackPressed()
        {
            Finish();
        }

        private void Boost_Click(object sender, EventArgs e)
        {
            if (_cgVM.SelectedPlayer.BoostUsed)
            {
                Toast.MakeText(this, "You have used your boost already.", ToastLength.Long).Show();
                return;
            }
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this, Resource.Style.AlertDialog_Boost);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Boosting");
            alert.SetMessage("Are you sure?");
            alert.Window.SetBackgroundDrawableResource(Resource.Color.mtrl_btn_transparent_bg_color);
            alert.SetButton("CANCEL", (c, ev) =>
            {
                return;
            });
            alert.SetButton2("YES", (c, ev) =>
            {
                _cgVM.SelectedPlayer.Level++;
                _cgVM.SelectedPlayer.BoostUsed = true;
                playerHUB.UpdateBoostPlayer(_cgVM.SelectedPlayer.Id, true);
                playerHUB.UpdateLevelChange(_cgVM.SelectedPlayer.Id, _cgVM.SelectedPlayer.Level);
                builder.Dismiss();
                txtLevelUp.Text = "Boost Used!";
                toast.Show();
            });
            alert.Show();
        }
        void MinusClickedEvent(object sender, Player e)
        {
            if (e.Level == 0)
            {
                return;
            }

            if (!_sqlVM.GetLocalPlayer().IsHost)
            {
                if (e.Id != _sqlVM.GetLocalPlayer().Id)
                {
                    Toast.MakeText(this, "You can only decrease yourself", ToastLength.Short).Show();
                    return;
                }
            }

            if (e.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris)
            {
                Toast.MakeText(this, "Dracsoris can't level down", ToastLength.Short).Show();
                return;
            }

            e.Level--;
            txtLevelUp.Text = "Decreased..";
            toast.Show();
            playerHUB.UpdateLevelChange(e.Id, e.Level);
        }
        void DragonHeadClickedEvent(object sender, Player e)
        {
            ImageView imgdragon;
            TextView txtTitleDragon;
            TextView txtDescription;
            LayoutInflater liDragon = LayoutInflater.From(this);
            View promptsViewDragon = liDragon.Inflate(Resource.Layout.DragonHeadClickLayout, null);
            imgdragon = promptsViewDragon.FindViewById<ImageView>(Resource.Id.imgDragon);
            txtTitleDragon = promptsViewDragon.FindViewById<TextView>(Resource.Id.txtTitleDragon);
            txtDescription = promptsViewDragon.FindViewById<TextView>(Resource.Id.txtDescriptionDragon);
            builder = new AlertDialog.Builder(this).Create();
            builder.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            switch (e.SlayedBeast)
            {
                case DrunkenWizard_SharedProject.Enums.BeastEnum.Orecan:
                    imgdragon.SetImageResource(Resource.Drawable.Orecan);
                    txtTitleDragon.Text = "Orecan";
                    txtDescription.Text = "You icrease 1 level and all other wizards Decrease 1 level.";
                    break;

                case DrunkenWizard_SharedProject.Enums.BeastEnum.Trexzor:
                    imgdragon.SetImageResource(Resource.Drawable.Trexzor);
                    txtTitleDragon.Text = "Trexzor";
                    txtDescription.Text = "You may increase a level, and decrease another wizard a level.";
                    break;

                case DrunkenWizard_SharedProject.Enums.BeastEnum.Ile:
                    imgdragon.SetImageResource(Resource.Drawable.Ile);
                    txtTitleDragon.Text = "Ile";
                    txtDescription.Text = "You are immune to spells for the next 3 levels.(You can still use your own spells).";
                    break;

                case DrunkenWizard_SharedProject.Enums.BeastEnum.Dracyllis:
                    imgdragon.SetImageResource(Resource.Drawable.Dracyllis);
                    txtTitleDragon.Text = "Dracyllis";
                    txtDescription.Text = "You may reuse your boost";
                    break;

                case DrunkenWizard_SharedProject.Enums.BeastEnum.Barcyl:
                    imgdragon.SetImageResource(Resource.Drawable.Barcyl);
                    txtTitleDragon.Text = "Barcyl";
                    txtDescription.Text = "Everytime you use a spell, every other wizards have to roll a dice. 3 or lower and they take a shot.";
                    break;

                case DrunkenWizard_SharedProject.Enums.BeastEnum.Zeodrenth:
                    imgdragon.SetImageResource(Resource.Drawable.Zeodrenth);
                    txtTitleDragon.Text = "Zeodrenth";
                    txtDescription.Text = "You may now roll 2 times every turn";
                    break;

                case DrunkenWizard_SharedProject.Enums.BeastEnum.Dracenic:
                    imgdragon.SetImageResource(Resource.Drawable.Dracenic);
                    txtTitleDragon.Text = "Dracenic";
                    txtDescription.Text = "Decrease 2 wizards by 1 level.";
                    break;

                default:
                    break;
            }
            builder.SetView(promptsViewDragon);
            builder.Show();
        }
        void BossClickedEvent(object sender, Player e)
        {
            builder = new AlertDialog.Builder(this, Resource.Style.AlertDialog_LevelUp).Create();
            LayoutInflater inflater = LayoutInflater.From(this);
            View promptview = inflater.Inflate(Resource.Layout.BossesClickedLayout, null);
            ImageView imgboss1 = promptview.FindViewById<ImageView>(Resource.Id.imgboss1);
            ImageView imgboss2 = promptview.FindViewById<ImageView>(Resource.Id.imgboss2);
            ImageView imgboss3 = promptview.FindViewById<ImageView>(Resource.Id.imgboss3);
            TextView txtxboss1 = promptview.FindViewById<TextView>(Resource.Id.txtboss1);
            TextView txtxboss2 = promptview.FindViewById<TextView>(Resource.Id.txtboss2);
            TextView txtxboss3 = promptview.FindViewById<TextView>(Resource.Id.txtboss3);

            if (e.Level >= 3)
            {
                imgboss1.SetImageResource(Resource.Drawable.Boss1);
                txtxboss1.Text = "Defeated!";
            }

            if (e.Level >= 6)
            {
                imgboss2.SetImageResource(Resource.Drawable.Boss2);
                txtxboss2.Text = "Defeated!";
            }
            if (e.Level >= 9)
            {
                imgboss3.SetImageResource(Resource.Drawable.Boss3);
                txtxboss3.Text = "Defeated!";
            }
            builder.SetView(promptview);
            builder.Show();
        }
        void CirkelImageClicked(object sender, Player TagObj)
        {
            LayoutInflater li = LayoutInflater.From(this);
            View promptsView = li.Inflate(Resource.Layout.Fragment_Spells, null);
            builder = new AlertDialog.Builder(this).Create();
            _cgVM.SelectedPlayer = TagObj;
            var intent = new Intent(this, typeof(SpellFragments_Activity));
            StartActivity(intent);
        }

        void RollingSpellsClicked(object sender, Player e)
        {
            _cgVM.SelectedPlayer = e;
            LayoutInflater li = LayoutInflater.From(this);
            View promptsView = li.Inflate(Resource.Layout.ThisLevelRolls_Layout, null);
            LinearLayout LL = promptsView.FindViewById<LinearLayout>(Resource.Id.linearLevelRoll);
            CardView cW = promptsView.FindViewById<CardView>(Resource.Id.cWLevelRoll);
            builder = new AlertDialog.Builder(this, Resource.Style.AlertDialog_LongClickMenu).Create();
            TextView level1 = promptsView.FindViewById<TextView>(Resource.Id.txtLevel1Roll1);
            TextView level1Effect = promptsView.FindViewById<TextView>(Resource.Id.txtLevel1Effect);
            TextView level2 = promptsView.FindViewById<TextView>(Resource.Id.txtLevel2Roll2);
            TextView level2Effect = promptsView.FindViewById<TextView>(Resource.Id.txtLevel2Effect);
            TextView level3 = promptsView.FindViewById<TextView>(Resource.Id.txtLevel3Roll3);
            TextView level3Effect = promptsView.FindViewById<TextView>(Resource.Id.txtLevel3Effect);
            TextView level4 = promptsView.FindViewById<TextView>(Resource.Id.txtLevel4Roll4);
            TextView level4Effect = promptsView.FindViewById<TextView>(Resource.Id.txtLevel4Effect);
            TextView level5 = promptsView.FindViewById<TextView>(Resource.Id.txtLevel5Roll5);
            TextView level5Effect = promptsView.FindViewById<TextView>(Resource.Id.txtLevel5Effect);
            TextView level6 = promptsView.FindViewById<TextView>(Resource.Id.txtLevel6Roll6);
            TextView level6Effect = promptsView.FindViewById<TextView>(Resource.Id.txtLevel6Effect);
            level1.SetTextColor(Color.White);
            level1Effect.SetTextColor(Color.White);
            level2.SetTextColor(Color.White);
            level2Effect.SetTextColor(Color.White);
            level3.SetTextColor(Color.White);
            level3Effect.SetTextColor(Color.White);
            level4.SetTextColor(Color.White);
            level4Effect.SetTextColor(Color.White);
            level5.SetTextColor(Color.White);
            level5Effect.SetTextColor(Color.White);
            level6.SetTextColor(Color.White);
            level6Effect.SetTextColor(Color.White);
            level5.Visibility = ViewStates.Gone;
            level5Effect.Visibility = ViewStates.Gone;
            if (_cgVM.SelectedPlayer.Level >= 3)
            {
                level2.Visibility = ViewStates.Visible;
                level2Effect.Visibility = ViewStates.Visible;
            }
            if (_cgVM.SelectedPlayer.Level >= 6)
            {
                level3.Visibility = ViewStates.Visible;
                level3Effect.Visibility = ViewStates.Visible;
            }
            if (_cgVM.SelectedPlayer.Level >= 9)
            {
                level4.Visibility = ViewStates.Visible;
                level4Effect.Visibility = ViewStates.Visible;
            }
            cW.SetCardBackgroundColor(Color.ParseColor(_cgVM.SelectedPlayer.GameClass.Color));
            level1Effect.Text = _cgVM.SelectedPlayer.GameClass.RollEffect1;
            level2Effect.Text = _cgVM.SelectedPlayer.GameClass.RollEffect2;
            level3Effect.Text = _cgVM.SelectedPlayer.GameClass.RollEffect3;
            level4Effect.Text = _cgVM.SelectedPlayer.GameClass.RollEffect4;
            level5Effect.Text = _cgVM.SelectedPlayer.GameClass.RollEffect5;
            level6Effect.Text = _cgVM.SelectedPlayer.GameClass.RollEffect6;

            if (_cgVM.SelectedPlayer.GameClass.Name == "Cleric" || _cgVM.SelectedPlayer.GameClass.Name == "Elementalist")
            {
                level1.SetTextColor(Color.Black);
                level1Effect.SetTextColor(Color.Black);
                level2.SetTextColor(Color.Black);
                level2Effect.SetTextColor(Color.Black);
                level3.SetTextColor(Color.Black);
                level3Effect.SetTextColor(Color.Black);
                level4.SetTextColor(Color.Black);
                level4Effect.SetTextColor(Color.Black);
                level5.SetTextColor(Color.Black);
                level5Effect.SetTextColor(Color.Black);
                level6.SetTextColor(Color.Black);
                level6Effect.SetTextColor(Color.Black);
            }
            builder.SetView(promptsView);
            builder.Show();
        }

        void MenuClicked(object sender, Player e)
        {
            _cgVM.SelectedPlayer = e;
            LayoutInflater li = LayoutInflater.From(this);
            View promptsView = li.Inflate(Resource.Layout.GameMenu, null);
            builder = new AlertDialog.Builder(this, Resource.Style.AlertDialog_LongClickMenu).Create();
            ImageButton imgbtnBoost = promptsView.FindViewById<ImageButton>(Resource.Id.imgbtnBoost);
            ImageButton imgbtnChange = promptsView.FindViewById<ImageButton>(Resource.Id.imgbtnChangePlayer);
            ImageButton imgbtnDragon = promptsView.FindViewById<ImageButton>(Resource.Id.imgbtnDragon);
            ImageButton imgbtnDelete = promptsView.FindViewById<ImageButton>(Resource.Id.imgbtnDelete);
            Button Close = promptsView.FindViewById<Button>(Resource.Id.btnClose);
            Close.Click += Close_Click;
            TextView txtBoostMenu = promptsView.FindViewById<TextView>(Resource.Id.txtBoost);
            TextView txtChangeMenu = promptsView.FindViewById<TextView>(Resource.Id.txtChangePlayer);
            TextView txtDragonMenu = promptsView.FindViewById<TextView>(Resource.Id.txtDragon);
            TextView txtDeleteMenu = promptsView.FindViewById<TextView>(Resource.Id.txtDelete);
            imgbtnChange.Click += Changeclass_Click;
            imgbtnDragon.Click += FightBoss_Click;
            imgbtnBoost.Click += Boost_Click;
            imgbtnDelete.Click += Deleteplayer_Click;
            builder.SetView(promptsView);
            builder.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            builder.Dismiss();
        }

        void PlusClickedEvent(object sender, Player e)
        {
            if (!_sqlVM.GetLocalPlayer().IsHost)
            {
                if (e.Id != _sqlVM.GetLocalPlayer().Id)
                {
                    Toast.MakeText(this, "You can only level yourself up", ToastLength.Short).Show();
                    return;
                }
            }
            if (e.Level == 10)
            {
                Toast.MakeText(this, "You are already max level", ToastLength.Short).Show();
                return;
            }
            e.Level++;
            if (builder != null)
            {
                builder.Dismiss();
            }


            builder = new AlertDialog.Builder(this, Resource.Style.AlertDialog_LevelUp).Create();
            LayoutInflater inflater = LayoutInflater.From(this);
            View promptview = inflater.Inflate(Resource.Layout.LevelUpSpell, null);
            TextView txtLevelUpSpell = promptview.FindViewById<TextView>(Resource.Id.txtMessageSpell);
            TextView txtSpell = promptview.FindViewById<TextView>(Resource.Id.txtspellName);
            TextView txtSpellEffect = promptview.FindViewById<TextView>(Resource.Id.txtspellEffect);
            TextView btnOK = promptview.FindViewById<TextView>(Resource.Id.btnlvlupok);
            ImageView imgDrunkenWizardLevel10 = promptview.FindViewById<ImageView>(Resource.Id.imgDrunkenWizardLevel10);
            View v1 = promptview.FindViewById<View>(Resource.Id.v1);
            btnOK.Click += BtnOK_Click;

            CardView CardViewLevelUp = promptview.FindViewById<CardView>(Resource.Id.cWLevelRoll);
            txtLevelUpSpell.Text = "Level Up!";

            if (e.Level == 3 || e.Level == 6 || e.Level == 9)
            {
                if (e.Name == "Dracsoris")
                {
                    CardViewLevelUp.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    btnOK.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    v1.Visibility = ViewStates.Gone;
                    txtSpell.Text = "Boss Fight!";
                    txtSpellEffect.Text = "You won the fight!";
                }
                else
                {
                    CardViewLevelUp.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    btnOK.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    v1.Visibility = ViewStates.Gone;
                    imgDrunkenWizardLevel10.Visibility = ViewStates.Visible;
                    txtSpellEffect.Text = "Drink a shot to beat the boss.";
                    switch (e.Level)
                    {
                        case 3:
                            imgDrunkenWizardLevel10.SetImageResource(Resource.Drawable.Boss1);
                            txtSpell.Text = "Boss Fight! Boss 1";
                            break;
                        case 6:
                            imgDrunkenWizardLevel10.SetImageResource(Resource.Drawable.Boss2);
                            txtSpell.Text = "Boss Fight! Boss 2";
                            break;
                        case 9:
                            imgDrunkenWizardLevel10.SetImageResource(Resource.Drawable.Boss3);
                            txtSpell.Text = "Boss Fight! Boss 3";
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (e.GameClass.Spells.FirstOrDefault(x => x.Level == e.Level) != null)
                {
                    string style = "";
                    if (e.GameClass.Spells.FirstOrDefault(x => x.Level == e.Level).Style != null)
                    {
                        style = e.GameClass.Spells.FirstOrDefault(x => x.Level == e.Level).Style;
                    }
                    else
                    {
                        style = "";
                    }
                    CardViewLevelUp.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(e.GameClass.Color));
                    btnOK.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(e.GameClass.Color));
                    v1.Visibility = ViewStates.Visible;
                    if (e.GameClass.Name == "Cleric" || e.GameClass.Name == "Elementalist")
                    {
                        var stringwithcolorCleric = _tcVM.GetColoredText(Color.Black, style, "Level " + e.Level + ". " + e.GameClass.Spells.FirstOrDefault(x => x.Level == e.Level).Name);
                        txtSpell.SetText(stringwithcolorCleric, BufferType.Spannable);
                        txtSpellEffect.SetTextColor(Color.Black);
                        btnOK.BackgroundTintList = ColorStateList.ValueOf(Color.Black);
                        btnOK.SetTextColor(Color.Black);
                        v1.SetBackgroundColor(Color.Black);
                    }
                    else
                    {
                        var stringwithcolor = _tcVM.GetColoredText(Color.White, style, "Level " + e.Level + ". " + e.GameClass.Spells.FirstOrDefault(x => x.Level == e.Level).Name);
                        txtSpell.SetText(stringwithcolor, BufferType.Spannable);
                    }

                    txtSpellEffect.Text = e.GameClass.Spells.FirstOrDefault(x => x.Level == e.Level).Description;

                }
                else if (e.Level == 10)
                {
                    CardViewLevelUp.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    btnOK.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    v1.Visibility = ViewStates.Gone;
                    txtSpell.Text = "You are now a Drunken Wizard!";
                    txtSpellEffect.Text = "";
                    imgDrunkenWizardLevel10.SetImageResource(Resource.Drawable.DrunkenWizardLogo);
                    imgDrunkenWizardLevel10.Visibility = ViewStates.Visible;
                }
                else
                {
                    CardViewLevelUp.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    btnOK.BackgroundTintList = ColorStateList.ValueOf(Color.Transparent);
                    v1.Visibility = ViewStates.Gone;
                    txtSpell.Text = "Drunken Wizard";
                    txtSpellEffect.Text = "You have already achieved the Drunken Wizard status!";
                }
            }
            builder.SetView(promptview);
            builder.Show();
            playerHUB.UpdateLevelChange(e.Id, e.Level);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            builder.Dismiss();
        }

        void ReturnedExistingPlayers(object sender, List<Player> players)
        {
        //    CheckIfYouAreHost(players);
            _cgVM.PlayerList = players;
            RunOnUiThread(() =>
            {
                updateadapter();

                HideHud();
            });
        }

        void ReturnedUpdateLevel(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    if (player.Level < (int)updateDTO.prop)
                    {
                        txtLevelUp.Text = "Level Up!";
                        toast.Show();
                    }
                    else if (player.Level > (int)updateDTO.prop)
                    {
                        txtLevelUp.Text = "Decreased..";
                        toast.Show();
                    }
                }
                player.Level = (int)updateDTO.prop;
            }

            RunOnUiThread(() =>
            {
                updateadapter();
                HideHud();
            });
        }

        void ReturnedIshost(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                var localplayer = _sqlVM.GetLocalPlayer();
                if (localplayer != null)
                {
                    if (player.Id == localplayer.Id)
                    {
                        txtLevelUp.Text = "You have become Host";
                        toast.Show();
                        localplayer.IsHost = true;
                        _sqlVM.UpdateLocalPlayer(localplayer);
                    }
                }
                player.IsHost = (bool)updateDTO.prop;
            }

            RunOnUiThread(() =>
            {
                updateadapter();
                HideHud();
            });
        }



        void ReturnedUpdateBoost(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    // box der skal vise at dit boost er blevet brugt
                    txtLevelUp.Text = "Boost Used!";
                    toast.Show();

                }
                player.BoostUsed = (bool)updateDTO.prop;
            }

            RunOnUiThread(() =>
            {
                updateadapter();
                HideHud();
            });
        }

        void ReturnedUpdateGameClass(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    txtLevelUp.Text = "Your class has been changed";
                    toast.Show();
                }
                player.GameClass = _cVM.ClassList.FirstOrDefault(x => x.Name == (string)updateDTO.prop);
            }

            RunOnUiThread(() =>
            {
                updateadapter();
                HideHud();
            });
        }

        void ReturnedUpdateSlayedBeast(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    txtLevelUp.Text = "You slyaed a Dragon!";
                    toast.Show();
                }
                player.SlayedBeast = (BeastEnum)updateDTO.prop;
            }

            RunOnUiThread(() =>
            {
                updateadapter();
                HideHud();
            });
        }

        void ReturnedDeletedPlayer(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player!= null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    _sqlVM.Delete(player);
                    playerHUB.GetExistingPlayers -= ReturnedExistingPlayers;
                    playerHUB.ReturnedUpdateHost -= ReturnedIshost;
                    playerHUB.ReturnedUpdateLevel -= ReturnedUpdateLevel;
                    playerHUB.ReturnedUpdateBoostPlayer -= ReturnedUpdateBoost;
                    playerHUB.ReturnedUpdateGameClass -= ReturnedUpdateGameClass;
                    playerHUB.ReturnedUpdateSlayedBeast -= ReturnedUpdateSlayedBeast;
                    playerHUB.ReturnedDeletedPlayer -= ReturnedDeletedPlayer;
                    playerHUB.SetHubConnToNull();
                    Finish();
                }
          
         
            RunOnUiThread(() =>
            {
                _cgVM.PlayerList.Remove(player);
                updateadapter();
                HideHud();
            });
            }
        }
        void Reconnecting(object sender, Exception exception)
        {
            RunOnUiThread(() =>
            {
                progressTextview.Text = "Trying to reconnect..";
                ShowHud();
            });
        }

        void Reconnected(object sender, string arg)
        {
            RunOnUiThread(() =>
            {
                progressTextview.Text = "Reconnected!";

                HideHud();
            });
        }

        void HideHud()
        {
            loader.Visibility = ViewStates.Gone;
            progressTextview.Visibility = ViewStates.Gone;
            progressframe.Visibility = ViewStates.Gone;
        }

        void ShowHud()
        {
            loader.Visibility = ViewStates.Visible;
            progressTextview.Visibility = ViewStates.Visible;
            progressframe.Visibility = ViewStates.Visible;
        }

        void CheckIfYouAreHost(List<Player> players)
        {
            var localplayer = _sqlVM.GetLocalPlayer();
            if (localplayer != null)
            {
                var player = players.FirstOrDefault(x => x.Id == localplayer.Id);
                if (player != null)
                {
                    localplayer.IsHost = player.IsHost;
                    _sqlVM.UpdateLocalPlayer(localplayer);
                }
                else
                {
                    _sqlVM.Delete(localplayer);
                    playerHUB.GetExistingPlayers -= ReturnedExistingPlayers;
                    playerHUB.ReturnedUpdateHost -= ReturnedIshost;
                    playerHUB.ReturnedUpdateLevel -= ReturnedUpdateLevel;
                    playerHUB.ReturnedUpdateBoostPlayer -= ReturnedUpdateBoost;
                    playerHUB.ReturnedUpdateGameClass -= ReturnedUpdateGameClass;
                    playerHUB.ReturnedUpdateSlayedBeast -= ReturnedUpdateSlayedBeast;
                    Finish();
                    return;
                }
            }
            else
            {
                Finish();
            }
        }


        #region animations
        private void ButtonSpell10_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell10.isPressed)
            {
                morphAnimationSpell10.morphIntoForm();
            }
            else
            {
                morphAnimationSpell10.morphIntoButtonSpell10();
            }
        }
        private void ButtonSpell9_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell9.isPressed)
            {
                morphAnimationSpell9.morphIntoForm();
            }
            else
            {
                morphAnimationSpell9.morphIntoButtonSpell9();
            }
        }
        private void ButtonSpell8_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell8.isPressed)
            {
                morphAnimationSpell8.morphIntoForm();
            }
            else
            {
                morphAnimationSpell8.morphIntoButtonSpell8();
            }
        }
        private void ButtonSpell7_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell7.isPressed)
            {
                morphAnimationSpell7.morphIntoForm();
            }
            else
            {
                morphAnimationSpell7.morphIntoButtonSpell7();
            }
        }
        private void ButtonSpell6_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell6.isPressed)
            {
                morphAnimationSpell6.morphIntoForm();
            }
            else
            {
                morphAnimationSpell6.morphIntoButtonSpell6();
            }
        }
        private void ButtonSpell5_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell5.isPressed)
            {
                morphAnimationSpell5.morphIntoForm();
            }
            else
            {
                morphAnimationSpell5.morphIntoButtonSpell5();
            }
        }
        private void ButtonSpell4_Click1(object sender, EventArgs e)
        {
            if (!morphAnimationSpell4.isPressed)
            {
                morphAnimationSpell4.morphIntoForm();
            }
            else
            {
                morphAnimationSpell4.morphIntoButtonSpell4();
            }
        }
        private void ButtonSpell3_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell3.isPressed)
            {
                morphAnimationSpell3.morphIntoForm();
            }
            else
            {
                morphAnimationSpell3.morphIntoButtonSpell3();
            }
        }
        private void ButtonSpell2_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell2.isPressed)
            {
                morphAnimationSpell2.morphIntoForm();
            }
            else
            {
                morphAnimationSpell2.morphIntoButtonSpell2();
            }

        }
        private void buttonSpell1_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell1.isPressed)
            {
                morphAnimationSpell1.morphIntoForm();
            }
            else
            {
                morphAnimationSpell1.morphIntoButton();
            }

        }
        #endregion
    }
}
