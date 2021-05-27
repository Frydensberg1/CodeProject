using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphics;
using DrunkenWizard_iOS.Base;
using DrunkenWizard_iOS.Services;
using DrunkenWizard_iOS.ViewControllers.Shared.BossDefeated;
using DrunkenWizard_iOS.ViewControllers.Shared.BossFight;
using DrunkenWizard_iOS.ViewControllers.Shared.LevelUp;
using DrunkenWizard_iOS.ViewControllers.Shared.PlayerMenu;
using DrunkenWizard_iOS.ViewControllers.Shared.RollingSpells;
using DrunkenWizard_iOS.ViewControllers.Shared.SpellPopUp;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_SharedProject.WebService.Hubs;
using GlobalToast;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.CurrentGame
{
    public partial class CurrentGameVc : UIViewControllerExtended
    {
        Player _localPlayer;
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        TextColorService _tcVM = ServiceContainer.Resolve<TextColorService>();
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        GameService _GS = ServiceContainer.Resolve<GameService>();
        PlayerHub playerHUB = ServiceContainer.Resolve<PlayerHub>();

        CurrentGameTableSource _currentGameTableSource;


        public CurrentGameVc() : base("CurrentGameVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Current Game".Translated();

            _localPlayer = _sqlVM.GetLocalPlayer();
            SetupTable();

            btnAddPlayer.TouchUpInside += BtnAddPlayer_TouchUpInside;
            btnLeaveGame.TouchUpInside += BtnLeaveGame_TouchUpInside;

            btnAddPlayer.MakeCircle(UIColor.White);

            btnGameKey.SetTitle($"{"Key".Translated()}: {_localPlayer.GameKey}", UIControlState.Normal);



            // TODO: Shadow 
            //btnAddPlayer.Layer.ShadowColor = UIColor.Black.CGColor;
            //btnAddPlayer.Layer.ShadowOffset = new CGSize(3, 3);
            //btnAddPlayer.Layer.ShadowRadius = 5;
            //btnAddPlayer.Layer.ShadowOpacity = 1f;
            //btnAddPlayer.Layer.MasksToBounds = true;
            //btnAddPlayer.Layer.ShadowPath = UIBezierPath.FromRoundedRect(btnAddPlayer.Bounds, 10).CGPath;

            playerHUB.GetExistingPlayers += ReturnedExistingPlayers; // Check
            playerHUB.ReturnedUpdateHost += ReturnedIsHost;
            playerHUB.ReturnedUpdateLevel += ReturnedUpdateLevel; // Check
            playerHUB.ReturnedUpdateBoostPlayer += ReturnedUpdateBoost; // Check
            playerHUB.ReturnedUpdateGameClass += ReturnedUpdateGameClass; // Check
            playerHUB.ReturnedUpdateSlayedBeast += ReturnedUpdateSlayedBeast; // Check
            playerHUB.Reconnecting += Reconnecting; // Check 
            playerHUB.Reconnected += Reconnected; // Check
            playerHUB.ReturnedDeletedPlayer += ReturnedDeletedPlayer;



            // iOS workaround
            ShowHUD("Loading...".Translated());
            Task.Run(() => playerHUB.ExistingPLayers(_localPlayer.GameKey));

        }

        private void ReturnedIsHost(object sender, UpdateDTO e)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == e.playerID);
            if (player != null)
            {
                var localplayer = _sqlVM.GetLocalPlayer();
                if (localplayer != null)
                {
                    if (player.Id == localplayer.Id)
                    {
                        InvokeOnMainThread(delegate
                        {
                            Toast.MakeToast("You have become Host!".Translated())
                             .SetAppearance(new ToastAppearance { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                             .SetDuration(3000)
                             .SetPosition(ToastPosition.Center)
                             .Show();
                        });
                        localplayer.IsHost = true;
                        _sqlVM.UpdateLocalPlayer(localplayer);
                    }
                }
                player.IsHost = (bool)e.prop;
            }

            InvokeOnMainThread(() =>
            {
                tblPlayers.ReloadData();
                HideHUD();
            });
        }

        private void ReturnedDeletedPlayer(object sender, UpdateDTO e)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == e.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    _sqlVM.Delete(player);
                    Unsubscribe();
                    playerHUB.SetHubConnToNull();
                    InvokeOnMainThread(() => NavigationController.PopViewController(true));
                }


                InvokeOnMainThread(() =>
                {
                    _cgVM.PlayerList.Remove(player);
                    InvokeOnMainThread(tblPlayers.ReloadData);
                    HideHUD();
                });
            }
        }

        void ReturnedUpdateSlayedBeast(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    InvokeOnMainThread(delegate
                    {
                        Toast.MakeToast("You slayed a Dragon!".Translated())
                         .SetAppearance(new ToastAppearance { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                         .SetDuration(3000)
                         .SetPosition(ToastPosition.Center)
                         .Show();
                    });

                }
                player.SlayedBeast = (BeastEnum)updateDTO.prop;
            }

            InvokeOnMainThread(() =>
            {
                InvokeOnMainThread(tblPlayers.ReloadData);
            });
        }

        void ReturnedUpdateGameClass(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    InvokeOnMainThread(delegate
                    {
                        Toast.MakeToast("Your class has been changed".Translated())
                         .SetAppearance(new ToastAppearance { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                         .SetDuration(3000)
                         .SetPosition(ToastPosition.Center)
                         .Show();
                    });
                }
                player.GameClass = _cVM.ClassList.FirstOrDefault(x => x.Name == (string)updateDTO.prop);
            }

            InvokeOnMainThread(() =>
            {
                InvokeOnMainThread(tblPlayers.ReloadData);
            });
        }

        void Reconnecting(object sender, Exception exception)
        {
            ShowHUD("Trying to reconnect");
        }

        void Reconnected(object sender, string arg)
        {
            HideHUD(true, "Reconnected".Translated());
        }

        void ReturnedUpdateBoost(object sender, UpdateDTO updateDTO)
        {
            var player = _cgVM.PlayerList.FirstOrDefault(x => x.Id == updateDTO.playerID);
            if (player != null)
            {
                if (player.Id == _sqlVM.GetLocalPlayer().Id)
                {
                    InvokeOnMainThread(delegate
                    {
                        Toast.MakeToast("Boost used!".Translated())
                         .SetAppearance(new ToastAppearance { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                         .SetDuration(3000)
                         .SetPosition(ToastPosition.Center)
                         .Show();
                    });
                }
                player.BoostUsed = (bool)updateDTO.prop;
            }

            InvokeOnMainThread(() =>
            {
                InvokeOnMainThread(tblPlayers.ReloadData);
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
                        InvokeOnMainThread(delegate
                        {
                            Toast.MakeToast("Level Up!".Translated())
                             .SetPosition(GlobalToast.ToastPosition.Center)
                             .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                             .Show();
                        });
                    }
                    else if (player.Level > (int)updateDTO.prop)
                    {
                        InvokeOnMainThread(delegate
                        {
                            Toast.MakeToast("Decreased...".Translated())
                            .SetPosition(GlobalToast.ToastPosition.Center)
                            .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                            .Show();
                        });
                    }
                }
                player.Level = (int)updateDTO.prop;
            }

            InvokeOnMainThread(() =>
            {
                tblPlayers.ReloadData();
            });
        }

        private void SetupTable()
        {
            _currentGameTableSource = new CurrentGameTableSource();

            _currentGameTableSource.MinusClicked += HandleMinusClicked;
            _currentGameTableSource.PlusClicked += HandlePlusClicked;
            _currentGameTableSource.BossClicked += HandleBossClicked;
            _currentGameTableSource.DragonHeadClicked += HandleDragonHeadClicked;
            _currentGameTableSource.DisplaySpell += HandleDisplaySpell;
            _currentGameTableSource.MenuClicked += HandleMenuClicked;
            _currentGameTableSource.RollingSpellsClicked += HandleRollingSpellClicked;
            _currentGameTableSource.CircleImageClicked += HandlePlusClicked;

            tblPlayers.RegisterNibForCellReuse(CurrentGameCell.Nib, CurrentGameCell.CellId);
            tblPlayers.Source = _currentGameTableSource;
            tblPlayers.SeparatorColor = UIColor.Black;
            tblPlayers.BackgroundColor = UIColor.DarkGray;
            tblPlayers.TableFooterView = new UIView();
        }

        private void HandleBossClicked(object sender, Player e)
        {
            var lvlUpVc = new BossDefeatedVc(e);
            lvlUpVc.ModalPresentationStyle = UIModalPresentationStyle.Automatic;
            PresentViewController(lvlUpVc, true, null);
        }

        private void HandleDragonHeadClicked(object sender, Player e)
        {
            //ImageView imgdragon;
            //TextView txtTitleDragon;
            //TextView txtDescription;
            //LayoutInflater liDragon = LayoutInflater.From(this);
            //View promptsViewDragon = liDragon.Inflate(Resource.Layout.DragonHeadClickLayout, null);
            //imgdragon = promptsViewDragon.FindViewById<ImageView>(Resource.Id.imgDragon);
            //txtTitleDragon = promptsViewDragon.FindViewById<TextView>(Resource.Id.txtTitleDragon);
            //txtDescription = promptsViewDragon.FindViewById<TextView>(Resource.Id.txtDescriptionDragon);
            //builder = new AlertDialog.Builder(this).Create();
            //builder.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            //switch (e.SlayedBeast)
            //{
            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Orecan:
            //        imgdragon.SetImageResource(Resource.Drawable.Orecan);
            //        txtTitleDragon.Text = "Orecan";
            //        txtDescription.Text = "You icrease 1 level and all other wizards Decrease 1 level.";
            //        break;

            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Trexzor:
            //        imgdragon.SetImageResource(Resource.Drawable.Trexzor);
            //        txtTitleDragon.Text = "Trexzor";
            //        txtDescription.Text = "You may increase a level, and decrease another wizard a level.";
            //        break;

            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Ile:
            //        imgdragon.SetImageResource(Resource.Drawable.Ile);
            //        txtTitleDragon.Text = "Ile";
            //        txtDescription.Text = "You are immune to spells for the next 3 levels.(You can still use your own spells).";
            //        break;

            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Dracyllis:
            //        imgdragon.SetImageResource(Resource.Drawable.Dracyllis);
            //        txtTitleDragon.Text = "Dracyllis";
            //        txtDescription.Text = "You may reuse your boost";
            //        break;

            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Barcyl:
            //        imgdragon.SetImageResource(Resource.Drawable.Barcyl);
            //        txtTitleDragon.Text = "Barcyl";
            //        txtDescription.Text = "Everytime you use a spell, every other wizards have to roll a dice. 3 or lower and they take a shot.";
            //        break;

            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Zeodrenth:
            //        imgdragon.SetImageResource(Resource.Drawable.Zeodrenth);
            //        txtTitleDragon.Text = "Zeodrenth";
            //        txtDescription.Text = "You may now roll 2 times every turn";
            //        break;

            //    case DrunkenWizard_SharedProject.Enums.BeastEnum.Dracenic:
            //        imgdragon.SetImageResource(Resource.Drawable.Dracenic);
            //        txtTitleDragon.Text = "Dracenic";
            //        txtDescription.Text = "Decrease 2 wizards by 1 level.";
            //        break;

            //    default:
            //        break;
            //}
            //builder.SetView(promptsViewDragon);
            //builder.Show();
        }

        private void HandleMenuClicked(object sender, Player e)
        {
            _cgVM.SelectedPlayer = e;

            var spellVc = new PlayerMenuVc();
            spellVc.ShowBossFightUi += HandleShowBossFightUi;
            spellVc.ModalPresentationStyle = UIModalPresentationStyle.Automatic;
            PresentViewController(spellVc, true, null);
        }

        private void HandleShowBossFightUi(object sender, EventArgs e)
        {
            var bossVc = new DragonFightVc();
            bossVc.ModalPresentationStyle = UIModalPresentationStyle.Automatic;
            PresentViewController(bossVc, true, null);
        }

        private void HandleRollingSpellClicked(object sender, Player e)
        {
            _cgVM.SelectedPlayer = e;

            var spellVc = new RollingSpellsVc();
            spellVc.ModalPresentationStyle = UIModalPresentationStyle.Automatic;
            PresentViewController(spellVc, true, null);
        }

        private void HandleDisplaySpell(object sender, Spell e)
        {
            var spellVc = new SpellPopUp(e);
            spellVc.ModalPresentationStyle = UIModalPresentationStyle.Automatic;
            PresentViewController(spellVc, true, null);
        }

        private void HandlePlusClicked(object sender, Player e)
        {
            if (!_sqlVM.GetLocalPlayer().IsHost)
            {
                if (e.Id != _sqlVM.GetLocalPlayer().Id)
                {
                    "You can only level yourself up".Translated().ReportError();
                    return;
                }
            }
            if (e.Level == 10)
            {
                "You are already max level".Translated().ReportError();
                return;
            }
            e.Level++;

            var lvlUpVc = new LevelUpModelVc(e);
            lvlUpVc.ModalPresentationStyle = UIModalPresentationStyle.Automatic;
            PresentViewController(lvlUpVc, true, null);

            playerHUB.UpdateLevelChange(e.Id, e.Level);
        }

        private void HandleMinusClicked(object sender, Player e)
        {
            if (e.Level == 0)
            {
                return;
            }

            if (!_sqlVM.GetLocalPlayer().IsHost)
            {
                if (e.Id != _sqlVM.GetLocalPlayer().Id)
                {
                    "You can only decrease yourself".Translated().ReportError();
                    return;
                }
            }

            if (e.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris)
            {
                "Dracsoris can't level down".Translated().ReportError();
                return;
            }

            e.Level--;

            Toast.MakeToast("Decreased...".Translated())
                .SetPosition(GlobalToast.ToastPosition.Center)
                .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                .Show();

            playerHUB.UpdateLevelChange(e.Id, e.Level);
        }

        private void BtnLeaveGame_TouchUpInside(object sender, EventArgs e)
        {
            if (_cgVM.PlayerList == null)
            {
                if (_sqlVM.GetLocalPlayer() != null)
                {
                    _sqlVM.Delete(_localPlayer);
                    NavigationController.PopViewController(true);
                }
            }
            else
            {
                if (_sqlVM.GetLocalPlayer().IsHost == true && _cgVM.PlayerList.Where(x => !x.LocalPLayer).ToList().Count > 1)
                {
                    //LayoutInflater li = LayoutInflater.From(this);
                    //View promptsView = li.Inflate(Resource.Layout.LeavingGameHost, null);
                    //builder = new AlertDialog.Builder(this).Create();
                    //RecyclerView rcvnewhost = promptsView.FindViewById<RecyclerView>(Resource.Id.recyclerHost);
                    //NewHostAdapter hostadapter = new NewHostAdapter(this);
                    //hostadapter.CellClicked += newhostcellclick;
                    //layoutManagerClass = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
                    //rcvnewhost.SetLayoutManager(layoutManagerClass);
                    //DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvnewhost.Context, DividerItemDecoration.Vertical);
                    //rcvnewhost.AddItemDecoration(dividerItemDecoration);
                    //rcvnewhost.SetAdapter(hostadapter);
                    //txtnewhost = promptsView.FindViewById<TextView>(Resource.Id.nameofplayer);
                    //Button btnLeave = promptsView.FindViewById<Button>(Resource.Id.btnLeaveHost);
                    //Button btnCancel = promptsView.FindViewById<Button>(Resource.Id.btnCancelHost);
                    //btnLeave.Click += BtnLeave_Click1;
                    //btnCancel.Click += BtnCancel_Click;
                    //builder.SetView(promptsView);
                    //builder.Show();
                }
                else
                {
                    Task.Run(async () =>
                    {
                        var res = await iTool.ShowConfirmBoolAlertAsync("Leaving game".Translated(), "Are you sure?".Translated());
                        if (!res)
                            return;
                        if (_cgVM.PlayerList.Count == 1)
                        {
                            _GS.DeleteGame(_sqlVM.GetLocalPlayer().GameKey);
                        }
                        else
                        {
                            playerHUB.Leavegame(_sqlVM.GetLocalPlayer().Id);
                        }
                        _sqlVM.Delete(_sqlVM.GetLocalPlayer());
                        Unsubscribe();
                        InvokeOnMainThread(() => NavigationController.PopViewController(true));

                    });
                }
            }
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            if (parent != null)
                return;
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            playerHUB.GetExistingPlayers -= ReturnedExistingPlayers; // Check
            playerHUB.ReturnedUpdateHost -= ReturnedIsHost;
            playerHUB.ReturnedUpdateLevel -= ReturnedUpdateLevel; // Check
            playerHUB.ReturnedUpdateBoostPlayer -= ReturnedUpdateBoost; // Check
            playerHUB.ReturnedUpdateGameClass -= ReturnedUpdateGameClass; // Check
            playerHUB.ReturnedUpdateSlayedBeast -= ReturnedUpdateSlayedBeast; // Check
            playerHUB.Reconnecting -= Reconnecting; // Check 
            playerHUB.Reconnected -= Reconnected; // Check
            playerHUB.ReturnedDeletedPlayer -= ReturnedDeletedPlayer;
        }

        void ReturnedExistingPlayers(object sender, List<Player> players)
        {
            HideHUD();
            CheckIfYouAreHost(players);
            _cgVM.PlayerList = players;
            InvokeOnMainThread(tblPlayers.ReloadData);
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
                    Unsubscribe();
                    InvokeOnMainThread(() => NavigationController.PopViewController(true));
                    return;
                }
            }
            else
            {
                InvokeOnMainThread(() => NavigationController.PopViewController(true));
            }
        }

        private void BtnAddPlayer_TouchUpInside(object sender, EventArgs e)
        {

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

