using System;
using CoreGraphics;
using MBProgressHUD;
using UIKit;
using DrunkenWizard_SharedProject.Tools;
using Foundation;

namespace DrunkenWizard_iOS.Base
{
    public class UIViewControllerExtended : UIViewController
    {
        public UIViewControllerExtended(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        protected MTMBProgressHUD hud;

        #region Progress Methods

        protected void ShowHUD(string message)
        {
            UpdateHUD(message);
        }

        void ShowNewHUD(string message)
        {
            InvokeOnMainThread(delegate
            {

                hud = new MTMBProgressHUD(View);
                hud.MinSize = new CGSize(135f, 125f);
                View.AddSubview(hud);
                hud.DidHide += HandleDidHide;
                hud.DimBackground = false;
                hud.LabelText = message;
                //hud.Mode = MBProgressHUDMode.Text;
                hud.AnimationType = MBProgressHUDAnimation.ZoomIn;
                hud.Show(true);
            });

        }

        protected void HandleDidHide(object sender, EventArgs e)
        {
            InvokeOnMainThread(delegate
            {
                if (hud == null)
                    return;

                hud.RemoveFromSuperview();
                hud = null;
            });


        }

        protected void UpdateHUD(string text)
        {
            InvokeOnMainThread(delegate
            {
                if (hud != null)
                    hud.LabelText = text?.Translated();
                else
                    ShowNewHUD(text?.Translated());
            });
        }

        protected void HideHUD(bool success, string message = "")
        {
            if (hud == null)
            {
                return;
            }

            string filename;
            string label;
            int sleepTimer;

            if (success)
            {
                filename = "checkmark";
                sleepTimer = 200;
                label = "Completed".Translated();
            }
            else
            {
                filename = "xmark";
                sleepTimer = 4000;
                label = "Failed".Translated();
            }



            InvokeOnMainThread(delegate
            {
                var config = UIImageSymbolConfiguration.Create(36f, UIImageSymbolWeight.Medium);
                if (hud != null)
                {
                    hud.CustomView = new UIImageView(UIImage.GetSystemImage(filename).ApplyConfiguration(config).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate)) { TintColor = UIColor.White };
                }
            });

            hud.Mode = MBProgressHUDMode.CustomView;
            if (message.IsNullOrWhiteSpace())
            {
                hud.LabelText = label;
            }
            else
            {
                sleepTimer = success ? 100 : 4000;
                hud.LabelText = message;
                if (!success)
                    hud.DetailsLabelText = "Please contact developer".Translated();
            }

            System.Threading.Thread.Sleep(sleepTimer);

            InvokeOnMainThread(delegate
            {
                if (hud != null)
                {
                    hud.Hide(true);
                }
            });

        }
        protected void HideHUD()
        {
            if (hud == null)
            {
                return;
            }

            hud.Mode = MBProgressHUDMode.CustomView;

            InvokeOnMainThread(() =>
            {
                if (hud != null)
                {
                    hud.Hide(true);
                }
            });
        }

        #endregion

    }
}
