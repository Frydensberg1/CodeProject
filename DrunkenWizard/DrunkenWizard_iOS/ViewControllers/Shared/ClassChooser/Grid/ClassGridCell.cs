using System;
using DrunkenWizard_SharedProject.Models;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Grid
{
    public partial class ClassGridCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("ClassGridCell");
        public static readonly UINib Nib;

        static ClassGridCell()
        {
            Nib = UINib.FromName("ClassGridCell", NSBundle.MainBundle);
        }

        protected ClassGridCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void ToggleSelected(bool reset = false)
        {
            //if (reset)
            //    Selected = false;

            //if (Selected)
            //{
            //    lblCellDate.TextColor = UIColor.White;

            //    if (TagObj.Date == DateTime.Today)
            //        vwBackground.BackgroundColor = UIColor.Red;
            //    else
            //        vwBackground.BackgroundColor = UIColor.Black;
            //}
            //else
            //{
            //    lblCellDate.TextColor = lbBlue;
            //    if (TagObj.Date == DateTime.Today)
            //        lblCellDate.TextColor = UIColor.Red;

            //    vwBackground.BackgroundColor = UIColor.White;
            //}
        }

        ClassesGridSource _parent;
        public void SetParent(ClassesGridSource parent)
        {
            _parent = parent;
        }

        public GameClass TagObj { get; set; }

        public void UpdateCell(GameClass gameClass)
        {
            TagObj = gameClass;
            lblClassName.Text = gameClass.Name;
            imgIcon.Image = UIImage.FromBundle(gameClass.Picture);
            vwClassContainer.Hidden = false;
            vwClassContainer.BackgroundColor = UIColor.Clear;
        }
    }
}
