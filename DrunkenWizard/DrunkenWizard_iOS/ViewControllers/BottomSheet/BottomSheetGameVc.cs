using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphics;
using DrunkenWizard_iOS.Base;
using DrunkenWizard_iOS.ViewControllers.Shared;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_SharedProject.WebService.Hubs;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.BottomSheet
{
    public partial class BottomSheetGameVc : UIViewControllerExtended
    {
        nfloat minY = 0;
        nfloat maxY = 0;
        nfloat maxYmargin = 75;
        nfloat minYmargin = 450;
        nfloat middle;

        PlayerHub playerHub = ServiceContainer.Resolve<PlayerHub>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        GameService _GS = ServiceContainer.Resolve<GameService>();

        GameClass _currentGameClass;

        public EventHandler NavigateToGameVc;
        public EventHandler<string> ShowHud;
        public EventHandler<bool> HideHud;

        public BottomSheetGameVc() : base("BottomSheetGameVc", null)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Clear;
            var gesture = new UIPanGestureRecognizer(PanGesture);
            View.AddGestureRecognizer(gesture);
            vwDragger.MakeBorder(UIColor.LightGray, 0);
            lblHostAGame.Text = "Host a game!".Translated();

            txtWizardName.LeftViewMode = UITextFieldViewMode.Always;
            txtWizardName.LeftView = new UIImageView(UIImage.FromBundle("GlowingWizardHat"));
            txtWizardName.MakeBorder(UIColor.White, 2f, 3);
            txtWizardName.AttributedPlaceholder = new NSAttributedString("TheWizard1337", new UIStringAttributes { ForegroundColor = UIColor.LightGray });
            txtWizardName.RightViewMode = UITextFieldViewMode.Always;
            txtWizardName.RightView = new UIImageView(UIImage.FromBundle("GlowingWizardHat"));
            txtWizardName.EditingDidBegin += TxtWizardName_EditingDidBegin;
            txtWizardName.ShouldReturn += TxtWizardName_ShouldReturn;

            btnChooseClass.MakeBorder(UIColor.White, 2, 3);
            btnChooseClass.TouchUpInside += BtnChooseClass_TouchUpInside;
            btnRandom.MakeBorder(UIColor.White, 2, 3);

            var image = UIImage.FromBundle("random").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            btnRandom.SetImage(image, UIControlState.Normal);
            btnRandom.TintColor = UIColor.White;
            btnRandom.TouchUpInside += BtnRandom_TouchUpInside;

            btnHostGame.MakeBorder(UIColor.White, 2, 3);
            btnHostGame.TouchUpInside += BtnHostGame_TouchUpInside;

            View.MakeBorder(UIColor.DarkGray, 1, 15);
        }

        private void BtnRandom_TouchUpInside(object sender, EventArgs e)
        {
            var rnd = new Random();
            var next = rnd.Next(0, _cVM.ClassList.Count);
            _currentGameClass = _cVM.ClassList.ElementAtOrDefault(next);
            btnChooseClass.SetTitle(_currentGameClass.Name, UIControlState.Normal);
            btnChooseClass.SetTitleColor(_currentGameClass.SelectedColor.FromHex(), UIControlState.Normal);
        }

        private void BtnHostGame_TouchUpInside(object sender, EventArgs e)
        {
            if (_sqlVM.GetLocalPlayer() != null)
            {
                "Game is already running".Translated().ReportError();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWizardName.Text))
            {
                "You forgot a name".Translated().ReportError();
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentGameClass.Name))
            {
                "Choose a class".Translated().ReportError();
                return;
            }

            HideSheet();

            playerHub.ReturnedPlayer += ReturnedPlayer;

            InvokeOnMainThread(() =>
            {
                ShowHud?.Invoke(this, "Loading...".Translated());
            });

            var hostname = txtWizardName.Text;

            Task.Run(async () =>
            {
                var game = await _GS.CreateGameAsync();

                var playerDTO = new JoinPlayerDTO()
                {
                    Name = hostname,
                    Level = 0,
                    ClassName = _currentGameClass.Name,
                    SlayedBeast = BeastEnum.none,
                    IsHost = true,
                    LocalPLayer = false,
                    GameKey = game.Key,
                    PremiumAccount = true
                };

                try
                {
                    playerHub.JoinGame(playerDTO);
                }
                catch (Exception ex)
                {
                    var f = ex;
                }
            });
        }

        void ReturnedPlayer(object sender, Player player)
        {
            if (player != null)
            {
                playerHub.ReturnedPlayer -= ReturnedPlayer;
                _sqlVM.SavePlayer(player.Id, player.GameKey, player.GameId, player.IsHost);
                Task.Run(() =>
                {
                    Task.Delay(1000).Wait();
                    playerHub.ExistingPLayers(player.GameKey);
                });

                HideHud?.Invoke(this, true);

                InvokeOnMainThread(() =>
                {
                    NavigateToGameVc?.Invoke(this, EventArgs.Empty);
                });
            }
            else
            {
                HideHud?.Invoke(this, false);
                InvokeOnMainThread(() =>
                {
                    "Something went wrong".Translated().ReportError();
                    return;
                });
            }
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

        private bool TxtWizardName_ShouldReturn(UITextField textField)
        {
            View.EndEditing(true);
            UIView.Animate(0.4, () =>
            {
                var frame = View.Frame;
                var yComponent = minY;
                View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
            });
            return true;
        }

        private void TxtWizardName_EditingDidBegin(object sender, EventArgs e)
        {
            UIView.Animate(0.4, () =>
            {
                var frame = View.Frame;
                var yComponent = minY - 50;
                View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
            });
        }

        void PanGesture(UIPanGestureRecognizer recognizer)
        {
            var translation = recognizer.TranslationInView(View);
            var y = View.Frame.GetMinY();
            var newY = y + translation.Y;
            if (newY < minY || newY > maxY)
                return;

            CGPoint velocity = recognizer.VelocityInView(View);

            if (velocity.Y > 0)   // panning down
            {
                if (newY > middle)
                {
                    UIView.Animate(0.3, () =>
                    {
                        var frame = View.Frame;
                        var yComponent = maxY;
                        View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
                    });
                    return;
                }
            }
            else  // panning up
            {
                if (newY < middle)
                {
                    UIView.Animate(0.3, () =>
                    {
                        var frame = View.Frame;
                        var yComponent = minY;
                        View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
                    });
                    return;
                }
            }

            View.Frame = new CGRect(0, y + translation.Y, View.Frame.Width, View.Frame.Height);
            recognizer.SetTranslation(CGPoint.Empty, View);
            //Debug.WriteLine($"Y: {View.Frame.Y}, State: {recognizer.State}");

            if (recognizer.State == UIGestureRecognizerState.Ended)
            {
                if (newY > middle)
                {
                    UIView.Animate(0.3, () =>
                    {
                        var frame = View.Frame;
                        var yComponent = maxY;
                        View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
                    });
                }
                else
                {
                    HideSheet();
                }
            }
        }

        private void HideSheet()
        {
            UIView.Animate(0.3, () =>
            {
                var frame = View.Frame;
                var yComponent = maxY;
                View.Frame = new CGRect(0, yComponent, frame.Width, frame.Height);
            });
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

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            maxY = View.Frame.Height - maxYmargin;
            minY = View.Frame.Height - minYmargin;
            middle = (maxY - minY) / 2 + minY;
            UIView.Animate(0.3, () =>
            {
                var frame = View.Frame;
                var yComponent = maxY;
                View.Frame = new CGRect(0, frame.Height - 75, frame.Width, frame.Height);
            });
        }
    }
}