using System.Collections.Generic;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.ViewModels
{
    public class CurrentGameViewModel
    {
        public CurrentGameViewModel()
        {

        }
        public List<Player> PlayerList { get; set; }
        public List<Player> PlayerListNewHost { get; set; }
        public Player SelectedPlayer { get; set; }
        public Game CurrentGame { get; set; }
        public bool ShowDracsoris { get; set; }
    }
}
