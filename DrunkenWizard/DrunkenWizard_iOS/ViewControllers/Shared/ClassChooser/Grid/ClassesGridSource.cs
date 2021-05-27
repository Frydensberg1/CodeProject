using System;
using System.Linq;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Grid
{
    public class ClassesGridSource : UICollectionViewSource
    {
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        public EventHandler<GameClass> ClassSelected;

        public ClassesGridSource()
        {

        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var gameClass = _cVM.ClassList.ElementAtOrDefault(indexPath.Row);
            var cell = (ClassGridCell)collectionView.DequeueReusableCell(ClassGridCell.Key, indexPath);
            cell.ToggleSelected();
            cell.SetParent(this);

            cell.UpdateCell(gameClass);

            return cell;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _cVM.ClassList.Count;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            _currentSelectedCell?.ToggleSelected(true);

            _currentSelectedCell = collectionView.CellForItem(indexPath) as ClassGridCell;
            _currentSelectedCell.ToggleSelected();
            //_calVm.PickedDate = _currentSelectedCell.TagObj;
            ClassSelected?.Invoke(this, _currentSelectedCell.TagObj);
        }
        ClassGridCell _currentSelectedCell;
        public ClassGridCell CurrentSelectedCell
        {
            get { return _currentSelectedCell; }
            set { _currentSelectedCell = value; }
        }


        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.CellForItem(indexPath) as ClassGridCell;
            cell.ToggleSelected();
        }

        public override bool ShouldSelectItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            //var weekday = (int)_calVm.SelectedDate.DayOfWeek - 1;
            //if (weekday == -1)
            //{
            //    weekday = 6;
            //}
            //if (indexPath.Row < weekday)
            //{
            //    return false;
            //}
            //if (indexPath.Row >= _calVm.DaysInSelectedDate + weekday)
            //{
            //    return false;
            //}
            return true;
        }

    }
}
