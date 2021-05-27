using DrunkenWizard_SharedProject.Tools;
using Microsoft.AppCenter.Crashes;
using UIKit;

namespace DrunkenWizard_iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (System.Exception ex)
            {
                SharedTool.WriteExceptionMessagesToOutputBox(ex);
                Crashes.TrackError(ex, SharedTool.GetAppCenterDetails());

            }
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.

        }
    }
}