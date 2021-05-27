using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Container;
using System.Linq;
using Android.Graphics;
using DrunkenWizard_Android.ViewModels;
using static Android.Widget.TextView;
using Android.Content.Res;
using System;

namespace DrunkenWizard_Android.Fragments.SpellsFragments
{
    class PyromancerFragment : SupportFragment
    {
        TextColorViewModel _tcVM = ServiceContainer.Resolve<TextColorViewModel>();
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        RelativeLayout LinearImageView;
        TextView txtLevel1_1;
        TextView txtLevel2_2;
        TextView txtLevel3_3;
        TextView txtLevel4_4;
        TextView txtLevel5_5;
        TextView txtLevel6_6;
        TextView txtLevel7_7;
        TextView txtLevel8_8;
        TextView txtLevel9_9;
        TextView txtLevel10_10;
        TextView txtSecondTextview1;
        TextView txtSecondTextview2;
        TextView txtSecondTextview3;
        TextView txtSecondTextview4;
        TextView txtSecondTextview5;
        TextView txtSecondTextview6;
        TextView txtSecondTextview7;
        TextView txtSecondTextview8;
        TextView txtSecondTextview9;
        TextView txtSecondTextview10;
        Button buttonSpell1;
        Button buttonSpell2;
        Button buttonSpell3;
        Button buttonSpell4;
        Button buttonSpell5;
        Button buttonSpell6;
        Button buttonSpell7;
        Button buttonSpell8;
        Button buttonSpell9;
        Button buttonSpell10;
        View Spell1Container;
        View Spell2Container;
        View Spell3Container;
        View Spell4Container;
        View Spell5Container;
        View Spell6Container;
        View Spell7Container;
        View Spell8Container;
        View Spell9Container;
        View Spell10Container;
        private MorphAnimation morphAnimationSpell1;
        private MorphAnimation morphAnimationSpell2;
        private MorphAnimation morphAnimationSpell3;
        private MorphAnimation morphAnimationSpell4;
        private MorphAnimation morphAnimationSpell5;
        private MorphAnimation morphAnimationSpell6;
        private MorphAnimation morphAnimationSpell7;
        private MorphAnimation morphAnimationSpell8;
        private MorphAnimation morphAnimationSpell9;
        private MorphAnimation morphAnimationSpell10;
        View view;
        GameClass TagObj;

        public PyromancerFragment(GameClass tagobj) 
        {
            TagObj = tagobj;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.RulesView, container, false);
            LinearImageView = view.FindViewById<RelativeLayout>(Resource.Id.RelativeImageView);
            txtLevel1_1 = view.FindViewById<TextView>(Resource.Id.txtLevel1Roll1);
            txtLevel2_2 = view.FindViewById<TextView>(Resource.Id.txtLevel2Roll2);
            txtLevel3_3 = view.FindViewById<TextView>(Resource.Id.txtLevel3Roll3);
            txtLevel4_4 = view.FindViewById<TextView>(Resource.Id.txtLevel4Roll4);
            txtLevel5_5 = view.FindViewById<TextView>(Resource.Id.txtLevel5Roll5);
            txtLevel6_6 = view.FindViewById<TextView>(Resource.Id.txtLevel6Roll6);
            txtLevel7_7 = view.FindViewById<TextView>(Resource.Id.txtLevel7Roll7);
            txtLevel8_8 = view.FindViewById<TextView>(Resource.Id.txtLevel8Roll8);
            txtLevel9_9 = view.FindViewById<TextView>(Resource.Id.txtLevel9Roll9);
            txtLevel10_10 = view.FindViewById<TextView>(Resource.Id.txtLevel10Roll10);

