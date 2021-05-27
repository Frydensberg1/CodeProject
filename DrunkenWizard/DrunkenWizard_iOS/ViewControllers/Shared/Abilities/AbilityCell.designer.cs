// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Abilities
{
	[Register ("AbilityCell")]
	partial class AbilityCell
	{
		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UIView vw1 { get; set; }

		[Outlet]
		UIKit.UIView vw2 { get; set; }

		[Outlet]
		UIKit.UIView vw3 { get; set; }

		[Outlet]
		UIKit.UIView vw4 { get; set; }

		[Outlet]
		UIKit.UIView vw5 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (vw1 != null) {
				vw1.Dispose ();
				vw1 = null;
			}

			if (vw2 != null) {
				vw2.Dispose ();
				vw2 = null;
			}

			if (vw3 != null) {
				vw3.Dispose ();
				vw3 = null;
			}

			if (vw4 != null) {
				vw4.Dispose ();
				vw4 = null;
			}

			if (vw5 != null) {
				vw5.Dispose ();
				vw5 = null;
			}
		}
	}
}
