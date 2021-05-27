using System.Collections.Generic;

namespace DrunkenWizard_SharedProject.Models
{
    public class Game
    {
        public Game()
        {
            this.Players = new HashSet<Player>();
        }
        public string Id { get; set; }
        public int Key { get; set; }
        public int PlayerId { get; set; }
        public virtual ICollection<Player> Players { get; set; }


    }

   
}