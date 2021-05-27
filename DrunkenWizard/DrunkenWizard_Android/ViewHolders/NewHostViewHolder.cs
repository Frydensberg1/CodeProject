using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_Android.ViewHolders
{
    public class NewHostViewHolder : RecyclerView.ViewHolder
    {
        public EventHandler<Player> CellClicked;
        TextView txtplayername;
        TextView txtlevel;
        ImageView imgclass;
        public NewHostViewHolder(View itemView) : base(itemView)
        {
            txtplayername = itemView.FindViewById<TextView>(Resource.Id.txtNamePlayerNewHost);
            txtlevel = itemView.FindViewById<TextView>(Resource.Id.newhostlevel);
            imgclass = itemView.FindViewById<ImageView>(Resource.Id.profile_imageNewHost);
            ItemView.Click += ItemView_Click;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            CellClicked?.Invoke(this, TagObj);
        }

        public void SetupCell(Player item)
        {
            TagObj = item;
            txtplayername.Text = item.Name;
            txtlevel.Text = item.Level.ToString();
            SetUpClassesCircleImage();
        }

        private void SetUpClassesCircleImage()
        {
            switch (TagObj.GameClass.Name)
            {
                case "Pyromancer":
                    imgclass.SetImageResource(Resource.Drawable.PyromancerLogo_tsp);
                    break;
                case "Necromancer":
                    imgclass.SetImageResource(Resource.Drawable.NecromancerLogo_tsp);
                    break;
                case "Druid":
                    imgclass.SetImageResource(Resource.Drawable.DruidLogo_tsp);
                    break;
                case "Cleric":
                    imgclass.SetImageResource(Resource.Drawable.ClericLogo_tsp);
                    break;
                case "Illusionist":
                    imgclass.SetImageResource(Resource.Drawable.IllusionistLogo_tsp);
                    break;
                case "Warlock":
                    imgclass.SetImageResource(Resource.Drawable.WarlockLogo_tsp);
                    break;
                case "Disrupted Sorcerer":
                    imgclass.SetImageResource(Resource.Drawable.DistruptedSorcerer_tsp);
                    break;
                case "Time Mage":
                    imgclass.SetImageResource(Resource.Drawable.TimeMage_tsp);
                    break;
                case "Dracsoris":
                    imgclass.SetImageResource(Resource.Drawable.DragonBoss);
                    break;
                case "Shaman":
                    imgclass.SetImageResource(Resource.Drawable.Shaman_tsp);
                    break;
                case "Alchemist":
                    imgclass.SetImageResource(Resource.Drawable.Alchemist_tsp);
                    if (TagObj.GameClass.Name == "Alchemist" && TagObj.Level == 4)
                    {
                        imgclass.SetImageResource(Resource.Drawable.Beast_Alchemist);
                    }
                    break;
                case "Witch":
                    imgclass.SetImageResource(Resource.Drawable.Witch_tsp);
                    break;
                case "Elementalist":
                    imgclass.SetImageResource(Resource.Drawable.Elementalist_tsp);
                    break;

                case "Summoner":
                    imgclass.SetImageResource(Resource.Drawable.Summoner_tsp);
                    break;
            }
        }
        public Player TagObj { get; set; }
    }
}