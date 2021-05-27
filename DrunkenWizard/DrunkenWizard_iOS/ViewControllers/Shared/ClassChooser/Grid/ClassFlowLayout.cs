using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Grid
{
    public class ClassFlowLayout : UICollectionViewFlowLayout
    {
        int itemCount = 3;
        private CGRect frame;

        public CGRect Frame
        {
            get { return frame; }
            set
            {
                frame = value;
            }
        }

        public ClassFlowLayout(CGRect frame)
        {
            var spacing = 0;
            var width = (frame.Width - spacing * (itemCount)) / itemCount;
            ItemSize = new CGSize(width, width * 1.5);
        }

        public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
        {
            return true;
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath path)
        {
            return base.LayoutAttributesForItem(path);
        }
    }
}
