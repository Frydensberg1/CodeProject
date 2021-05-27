using System;
using Android.Widget;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Graphics;
using System.Linq;
using System.Collections.Generic;
using DrunkenWizard_SharedProject.Webservice;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_Android.ViewModels;

namespace DrunkenWizard_Android.ViewHolder
{
    class CurrentGameViewHolder : RecyclerView.ViewHolder
    {
        PlayerService _PS = ServiceContainer.Resolve<PlayerService>();
        public ImageView CircleImage { get; private set; }
        public ImageView ImageSpell1 { get; private set; }
        public ImageView ImageSpell2 { get; private set; }
        public ImageView ImageSpell3 { get; private set; }
        public ImageView ImageRollingSpells { get; private set; }
        public ImageView btnPlus { get; private set; }
        public ImageView btnMinus { get; private set; }
        public TextView PlayerName { get; private set; }
        public ImageView imgBeastSlayed { get; private set; }
        public ImageView imgLevelCheering { get; private set; }
        public TextView Level { get; private set; }
        public FrameLayout plusClick;
        public FrameLayout minusCLick;
        public EventHandler<Player> MinusClicked;
        public EventHandler<Player> PlusClicked;
        public EventHandler<Player> BossClicked;
        public EventHandler<Player> RollSpellsClicked;
        public EventHandler<Player> DragonHeadClicked;
        //public EventHandler<Player> SpellImage1Clicked;
        //public EventHandler<Player> SpellImage2Clicked;
        //public EventHandler<Player> SpellImage3Clicked;
        public EventHandler<Player> MenuClicked;
        public EventHandler<Player> CircleImageClicked;
        AlertDialog SpellAlert;
        TextView txtmessage;
        TextView txtTitle;
        // Toast toast;
        LayoutInflater Toastinf;
        // View ToastView;
        ImageView ImgMenu;
        Spell sp1;
        Spell sp2;
        Spell sp3;

        public CurrentGameViewHolder(View itemView) : base(itemView)
        {
            CircleImage = itemView.FindViewById<ImageView>(Resource.Id.profile_image);
            Level = ItemView.FindViewById<TextView>(Resource.Id.level);
            PlayerName = ItemView.FindViewById<TextView>(Resource.Id.txtNamePlayer);
            ImageRollingSpells = itemView.FindViewById<ImageView>(Resource.Id.imgbtnRollingSpells);
            ImageRollingSpells.Click += ImageRollingSpells_Click;
            btnMinus = ItemView.FindViewById<ImageView>(Resource.Id.btnminus);
            btnMinus.Click += BtnMinus_Click;
            imgBeastSlayed = ItemView.FindViewById<ImageView>(Resource.Id.imgMagicBeast);
            btnPlus = ItemView.FindViewById<ImageView>(Resource.Id.btnplus);
            btnPlus.Click += BtnPlus_Click;
            imgLevelCheering = ItemView.FindViewById<ImageView>(Resource.Id.imgLevelUpCheering);
            ImageSpell1 = ItemView.FindViewById<ImageView>(Resource.Id.imgSpell1);
            ImageSpell2 = ItemView.FindViewById<ImageView>(Resource.Id.imgSpell2);
            ImageSpell3 = ItemView.FindViewById<ImageView>(Resource.Id.imgSpell3);
            ImgMenu = ItemView.FindViewById<ImageView>(Resource.Id.dice);
            ImgMenu.Click += ImgMenu_Click;
            imgLevelCheering.Click += ImgLevelCheering_Click;
            btnMinus.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);
            btnPlus.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);
            CircleImage.Click += CircleImage_Click;
            ImageSpell1.Click += ImageSpell1_Click;
            ImageSpell2.Click += ImageSpell2_Click;
            ImageSpell3.Click += ImageSpell3_Click;
            imgBeastSlayed.Click += ImgBeastSlayed_Click;

