// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.CurrentGame
{
	[Register ("CurrentGameVc")]
	partial class CurrentGameVc
	{
		[Outlet]
		UIKit.UIButton btnAddPlayer { get; set; }

		[Outlet]
		UIKit.UIButton btnGameKey { get; set; }

		[Outlet]
		UIKit.UIButton btnLeaveGame { get; set; }

		[Outlet]
		UIKit.UITableView tblPlayers { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnAddPlayer != null) {
				btnAddPlayer.Dispose ();
				btnAddPlayer = null;
			}

			if (btnGameKey != null) {
				btnGameKey.Dispose ();
				btnGameKey = null;
			}

			if (btnLeaveGame != null) {
				btnLeaveGame.Dispose ();
				btnLeaveGame = null;
			}

			if (tblPlayers != null) {
				tblPlayers.Dispose ();
				tblPlayers = null;
			}
		}
	}
}
