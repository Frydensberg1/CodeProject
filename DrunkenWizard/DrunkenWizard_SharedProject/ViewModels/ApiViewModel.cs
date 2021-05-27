using System.Collections.Generic;
using DrunkenWizard_SharedProject.Models;

namespace TheGrandWizard.ViewModels
{
    public class ApiViewModel
    {   
        public ApiViewModel()
        {

        }
       public Player CurrentPlayer { get; set; }
       public List<Player> CurrentPlayers { get; set; }

    }
}