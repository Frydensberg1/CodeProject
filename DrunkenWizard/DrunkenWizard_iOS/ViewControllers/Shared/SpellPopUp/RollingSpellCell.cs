using System;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.SpellPopUp
{
    public partial class RollingSpellCell : UITableViewCell
    {
        CurrentGameViewModel _cgVm = ServiceContainer.Resolve<CurrentGameViewModel>();
        public static readonly NSString Key = new NSString("RollingSpellCell");
        public static readonly UINib Nib;
        public static readonly string CellId = nameof(RollingSpellCell) + "Id";

        static RollingSpellCell()
        {
            Nib = UINib.FromName("RollingSpellCell", NSBundle.MainBundle);
        }

        protected RollingSpellCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }



        internal void SetupCell(string rEffect, int number, int max)
        {
            if (number == max - 1 || number == 0)
            {
                lblEffect.Font = UIFont.BoldSystemFontOfSize(15);
                lblLevel.Font = UIFont.BoldSystemFontOfSize(15);
            }
            else
            {
                lblEffect.Font = UIFont.SystemFontOfSize(15);
                lblLevel.Font = UIFont.SystemFontOfSize(15);
            }

            var lvlInt = number == max - 1 ? 6 : number + 1;
            lblLevel.Text = $"Rolling {lvlInt}:";
            lblEffect.Text = rEffect;

            ContentView.BackgroundColor = _cgVm.SelectedPlayer.GameClass.Color.FromHex();
            if (ContentView.BackgroundColor.ColorIsLight())
                lblEffect.TextColor = lblLevel.TextColor = UIColor.Black;
            else
                lblEffect.TextColor = lblLevel.TextColor = UIColor.White;
        }
    }
}
