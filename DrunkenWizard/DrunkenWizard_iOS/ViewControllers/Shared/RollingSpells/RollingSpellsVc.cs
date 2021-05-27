using System;
using DrunkenWizard_iOS.ViewControllers.Shared.SpellPopUp;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.RollingSpells
{
    public partial class RollingSpellsVc : UIViewController
    {
        CurrentGameViewModel _cgVm = ServiceContainer.Resolve<CurrentGameViewModel>();
        public RollingSpellsVc() : base("RollingSpellsVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tblSpells.RegisterNibForCellReuse(RollingSpellCell.Nib, RollingSpellCell.CellId);
            tblSpells.DataSource = new RollingSpellTableDataSource();
            tblSpells.SeparatorColor = UIColor.Clear;
            tblSpells.BackgroundColor = _cgVm.SelectedPlayer.GameClass.Color.FromHex();

            var originalHeight = tblSpells.Frame.Height;
            tblSpells.SizeToFit();
            var newHeight = tblSpells.Frame.Height - 20;
            var difference = (originalHeight - newHeight) * -1;

            var mainHeght = vwContainer.Frame.Height;
            vwContainer.HeightAnchor.ConstraintEqualTo(mainHeght + difference).Active = true;

            btnOk.TouchUpInside += BtnOk_TouchUpInside;
            btnOk.BackgroundColor = _cgVm.SelectedPlayer.GameClass.Color.FromHex();
            btnOk.SetTitleColor(_cgVm.SelectedPlayer.GameClass.Color.FromHex().ColorIsLight() ? UIColor.Black : UIColor.White, UIControlState.Normal);

            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void BtnOk_TouchUpInside(object sender, EventArgs e)
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

