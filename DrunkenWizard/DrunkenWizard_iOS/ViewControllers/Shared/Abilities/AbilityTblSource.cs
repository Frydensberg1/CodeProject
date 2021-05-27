using System;
using DrunkenWizard_SharedProject.Models;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.Abilities
{
    public class AbilityTblSource : UITableViewSource
    {
        public GameClass SelectedClass { get; set; }

        public AbilityTblSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (AbilityCell)tableView.DequeueReusableCell(AbilityCell.CellId);

            if (indexPath.Row == 0)
                cell.SetupCell(nameof(GameClass.Aggressive), SelectedClass.Aggressive, SelectedClass.Color);
            if (indexPath.Row == 1)
                cell.SetupCell(nameof(GameClass.Defensive), SelectedClass.Defensive, SelectedClass.Color);
            if (indexPath.Row == 2)
                cell.SetupCell(nameof(GameClass.Entertaining), SelectedClass.Entertaining, SelectedClass.Color);
            if (indexPath.Row == 3)
                cell.SetupCell(nameof(GameClass.Speed), SelectedClass.Speed, SelectedClass.Color);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return SelectedClass != null ? 4 : 0;
        }
    }
}
