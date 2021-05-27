using System;
using DrunkenWizard_SharedProject.Models;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.BossDefeated
{
    public partial class BossDefeatedVc : UIViewController
    {
        Player _player;
        public BossDefeatedVc(Player player) : base("BossDefeatedVc", null)
        {
            _player = player;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnDismiss.TouchUpInside += (sender, args) => DismissViewController(true, null);

            if (_player.Level >= 3)
            {
                lblBoss1Defeated.Text = "Defeated!".Translated();
                imgBoss1.Image = UIImage.FromBundle("Boss1");
            }

            if (_player.Level >= 6)
            {
                lblBoss2Defeated.Text = "Defeated!".Translated();
                imgBoss2.Image = UIImage.FromBundle("Boss2");
            }

            if (_player.Level >= 9)
            {
                lblBoss3Defeated.Text = "Defeated!".Translated();
                imgBoss3.Image = UIImage.FromBundle("Boss2");
            }
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

