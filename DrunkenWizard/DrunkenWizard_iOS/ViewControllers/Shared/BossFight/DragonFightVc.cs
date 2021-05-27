using System;
using System.Linq;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.WebService.Hubs;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.BossFight
{
    public partial class DragonFightVc : UIViewController
    {
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();
        PlayerHub playerHUB = ServiceContainer.Resolve<PlayerHub>();
        ClassViewModel _classVM = ServiceContainer.Resolve<ClassViewModel>();
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        Monster _monster;

        public DragonFightVc() : base("DragonFightVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            imgBackground.Image = UIImage.FromBundle("darkred");
            imgBackground.ContentMode = UIViewContentMode.ScaleAspectFill;
            RandomDragon();

            btnWin.TouchUpInside += BtnWin_TouchUpInside;

            ModalInPresentation = true;
        }

        private async void BtnWin_TouchUpInside(object sender, EventArgs e)
        {
            var res = await iTool.ShowConfirmBoolAlertAsync("Fighting the Mighty beast".Translated(), "Did you win?".Translated(), "Let me out!".Translated(), "YES!!!".Translated());
            if (!res)
                Lost();
            else
                Won();
        }

        private void Won()
        {
            switch (_monster.Name)
            {
                case "Orecan":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Orecan;
                    _bfVM.selectedplayer.Level++;
                    foreach (var item in _cgVM.PlayerList.Where(x => x.Id != _bfVM.selectedplayer.Id))
                    {
                        if (item.Level != 0)
                        {
                            item.Level = item.Level - 1;
                            playerHUB.UpdateLevelChange(item.Id, item.Level);
                        }
                    }
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Trexzor":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Trexzor;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Ile":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Ile;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Dracyllis":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Dracyllis;
                    _bfVM.selectedplayer.BoostUsed = false;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Barcyl":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Barcyl;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Zeodrenth":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Zeodrenth;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Dracenic":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Dracenic;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;

                case "Dracsoris":
                    _bfVM.selectedplayer.SlayedBeast = DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris;
                    _bfVM.selectedplayer.GameClass = _classVM.Dracsoris;
                    playerHUB.UpdateSlayedBeast(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.SlayedBeast);

                    break;
            }

            InvokeOnMainThread(() => DismissViewController(true, null));
        }

        private void Lost()
        {
            _bfVM.selectedplayer.Level = _bfVM.selectedplayer.Level - 1;
            playerHUB.UpdateLevelChange(_bfVM.selectedplayer.Id, _bfVM.selectedplayer.Level);
            InvokeOnMainThread(() => DismissViewController(true, null));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void RandomDragon()
        {
            Random random = new Random();
            int index = random.Next(_bfVM.MonsterList.Count);
            _monster = _bfVM.MonsterList[index];
            SetupDragon();
        }

        private void SetupDragon()
        {
            txtInfo.Text = _monster.Info;
            txtQuest.Text = _monster.Quest;
            txtReward.Text = _monster.Reward;

            imgDragon.Image = UIImage.FromBundle(_monster.Picture);
            imgDragon.ContentMode = UIViewContentMode.ScaleAspectFill;

            lblMonsterName.Text = _monster.Name;

            // TODO: Monster name
        }
    }
}

