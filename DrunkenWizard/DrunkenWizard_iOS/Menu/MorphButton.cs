using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.Menu
{
    [Register("MorphButton")]
    public class MorphButton : UIButton
    {
        const int lineHeight = 3;

        UIView topLine;
        UIView centerLine;
        UIView bottomLine;

        bool _opened;

        public MorphButton()
        {
            Initialize();
        }

        public MorphButton(IntPtr p) : base(p)
        {
            Initialize();
        }

        public MorphButton(CGRect frame) : base(frame)
        {
            Initialize();
        }

        void Initialize()
        {
            var vHeight = Frame.Height;
            var vWidth = Frame.Width;
            var spacing = (vHeight - lineHeight * 3) / 3;

            topLine = new UIView(new CGRect(0, 0, vWidth, lineHeight))
            {
                BackgroundColor = UIColor.White,
                UserInteractionEnabled = false
            };
            centerLine = new UIView(new CGRect(0, spacing + lineHeight, vWidth, lineHeight))
            {
                BackgroundColor = UIColor.White,
                UserInteractionEnabled = false
            };
            bottomLine = new UIView(new CGRect(0, 2 * spacing + 2 * lineHeight, vWidth, lineHeight))
            {
                BackgroundColor = UIColor.White,
                UserInteractionEnabled = false
            };

            AddSubviews(topLine, centerLine, bottomLine);

            BackgroundColor = UIColor.Clear;

            TouchUpInside += delegate
            {
                //ToggleState();
            };
        }

        void MakeMenu()
        {
            AnimateNotify(2.8, 0, 0.6f, 2.0f, UIViewAnimationOptions.CurveEaseOut, () =>
            {
                centerLine.Transform = CGAffineTransform.MakeIdentity();

                topLine.Transform = CGAffineTransform.MakeIdentity();
                topLine.Center = oldTopCenter;

                bottomLine.Transform = CGAffineTransform.MakeIdentity();
                bottomLine.Center = oldBottomCenter;
            }, null);
        }

        CGPoint oldTopCenter;
        CGPoint oldBottomCenter;

        void MakeX()
        {
            var angle = (float)(Math.PI / 4);
            CGPoint center = centerLine.Center;

            oldTopCenter = topLine.Center;
            oldBottomCenter = bottomLine.Center;

            AnimateNotify(2.8, 0, 0.6f, 2.0f, UIViewAnimationOptions.CurveEaseOut, () =>
            {
                topLine.Transform = CGAffineTransform.MakeRotation(-angle * 5f);
                topLine.Center = center;

                bottomLine.Transform = CGAffineTransform.MakeRotation(angle * 5f);
                bottomLine.Center = center;

                centerLine.Transform = CGAffineTransform.MakeScale(0, 1);

            }, null);
        }

        public void SetLineColor(UIColor color)
        {
            topLine.BackgroundColor = centerLine.BackgroundColor = bottomLine.BackgroundColor = color;
        }

        public void ToggleState()
        {
            if (_opened)
            {
                _opened = false;
                MakeMenu();
            }
            else
            {
                _opened = true;
                MakeX();
            }
        }

    }
}
