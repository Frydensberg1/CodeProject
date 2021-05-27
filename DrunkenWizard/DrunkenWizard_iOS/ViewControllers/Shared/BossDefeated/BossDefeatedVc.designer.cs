// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.BossDefeated
{
	[Register ("BossDefeatedVc")]
	partial class BossDefeatedVc
	{
		[Outlet]
		UIKit.UIButton btnDismiss { get; set; }

		[Outlet]
		UIKit.UIImageView imgBoss1 { get; set; }

		[Outlet]
		UIKit.UIImageView imgBoss2 { get; set; }

		[Outlet]
		UIKit.UIImageView imgBoss3 { get; set; }

		[Outlet]
		UIKit.UILabel lblBoss1Defeated { get; set; }

		[Outlet]
		UIKit.UILabel lblBoss2Defeated { get; set; }

		[Outlet]
		UIKit.UILabel lblBoss3Defeated { get; set; }

		[Outlet]
		UIKit.UILabel lblBossFightsUi { get; set; }

		[Outlet]
		UIKit.UILabel lblLevel3 { get; set; }

		[Outlet]
		UIKit.UILabel lblLevel6 { get; set; }

		[Outlet]
		UIKit.UILabel lblLevel9 { get; set; }

		[Outlet]
		UIKit.UIView vwBoss1 { get; set; }

		[Outlet]
		UIKit.UIView vwBoss2 { get; set; }

		[Outlet]
		UIKit.UIView vwBoss3 { get; set; }

		[Outlet]
		UIKit.UIView vwContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (vwContainer != null) {
				vwContainer.Dispose ();
				vwContainer = null;
			}

			if (lblBossFightsUi != null) {
				lblBossFightsUi.Dispose ();
				lblBossFightsUi = null;
			}

			if (btnDismiss != null) {
				btnDismiss.Dispose ();
				btnDismiss = null;
			}

			if (vwBoss1 != null) {
				vwBoss1.Dispose ();
				vwBoss1 = null;
			}

			if (vwBoss2 != null) {
				vwBoss2.Dispose ();
				vwBoss2 = null;
			}

			if (vwBoss3 != null) {
				vwBoss3.Dispose ();
				vwBoss3 = null;
			}

			if (lblLevel3 != null) {
				lblLevel3.Dispose ();
				lblLevel3 = null;
			}

			if (lblLevel9 != null) {
				lblLevel9.Dispose ();
				lblLevel9 = null;
			}

			if (lblLevel6 != null) {
				lblLevel6.Dispose ();
				lblLevel6 = null;
			}

			if (lblBoss1Defeated != null) {
				lblBoss1Defeated.Dispose ();
				lblBoss1Defeated = null;
			}

			if (lblBoss3Defeated != null) {
				lblBoss3Defeated.Dispose ();
				lblBoss3Defeated = null;
			}

			if (lblBoss2Defeated != null) {
				lblBoss2Defeated.Dispose ();
				lblBoss2Defeated = null;
			}

			if (imgBoss1 != null) {
				imgBoss1.Dispose ();
				imgBoss1 = null;
			}

			if (imgBoss3 != null) {
				imgBoss3.Dispose ();
				imgBoss3 = null;
			}

			if (imgBoss2 != null) {
				imgBoss2.Dispose ();
				imgBoss2 = null;
			}
		}
	}
}