            //  toast = new Toast(ItemView.Context);
            //Toastinf = LayoutInflater.From(ItemView.Context);
            //ToastView = Toastinf.Inflate(Resource.Layout.TxtToast_SpellImage1, null);
            //txtmessage = ToastView.FindViewById<TextView>(Resource.Id.txtMessage);
            //txtTitle = ToastView.FindViewById<TextView>(Resource.Id.txtTitle);
            //toast.View = ToastView;
            //toast.Duration = ToastLength.Long;
            //toast.SetGravity(GravityFlags.Center, 0, 0);
            LayoutInflater liClass = LayoutInflater.From(ItemView.Context);
            View promptsView = liClass.Inflate(Resource.Layout.SpellImageLayout, null);
            SpellAlert = new AlertDialog.Builder(ItemView.Context, Resource.Style.AlertDialog_LevelUp).Create();
            SpellAlert.SetView(promptsView);
            txtmessage = promptsView.FindViewById<TextView>(Resource.Id.txtMessage);
            txtTitle = promptsView.FindViewById<TextView>(Resource.Id.txtTitle);
        }

        public Player TagObj { get; set; }
        public void SetupCell(Player item)
        {
            TagObj = item;
            PlayerName.Text = TagObj.Name;
            Level.Text = TagObj.Level.ToString();
            ImgMenu.SetColorFilter(Color.ParseColor(TagObj.GameClass.Color), PorterDuff.Mode.Multiply);
            ImageRollingSpells.SetColorFilter(Color.ParseColor(TagObj.GameClass.Color), PorterDuff.Mode.Multiply);
            HandleDragonImage();
            HandlePassiveReactionClickImage();
            SetUpClassesCircleImage();
            SetBossesImages();
        }

        private void ImageRollingSpells_Click(object sender, EventArgs e)
        {
            RollSpellsClicked?.Invoke(this, TagObj);
        }

        private void CircleImage_Click(object sender, EventArgs e)
        {
            CircleImageClicked?.Invoke(this, TagObj);
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            PlusClicked?.Invoke(this, TagObj);
        }
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            MinusClicked?.Invoke(this, TagObj);
        }
        private void ImgLevelCheering_Click(object sender, EventArgs e)
        {
            BossClicked?.Invoke(this, TagObj);
        }
        private void ImgBeastSlayed_Click(object sender, EventArgs e)
        {
            DragonHeadClicked?.Invoke(this, TagObj);
        }
        private void ImageSpell1_Click(object sender, EventArgs e)
        {
            //toast = new Toast(ItemView.Context);
            //toast.View = ToastView;
            //toast.Duration = ToastLength.Long;
            //toast.SetGravity(GravityFlags.Center, 0, 0);



            txtTitle.Text = sp1.Name;
            int resourceId = (int)typeof(Resource.Mipmap).GetField(sp1.SpellImage).GetValue(null);
            txtTitle.SetCompoundDrawablesWithIntrinsicBounds(resourceId, 0, 0, 0);
            if (TagObj.GameClass.Name == "Shaman")
            {
                HandleShamanTotems();
                //  toast.Show();
                SpellAlert.Show();
            }
            else
            {
                txtmessage.Text = sp1.Description;
                // toast.Show();
                SpellAlert.Show();
            }
        }
        private void ImageSpell2_Click(object sender, EventArgs e)
        {
            //toast = new Toast(ItemView.Context);
            //toast.View = ToastView;
            //toast.Duration = ToastLength.Long;
            //toast.SetGravity(GravityFlags.Center, 0, 0);
            txtmessage.Text = sp2.Description;
            int resourceId = (int)typeof(Resource.Mipmap).GetField(sp2.SpellImage).GetValue(null);
            txtTitle.SetCompoundDrawablesWithIntrinsicBounds(resourceId, 0, 0, 0);
            txtTitle.Text = sp2.Name;
            SpellAlert.Show();
        }
        private void ImageSpell3_Click(object sender, EventArgs e)
        {
            //toast = new Toast(ItemView.Context);
            //toast.View = ToastView;
            //toast.Duration = ToastLength.Long;
            //toast.SetGravity(GravityFlags.Center, 0, 0);
            txtmessage.Text = sp3.Description;
            int resourceId = (int)typeof(Resource.Mipmap).GetField(sp3.SpellImage).GetValue(null);
            txtTitle.SetCompoundDrawablesWithIntrinsicBounds(resourceId, 0, 0, 0);
            txtTitle.Text = sp3.Name;
            // toast.Show();
            SpellAlert.Show();
        }
        private void HandleShamanTotems()
        {
            switch (TagObj.Level)
            {
                case 1:
                    txtmessage.Text = "Give away 3 drinks as you want.";
                    break;
                case 2:
                    txtmessage.Text = "Block 2 drinks from your punishments.";
                    break;
                case 3:
                    txtmessage.Text = "Use Disrupted Sorcerer's spell 1.";
                    break;
                case 4:
                    txtmessage.Text = "Target a wizard to suffer the same as you. Can Only be casted one time.";
                    break;
                case 5:
                    txtmessage.Text = "Everybody Cheers with 2 zip from their wizard can.";
                    break;
                case 6:
                    txtmessage.Text = "Redirect spell used on another wizard than yourself. Can't be back to the attacker.";
                    break;
                case 7:
                    txtmessage.Text = "Players next to you, drinks 3 drinks.";
                    break;
                case 8:
                    txtmessage.Text = "Roll a die, if it's 5 or 6 you may cancel a spell used on you.(only 1 time).";
                    break;
                case 9:
                    txtmessage.Text = "drink half against the boss.";
                    break;
                case 10:
                    txtmessage.Text = "Target a wizard to take a shot.";
                    break;
                case 11:
                    txtmessage.Text = "You are a wizard!";
                    break;
                case 12:
                    txtmessage.Text = "You are a wizard!";
                    break;
                case 13:
                    txtmessage.Text = "You are a wizard!";
                    break;
            }
        }

        private void HandleDragonImage()
        {
            imgBeastSlayed.SetImageResource(Resource.Drawable.DragonHead);
            if (TagObj.SlayedBeast == DrunkenWizard_SharedProject.Enums.BeastEnum.none)
            {
                imgBeastSlayed.Visibility = ViewStates.Gone;
            }
            else
            {
                imgBeastSlayed.Visibility = ViewStates.Visible;
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
                imgBeastSlayed.Visibility = ViewStates.Gone;
            }
        }

        private void HandlePassiveReactionClickImage()
        {
            var spellList = TagObj.GameClass.SetSpellList(TagObj);
            sp1 = spellList.ElementAtOrDefault(0);
            sp2 = spellList.ElementAtOrDefault(1);
            sp3 = spellList.ElementAtOrDefault(2);
            if (sp1 != null)
            {
                int resourceId = (int)typeof(Resource.Mipmap).GetField(sp1.SpellImage).GetValue(null);
                if (resourceId != 0)
                {
                    ImageSpell1.SetImageResource(resourceId);
                    ImageSpell1.Visibility = ViewStates.Visible;
                }

            }
            else
                ImageSpell1.Visibility = ViewStates.Gone;

            if (sp2 != null)
            {
                int resourceId = (int)typeof(Resource.Mipmap).GetField(sp2.SpellImage).GetValue(null);
                if (resourceId != 0)
                {
                    ImageSpell2.SetImageResource(resourceId);
                    ImageSpell2.Visibility = ViewStates.Visible;
                }
            }
            else
                ImageSpell2.Visibility = ViewStates.Gone;

            if (sp3 != null)
            {
                if (sp3.SpellImage != null)
                {
                    int resourceId = (int)typeof(Resource.Mipmap).GetField(sp3.SpellImage).GetValue(null);
                    if (resourceId != 0)
                    {
                        ImageSpell3.SetImageResource(resourceId);
                        ImageSpell3.Visibility = ViewStates.Visible;
                    }
                }
            }
            else
                ImageSpell3.Visibility = ViewStates.Gone;
        }

        private void SetUpClassesCircleImage()
        {
            switch (TagObj.GameClass.Name)
            {
                case "Pyromancer":
                    CircleImage.SetImageResource(Resource.Drawable.PyromancerLogo_tsp);
                    break;
                case "Necromancer":
                    CircleImage.SetImageResource(Resource.Drawable.NecromancerLogo_tsp);
                    break;
                case "Druid":
                    CircleImage.SetImageResource(Resource.Drawable.DruidLogo_tsp);
                    break;
                case "Cleric":
                    CircleImage.SetImageResource(Resource.Drawable.ClericLogo_tsp);
                    break;
                case "Illusionist":
                    CircleImage.SetImageResource(Resource.Drawable.IllusionistLogo_tsp);
                    break;
                case "Warlock":
                    CircleImage.SetImageResource(Resource.Drawable.WarlockLogo_tsp);
                    break;
                case "Disrupted Sorcerer":
                    CircleImage.SetImageResource(Resource.Drawable.DistruptedSorcerer_tsp);
                    break;
                case "Time Mage":
                    CircleImage.SetImageResource(Resource.Drawable.TimeMage_tsp);
                    break;
                case "Dracsoris":
                    CircleImage.SetImageResource(Resource.Drawable.DragonBoss);
                    break;
                case "Shaman":
                    CircleImage.SetImageResource(Resource.Drawable.Shaman_tsp);
                    break;
                case "Alchemist":
                    CircleImage.SetImageResource(Resource.Drawable.Alchemist_tsp);
                    if (TagObj.GameClass.Name == "Alchemist" && TagObj.Level == 4)
                    {
                        CircleImage.SetImageResource(Resource.Drawable.Beast_Alchemist);
                    }
                    break;
                case "Witch":
                    CircleImage.SetImageResource(Resource.Drawable.Witch_tsp);
                    break;
                case "Elementalist":
                    CircleImage.SetImageResource(Resource.Drawable.Elementalist_tsp);
                    break;

                case "Summoner":
                    CircleImage.SetImageResource(Resource.Drawable.Summoner_tsp);
                    break;
            }
        }


        private void SetBossesImages()
        {
            if (TagObj != null)
            {
                if (TagObj.Level < 3)
                {
                    imgLevelCheering.SetImageResource(Resource.Drawable.BossUndefeated);
                }
                if (TagObj.Level >= 3 && TagObj.Level < 6)
                {
                    imgLevelCheering.SetImageResource(Resource.Drawable.Boss1);
                    //imgLevelCheering.Visibility = ViewStates.Visible;
                }
                else if (TagObj.Level >= 6 && TagObj.Level < 9)
                {
                    imgLevelCheering.SetImageResource(Resource.Drawable.Boss2);
                    // imgLevelCheering.Visibility = ViewStates.Visible;
                }
                else if (TagObj.Level >= 9)
                {
                    imgLevelCheering.SetImageResource(Resource.Drawable.Boss3);
                    // imgLevelCheering.Visibility = ViewStates.Visible;
                }
                else
                {
                    // imgLevelCheering.Visibility = ViewStates.Invisible;
                }
            }
        }
        private void ImgMenu_Click(object sender, EventArgs e)
        {
            MenuClicked?.Invoke(this, TagObj);
        }
    }
}