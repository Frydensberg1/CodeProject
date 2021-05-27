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
	[Register ("SpellPopUp")]
	partial class SpellPopUp
	{
		[Outlet]
		UIKit.UIButton btnOK { get; set; }

		[Outlet]
		UIKit.UIImageView imgSpell { get; set; }

		[Outlet]
		UIKit.UILabel lblSpell { get; set; }

		[Outlet]
		UIKit.UITextView txtSpellDesc { get; set; }

		[Outlet]
		UIKit.UIView vwContainer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgSpell != null) {
				imgSpell.Dispose ();
				imgSpell = null;
			}

			if (lblSpell != null) {
				lblSpell.Dispose ();
				lblSpell = null;
			}

			if (txtSpellDesc != null) {
				txtSpellDesc.Dispose ();
				txtSpellDesc = null;
			}

			if (vwContainer != null) {
				vwContainer.Dispose ();
				vwContainer = null;
			}

			if (btnOK != null) {
				btnOK.Dispose ();
				btnOK = null;
			}
		}
	}
}
