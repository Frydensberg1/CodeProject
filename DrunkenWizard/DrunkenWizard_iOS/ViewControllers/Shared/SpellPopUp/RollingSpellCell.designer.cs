// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrunkenWizard_iOS.ViewControllers.Shared.SpellPopUp
{
	[Register ("RollingSpellCell")]
	partial class RollingSpellCell
	{
		[Outlet]
		UIKit.UILabel lblEffect { get; set; }

		[Outlet]
		UIKit.UILabel lblLevel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblLevel != null) {
				lblLevel.Dispose ();
				lblLevel = null;
			}

			if (lblEffect != null) {
				lblEffect.Dispose ();
				lblEffect = null;
			}
		}
	}
}
