using System;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_Android.ViewHolder
{
    class FragmentClassViewHolder : RecyclerView.ViewHolder
    {
        ImageView imgClass;
        TextView txtClass;
        TextView txtClassDescription;
        public EventHandler<GameClass> txtspellsCellClassClicked;
        TextView txtClassType;
        View frameClassType;
        LinearLayout linearaggressive;
        LinearLayout linearDefensive;
        LinearLayout linearEntertaining;
        LinearLayout linearSpeed;
        TextView txtpremium;
        private MorphAnimation morphClassType;
        TextView txtspellsCellClass;

        public FragmentClassViewHolder(View itemView) : base(itemView)
        {
            imgClass = itemView.FindViewById<ImageView>(Resource.Id.imgFragmentClass);
            txtClass = itemView.FindViewById<TextView>(Resource.Id.txtFragmentClass);
            txtClassDescription = itemView.FindViewById<TextView>(Resource.Id.txtClassDescription);
            txtClassType = (TextView)itemView.FindViewById(Resource.Id.txtType);
            txtspellsCellClass = itemView.FindViewById<TextView>(Resource.Id.txtspellsCellClass);
            txtClassType.Click += TxtClassType_Click;
            linearaggressive = itemView.FindViewById<LinearLayout>(Resource.Id.linearaggressive);
            linearDefensive = itemView.FindViewById<LinearLayout>(Resource.Id.linearDefensive);
            linearEntertaining = itemView.FindViewById<LinearLayout>(Resource.Id.linearEntertaining);
            linearSpeed = itemView.FindViewById<LinearLayout>(Resource.Id.linearSpeed);
            txtpremium = ItemView.FindViewById<TextView>(Resource.Id.txtpremium);
            frameClassType = itemView.FindViewById<View>(Resource.Id.frameClassType);
            RelativeLayout rtlclasstype = itemView.FindViewById<RelativeLayout>(Resource.Id.rtlclasstype);
            ViewGroup LinearClassType = (ViewGroup)itemView.FindViewById<ViewGroup>(Resource.Id.LinearClassType);
            morphClassType = new MorphAnimation(frameClassType, rtlclasstype, LinearClassType);
            txtspellsCellClass.Click += txtspellsCellClass_Click;
        }

        private void txtspellsCellClass_Click(object sender, EventArgs e)
        {
            txtspellsCellClassClicked?.Invoke(this, TagObj);
        }

        public void SetupCell(GameClass item)
        {
            TagObj = item;
            int resourceId = (int)typeof(Resource.Drawable).GetField(item.Picture).GetValue(null);
            imgClass.SetImageResource(resourceId);
            txtClass.Text = item.Name;
            txtClass.SetTextColor(Color.ParseColor(item.Color));
            txtClassDescription.Text = item.GameClassInfo;
            txtClassType.Text = item.ClassType;
            txtspellsCellClass.SetTextColor(Color.ParseColor(item.Color));
            if (item.PremiumClass)
            {
                txtpremium.Text = "Premium";
                txtpremium.SetTextColor(Color.ParseColor("#e5c100"));
            }
            else
            {
                txtpremium.Text = "Basic";
                txtpremium.SetTextColor(Color.White);
            }
           
            HandleClassType();
        }
        private void TxtClassType_Click(object sender, System.EventArgs e)
        {
            if (!morphClassType.isPressed)
            {
                morphClassType.morphIntoForm();
            }
            else
            {
                morphClassType.morphIntoButton();
            }
        }

        void HandleClassType() 
        {
            for (int i = 1; i <= 5; i++)
            {
                linearaggressive.GetChildAt(i).SetBackgroundColor(Color.Gray);
                linearDefensive.GetChildAt(i).SetBackgroundColor(Color.Gray);
                linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.Gray);
                linearSpeed.GetChildAt(i).SetBackgroundColor(Color.Gray);
            }
            for (int i = 1; i <= TagObj.Aggressive; i++)
            {
                if (TagObj.Name== "Disrupted Sorcerer")
                {
                    linearaggressive.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearaggressive.GetChildAt(i).SetBackgroundColor(Color.ParseColor(TagObj.Color));
                }
               
            }
            for (int i = 1; i <= TagObj.Defensive; i++)
            {
                if (TagObj.Name == "Disrupted Sorcerer")
                {
                    linearDefensive.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearDefensive.GetChildAt(i).SetBackgroundColor(Color.ParseColor(TagObj.Color));
                }
               
            }
            for (int i = 1; i <= TagObj.Entertaining; i++)
            {
                if (TagObj.Name == "Disrupted Sorcerer")
                {
                    linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.ParseColor(TagObj.Color));
                }
            }
              
            for (int i = 1; i <= TagObj.Speed; i++)
            {
                if (TagObj.Name == "Disrupted Sorcerer")
                {
                    linearSpeed.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearSpeed.GetChildAt(i).SetBackgroundColor(Color.ParseColor(TagObj.Color));
                }
                
            }
        }

        public GameClass TagObj { get; set; }

    }
}