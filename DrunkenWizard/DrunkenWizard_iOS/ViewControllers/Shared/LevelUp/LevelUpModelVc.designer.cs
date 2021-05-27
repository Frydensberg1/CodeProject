// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.LevelUp
{
	[Register ("LevelUpModelVc")]
	partial class LevelUpModelVc
	{
		[Outlet]
		UIKit.UIButton btnOk { get; set; }

		[Outlet]
		UIKit.UIImageView imgBoss { get; set; }

		[Outlet]
		UIKit.UILabel lblLevelUpSpell { get; set; }

		[Outlet]
		UIKit.UILabel lblSpell { get; set; }

		[Outlet]
		UIKit.UITextView txtSpellEffect { get; set; }

		[Outlet]
		UIKit.UIView vwDialog { get; set; }

		[Outlet]
		UIKit.UIView vwFadeBackground { get; set; }

		[Outlet]
		UIKit.UIView vwMainContainer { get; set; }

		[Outlet]
		UIKit.UIView vwSeparator { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnOk != null) {
				btnOk.Dispose ();
				btnOk = null;
			}

			if (lblLevelUpSpell != null) {
				lblLevelUpSpell.Dispose ();
				lblLevelUpSpell = null;
			}

			if (lblSpell != null) {
				lblSpell.Dispose ();
				lblSpell = null;
			}

			if (txtSpellEffect != null) {
				txtSpellEffect.Dispose ();
				txtSpellEffect = null;
			}

			if (vwDialog != null) {
				vwDialog.Dispose ();
				vwDialog = null;
			}

			if (vwFadeBackground != null) {
				vwFadeBackground.Dispose ();
				vwFadeBackground = null;
			}

			if (vwMainContainer != null) {
				vwMainContainer.Dispose ();
				vwMainContainer = null;
			}

			if (vwSeparator != null) {
				vwSeparator.Dispose ();
				vwSeparator = null;
			}

			if (imgBoss != null) {
				imgBoss.Dispose ();
				imgBoss = null;
			}
		}
	}
}
