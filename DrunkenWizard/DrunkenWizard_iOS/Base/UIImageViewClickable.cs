using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.Base
{
    [Register("UIImageViewClickable")]
    public class UIImageViewClickable : UIImageView
    {
        UITapGestureRecognizer _tapGesture;

        public UIImageViewClickable()
        {
        }

        public UIImageViewClickable(CGRect frame) : base(frame)
        {

        }

        public UIImageViewClickable(IntPtr p) : base(p)
        {

        }

        private Action _tapAction;
        public Action TapAction
        {
            get
            {
                return _tapAction;
            }
            set
            {
                _tapAction = value;
                SetupGestureRecogniser();
            }
        }

        private void SetupGestureRecogniser()
        {
            if (_tapAction == null && _tapGesture != null)
            {
                RemoveGestureRecognizer(_tapGesture);
                return;
            }

            if (_tapAction != null && _tapGesture != null)
                return;

            _tapGesture = new UITapGestureRecognizer();
            _tapGesture.NumberOfTapsRequired = 1;
            UserInteractionEnabled = true;
            _tapGesture.AddTarget(TapAction);
            AddGestureRecognizer(_tapGesture);
        }
    }
}
