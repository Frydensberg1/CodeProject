// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.JoinGame
{
	[Register ("JoinGameVc")]
	partial class JoinGameVc
	{
		[Outlet]
		UIKit.UIButton btnChooseClass { get; set; }

		[Outlet]
		UIKit.UIButton btnJoinGame { get; set; }

		[Outlet]
		UIKit.UIButton btnRandom { get; set; }

		[Outlet]
		UIKit.UILabel lblEnterKeyUi { get; set; }

		[Outlet]
		UIKit.UILabel lblViewTitle { get; set; }

		[Outlet]
		UIKit.UILabel lblWizardNameUi { get; set; }

		[Outlet]
		UIKit.UITextField txtEnterKey { get; set; }

		[Outlet]
		UIKit.UITextField txtWizardName { get; set; }

		[Outlet]
		UIKit.UIView vwSeparator1 { get; set; }

		[Outlet]
		UIKit.UIView vwSeparator2 { get; set; }

		[Outlet]
		UIKit.UIView vwSeparator3 { get; set; }

		[Outlet]
		UIKit.UIView vwSeparator4 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (vwSeparator1 != null) {
				vwSeparator1.Dispose ();
				vwSeparator1 = null;
			}

			if (vwSeparator2 != null) {
				vwSeparator2.Dispose ();
				vwSeparator2 = null;
			}

			if (vwSeparator3 != null) {
				vwSeparator3.Dispose ();
				vwSeparator3 = null;
			}

			if (vwSeparator4 != null) {
				vwSeparator4.Dispose ();
				vwSeparator4 = null;
			}

			if (lblViewTitle != null) {
				lblViewTitle.Dispose ();
				lblViewTitle = null;
			}

			if (lblWizardNameUi != null) {
				lblWizardNameUi.Dispose ();
				lblWizardNameUi = null;
			}

			if (txtWizardName != null) {
				txtWizardName.Dispose ();
				txtWizardName = null;
			}

			if (lblEnterKeyUi != null) {
				lblEnterKeyUi.Dispose ();
				lblEnterKeyUi = null;
			}

			if (txtEnterKey != null) {
				txtEnterKey.Dispose ();
				txtEnterKey = null;
			}

			if (btnRandom != null) {
				btnRandom.Dispose ();
				btnRandom = null;
			}

			if (btnChooseClass != null) {
				btnChooseClass.Dispose ();
				btnChooseClass = null;
			}

			if (btnJoinGame != null) {
				btnJoinGame.Dispose ();
				btnJoinGame = null;
			}
		}
	}
}
