using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_Android.ViewHolders
{
    class DragonsViewHolder : RecyclerView.ViewHolder
    {
        ImageView imgdragon;
        TextView txtdragname;
        public EventHandler<Monster> CellClicked;
        public DragonsViewHolder(View itemView) : base(itemView)
        {
            imgdragon = ItemView.FindViewById<ImageView>(Resource.Id.imgdrag);
            txtdragname = ItemView.FindViewById<TextView>(Resource.Id.txtdrag);
            itemView.Click += ItemView_Click;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            CellClicked?.Invoke(this, TagObj);
        }

        public void SetupCell(Monster item)
        {
            TagObj = item;
            int resourceId = (int)typeof(Resource.Drawable).GetField(item.Picture).GetValue(null);
            imgdragon.SetImageResource(resourceId);
            txtdragname.Text = item.Name;
        }

        public Monster TagObj { get; set; }
    }
}