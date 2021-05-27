using System;
using System.Threading.Tasks;
using CoreGraphics;
using DrunkenWizard_iOS.Base;
using DrunkenWizard_iOS.Menu;
using DrunkenWizard_iOS.ViewControllers.BottomSheet;
using DrunkenWizard_iOS.ViewControllers.CurrentGame;
using DrunkenWizard_iOS.ViewControllers.JoinGame;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.WebService.Hubs;
using Foundation;
using JokesV2;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers
{
    public partial class MainVc : UIViewControllerExtended, ITopView
    {
        MorphButton _btnMenu;
        BottomSheetGameVc _bottomSheetVC;
        ParallaxMenu _menu = ServiceContainer.Resolve<ParallaxMenu>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        PlayerHub playerHub = ServiceContainer.Resolve<PlayerHub>();

        bool _bottomSheetAdded;

        public MainVc() : base("MainVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //NavigationController.SetNavigationBarHidden(true, false);
            Title = "Main";
            _btnMenu = new MorphButton(new CGRect(0, 0, 24, 24));
            _btnMenu.TouchUpInside += _btnMenu_TouchUpInside;
            View.BackgroundColor = UIColor.Black;
            NavigationItem.LeftBarButtonItem = new UIBarButtonItem(_btnMenu);
        }

        void addBottomSheetView()
        {
            _bottomSheetAdded = true;
            // 1- Init bottomSheetVC
            _bottomSheetVC = new BottomSheetGameVc();

            // 2- Add bottomSheetVC as a child view 
            this.AddChildViewController(_bottomSheetVC);
            this.View.AddSubview(_bottomSheetVC.View);
            _bottomSheetVC.DidMoveToParentViewController(this);

            // 3- Adjust bottomSheet frame and initial position.
            var height = View.Frame.Height;
            var width = View.Frame.Width;
            var maxY = View.Frame.GetMaxY();
            _bottomSheetVC.View.Frame = new CGRect(0, maxY, width, height);
            _bottomSheetVC.NavigateToGameVc += NavigateToGameVc;
            _bottomSheetVC.ShowHud += _bottomSheetVC_ShowHud;
            _bottomSheetVC.HideHud += _bottomSheetVC_HideHud;

            InitMenuHandlers();
        }

        private void InitMenuHandlers()
        {
            var vc = _menu.MenuViewController as SideMenuController;
            vc.MenuOptionSelected += vc_MenuOptionSelected;
        }

        private void vc_MenuOptionSelected(object sender, MenuOption e)
        {
            switch (e)
            {
                case MenuOption.CurrentGame:
                    HandleShowCurrentGame();
                    break;

                case MenuOption.JoinGame:
                    HandleJoinGame();
                    break;
            }
        }


        JoinGameVc _joinVc;
        private void HandleJoinGame()
        {
            _joinVc = new JoinGameVc();
            _joinVc.NavigateToGameVc += _joinVc_NavigateToGameVc;
            //_classChooserVc.ClassSelected += _classChooserVc_ClassSelected;
            _joinVc.ModalPresentationStyle = UIModalPresentationStyle.Popover;
            PresentModalViewController(_joinVc, true);
        }

        private void _joinVc_NavigateToGameVc(object sender, EventArgs e)
        {
            _joinVc.NavigateToGameVc -= _joinVc_NavigateToGameVc;
            _joinVc.DismissViewController(true, () => NavigateToGameVc(sender, e));
        }

        private void HandleShowCurrentGame()
        {
            var player = _sqlVM.GetLocalPlayer();

            if (player == null)
            {
                "No games are running at the moment".Translated().ReportError();
            }
            else
            {
                //UpdateHUD("Loading...".Translated());
                //Task.Run(() =>
                //{
                //    int data = player.GameKey;
                //    if (data != 0)
                //    {
                //        Task.Run(() =>
                //        {
                //            Task.Delay(500).Wait();
                //            playerHub.ExistingPLayers(data);
                //        });
                //    }

                //    InvokeOnMainThread(() =>
                //    {
                //        HideHUD();
                //        NavigateToGameVc(this, EventArgs.Empty);
                //    });
                //});
                NavigateToGameVc(this, EventArgs.Empty);
            }
        }

        private void _bottomSheetVC_ShowHud(object sender, string e)
        {
            UpdateHUD(e);
        }

        private void _bottomSheetVC_HideHud(object sender, bool e)
        {
            HideHUD(e);
        }

        private void NavigateToGameVc(object sender, EventArgs e)
        {
            NavigationController.PushViewController(new CurrentGameVc(), true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (!_bottomSheetAdded)
                addBottomSheetView();
        }

        public override UIStatusBarAnimation PreferredStatusBarUpdateAnimation => UIStatusBarAnimation.Slide;



        private void _btnMenu_TouchUpInside(object sender, EventArgs e)
        {
            var menu = ServiceContainer.Resolve<ParallaxMenu>();
            menu.PresentMenuViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (NavigationController == null)
                return;

            // Color of the bar itself
            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0, 0, 0);

            // Whether it should be a bit transparent/translucent (washes out color a bit)
            NavigationController.NavigationBar.Translucent = false;

            // It style black, it changes system symbols to white (clock, wifi signal, cellular)
            // Default for black
            //if (NavigationController.NavigationBar.BarTintColor.ColorIsLight())
            //    NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;
            //else
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            // Text color of the title text. Any color can be used, but black/white should be used to match status bar
            NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes(new NSDictionary(UIStringAttributeKey.ForegroundColor, UIColor.FromRGB(255, 255, 255)));

            // Color of the bar buttons. Either black / white ot separator color
            NavigationController.NavigationBar.TintColor = UIColor.FromRGB(255, 255, 255);
        }

        public void ToggleMenu()
        {
            _btnMenu.ToggleState();
        }
    }
}