            txtSecondTextview1 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview1);
            txtSecondTextview2 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview2);
            txtSecondTextview3 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview3);
            txtSecondTextview4 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview4);
            txtSecondTextview5 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview5);
            txtSecondTextview6 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview6);
            txtSecondTextview7 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview7);
            txtSecondTextview8 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview8);
            txtSecondTextview9 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview9);
            txtSecondTextview10 = view.FindViewById<TextView>(Resource.Id.txtSecondTextview10);

            ImageView imgboss = view.FindViewById<ImageView>(Resource.Id.imgLevelUpCheering);

            buttonSpell1 = (Button)view.FindViewById(Resource.Id.Spell1_btn);
            buttonSpell1.Click += buttonSpell1_Click;
            Spell1Container = view.FindViewById<View>(Resource.Id.form_Spell1);
            ViewGroup Spell1View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell1_views);

            buttonSpell2 = (Button)view.FindViewById(Resource.Id.Spell2_btn);
            buttonSpell2.Click += ButtonSpell2_Click;
            Spell2Container = view.FindViewById<View>(Resource.Id.form_Spell2);
            ViewGroup Spell2View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell2_views);

            buttonSpell3 = (Button)view.FindViewById(Resource.Id.Spell3_btn);
            buttonSpell3.Click += ButtonSpell3_Click;
            Spell3Container = view.FindViewById<View>(Resource.Id.form_Spell3);
            ViewGroup Spell3View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell3_views);

            buttonSpell4 = (Button)view.FindViewById(Resource.Id.Spell4_btn);
            buttonSpell4.Click += ButtonSpell4_Click1;
            Spell4Container = view.FindViewById<View>(Resource.Id.form_Spell4);
            ViewGroup Spell4View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell4_views);

            buttonSpell5 = (Button)view.FindViewById(Resource.Id.Spell5_btn);
            buttonSpell5.Click += ButtonSpell5_Click;
            Spell5Container = view.FindViewById<View>(Resource.Id.form_Spell5);
            ViewGroup Spell5View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell5_views);

            buttonSpell6 = (Button)view.FindViewById(Resource.Id.Spell6_btn);
            buttonSpell6.Click += ButtonSpell6_Click;
            Spell6Container = view.FindViewById<View>(Resource.Id.form_Spell6);
            ViewGroup Spell6View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell6_views);

            buttonSpell7 = (Button)view.FindViewById(Resource.Id.Spell7_btn);
            buttonSpell7.Click += ButtonSpell7_Click;
            Spell7Container = view.FindViewById<View>(Resource.Id.form_Spell7);
            ViewGroup Spell7View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell7_views);

            buttonSpell8 = (Button)view.FindViewById(Resource.Id.Spell8_btn);
            buttonSpell8.Click += ButtonSpell8_Click;
            Spell8Container = view.FindViewById<View>(Resource.Id.form_Spell8);
            ViewGroup Spell8View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell8_views);

            buttonSpell9 = (Button)view.FindViewById(Resource.Id.Spell9_btn);
            buttonSpell9.Click += ButtonSpell9_Click;
            Spell9Container = view.FindViewById<View>(Resource.Id.form_Spell9);
            ViewGroup Spell9View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell9_views);

            buttonSpell10 = (Button)view.FindViewById(Resource.Id.Spell10_btn);
            buttonSpell10.Click += ButtonSpell10_Click;
            Spell10Container = view.FindViewById<View>(Resource.Id.form_Spell10);
            ViewGroup Spell10View = (ViewGroup)view.FindViewById<ViewGroup>(Resource.Id.Spell10_views);

            RelativeLayout rootViewSpell1 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell1);
            RelativeLayout rootViewSpell2 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell2);
            RelativeLayout rootViewSpell3 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell3);
            RelativeLayout rootViewSpell4 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell4);
            RelativeLayout rootViewSpell5 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell5);
            RelativeLayout rootViewSpell6 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell6);
            RelativeLayout rootViewSpell7 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell7);
            RelativeLayout rootViewSpell8 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell8);
            RelativeLayout rootViewSpell9 = view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell9);
            RelativeLayout rootViewSpell10 =view.FindViewById<RelativeLayout>(Resource.Id.rtlRootSpell10);

            morphAnimationSpell1 = new MorphAnimation(Spell1Container, rootViewSpell1, Spell1View);
            morphAnimationSpell2 = new MorphAnimation(Spell2Container, rootViewSpell2, Spell2View);
            morphAnimationSpell3 = new MorphAnimation(Spell3Container, rootViewSpell3, Spell3View);
            morphAnimationSpell4 = new MorphAnimation(Spell4Container, rootViewSpell4, Spell4View);
            morphAnimationSpell5 = new MorphAnimation(Spell5Container, rootViewSpell5, Spell5View);
            morphAnimationSpell6 = new MorphAnimation(Spell6Container, rootViewSpell6, Spell6View);
            morphAnimationSpell7 = new MorphAnimation(Spell7Container, rootViewSpell7, Spell7View);
            morphAnimationSpell8 = new MorphAnimation(Spell8Container, rootViewSpell8, Spell8View);
            morphAnimationSpell9 = new MorphAnimation(Spell9Container, rootViewSpell9, Spell9View);
            morphAnimationSpell10 = new MorphAnimation(Spell10Container, rootViewSpell10, Spell10View);

            if (TagObj.Name == "Dracsoris")
            {

                Setbackground(Color.ParseColor(TagObj.Color));
                Spell1Container.Visibility = ViewStates.Gone;
                Spell2Container.Visibility = ViewStates.Gone;
                Spell3Container.Visibility = ViewStates.Gone;
                Spell4Container.Visibility = ViewStates.Gone;

                var currentspells = TagObj.Spells.OrderBy(x => x.Level);
                SetTextButtonColorWhite(Color.White);
                SetTextColorSelectedColor(Color.White);
                var spell5Drac = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(0).Style, "Level 5. ", currentspells.ElementAtOrDefault(0).Name);
                buttonSpell5.SetText(spell5Drac, BufferType.Spannable);
                var spell7Drac = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(1).Style, "Level 7. ", currentspells.ElementAtOrDefault(1).Name);
                buttonSpell7.SetText(spell7Drac, BufferType.Spannable);
                var spell8Drac = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(2).Style, "Level 8. ", currentspells.ElementAtOrDefault(2).Name);
                buttonSpell8.SetText(spell8Drac, BufferType.Spannable);
                buttonSpell3.Text = "Level 3. Boss fighting ";
                buttonSpell6.Text = "Level 6. Boss Fighting ";
                buttonSpell9.Text = "Level 9. Boss fighting ";
                buttonSpell10.Text = "Level 10. Wizard!";
                txtLevel10_10.Text = "Congratz! You are now a Drunken Wizard!";
                txtLevel6_6.Text = "The boss is terrified of you, and you win the fight";
                txtLevel5_5.Text = currentspells.ElementAtOrDefault(0).Description;
                txtLevel9_9.Text = "The boss is terrified of you, and you win the fight";
                txtLevel7_7.Text = currentspells.ElementAtOrDefault(1).Description;
                txtLevel8_8.Text = currentspells.ElementAtOrDefault(2).Description;

                switch (_cgVM.SelectedPlayer.Level)
                {
                    case 5:
                        Spell5Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                        break;
                    case 6:
                        Spell6Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                        break;
                    case 7:
                        Spell7Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                        break;
                    case 8:
                        Spell8Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                        break;
                    case 9:
                        Spell9Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                        break;
                    case 10:
                        Spell10Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                        break;
                }
            }
            else
            {

                txtLevel3_3.Text = "You have to drink 1 shot to beat the boss.";
                txtLevel6_6.Text = "You have to drink 1 shot to beat the boss.";
                txtLevel9_9.Text = "You have to drink 1 shot to beat the boss.";
                buttonSpell3.Text = "Level 3. Boss fighting ";
                buttonSpell6.Text = "Level 6. Boss Fighting ";
                buttonSpell9.Text = "Level 9. Boss fighting ";
                buttonSpell10.Text = "Level 10. Wizard!";
                txtLevel10_10.Text = "Congratz! You are now a Drunken Wizard!";
                txtSecondTextview3.Text = "A new roll spell has been unlocked!";
                txtSecondTextview3.SetTextColor(Color.SlateGray);
                txtSecondTextview6.Text = "A new roll spell has been unlocked!";
                txtSecondTextview6.SetTextColor(Color.SlateGray);
                txtSecondTextview9.Text = "A new roll spell has been unlocked!";
                txtSecondTextview9.SetTextColor(Color.SlateGray);
                var currentspells = TagObj.Spells.OrderBy(x => x.Level);

                Setbackground(Color.ParseColor(TagObj.Color));
                SetTextButtonColorWhite(Color.White);
                SetTextColorSelectedColor(Color.White);
                var spell1 = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(0).Style, "Level 1. " + currentspells.ElementAtOrDefault(0).Name);
                buttonSpell1.SetText(spell1, BufferType.Spannable);
                txtLevel1_1.Text = currentspells.ElementAtOrDefault(0).Description;
                var spell2 = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(1).Style, "Level 2. " + currentspells.ElementAtOrDefault(1).Name);
                buttonSpell2.SetText(spell2, BufferType.Spannable);
                txtLevel2_2.Text = currentspells.ElementAtOrDefault(1).Description;
                var spell4 = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(2).Style, "Level 4. " + currentspells.ElementAtOrDefault(2).Name);
                buttonSpell4.SetText(spell4, BufferType.Spannable);
                txtLevel4_4.Text = currentspells.ElementAtOrDefault(2).Description;
                var spell5 = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(3).Style, "Level 5. " + currentspells.ElementAtOrDefault(3).Name);
                buttonSpell5.SetText(spell5, BufferType.Spannable);
                txtLevel5_5.Text = currentspells.ElementAtOrDefault(3).Description;
                var spell7 = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(4).Style, "Level 7. " + currentspells.ElementAtOrDefault(4).Name);
                buttonSpell7.SetText(spell7, BufferType.Spannable);
                txtLevel7_7.Text = currentspells.ElementAtOrDefault(4).Description;
                var spell8 = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(5).Style, "Level 8. " + currentspells.ElementAtOrDefault(5).Name);
                buttonSpell8.SetText(spell8, BufferType.Spannable);
                txtLevel8_8.Text = currentspells.ElementAtOrDefault(5).Description;

                if (TagObj.Name == "Cleric")
                {
                    SetTextButtonColorWhite(Color.Black);
                    SetTextColorSelectedColor(Color.Black);
                    var spell1Cleric = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(0).Style, "Level 1. " + currentspells.ElementAtOrDefault(0).Name);
                    buttonSpell1.SetText(spell1Cleric, BufferType.Spannable);
                    var spell2Cleric = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(1).Style, "Level 2. " + currentspells.ElementAtOrDefault(1).Name);
                    buttonSpell2.SetText(spell2Cleric, BufferType.Spannable);
                    var spell4Cleric = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(2).Style, "Level 4. " + currentspells.ElementAtOrDefault(2).Name);
                    buttonSpell4.SetText(spell4Cleric, BufferType.Spannable);
                    var spell5Cleric = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(3).Style, "Level 5. " + currentspells.ElementAtOrDefault(3).Name);
                    buttonSpell5.SetText(spell5Cleric, BufferType.Spannable);
                    var spell7Cleric = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(4).Style, "Level 7. " + currentspells.ElementAtOrDefault(4).Name);
                    buttonSpell7.SetText(spell7Cleric, BufferType.Spannable);
                    var FirstEffectCleric = _tcVM.GetColoredText(Color.Black, "Not", "", currentspells.ElementAtOrDefault(4).SecondStyle);
                    txtSecondTextview7.SetText(FirstEffectCleric, BufferType.Spannable);
                    var spell8Cleric = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(5).Style, "Level 8. " + currentspells.ElementAtOrDefault(5).Name);
                    buttonSpell8.SetText(spell8Cleric, BufferType.Spannable);
                }

                if (TagObj.Name =="Elementalist")
                {
                    SetTextButtonColorWhite(Color.Black);
                    SetTextColorSelectedColor(Color.Black);
                    var spell1Elementalist = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(0).Style, "Level 1. " + currentspells.ElementAtOrDefault(0).Name);
                    buttonSpell1.SetText(spell1Elementalist, BufferType.Spannable);
                    var spell2Elementalist = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(1).Style, "Level 2. " + currentspells.ElementAtOrDefault(1).Name);
                    buttonSpell2.SetText(spell2Elementalist, BufferType.Spannable);
                    var spell4Elementalist = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(2).Style, "Level 4. " + currentspells.ElementAtOrDefault(2).Name);
                    buttonSpell4.SetText(spell4Elementalist, BufferType.Spannable);
                    var spell5Elementalist = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(3).Style, "Level 5. " + currentspells.ElementAtOrDefault(3).Name);
                    buttonSpell5.SetText(spell5Elementalist, BufferType.Spannable);
                    var spell7Elementalist = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(4).Style, "Level 7. " + currentspells.ElementAtOrDefault(4).Name);
                    buttonSpell7.SetText(spell7Elementalist, BufferType.Spannable);                   
                    var spell8Elementalist = _tcVM.GetColoredText(Color.Black, currentspells.ElementAtOrDefault(5).Style, "Level 8. " + currentspells.ElementAtOrDefault(5).Name);
                    buttonSpell8.SetText(spell8Elementalist, BufferType.Spannable);
                    var FirstEffectElementalist = _tcVM.GetColoredText(Color.Black, "Not", "", currentspells.ElementAtOrDefault(5).SecondStyle);
                    txtSecondTextview8.SetText(FirstEffectElementalist, BufferType.Spannable);
                }

                if (TagObj.Name == "Shaman")
                {
                    var FirstEffectShanan = _tcVM.GetColoredText(Color.White, "Not", "", currentspells.ElementAtOrDefault(2).SecondStyle);
                    txtSecondTextview4.SetText(FirstEffectShanan, BufferType.Spannable);
                }
                if (TagObj.Name == "Warlock")
                {
                    var FirstEffectWarlock = _tcVM.GetColoredText(Color.White, "Not", "", currentspells.ElementAtOrDefault(2).SecondStyle);
                    txtSecondTextview4.SetText(FirstEffectWarlock, BufferType.Spannable);
                }

                if (TagObj.Name == "Disrupted Sorcerer")
                {
                    var spell9Disrupted = _tcVM.GetColoredText(Color.White, currentspells.ElementAtOrDefault(6).Style, "Level 9. " + currentspells.ElementAtOrDefault(6).Name);
                    buttonSpell10.SetText(spell9Disrupted, BufferType.Spannable);
                    var FirstEffectDisrupted = _tcVM.GetColoredText(Color.White, "Not", "", currentspells.ElementAtOrDefault(6).SecondStyle);
                    txtSecondTextview10.SetText(FirstEffectDisrupted, BufferType.Spannable);
                }

            }
            switch (_cgVM.SelectedPlayer.Level)
            {
                case 1:
                    Spell1Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 2:
                    Spell2Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 3:
                    Spell3Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 4:
                    Spell4Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 5:
                    Spell5Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 6:
                    Spell6Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 7:
                    Spell7Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 8:
                    Spell8Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 9:
                    Spell9Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
                case 10:
                    Spell10Container.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(TagObj.SelectedColor));
                    break;
            }

            return view;
        }

        public void Setbackground(Color backgroundColor)
        {
            Spell1Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell2Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell3Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell4Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell5Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell6Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell7Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell8Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell9Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
            Spell10Container.BackgroundTintList = ColorStateList.ValueOf(backgroundColor);
        }
        public void SetTextButtonColorWhite(Color classColor)
        {
            buttonSpell1.SetTextColor(classColor);
            buttonSpell2.SetTextColor(classColor);
            buttonSpell3.SetTextColor(classColor);
            buttonSpell4.SetTextColor(classColor);
            buttonSpell5.SetTextColor(classColor);
            buttonSpell6.SetTextColor(classColor);
            buttonSpell7.SetTextColor(classColor);
            buttonSpell8.SetTextColor(classColor);
            buttonSpell9.SetTextColor(classColor);
            buttonSpell10.SetTextColor(classColor);
        }
        public void SetTextColorSelectedColor(Color classColor)
        {
            txtLevel1_1.SetTextColor(classColor);
            txtLevel2_2.SetTextColor(classColor);
            txtLevel3_3.SetTextColor(classColor);
            txtLevel4_4.SetTextColor(classColor);
            txtLevel5_5.SetTextColor(classColor);
            txtLevel6_6.SetTextColor(classColor);
            txtLevel7_7.SetTextColor(classColor);
            txtLevel8_8.SetTextColor(classColor);
            txtLevel9_9.SetTextColor(classColor);
            txtLevel10_10.SetTextColor(classColor);
        }
        private void ButtonSpell10_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell10.isPressed)
            {
                morphAnimationSpell10.morphIntoForm();
            }
            else
            {
                morphAnimationSpell10.morphIntoButtonSpell10();
            }
        }
        private void ButtonSpell9_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell9.isPressed)
            {
                morphAnimationSpell9.morphIntoForm();
            }
            else
            {
                morphAnimationSpell9.morphIntoButtonSpell9();
            }
        }
        private void ButtonSpell8_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell8.isPressed)
            {
                morphAnimationSpell8.morphIntoForm();
            }
            else
            {
                morphAnimationSpell8.morphIntoButtonSpell8();
            }
        }
        private void ButtonSpell7_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell7.isPressed)
            {
                morphAnimationSpell7.morphIntoForm();
            }
            else
            {
                morphAnimationSpell7.morphIntoButtonSpell7();
            }
        }
        private void ButtonSpell6_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell6.isPressed)
            {
                morphAnimationSpell6.morphIntoForm();
            }
            else
            {
                morphAnimationSpell6.morphIntoButtonSpell6();
            }
        }
        private void ButtonSpell5_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell5.isPressed)
            {
                morphAnimationSpell5.morphIntoForm();
            }
            else
            {
                morphAnimationSpell5.morphIntoButtonSpell5();
            }
        }
        private void ButtonSpell4_Click1(object sender, EventArgs e)
        {
            if (!morphAnimationSpell4.isPressed)
            {
                morphAnimationSpell4.morphIntoForm();
            }
            else
            {
                morphAnimationSpell4.morphIntoButtonSpell4();
            }
        }
        private void ButtonSpell3_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell3.isPressed)
            {
                morphAnimationSpell3.morphIntoForm();
            }
            else
            {
                morphAnimationSpell3.morphIntoButtonSpell3();
            }
        }
        private void ButtonSpell2_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell2.isPressed)
            {
                morphAnimationSpell2.morphIntoForm();
            }
            else
            {
                morphAnimationSpell2.morphIntoButtonSpell2();
            }

        }
        private void buttonSpell1_Click(object sender, EventArgs e)
        {
            if (!morphAnimationSpell1.isPressed)
            {
                morphAnimationSpell1.morphIntoForm();
            }
            else
            {
                morphAnimationSpell1.morphIntoButton();
            }

        }

    }
}