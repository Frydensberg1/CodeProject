// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared
{
	[Register ("ChooseClassVc")]
	partial class ChooseClassVc
	{
		[Outlet]
		UIKit.UIButton btnCancel { get; set; }

		[Outlet]
		UIKit.UIButton btnChoose { get; set; }

		[Outlet]
		UIKit.UICollectionView gridClasses { get; set; }

		[Outlet]
		UIKit.UIImageView imgIcon { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UITableView tblProperties { get; set; }

		[Outlet]
		UIKit.UIView vwDetails { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (gridClasses != null) {
				gridClasses.Dispose ();
				gridClasses = null;
			}

			if (imgIcon != null) {
				imgIcon.Dispose ();
				imgIcon = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (tblProperties != null) {
				tblProperties.Dispose ();
				tblProperties = null;
			}

			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}

			if (btnChoose != null) {
				btnChoose.Dispose ();
				btnChoose = null;
			}

			if (vwDetails != null) {
				vwDetails.Dispose ();
				vwDetails = null;
			}
		}
	}
}
