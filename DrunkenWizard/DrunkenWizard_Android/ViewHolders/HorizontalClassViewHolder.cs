using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_Android.ViewHolder
{
    public class HorizontalClassViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }
        public EventHandler<GameClass> CellClicked;
        public EventHandler<View> CellClicked_CenterItem;
        public  HorizontalClassViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageViewHorizontal);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textHorizontal);
            itemView.Click += ItemView_Click;
            itemView.Click += ItemViewClicked_CenterItem;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            CellClicked?.Invoke(this, TagObj);
        }

        private void ItemViewClicked_CenterItem(object sender, EventArgs e)
        {
            CellClicked_CenterItem?.Invoke(this, ItemView);
        }
        public void SetupCell(GameClass item)
        {
            TagObj = item;
            int resourceId = (int)typeof(Resource.Drawable).GetField(item.Picture).GetValue(null);
            Image.SetImageResource(resourceId);
            Caption.Text = item.Name;
        }

        public GameClass TagObj { get; set; }
    }
}