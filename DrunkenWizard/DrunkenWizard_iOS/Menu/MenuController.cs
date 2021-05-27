using System;
using DrunkenWizard_iOS.ViewControllers;
using DrunkenWizard_SharedProject.Container;
using JokesV2;
using UIKit;

namespace DrunkenWizard_iOS.Menu
{
    public class MenuController : ParallaxMenu
    {
        public MenuController()
        {
            this.ScaleBackgroundImageView = true;
            this.ScaleContentView = true;
            this.IsPanGestureEnabled = false;
            ContentViewScaleValue = 0.85f;
            ServiceContainer.Register<ParallaxMenu>(() => this);

            MenuViewController = new SideMenuController(this);

            ContentViewController = new UINavigationController(new MainVc());



            BackgroundImage = UIImage.FromBundle("dragon");

        }

        public void ShowMenu(object sender, EventArgs e)
        {
            base.PresentMenuViewController();
        }
    }


}

