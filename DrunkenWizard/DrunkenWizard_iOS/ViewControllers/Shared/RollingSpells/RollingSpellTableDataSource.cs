using System;
using System.Linq;
using DrunkenWizard_iOS.ViewControllers.Shared.SpellPopUp;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.RollingSpells
{
    public class RollingSpellTableDataSource : UITableViewDataSource
    {
        CurrentGameViewModel _cgVm = ServiceContainer.Resolve<CurrentGameViewModel>();

        public RollingSpellTableDataSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(RollingSpellCell.CellId) as RollingSpellCell;

            var rollEffects = _cgVm.SelectedPlayer.GameClass.GetRollEffects();

            var maxRows = (int)RowsInSection(tableView, 0);

            var rEffect = string.Empty;

            if (indexPath.Row == maxRows - 1)
                rEffect = rollEffects.LastOrDefault();
            else
                rEffect = rollEffects.ElementAtOrDefault(indexPath.Row);


            cell.SetupCell(rEffect, indexPath.Row, maxRows);

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            var initialCount = 2;

            if (_cgVm.SelectedPlayer.Level >= 3)
                initialCount++;
            if (_cgVm.SelectedPlayer.Level >= 6)
                initialCount++;
            if (_cgVm.SelectedPlayer.Level >= 9)
                initialCount++;

            return initialCount;
        }
    }
}
