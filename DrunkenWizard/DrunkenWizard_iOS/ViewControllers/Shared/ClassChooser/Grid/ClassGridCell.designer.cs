// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Grid
{
	[Register ("ClassGridCell")]
	partial class ClassGridCell
	{
		[Outlet]
		UIKit.UIImageView imgIcon { get; set; }

		[Outlet]
		UIKit.UILabel lblClassName { get; set; }

		[Outlet]
		UIKit.UIView vwClassContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgIcon != null) {
				imgIcon.Dispose ();
				imgIcon = null;
			}

			if (lblClassName != null) {
				lblClassName.Dispose ();
				lblClassName = null;
			}

			if (vwClassContainer != null) {
				vwClassContainer.Dispose ();
				vwClassContainer = null;
			}
		}
	}
}
