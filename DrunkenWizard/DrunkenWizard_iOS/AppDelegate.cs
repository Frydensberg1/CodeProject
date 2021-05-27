using DrunkenWizard_iOS.Menu;
using DrunkenWizard_iOS.ViewControllers;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Tools;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using UIKit;

namespace DrunkenWizard_iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        UINavigationController nav;
        UIViewController masterviewcontroller;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            AppCenter.Start("b83990d5-f5b5-426c-ba90-9ec7ba78019e", typeof(Analytics), typeof(Crashes));
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            ServiceContainer.Register(window);
            ServiceContainer.Register(this);


            masterviewcontroller = new MenuController();
            window.RootViewController = masterviewcontroller;
            window.MakeKeyAndVisible();

            Analytics.TrackEvent(SharedTool.SESSION_STARTED, SharedTool.GetAppCenterDetails());
            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            Analytics.TrackEvent(SharedTool.SESSION_PAUSED, SharedTool.GetAppCenterDetails());
        }

        public override void OnActivated(UIApplication application)
        {
            Analytics.TrackEvent(SharedTool.SESSION_RESUMED, SharedTool.GetAppCenterDetails());
        }

        public override void DidEnterBackground(UIApplication application)
        {
            Analytics.TrackEvent(SharedTool.SESSION_PAUSED, SharedTool.GetAppCenterDetails());
        }

        // This method is called as part of the transiton from background to active state.
        public override void WillEnterForeground(UIApplication application)
        {
            Analytics.TrackEvent(SharedTool.SESSION_RESUMED, SharedTool.GetAppCenterDetails());
        }

    }
}

