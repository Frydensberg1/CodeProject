using System;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Text;
using Android.Text.Style;
using Android.Graphics;
using static Android.Widget.TextView;

namespace DrunkenWizard_Android.Fragments
{
    class Class_SpellsFragment : SupportFragment
    {
        TextView txt1;
        TextView txt2;
        string ClassAndSpells = "Each of the classes has a spell for each level. Some spells have categories. There is ";
        string MultipleExplained = "Which means you can use this spell twice during your current level. ";
        string PassiveExplained = "Which means that it applies throughout the game. ";
        string FirstExplained = "Which means that if you are the first person to reach that level a speciel effect will take place. ";
        string ReactionExplained = "Which means that it only applies while you are at that level. ";
        string text2 = "There are different classes, which all have different spells. The various spells and their use are described under the Class tab where you can see all the classes as well.";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Class_SpellsFragmentLayout, container, false);
            txt1 = view.FindViewById<TextView>(Resource.Id.Headline);
            txt2 = view.FindViewById<TextView>(Resource.Id.Headline2);
            SpannableStringBuilder builder = new SpannableStringBuilder();
            String Multiple = "<Multiple> ";
            String Passive = "<Passive> ";
            String Reaction = "<Reaction> ";
            String First = "<First> ";


            SpannableString classspellSpannable = new SpannableString(ClassAndSpells);
            classspellSpannable.SetSpan(new ForegroundColorSpan(Color.White), 0, ClassAndSpells.Length, 0);
            builder.Append(classspellSpannable);

            SpannableString MultipleSpannable = new SpannableString(Multiple);
            MultipleSpannable.SetSpan(new ForegroundColorSpan(Color.Red), 0, Multiple.Length, 0);
            builder.Append(MultipleSpannable);

            SpannableString MultipleExplainedSpannable = new SpannableString(MultipleExplained);
            MultipleExplainedSpannable.SetSpan(new ForegroundColorSpan(Color.White), 0, MultipleExplained.Length, 0);
            builder.Append(MultipleExplainedSpannable);


            SpannableString PassiveSpannable = new SpannableString(Passive);
            PassiveSpannable.SetSpan(new ForegroundColorSpan(Color.Blue), 0, Passive.Length, 0);
            builder.Append(PassiveSpannable);

            SpannableString PassiveExplainedSpannable = new SpannableString(PassiveExplained);
            PassiveExplainedSpannable.SetSpan(new ForegroundColorSpan(Color.White), 0, PassiveExplained.Length, 0);
            builder.Append(PassiveExplainedSpannable);

            SpannableString ReactionSpannable = new SpannableString(Reaction);
            ReactionSpannable.SetSpan(new ForegroundColorSpan(Color.Green), 0, Reaction.Length, 0);
            builder.Append(ReactionSpannable);

            SpannableString ReactionExplainedSpannable = new SpannableString(ReactionExplained);
            ReactionExplainedSpannable.SetSpan(new ForegroundColorSpan(Color.White), 0, ReactionExplained.Length, 0);
            builder.Append(ReactionExplainedSpannable);

            SpannableString FirstSpannable = new SpannableString(First);
            FirstSpannable.SetSpan(new ForegroundColorSpan(Color.Orange), 0, First.Length, 0);
            builder.Append(FirstSpannable);


            SpannableString FirstExplainedSpannable = new SpannableString(FirstExplained);
            FirstExplainedSpannable.SetSpan(new ForegroundColorSpan(Color.White), 0, FirstExplained.Length, 0);
            builder.Append(FirstExplainedSpannable);

            txt1.SetText(builder, BufferType.Spannable);
            txt2.Text = text2;
            return view;
        }
    }
}