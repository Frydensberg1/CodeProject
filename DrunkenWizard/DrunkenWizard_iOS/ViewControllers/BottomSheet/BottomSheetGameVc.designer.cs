// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.BottomSheet
{
    [Register("BottomSheetGameVc")]
    partial class BottomSheetGameVc
    {
        [Outlet]
        UIKit.UIButton btnChooseClass { get; set; }

        [Outlet]
        UIKit.UIButton btnHostGame { get; set; }

        [Outlet]
        UIKit.UIButton btnRandom { get; set; }

        [Outlet]
        UIKit.UILabel lblHostAGame { get; set; }

        [Outlet]
        UIKit.UITextField txtWizardName { get; set; }

        [Outlet]
        UIKit.UIView vwDragger { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (lblHostAGame != null)
            {
                lblHostAGame.Dispose();
                lblHostAGame = null;
            }

            if (txtWizardName != null)
            {
                txtWizardName.Dispose();
                txtWizardName = null;
            }

            if (vwDragger != null)
            {
                vwDragger.Dispose();
                vwDragger = null;
            }

            if (btnRandom != null)
            {
                btnRandom.Dispose();
                btnRandom = null;
            }

            if (btnChooseClass != null)
            {
                btnChooseClass.Dispose();
                btnChooseClass = null;
            }

            if (btnHostGame != null)
            {
                btnHostGame.Dispose();
                btnHostGame = null;
            }
        }
    }
}
