using System;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.WebService.Hubs;
using GlobalToast;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.PlayerMenu
{
    public partial class PlayerMenuVc : UIViewController
    {
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        PlayerHub playerHUB = ServiceContainer.Resolve<PlayerHub>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();

        public EventHandler ShowBossFightUi;

        public PlayerMenuVc() : base("PlayerMenuVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnClose.TouchUpInside += BtnClose_TouchUpInside;

            vwBoost.MakeCircle(vwBoost.BackgroundColor, 0);
            vwDelete.MakeCircle(vwDelete.BackgroundColor, 0);
            vwChange.MakeCircle(vwChange.BackgroundColor, 0);
            vwDragons.MakeCircle(vwDragons.BackgroundColor, 0);

            btnBoost.TouchUpInside += BtnBoost_TouchUpInside;
            btnDelete.TouchUpInside += BtnDelete_TouchUpInside;
            btnChange.TouchUpInside += BtnChange_TouchUpInside;
            btnDragons.TouchUpInside += BtnDragons_TouchUpInside;
        }

        private async void BtnDragons_TouchUpInside(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeToast("You can fight dragons after level 5, but only on the host's phone.".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }

            if (_cgVM.SelectedPlayer.Level < 5)
            {
                Toast.MakeToast("You have to be level 5 to enter".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }

            if (_cgVM.SelectedPlayer.SlayedBeast != DrunkenWizard_SharedProject.Enums.BeastEnum.none)
            {
                Toast.MakeToast("You already fought a mighty beast".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }

            var res = await iTool.ShowConfirmBoolAlertAsync("Fighting Mighty Magic Beast", "If you dont complete it, you decrease a level. Are you sure?", "I am too afraid!".Translated(), "Brint it on".Translated());
            if (!res)
                return;

            _bfVM.selectedplayer = _cgVM.SelectedPlayer;
            DismissViewController(true, null);
            ShowBossFightUi?.Invoke(this, EventArgs.Empty);
        }

        private void BtnChange_TouchUpInside(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeToast("Only the host may change a players class.".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }

            if (_cgVM.SelectedPlayer.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris)
            {
                Toast.MakeToast("You can't change Dracsoris to another class".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }

            _classChooserVc = new ChooseClassVc();
            _classChooserVc.ClassSelected += _classChooserVc_ClassSelected;
            _classChooserVc.ModalPresentationStyle = UIModalPresentationStyle.Popover;
            PresentModalViewController(_classChooserVc, true);
        }

        ChooseClassVc _classChooserVc;

        private void _classChooserVc_ClassSelected(object sender, GameClass e)
        {
            _classChooserVc.ClassSelected -= _classChooserVc_ClassSelected;

            if (_cgVM.SelectedPlayer.PremiumAccount == false && e.PremiumClass == true)
            {
                Toast.MakeToast("his Class requires Premium Version".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }
            _cgVM.SelectedPlayer.GameClass = e;
            playerHUB.UpdateChangeGameClass(_cgVM.SelectedPlayer.Id, e.Name);
            DismissViewController(true, null);
            DismissViewController(true, null);
        }

        private async void BtnDelete_TouchUpInside(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer().IsHost != true)
            {
                Toast.MakeToast("Only the host of the game can delete a player.".Translated())
                    .SetPosition(ToastPosition.Center)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                return;
            }

            var res = await iTool.ShowConfirmBoolAlertAsync("Deleting Player", "Are you sure?");
            if (!res)
                return;


            if (_cgVM.SelectedPlayer.IsHost == true)
            {
                Toast.MakeToast("You can't delete the host of the game.".Translated())
                    .SetPosition(ToastPosition.Center)
                    //.SetDuration(10)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
            }
            else
            {
                playerHUB.RemovePlayer(_cgVM.SelectedPlayer.Id);
            }
            DismissViewController(true, null);
        }

        private async void BtnBoost_TouchUpInside(object sender, EventArgs e)
        {
            if (_cgVM.SelectedPlayer.BoostUsed)
            {
                InvokeOnMainThread(delegate
                {
                    Toast.MakeToast("You have used your boost already.".Translated())
                    .SetPosition(ToastPosition.Center)
                    //.SetDuration(10)
                    .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(25) })
                    .Show();
                });

                return;
            }

            var res = await iTool.ShowConfirmBoolAlertAsync("Boosting".Translated(), "Are you sure?".Translated());
            if (!res)
                return;

            _cgVM.SelectedPlayer.Level++;
            _cgVM.SelectedPlayer.BoostUsed = true;
            playerHUB.UpdateBoostPlayer(_cgVM.SelectedPlayer.Id, true);
            playerHUB.UpdateLevelChange(_cgVM.SelectedPlayer.Id, _cgVM.SelectedPlayer.Level);

            Toast.MakeToast("Boost used!".Translated())
                .SetPosition(ToastPosition.Center)
                .SetAppearance(new ToastAppearance() { MessageFont = UIFont.BoldSystemFontOfSize(35) })
                .Show();

            DismissViewController(true, null);
        }

        private void BtnClose_TouchUpInside(object sender, EventArgs e)
        {
            DismissViewController(true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

