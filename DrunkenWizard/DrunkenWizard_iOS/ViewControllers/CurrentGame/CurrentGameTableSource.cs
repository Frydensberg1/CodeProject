using System;
using System.Linq;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.CurrentGame
{
    public class CurrentGameTableSource : UITableViewSource
    {
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();

        public EventHandler<Player> MinusClicked;
        public EventHandler<Player> PlusClicked;
        public EventHandler<Player> BossClicked;
        public EventHandler<Player> DragonHeadClicked;
        public EventHandler<Spell> DisplaySpell;
        public EventHandler<Player> MenuClicked;
        public EventHandler<Player> RollingSpellsClicked;
        public EventHandler<Player> CircleImageClicked;

        public CurrentGameTableSource()
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CurrentGameCell.CellId) as CurrentGameCell;

            var data = _cgVM.PlayerList.OrderByDescending(x => x.Level).ElementAtOrDefault(indexPath.Row); ;

            if (cell.MinusClicked == null)
            {
                cell.MinusClicked += (sender, e) => { MinusClicked?.Invoke(this, e); };
                cell.PlusClicked += (sender, e) => { PlusClicked?.Invoke(this, e); };
                cell.BossClicked += (sender, e) => { BossClicked?.Invoke(this, e); };
                cell.DragonHeadClicked += (sender, e) => { DragonHeadClicked?.Invoke(this, e); };
                cell.DisplaySpell += (sender, e) => { DisplaySpell?.Invoke(this, e); };
                cell.MenuClicked += (sender, e) => { MenuClicked?.Invoke(this, e); };
                cell.RollSpellsClicked += (sender, e) => { RollingSpellsClicked?.Invoke(this, e); };
                cell.CircleImageClicked += (sender, e) => { CircleImageClicked?.Invoke(this, e); };
            }

            cell.SetupCell(data);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _cgVM.PlayerList?.Count ?? 0;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 120f;
        }
    }
}
