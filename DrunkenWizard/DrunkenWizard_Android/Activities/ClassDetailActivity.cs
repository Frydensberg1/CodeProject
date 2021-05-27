using System;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android
{
    [Activity(Label = "ClassDetailActivity")]
    public class ClassDetailActivity : AppCompatActivity
    {
        RecyclerView rcvSpells;
        ClassDetailAdapter adapter;
        private MorphAnimation morphRollSpells;
        RelativeLayout rootview;
        ViewGroup cardView;
        LinearLayout rollSpellsLinear;
        Button btnRollingSpells;
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        TextView RollSpell1;
        TextView RollSpell2;
        TextView RollSpell3;
        TextView RollSpell4;
        TextView RollSpell6;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ClassDetailLayout);
            rcvSpells = FindViewById<RecyclerView>(Resource.Id.rcvSpells);
            LinearLayoutManager llm = new LinearLayoutManager(this);
            rcvSpells.SetLayoutManager(llm);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rcvSpells.Context, DividerItemDecoration.Vertical);
            rcvSpells.AddItemDecoration(dividerItemDecoration);
            adapter = new ClassDetailAdapter(this);
            rootview = FindViewById<RelativeLayout>(Resource.Id.rtlRollSpells);
            cardView = (ViewGroup) FindViewById<ViewGroup>(Resource.Id.formrollspells);
            rollSpellsLinear = FindViewById<LinearLayout>(Resource.Id.rollSpells);
            btnRollingSpells =(Button) FindViewById<Button>(Resource.Id.Roll_Spellsbtn);
            btnRollingSpells.SetBackgroundColor(Color.ParseColor(_cVM.SelectedClass.Color));
            btnRollingSpells.Click += BtnRollingSpells_Click;
            morphRollSpells = new MorphAnimation(cardView, rootview, rollSpellsLinear);
            RollSpell1 = FindViewById<TextView>(Resource.Id.Roll1);
            RollSpell2 = FindViewById<TextView>(Resource.Id.Roll2);
            RollSpell3 = FindViewById<TextView>(Resource.Id.Roll3);
            RollSpell4 = FindViewById<TextView>(Resource.Id.Roll4);
            RollSpell6 = FindViewById<TextView>(Resource.Id.Roll6);
            cardView.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor(_cVM.SelectedClass.Color));
            RollSpell1.Text = "Roll 1. " + _cVM.SelectedClass.RollEffect1;
            RollSpell2.Text = "Roll 2. " + _cVM.SelectedClass.RollEffect2;
            RollSpell3.Text = "Roll 3. " + _cVM.SelectedClass.RollEffect3;
            RollSpell4.Text = "Roll 4. " + _cVM.SelectedClass.RollEffect4;
            RollSpell6.Text = "Roll 6. " + _cVM.SelectedClass.RollEffect6;

            if (_cVM.SelectedClass.Name == "Cleric" || _cVM.SelectedClass.Name == "Elementalist")
            {
                RollSpell1.SetTextColor(Color.Black);
                RollSpell2.SetTextColor(Color.Black);
                RollSpell3.SetTextColor(Color.Black);
                RollSpell4.SetTextColor(Color.Black);
                RollSpell6.SetTextColor(Color.Black);
                btnRollingSpells.SetTextColor(Color.Black);
            }

            SetupToolbar();
            rcvSpells.SetAdapter(adapter);
        }

        private void SetupToolbar()
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarSpell);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.Title = _cVM.SelectedClass.Name + " Spells";
                toolbar.SetTitleTextColor(Color.ParseColor(_cVM.SelectedClass.Color));
                toolbar.SetBackgroundColor(Color.ParseColor("#02000d"));
                toolbar.NavigationClick += (sender, args) => { Finish(); };
            }
        }

        private void BtnRollingSpells_Click(object sender, EventArgs e)
        {
            if (!morphRollSpells.isPressed)
            {
                morphRollSpells.morphIntoForm();
            }
            else
            {
                morphRollSpells.morphIntoButtonRollSpells();
            }
        }
    }
}