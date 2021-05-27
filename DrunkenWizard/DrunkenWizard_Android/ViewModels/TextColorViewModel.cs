using System;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;

namespace DrunkenWizard_Android.ViewModels
{
    public class TextColorViewModel
    {
        public TextColorViewModel()
        {
        }

        public SpannableStringBuilder classtextcolor(string ClassName)
        {
            SpannableStringBuilder spanbuilder = new SpannableStringBuilder();

            switch (ClassName)
            {
                case "Cleric":
                    SpannableString clericSpannable = new SpannableString("Cleric");
                    clericSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#FFD700")), 0, "Cleric".Length, 0);
                    spanbuilder.Append(clericSpannable);
                    break;

                case "Druid":
                    SpannableString druidSpannable = new SpannableString("Druid");
                    druidSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#80FF84")), 0, "Druid".Length, 0);
                    spanbuilder.Append(druidSpannable);

                    break;

                case "Warlock":
                    SpannableString warlockSpannable = new SpannableString("Warlock");
                    warlockSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#800000")), 0, "Warlock".Length, 0);
                    spanbuilder.Append(warlockSpannable);

                    break;

                case "Illusionist":
                    SpannableString illusionistSpannable = new SpannableString("Illusionist");
                    illusionistSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#4169E1")), 0, "Illusionist".Length, 0);
                    spanbuilder.Append(illusionistSpannable);

                    break;

                case "Necromancer":
                    SpannableString necromancerSpannable = new SpannableString("Necromancer");
                    necromancerSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#4B0082")), 0, "Necromancer".Length, 0);
                    spanbuilder.Append(necromancerSpannable);

                    break;

                case "Pyromancer":
                    SpannableString pyromancerSpannable = new SpannableString("Pyromancer");
                    pyromancerSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#FF4500")), 0, "Pyromancer".Length, 0);
                    spanbuilder.Append(pyromancerSpannable);

                    break;

                case "Disrupted Sorcerer":
                    SpannableString DisruptedSpannable = new SpannableString("Disrupted Sorcerer");
                    DisruptedSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#696969")), 0, "Disrupted Sorcerer".Length, 0);
                    spanbuilder.Append(DisruptedSpannable);

                    break;

                case "Time Mage":
                    SpannableString TimeMageSpannable = new SpannableString("Time Mage");
                    TimeMageSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#40E0D0")), 0, "Time Mage".Length, 0);
                    spanbuilder.Append(TimeMageSpannable);

                    break;

                case "Shaman":
                    SpannableString ShamanSpannable = new SpannableString("Shaman");
                    ShamanSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#008080")), 0, "Shaman".Length, 0);
                    spanbuilder.Append(ShamanSpannable);

                    break;

                case "Alchemist":
                    SpannableString AlchemistSpannable = new SpannableString("Alchemist");
                    AlchemistSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#FF05E1")), 0, "Alchemist".Length, 0);
                    spanbuilder.Append(AlchemistSpannable);

                    break;

                case "Witch":
                    SpannableString WitchSpannable = new SpannableString("Witch");
                    WitchSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#CCCC00")), 0, "Witch".Length, 0);
                    spanbuilder.Append(WitchSpannable);

                    break;

                case "Summoner":
                    SpannableString SummonerSpannable = new SpannableString("Summoner");
                    SummonerSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#D0021B")), 0, "Summoner".Length, 0);
                    spanbuilder.Append(SummonerSpannable);

                    break;

                case "Elementalist":
                    SpannableString ElementalistSpannable = new SpannableString("Elementalist");
                    ElementalistSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#FFFFF0")), 0, "Elementalist".Length, 0);
                    spanbuilder.Append(ElementalistSpannable);

                    break;
            }

            return spanbuilder;
        }

        public SpannableStringBuilder GetColoredText(Color TextColor, string spelltype, string before = "", string after = "")
        {
            SpannableStringBuilder builder = new SpannableStringBuilder();
            String Multiple = " <Multiple> ";
            String Passive = " <Passive> ";
            String Reaction = " <Reaction> ";
            String First = " <First> ";
            String Not = " <Not> ";
            string Aoe = " <Aoe> ";

            if (!String.IsNullOrEmpty(before))
            {
                SpannableString beforeSpannable = new SpannableString(before);
                beforeSpannable.SetSpan(new ForegroundColorSpan(TextColor), 0, before.Length, 0);
                builder.Append(beforeSpannable);
            }

            switch (spelltype)
            {
                case "Multiple":
                    SpannableString MultipleSpannable = new SpannableString(Multiple);
                    MultipleSpannable.SetSpan(new ForegroundColorSpan(Color.Red), 0, Multiple.Length, 0);
                    builder.Append(MultipleSpannable);
                    break;
                case "Passive":
                    SpannableString PassiveSpannable = new SpannableString(Passive);
                    PassiveSpannable.SetSpan(new ForegroundColorSpan(Color.Blue), 0, Passive.Length, 0);
                    builder.Append(PassiveSpannable);
                    break;
                case "Reaction":
                    SpannableString ReactionSpannable = new SpannableString(Reaction);
                    ReactionSpannable.SetSpan(new ForegroundColorSpan(Color.Green), 0, Reaction.Length, 0);
                    builder.Append(ReactionSpannable);
                    break;
                case "First":
                    SpannableString FirstSpannable = new SpannableString(First);
                    FirstSpannable.SetSpan(new ForegroundColorSpan(Color.Orange), 0, First.Length, 0);
                    builder.Append(FirstSpannable);
                    break;

                case "Not":
                    SpannableString NotSpannable = new SpannableString(Not);
                    NotSpannable.SetSpan(new ForegroundColorSpan(Color.Orange), 0, Not.Length, 0);
                    builder.Append(NotSpannable);
                    break;
                case "Aoe":

                    SpannableString AoeSpannable = new SpannableString(Aoe);
                    AoeSpannable.SetSpan(new ForegroundColorSpan(Color.Purple), 0, Aoe.Length, 0);
                    builder.Append(AoeSpannable);
                    break;
            }

            if (!String.IsNullOrEmpty(after))
            {
                SpannableString AfterSpannable = new SpannableString(after);
                AfterSpannable.SetSpan(new ForegroundColorSpan(TextColor), 0, after.Length, 0);
                builder.Append(AfterSpannable);
            }
            return builder;
        }
    }
}