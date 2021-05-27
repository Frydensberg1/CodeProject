using System;
using System.Linq;
using DrunkenWizard_iOS.Services;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using UIKit;

namespace DrunkenWizard_iOS.ViewControllers.Shared.LevelUp
{
    public partial class LevelUpModelVc : UIViewController
    {
        Player _player;
        //public EventHandler Dismiss;
        TextColorService _tcVM = ServiceContainer.Resolve<TextColorService>();
        bool _bossFight;
        bool _makeBorder;

        public LevelUpModelVc(Player player) : base("LevelUpModelVc", null)
        {
            _player = player;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupSpellUi();

            btnOk.TouchUpInside += BtnOk_TouchUpInside;
            txtSpellEffect.BackgroundColor = UIColor.Clear;
        }

        private void BtnOk_TouchUpInside(object sender, EventArgs e)
        {
            DismissViewController(true, null);
        }

        private void SetupSpellUi()
        {
            lblLevelUpSpell.Text = "Level Up!".Translated();

            if (_player.Level == 3 || _player.Level == 6 || _player.Level == 9)
            {
                _bossFight = true;
                if (_player.Name == "Dracsoris")
                {
                    vwDialog.BackgroundColor = UIColor.Clear;

                    btnOk.BackgroundColor = UIColor.Clear;
                    vwSeparator.Hidden = true;
                    lblSpell.Text = "Boss Fight!";
                    txtSpellEffect.Text = "You won the fight!";
                }
                else
                {
                    vwDialog.BackgroundColor = UIColor.Clear;
                    btnOk.BackgroundColor = UIColor.Clear;
                    vwSeparator.Hidden = true;

                    txtSpellEffect.Text = "Drink a shot to beat the boss.";
                    switch (_player.Level)
                    {
                        case 3:
                            imgBoss.Image = UIImage.FromBundle("Boss1");
                            lblSpell.Text = "Boss Fight! Boss 1";
                            break;
                        case 6:
                            imgBoss.Image = UIImage.FromBundle("Boss2");
                            lblSpell.Text = "Boss Fight! Boss 2";
                            break;
                        case 9:
                            imgBoss.Image = UIImage.FromBundle("Boss3");
                            lblSpell.Text = "Boss Fight! Boss 3";
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (_player.GameClass.Spells.FirstOrDefault(x => x.Level == _player.Level) != null)
                {
                    Spell currentSpell = _player.GameClass.Spells.FirstOrDefault(x => x.Level == _player.Level);
                    string spellStyle = currentSpell.Style ?? "";

                    vwDialog.BackgroundColor = _player.GameClass.Color.FromHex();

                    btnOk.BackgroundColor = _player.GameClass.Color.FromHex();
                    vwSeparator.Hidden = false;
                    if (_player.GameClass.Name == "Cleric" || _player.GameClass.Name == "Elementalist")
                    {
                        var stringwithcolorCleric = _tcVM.GetColoredText(UIColor.Black, spellStyle, "Level " + _player.Level + ". " + _player.GameClass.Spells.FirstOrDefault(x => x.Level == _player.Level).Name);
                        lblSpell.AttributedText = stringwithcolorCleric;
                        txtSpellEffect.TextColor = UIColor.Black;
                        //btnOk.BackgroundColor = UIColor.Black;
                        btnOk.SetTitleColor(UIColor.Black, UIControlState.Normal);
                        vwSeparator.BackgroundColor = UIColor.Black;
                    }
                    else
                    {
                        var stringwithcolor = _tcVM.GetColoredText(UIColor.White, spellStyle, "Level " + _player.Level + ". " + currentSpell.Name);
                        lblSpell.AttributedText = stringwithcolor;
                    }

                    txtSpellEffect.Text = _player.GameClass.Spells.FirstOrDefault(x => x.Level == _player.Level).Description;

                    _makeBorder = true;
                }
                else if (_player.Level == 10)
                {
                    _makeBorder = false;
                    _bossFight = true;
                    btnOk.BackgroundColor = UIColor.Clear;
                    vwSeparator.Hidden = true;
                    lblSpell.Text = "You are now a Drunken Wizard!";
                    txtSpellEffect.Text = "";
                    imgBoss.Image = UIImage.FromBundle("DrunkenWizardLogo");

                }
                else
                {
                    _makeBorder = false;
                    btnOk.BackgroundColor = UIColor.Clear;
                    vwSeparator.Hidden = true;
                    lblSpell.Text = "Drunken Wizard";
                    txtSpellEffect.Text = "You have already achieved the Drunken Wizard status!";
                }
            }

            var originalHeight = txtSpellEffect.Frame.Height;
            txtSpellEffect.SizeToFit();
            var newHeight = txtSpellEffect.Frame.Height;
            var difference = (originalHeight - newHeight) * -1;

            if (!_bossFight)
            {
                var imgHeight = imgBoss.Frame.Height;
                difference -= imgHeight;
            }

            var mainHeght = vwMainContainer.Frame.Height;
            vwMainContainer.HeightAnchor.ConstraintEqualTo(mainHeght + difference).Active = true;

            if (!_bossFight)
                imgBoss.HeightAnchor.ConstraintEqualTo(0).Active = true;

            if (_makeBorder)
                vwDialog.MakeBorder(_player.GameClass.Color.FromHex(), 2, 15);
            txtSpellEffect.Editable = false;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (_bossFight)
                UIView.Animate(1, () =>
                {
                    vwFadeBackground.Alpha = 1f;
                });
        }
    }
}

