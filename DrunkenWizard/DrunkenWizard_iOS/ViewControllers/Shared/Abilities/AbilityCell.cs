using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Abilities
{
    public partial class AbilityCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("AbilityCell");
        public static readonly UINib Nib;
        public static NSString CellId = new NSString("AbilityCellID");

        static AbilityCell()
        {
            Nib = UINib.FromName("AbilityCell", NSBundle.MainBundle);
        }

        protected AbilityCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        bool _isSetup;

        List<UIView> _rateViews = new List<UIView>();

        internal void SetupCell(string name, int strength, string color)
        {
            if (!_isSetup)
            {
                _isSetup = true;
                _rateViews.Add(vw1);
                _rateViews.Add(vw2);
                _rateViews.Add(vw3);
                _rateViews.Add(vw4);
                _rateViews.Add(vw5);
                SelectionStyle = UITableViewCellSelectionStyle.None;
            }

            lblName.Text = name;
            _rateViews.ForEach(v => v.BackgroundColor = UIColor.DarkGray);
            _rateViews.Take(strength).ToList().ForEach(v => v.BackgroundColor = color.FromHex());
        }
    }
}
