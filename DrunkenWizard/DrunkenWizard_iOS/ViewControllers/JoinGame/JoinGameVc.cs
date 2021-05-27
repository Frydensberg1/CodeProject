using System;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_iOS.Base;
using DrunkenWizard_iOS.ViewControllers.Shared;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.WebService.Hubs;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.JoinGame
{
    public partial class JoinGameVc : UIViewControllerExtended
    {
        GameClass _currentGameClass;
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        PlayerHub playerHub = ServiceContainer.Resolve<PlayerHub>();
        public EventHandler NavigateToGameVc;

        public JoinGameVc() : base("JoinGameVc", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            lblViewTitle.Text = "Join game!".Translated();
            lblWizardNameUi.Text = "Enter your wizard name".Translated();
            lblEnterKeyUi.Text = "Enter Your Key".Translated();
            btnChooseClass.SetTitle("Choose class".Translated(), UIControlState.Normal);
            btnJoinGame.SetTitle("Join game".Translated().ToUpper(), UIControlState.Normal);

            txtWizardName.LeftViewMode = UITextFieldViewMode.Always;
            txtWizardName.LeftView = new UIImageView(UIImage.FromBundle("GlowingWizardHat"));
            txtWizardName.MakeBorder(UIColor.White, 2f, 3);
            txtWizardName.AttributedPlaceholder = new NSAttributedString("TheWizard1337", new UIStringAttributes { ForegroundColor = UIColor.LightGray });
            txtWizardName.RightViewMode = UITextFieldViewMode.Always;
            txtWizardName.RightView = new UIImageView(UIImage.FromBundle("GlowingWizardHat"));
            txtWizardName.EditingDidBegin += TxtWizardName_EditingDidBegin;
            txtWizardName.ShouldReturn += TxtWizardName_ShouldReturn;

            txtEnterKey.LeftViewMode = UITextFieldViewMode.Always;
            txtEnterKey.LeftView = new UIImageView(UIImage.FromBundle("Key"));
            txtEnterKey.MakeBorder(UIColor.White, 2f, 3);
            txtEnterKey.AttributedPlaceholder = new NSAttributedString("Type your key here", new UIStringAttributes { ForegroundColor = UIColor.LightGray });
            txtEnterKey.RightViewMode = UITextFieldViewMode.Always;
            txtEnterKey.RightView = new UIImageView(UIImage.FromBundle("Key"));
            txtEnterKey.EditingDidBegin += TxtWizardName_EditingDidBegin;
            txtEnterKey.ShouldReturn += TxtWizardName_ShouldReturn;

            btnChooseClass.TouchUpInside += BtnChooseClass_TouchUpInside;
            btnRandom.TouchUpInside += BtnRandom_TouchUpInside;
            btnJoinGame.TouchUpInside += BtnJoinGame_TouchUpInside;

            btnChooseClass.MakeBorder(UIColor.White, 2, 3);
            btnChooseClass.TouchUpInside += BtnChooseClass_TouchUpInside;
            btnRandom.MakeBorder(UIColor.White, 2, 3);

            var image = UIImage.FromBundle("random").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            btnRandom.SetImage(image, UIControlState.Normal);
            btnRandom.TintColor = UIColor.White;

            btnJoinGame.MakeBorder(UIColor.White, 2, 3);
        }

        private void TxtWizardName_EditingDidBegin(object sender, EventArgs e)
        {
            //UIView.Animate(0.4, () =>
            //{
            //    var frame = View.Frame;
            //    var yComponent = minY - 50;
            //    View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
            //});
        }

        private bool TxtWizardName_ShouldReturn(UITextField textField)
        {
            View.EndEditing(true);
            //UIView.Animate(0.4, () =>
            //{
            //    var frame = View.Frame;
            //    var yComponent = minY;
            //    View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
            //});
            return true;
        }

        private void BtnJoinGame_TouchUpInside(object sender, EventArgs e)
        {
            View.EndEditing(true);
            var player = _sqlVM.GetLocalPlayer();
            if (player != null)
            {
                "You are already in a game. Leave it before you can join another".Translated().ReportError();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtWizardName.Text))
            {
                "You forgot a name".Translated().ReportError();
                return;
            }
            if (_currentGameClass == null)
            {
                "Choose a class".Translated().ReportError();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEnterKey.Text))
            {
                "Enter a Key".Translated().ReportError();
                return;
            }

            JoinPlayerDTO playerDTO = new JoinPlayerDTO()
            {
                Name = txtWizardName.Text,
                Level = 0,
                ClassName = _currentGameClass.Name,
                SlayedBeast = BeastEnum.none,
                IsHost = false,
                LocalPLayer = false,
                GameKey = Convert.ToInt32(txtEnterKey.Text),
                PremiumAccount = true
            };

            UpdateHUD("Loading...".Translated());

            Task.Run(() =>
            {
                playerHub.ReturnedPlayer += ReturnedPlayer;
                playerHub.JoinGame(playerDTO);
            });
        }

        void ReturnedPlayer(object sender, Player player)
        {
            playerHub.ReturnedPlayer -= ReturnedPlayer;
            if (player == null)
            {
                HideHUD(false);
                "Error, Your Key is probably not correct".Translated().ReportError();
                return;
            }
            else
            {
                _sqlVM.SavePlayer(player.Id, player.GameKey, player.GameId, player.IsHost);
                HideHUD(true);
                InvokeOnMainThread(() => NavigateToGameVc?.Invoke(this, EventArgs.Empty));
            }
        }

        private void BtnRandom_TouchUpInside(object sender, EventArgs e)
        {
            var rnd = new Random();
            var next = rnd.Next(0, _cVM.ClassList.Count);
            _currentGameClass = _cVM.ClassList.ElementAtOrDefault(next);
            btnChooseClass.SetTitle(_currentGameClass.Name, UIControlState.Normal);
            btnChooseClass.SetTitleColor(_currentGameClass.SelectedColor.FromHex(), UIControlState.Normal);
        }

        ChooseClassVc _classChooserVc;
        private void BtnChooseClass_TouchUpInside(object sender, EventArgs e)
        {
            _classChooserVc = new ChooseClassVc();
            _classChooserVc.ClassSelected += _classChooserVc_ClassSelected;
            _classChooserVc.ModalPresentationStyle = UIModalPresentationStyle.Popover;
            PresentModalViewController(_classChooserVc, true);
        }

        private void _classChooserVc_ClassSelected(object sender, GameClass e)
        {
            _classChooserVc.ClassSelected -= _classChooserVc_ClassSelected;
            _currentGameClass = e;
            btnChooseClass.SetTitle(e.Name, UIControlState.Normal);
            btnChooseClass.SetTitleColor(_currentGameClass.SelectedColor.FromHex(), UIControlState.Normal);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void prepareBackgroundView()
        {
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.SystemUltraThinMaterialDark);
            var visualEffect = new UIVisualEffectView(blurEffect);
            var bluredView = new UIVisualEffectView(blurEffect);
            //bluredView.ContentView.AddSubview(visualEffect);

            //visualEffect.Frame = UIScreen.MainScreen.Bounds;
            bluredView.Frame = UIScreen.MainScreen.Bounds;

            View.InsertSubview(bluredView, 0);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            prepareBackgroundView();
        }
    }
}

