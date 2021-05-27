using System;

using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Main
{
    public partial class HostGameBottomSheet : UIViewController
    {
        public HostGameBottomSheet() : base("HostGameBottomSheet", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

