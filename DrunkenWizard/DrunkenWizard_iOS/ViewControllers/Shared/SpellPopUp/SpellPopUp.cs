using System;
using DrunkenWizard_SharedProject.Models;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.SpellPopUp
{
    public partial class SpellPopUp : UIViewController
    {
        Spell _spell;
        public SpellPopUp(Spell spell) : base("SpellPopUp", null)
        {
            _spell = spell;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (_spell == null)
                return;

            lblSpell.Text = _spell.Name;
            txtSpellDesc.Text = _spell.Description;
            txtSpellDesc.Editable = false;
            imgSpell.Image = UIImage.FromBundle(_spell.SpellImage);

            var originalHeight = txtSpellDesc.Frame.Height;
            txtSpellDesc.SizeToFit();
            var newHeight = txtSpellDesc.Frame.Height + 20;
            var difference = (originalHeight - newHeight) * -1;


            var mainHeght = vwContainer.Frame.Height;
            vwContainer.HeightAnchor.ConstraintEqualTo(mainHeght + difference).Active = true;


            btnOK.TouchUpInside += BtnOK_TouchUpInside;
        }

        private void BtnOK_TouchUpInside(object sender, EventArgs e)
        {
            DismissViewController(true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

