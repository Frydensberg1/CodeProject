// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using DrunkenWizard_iOS.Base;
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.CurrentGame
{
    [Register("CurrentGameCell")]
    partial class CurrentGameCell
    {
        [Outlet]
        UIKit.UIButton btnDice { get; set; }

        [Outlet]
        UIKit.UIButton btnMinus { get; set; }

        [Outlet]
        UIKit.UIButton btnPlus { get; set; }

        [Outlet]
        UIKit.UIButton btnRollingSpells { get; set; }

        [Outlet]
        UIImageViewClickable imgLevelUpCheering { get; set; }

        [Outlet]
        UIImageViewClickable imgMagicBeast { get; set; }

        [Outlet]
        UIImageViewClickable imgProfile { get; set; }

        [Outlet]
        UIImageViewClickable imgSpell1 { get; set; }

        [Outlet]
        UIImageViewClickable imgSpell2 { get; set; }

        [Outlet]
        UIImageViewClickable imgSpell3 { get; set; }

        [Outlet]
        UIKit.UILabel lblLevel { get; set; }

        [Outlet]
        UIKit.UILabel txtNamePlayer { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (btnPlus != null)
            {
                btnPlus.Dispose();
                btnPlus = null;
            }

            if (btnMinus != null)
            {
                btnMinus.Dispose();
                btnMinus = null;
            }

            if (btnRollingSpells != null)
            {
                btnRollingSpells.Dispose();
                btnRollingSpells = null;
            }

            if (btnDice != null)
            {
                btnDice.Dispose();
                btnDice = null;
            }

            if (imgSpell1 != null)
            {
                imgSpell1.Dispose();
                imgSpell1 = null;
            }

            if (imgSpell2 != null)
            {
                imgSpell2.Dispose();
                imgSpell2 = null;
            }

            if (imgSpell3 != null)
            {
                imgSpell3.Dispose();
                imgSpell3 = null;
            }

            if (imgMagicBeast != null)
            {
                imgMagicBeast.Dispose();
                imgMagicBeast = null;
            }

            if (imgLevelUpCheering != null)
            {
                imgLevelUpCheering.Dispose();
                imgLevelUpCheering = null;
            }

            if (lblLevel != null)
            {
                lblLevel.Dispose();
                lblLevel = null;
            }

            if (imgProfile != null)
            {
                imgProfile.Dispose();
                imgProfile = null;
            }

            if (txtNamePlayer != null)
            {
                txtNamePlayer.Dispose();
                txtNamePlayer = null;
            }
        }
    }
}
