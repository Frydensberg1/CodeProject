using SupportFragment = Android.Support.V4.App.Fragment;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace DrunkenWizard_Android.Fragments
{
    class GamePlayFragment : SupportFragment
    {
        TextView txt1;
        TextView txt2;
        string GamePlay = "All players will have to choose a class and a name. Then all players can be seen in the list of players. In the middle of each player's column, you can see a logo of the selected class. By clicking on it, you are able to see its spells. Beneath the class logo, the rolling spell for the class can be seen by clicking on the dice logo. All Passive & Reaction spells can be seen in the left side as small icons, when the given level is reached. Furthermore the name and one's level can be seen. You can increase and decrease the players' level.";
        string gameplay2 = "Underneath the Class iage, you can see a menu icon. Here you can delete a player from the game, change a player's class (Only legally via spells), Use a boost that increases you a level( Only possible to use 1 time throughout the game) and fight against Mighty Magic Beasts. This option is not for the faint of heart. You have to do a hard quest, but will also recieve a good reward. If you have approached a monster, you must complete its quest. Otherwise you lose a level. If you use back button you won't level down, but it is only allowed if your spell specifies it.";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.GamePlayLayout, container, false);
            txt1 = view.FindViewById<TextView>(Resource.Id.Headline);
            txt2 = view.FindViewById<TextView>(Resource.Id.Headline2);
            txt1.Text = GamePlay;
            txt2.Text = gameplay2;

            return view;
        }
    }
}