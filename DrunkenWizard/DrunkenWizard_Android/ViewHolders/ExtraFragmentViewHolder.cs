using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_Android.ViewHolder
{
    public  class ExtraFragmentViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }
 
        public ExtraFragmentViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);         
        }

        public void SetupCell(GameClass item)
        {
            TagObj = item;
            int resourceId = (int)typeof(Resource.Mipmap).GetField(item.Picture).GetValue(null);
            Image.SetImageResource(resourceId);
            Caption.Text = item.Name;
        }
        public GameClass TagObj { get; set; }
    }
}