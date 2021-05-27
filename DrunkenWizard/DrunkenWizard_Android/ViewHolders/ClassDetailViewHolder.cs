using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_Android.ViewModels;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using static Android.Widget.TextView;

namespace DrunkenWizard_Android.ViewHolder
{
    class ClassDetailViewHolder : RecyclerView.ViewHolder
    {
        TextColorViewModel _tcVM = ServiceContainer.Resolve<TextColorViewModel>();
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        TextView SpellName;
        TextView Level;
        TextView LevelText;
        TextView EffectSpell;
        TextView EffectSecondspell;

        public ClassDetailViewHolder(View itemView) : base(itemView)
        {
            SpellName = ItemView.FindViewById<TextView>(Resource.Id.textviewSpellName);
            Level = ItemView.FindViewById<TextView>(Resource.Id.txtLevelspell);
            LevelText = ItemView.FindViewById<TextView>(Resource.Id.textViewlevel);
            EffectSpell = ItemView.FindViewById<TextView>(Resource.Id.textViewSpellEffect);
            EffectSecondspell = ItemView.FindViewById<TextView>(Resource.Id.textViewSpellEffectSecond);
        }

        public void SetupCell(Spell item)
        {
            TagObj = item;
            var spell1 = _tcVM.GetColoredText(Color.ParseColor(_cVM.SelectedClass.Color), item.Style, item.Name);
            SpellName.SetText(spell1, BufferType.Spannable);
            var SecondStyle = _tcVM.GetColoredText(Color.White, "Not", "", item.SecondStyle);
            EffectSecondspell.SetText(SecondStyle, BufferType.Spannable);
            Level.Text = item.Level.ToString() + ". ";
            Level.SetTextColor(Color.ParseColor(_cVM.SelectedClass.Color));
            EffectSpell.Text = item.Description;
            LevelText.SetTextColor(Color.ParseColor(_cVM.SelectedClass.Color));

            if (item.SecondStyle != null)
            {
                EffectSecondspell.Visibility = ViewStates.Visible;
            }
            else
            {
                EffectSecondspell.Visibility = ViewStates.Gone;
            }
        }
        public Spell TagObj { get; set; }
    }
}