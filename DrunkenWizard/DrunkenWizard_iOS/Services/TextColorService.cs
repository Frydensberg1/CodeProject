using System;
using CoreData;
using Foundation;
using UIKit;

namespace DrunkenWizard_iOS.Services
{
    public class TextColorService
    {
        public TextColorService()
        {
        }

        public NSMutableAttributedString GetColoredText(UIColor TextColor, string spelltype, string before = "", string after = "")
        {
            NSMutableAttributedString builder = new NSMutableAttributedString();

            String Multiple = " <Multiple> ";
            String Passive = " <Passive> ";
            String Reaction = " <Reaction> ";
            String First = " <First> ";
            String Not = " <Not> ";
            string Aoe = " <Aoe> ";

            if (!string.IsNullOrEmpty(before))
            {
                var beforeSpannable = new NSMutableAttributedString(before);
                beforeSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, TextColor, new NSRange(0, before.Length));
                builder.Append(beforeSpannable);
            }

            switch (spelltype)
            {
                case "Multiple":
                    var MultipleSpannable = new NSMutableAttributedString(Multiple);
                    MultipleSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, (UIColor.Red), new NSRange(0, Multiple.Length));
                    builder.Append(MultipleSpannable);
                    break;
                case "Passive":
                    var PassiveSpannable = new NSMutableAttributedString(Passive);
                    PassiveSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, (UIColor.Blue), new NSRange(0, Passive.Length));
                    builder.Append(PassiveSpannable);
                    break;
                case "Reaction":
                    var ReactionSpannable = new NSMutableAttributedString(Reaction);
                    ReactionSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, (UIColor.Green), new NSRange(0, Reaction.Length));
                    builder.Append(ReactionSpannable);
                    break;
                case "First":
                    var FirstSpannable = new NSMutableAttributedString(First);
                    FirstSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, (UIColor.Orange), new NSRange(0, First.Length));
                    builder.Append(FirstSpannable);
                    break;

                case "Not":
                    var NotSpannable = new NSMutableAttributedString(Not);
                    NotSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, UIColor.Orange, new NSRange(0, Not.Length));
                    builder.Append(NotSpannable);
                    break;
                case "Aoe":

                    var AoeSpannable = new NSMutableAttributedString(Aoe);
                    AoeSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, (UIColor.Purple), new NSRange(0, Aoe.Length));
                    builder.Append(AoeSpannable);
                    break;
            }

            if (!String.IsNullOrEmpty(after))
            {
                var AfterSpannable = new NSMutableAttributedString(after);
                AfterSpannable.AddAttribute(UIStringAttributeKey.ForegroundColor, (TextColor), new NSRange(0, after.Length));
                builder.Append(AfterSpannable);
            }

            //var i = text.IndexOf(textToFind);
            //var str = new NSMutableAttributedString(text);
            //str.AddAttribute(UIStringAttributeKey.ForegroundColor, UIColor.Red, new NSRange(i, textToFind.Length));

            return builder;
        }
    }
}
