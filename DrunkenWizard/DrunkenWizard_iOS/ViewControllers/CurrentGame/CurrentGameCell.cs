using System;
using System.Linq;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_SharedProject.Container;
using Foundation;
using UIKit;
using System.Collections.Generic;

namespace DrunkenWizard_iOS.ViewControllers.CurrentGame
{
    public partial class CurrentGameCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CurrentGameCell");
        public static readonly UINib Nib;
        public static string CellId = "CurrentGameCellId";

        public EventHandler<Player> MinusClicked;
        public EventHandler<Player> PlusClicked;
        public EventHandler<Player> BossClicked;
        public EventHandler<Player> RollSpellsClicked;
        public EventHandler<Player> DragonHeadClicked;
        public EventHandler<Spell> SpellImage1Clicked;
        public EventHandler<Spell> SpellImage2Clicked;
        public EventHandler<Spell> SpellImage3Clicked;
        public EventHandler<Spell> DisplaySpell;
        public EventHandler<Player> MenuClicked;
        public EventHandler<Player> CircleImageClicked;

        static CurrentGameCell()
        {
            Nib = UINib.FromName("CurrentGameCell", NSBundle.MainBundle);
        }

        bool _isSetup;

        PlayerService _PS = ServiceContainer.Resolve<PlayerService>();

        protected CurrentGameCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        internal void SetupCell(Player data)
        {
            if (!_isSetup)
            {
                _isSetup = true;
                imgProfile.MakeCircle(UIColor.Black, 2);
                btnMinus.TouchUpInside += BtnMinus_TouchUpInside;
                btnPlus.TouchUpInside += BtnPlus_TouchUpInside;

                imgProfile.TapAction = () => { CircleImageClicked?.Invoke(this, TagObj); };
                imgSpell1.TapAction = () => { DisplaySpell?.Invoke(this, _sp1); };
                imgSpell2.TapAction = () => { DisplaySpell?.Invoke(this, _sp2); };
                imgSpell3.TapAction = () => { DisplaySpell?.Invoke(this, _sp3); };
                imgMagicBeast.TapAction = () => { DragonHeadClicked?.Invoke(this, TagObj); };
                imgLevelUpCheering.TapAction = () => { BossClicked?.Invoke(this, TagObj); };
                btnRollingSpells.TouchUpInside += (sender, args) => { RollSpellsClicked?.Invoke(this, TagObj); };
                btnDice.TouchUpInside += (sender, args) => { MenuClicked?.Invoke(this, TagObj); };
            }

            TagObj = data;
            txtNamePlayer.Text = data.Name;
            lblLevel.Text = data.Level.ToString();

            btnDice.TintColor = data.GameClass.Color.FromHex();
            btnRollingSpells.TintColor = data.GameClass.Color.FromHex();
            SetUpClassesCircleImage();
            SetBossesImages();
            HandleDragonImage();
            HandlePassiveReactionClickImage();
        }

        private void HandleDragonImage()
        {
            imgMagicBeast.Image = UIImage.FromBundle("DragonHead");
            if (TagObj.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.none)
            {
                imgMagicBeast.Hidden = true;
            }
            else
            {
                imgMagicBeast.Hidden = false;
            }

            if (TagObj.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.Dracsoris)
            {
                List<Spell> dracsorisseplls = new List<Spell>();

                Spell spell1 = new Spell()
                {
                    GameClassName = "Dracsoris",
                    Name = "DragonPower",
                    Level = 5,
                    Style = "Passive",
                    Description = "You can't decrease or change dracsoris",
                    SpellImage = "DracsorisLevel5"
                };
                Spell spell2 = new Spell()
                {
                    GameClassName = "Dracsoris",
                    Name = "Retaliate",
                    Level = 7,
                    Style = "Passive",
                    Description = "When targeted, send a fireball back, that deals 5 drinks as damage.",
                    SpellImage = "DracsorisLevel7"
                };
                Spell spell3 = new Spell()
                {
                    GameClassName = "Dracsoris",
                    Name = "Ice Tower",
                    Level = 8,
                    Style = "Multiple",
                    Description = "Freeze a target wizard till you level up, or he drinks 2 shots",
                };

                dracsorisseplls.Add(spell1);
                dracsorisseplls.Add(spell2);
                dracsorisseplls.Add(spell3);

                GameClass dracsoris = new GameClass()
                {
                    Name = "Dracsoris",
                    Picture = "DragonBoss",
                    Color = "#8B0000",
                    RollEffect1 = "Reroll",
                    RollEffect2 = "You are immune this turn",
                    RollEffect3 = "Every other wizard roll a die, highest roll drinks the amount he rolled",
                    RollEffect4 = "Level up!",
                    RollEffect5 = "",
                    RollEffect6 = "Level up!",
                    Spells = dracsorisseplls,
                    SelectedColor = "#FF80AA"
                };

                TagObj.GameClass = dracsoris;
                _PS.UpdatePlayerChangeClass(TagObj);
                imgMagicBeast.Hidden = true;
            }
        }

        Spell _sp1, _sp2, _sp3;

        private void HandlePassiveReactionClickImage()
        {
            var spellList = TagObj.GameClass.SetSpellList(TagObj);
            _sp1 = spellList.ElementAtOrDefault(0);
            _sp2 = spellList.ElementAtOrDefault(1);
            _sp3 = spellList.ElementAtOrDefault(2);

            imgSpell1.Image = _sp1 != null ? UIImage.FromBundle(_sp1.SpellImage) : null;
            imgSpell2.Image = _sp2 != null ? UIImage.FromBundle(_sp2.SpellImage) : null;
            imgSpell3.Image = _sp3 != null ? UIImage.FromBundle(_sp3.SpellImage) : null;
        }

        private void SetBossesImages()
        {
            if (TagObj == null)
            {
                return;
            }

            if (TagObj.Level < 3)
            {
                imgLevelUpCheering.Image = UIImage.FromBundle("BossUndefeated");
            }
            if (TagObj.Level >= 3 && TagObj.Level < 6)
            {
                imgLevelUpCheering.Image = UIImage.FromBundle("Boss1");
            }
            else if (TagObj.Level >= 6 && TagObj.Level < 9)
            {
                imgLevelUpCheering.Image = UIImage.FromBundle("Boss2");
            }
            else if (TagObj.Level >= 9)
            {
                imgLevelUpCheering.Image = UIImage.FromBundle("Boss3");
            }
            else
            {

            }
        }

        private void BtnPlus_TouchUpInside(object sender, EventArgs e)
        {
            PlusClicked?.Invoke(this, TagObj);
        }

        private void BtnMinus_TouchUpInside(object sender, EventArgs e)
        {
            MinusClicked?.Invoke(this, TagObj);
        }

        public Player TagObj { get; set; }

        private void SetUpClassesCircleImage()
        {
            imgProfile.Image = UIImage.FromBundle(TagObj.GameClass.Picture);

            if (TagObj.GameClass.Name == "Alchemist" && TagObj.Level == 4)
            {
                imgProfile.Image = UIImage.FromBundle("Beast_Alchemist");
            }
        }
    }
}
