// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.BossFight
{
	[Register ("DragonFightVc")]
	partial class DragonFightVc
	{
		[Outlet]
		UIKit.UIButton btnWin { get; set; }

		[Outlet]
		UIKit.UIImageView imgBackground { get; set; }

		[Outlet]
		UIKit.UIImageView imgDragon { get; set; }

		[Outlet]
		UIKit.UILabel lblMonsterName { get; set; }

		[Outlet]
		UIKit.UITextView txtInfo { get; set; }

		[Outlet]
		UIKit.UITextView txtQuest { get; set; }

		[Outlet]
		UIKit.UITextView txtReward { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgBackground != null) {
				imgBackground.Dispose ();
				imgBackground = null;
			}

			if (imgDragon != null) {
				imgDragon.Dispose ();
				imgDragon = null;
			}

			if (lblMonsterName != null) {
				lblMonsterName.Dispose ();
				lblMonsterName = null;
			}

			if (txtInfo != null) {
				txtInfo.Dispose ();
				txtInfo = null;
			}

			if (txtQuest != null) {
				txtQuest.Dispose ();
				txtQuest = null;
			}

			if (txtReward != null) {
				txtReward.Dispose ();
				txtReward = null;
			}

			if (btnWin != null) {
				btnWin.Dispose ();
				btnWin = null;
			}
		}
	}
}
