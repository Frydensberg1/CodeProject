using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_Android.ViewHolder
{
    class RulesSymbolViewHolder: RecyclerView.ViewHolder
    {
        public TextView Titel { get; private set; }
        public TextView Description { get; private set; }
        public RulesSymbolViewHolder(View itemView) : base(itemView)
        {
            Titel = itemView.FindViewById <TextView>(Resource.Id.TxtRulesTitle);
            Description = itemView.FindViewById<TextView>(Resource.Id.TxtRulesDescription);
        }

        public void SetupCell(FAQ item)
        {
            TagObj = item;
            Titel.Text = item.Titel;
            Description.Text = item.Description;
        }
        public FAQ TagObj { get; set; }
    }
}