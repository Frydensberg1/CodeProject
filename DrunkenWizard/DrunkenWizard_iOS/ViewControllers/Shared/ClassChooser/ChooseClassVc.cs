using System;
using DrunkenWizard_iOS.Base;
using DrunkenWizard_iOS.ViewControllers.Shared.Abilities;
using DrunkenWizard_iOS.ViewControllers.Shared.Grid;
using DrunkenWizard_SharedProject.Models;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared
{
    public partial class ChooseClassVc : UIViewControllerExtended
    {
        UIView blurredView;
        ClassesGridSource _grdSrc;
        AbilityTblSource _classAbilityTblSrc;
        ClassFlowLayout _gridLayout;
        GameClass _currentSelectedClass;
        public EventHandler<GameClass> ClassSelected;

        public ChooseClassVc() : base("ChooseClassVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupGrid();
            SetupDetailsView();


            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void SetupDetailsView()
        {
            vwDetails.Alpha = 0;
            btnCancel.MakeBorder(UIColor.White, 1, 0);
            btnChoose.MakeBorder(UIColor.White, 1, 0);

            btnCancel.TouchUpInside += BtnCancel_TouchUpInside;
            btnChoose.TouchUpInside += BtnChoose_TouchUpInside;
            vwDetails.MakeBorder(UIColor.White, 2);
            _classAbilityTblSrc = new AbilityTblSource();
            tblProperties.Source = _classAbilityTblSrc;
            tblProperties.RegisterNibForCellReuse(AbilityCell.Nib, AbilityCell.CellId);
            tblProperties.UserInteractionEnabled = false;
            tblProperties.SeparatorColor = UIColor.Clear;
            tblProperties.BackgroundColor = UIColor.Black;
        }

        private void BtnChoose_TouchUpInside(object sender, EventArgs e)
        {
            if (_currentSelectedClass == null)
            {
                "Select a class first".Translated().ReportError();
                return;
            }

            ClassSelected?.Invoke(this, _currentSelectedClass);

            UIView.AnimateNotify(0.3f, () =>
            {
                vwDetails.Alpha = 0;
            }, (completed) =>
            {
                if (completed)
                    vwDetails.Hidden = true;
                DismissModalViewController(true);
            });
        }

        private void BtnCancel_TouchUpInside(object sender, EventArgs e)
        {
            _currentSelectedClass = null;
            UIView.AnimateNotify(0.3f, () =>
            {
                vwDetails.Alpha = 0;
            }, (completed) =>
            {
                if (completed)
                    vwDetails.Hidden = true;
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void prepareBackgroundView()
        {
            if (blurredView != null)
                return;
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.SystemUltraThinMaterialDark);
            var visualEffect = new UIVisualEffectView(blurEffect);
            blurredView = new UIVisualEffectView(blurEffect);
            blurredView.Frame = UIScreen.MainScreen.Bounds;

            View.InsertSubview(blurredView, 0);
        }

        void SetupGrid()
        {
            _gridLayout = new ClassFlowLayout(gridClasses.Frame)
            {
                SectionInset = new UIEdgeInsets(5, 5, 0, 5), // distance to edges, not eachother
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                MinimumInteritemSpacing = 0, // minimum spacing between cells
                MinimumLineSpacing = 0, // minimum spacing between rows if ScrollDirection is Vertical or between columns if Horizontal
            };

            gridClasses.RegisterNibForCell(ClassGridCell.Nib, ClassGridCell.Key);
            gridClasses.CollectionViewLayout = _gridLayout;

            _grdSrc = new ClassesGridSource();
            _grdSrc.ClassSelected += HandleGameClassSelected;
            //_calendarCellDataSource.DateWasClicked += _calendarCellDataSource_DateWasClicked;
            gridClasses.Source = _grdSrc;
        }

        private void HandleGameClassSelected(object sender, GameClass e)
        {
            _currentSelectedClass = e;
            _classAbilityTblSrc.SelectedClass = e;
            tblProperties.ReloadData();
            vwDetails.Hidden = false;
            UIView.Animate(0.3f, () =>
            {
                vwDetails.Alpha = 1;
            });

            imgIcon.Image = UIImage.FromBundle(e.Picture);
            lblName.Text = e.Name;

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            prepareBackgroundView();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            _gridLayout.Frame = gridClasses.Frame;
        }
    }
}

