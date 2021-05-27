using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DrunkenWizard_SharedProject.Models;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS
{
    public static class iTool
    {
        public static UIView MakeBorder(this UIView view, UIColor color, float width = 2f, float radius = 5f, bool clips = true)
        {
            view.ClipsToBounds = clips;
            view.Layer.BorderColor = color.CGColor;
            view.Layer.BorderWidth = width;
            view.Layer.CornerRadius = radius;
            return view;
        }

        public static UIView MakeCircle(this UIView view, UIColor color, float width = 3f)
        {
            double min = Math.Min(view.Frame.Width, view.Frame.Height);
            view.Layer.CornerRadius = (float)(min / 2.0);
            view.Layer.MasksToBounds = false;
            view.Layer.BorderColor = color.CGColor;
            view.Layer.BorderWidth = width;
            view.ClipsToBounds = true;
            return view;
        }

        public static string Translated(this string key)
        {
            // TODO: Implement
            return key;
        }

        public static UIColor FromHex(this string hexValue, float alpha = 1)
        {
            if (hexValue.StartsWith("#"))
                hexValue = hexValue.Substring(1, hexValue.Length - 1);

            int colValue = Int32.Parse(hexValue, NumberStyles.HexNumber);
            return UIColor.FromRGBA(
                (((float)((colValue & 0xFF0000) >> 16)) / 255.0f),
                (((float)((colValue & 0xFF00) >> 8)) / 255.0f),
                (((float)(colValue & 0xFF)) / 255.0f), alpha);
        }

        public static bool ColorIsLight(this UIColor color)
        {
            var components = color.CGColor.Components;
            var brightness = ((components[0] * 299) + (components[1] * 587) + (components[2] * 114)) / 1000;
            if (brightness < 0.5)
                return false;
            return true;
        }

        public static void ReportError(this string exceptionMessage, string title = "", EventHandler<UIButtonEventArgs> onDismissed = null)
        {
            using (var pool = new NSAutoreleasePool())
            {
                try
                {
                    pool.InvokeOnMainThread(delegate
                    {
                        var MessageBox = new UIAlertView(title, exceptionMessage, (null as IUIAlertViewDelegate), "Ok");
                        if (onDismissed != null)
                        {
                            MessageBox.Dismissed += onDismissed;
                        }
                        MessageBox.Show();
                    });
                }
                catch
                {
                }
            }
        }

        public static Task<bool> ShowConfirmBoolAlertAsync(string title, string message, string cancelStr = "", string okStr = "")
        {
            var tcs = new TaskCompletionSource<bool>();

            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                UIAlertView alert = new UIAlertView(
                    title,
                    message,
                    (null as IUIAlertViewDelegate),
                    cancelStr.IsNullOrWhiteSpace() ? "Cancel".Translated() : cancelStr,
                    okStr.IsNullOrWhiteSpace() ? "OK".Translated() : okStr);
                alert.AlertViewStyle = UIAlertViewStyle.Default;

                alert.Clicked += (sender, buttonArgs) =>
                {
                    if (buttonArgs.ButtonIndex == alert.CancelButtonIndex)
                    {
                        tcs.SetResult(false);
                    }
                    else
                    {
                        tcs.SetResult(true);
                    }
                };
                alert.Show();
            });

            return tcs.Task;
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static List<string> GetRollEffects(this GameClass gClass)
        {
            var list = new List<string>();

            list.Add(gClass.RollEffect1);
            list.Add(gClass.RollEffect2);
            list.Add(gClass.RollEffect3);
            list.Add(gClass.RollEffect4);
            list.Add(gClass.RollEffect5);
            list.Add(gClass.RollEffect6);

            return list;
        }
    }
}
