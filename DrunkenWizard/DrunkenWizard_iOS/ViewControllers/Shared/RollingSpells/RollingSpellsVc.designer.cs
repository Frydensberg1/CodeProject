// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.RollingSpells
{
	[Register ("RollingSpellsVc")]
	partial class RollingSpellsVc
	{
		[Outlet]
		UIKit.UIButton btnOk { get; set; }

		[Outlet]
		UIKit.UILabel lblRollingSpells { get; set; }

		[Outlet]
		UIKit.UITableView tblSpells { get; set; }

		[Outlet]
		UIKit.UIView vwContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblRollingSpells != null) {
				lblRollingSpells.Dispose ();
				lblRollingSpells = null;
			}

			if (tblSpells != null) {
				tblSpells.Dispose ();
				tblSpells = null;
			}

			if (vwContainer != null) {
				vwContainer.Dispose ();
				vwContainer = null;
			}

			if (btnOk != null) {
				btnOk.Dispose ();
				btnOk = null;
			}
		}
	}
}
