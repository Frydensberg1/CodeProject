using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.Menu
{
    public enum MenuOption
    {
        Blank0,
        Blank1,
        Blank2,
        Home,
        Rules,
        Classes,
        Blank6,
        JoinGame,
        CurrentGame
    }

    public class SideMenuController : UITableViewController
    {
        TableSource _tblSrc;
        MenuController _parent;
        public EventHandler<MenuOption> MenuOptionSelected;

        public SideMenuController(MenuController parent)
        {
            _parent = parent;
        }

        public override void LoadView()
        {
            base.LoadView();
            View.BackgroundColor = UIColor.Clear;

            TableView.ScrollEnabled = false;
            _tblSrc = new TableSource();
            TableView.Source = _tblSrc;
            _tblSrc.SelectRow += _tblSrc_SelectRow;
            TableView.SeparatorColor = UIColor.Clear;
        }

        void _tblSrc_SelectRow(int section, int row)
        {
            _parent.HideMenuViewController();
            MenuOptionSelected?.Invoke(this, (MenuOption)row);
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }

        class TableSource : UITableViewSource
        {


            protected string _cellIdentifier = "MenuTableCellID";
            protected Dictionary<int, UITableViewCell> _cellControllers = new Dictionary<int, UITableViewCell>();

            public delegate void RowEvent(int section, int row);

            public event RowEvent SelectRow;

            int tagNR = 0;

            public TableSource()
            {

            }

            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override string TitleForHeader(UITableView tableView, nint section)
            {
                return "";
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return 11;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {

                UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, _cellIdentifier);

                cell.BackgroundColor = UIColor.FromWhiteAlpha(1f, 0.6f);
                cell.ContentView.BackgroundColor = UIColor.Clear;

                cell.TextLabel.TextColor = UIColor.Black;
                cell.TextLabel.Font = UIFont.BoldSystemFontOfSize(24f);

                cell.TextLabel.Text = "";
                var config = UIImageSymbolConfiguration.Create(36f);

                if (indexPath.Row == 3)
                {
                    var img = UIImage.GetSystemImage("house.fill");
                    img = img.ApplyConfiguration(config);

                    cell.TextLabel.Text = "Home".Translated();
                    cell.ImageView.Image = img;
                    cell.ImageView.TintColor = UIColor.Black;
                }
                if (indexPath.Row == 4)
                {
                    cell.TextLabel.Text = "Rules".Translated();
                    var img = UIImage.GetSystemImage("book.fill");
                    img = img.ApplyConfiguration(config);
                    cell.ImageView.Image = img;
                    cell.ImageView.TintColor = UIColor.Black;
                }
                if (indexPath.Row == 5)
                {
                    cell.TextLabel.Text = "Classes".Translated();
                    var img = UIImage.GetSystemImage("wand.and.stars");
                    img = img.ApplyConfiguration(config);
                    cell.ImageView.Image = img;
                    cell.ImageView.TintColor = UIColor.Black;
                }
                if (indexPath.Row == 7)
                {
                    cell.TextLabel.Text = "Join game".Translated();
                    var img = UIImage.GetSystemImage("gamecontroller");
                    img = img.ApplyConfiguration(config);
                    cell.ImageView.Image = img;
                    cell.ImageView.TintColor = UIColor.Black;
                }
                if (indexPath.Row == 8)
                {
                    cell.TextLabel.Text = "Current game".Translated();
                    var img = UIImage.GetSystemImage("gamecontroller.fill");
                    img = img.ApplyConfiguration(config);
                    cell.ImageView.Image = img;
                    cell.ImageView.TintColor = UIColor.Black;
                }

                return cell;
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                // NOTE: Don't call the base implementation on a Model class
                // see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events 
                return tableView.Frame.Height / 11;
            }

            public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
            {
                //				var cell = tableView.CellAt (indexPath);
                //				var cCell = cell as LogCell;
                //				if (cCell == null)
                //					return;
                //
                //				cCell.ShowDetails (tableView);
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (SelectRow != null)
                    SelectRow(indexPath.Section, indexPath.Row);
            }

        }
    }
}
