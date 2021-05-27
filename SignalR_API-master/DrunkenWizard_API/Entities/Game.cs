using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrunkenWizard_API.Entities
{
    public class Game
    {
        public Game()
        {
            this.Players = new HashSet<Player>();
        }
        public int Id { get; set; }
        public int Key { get; set; }
        public int PlayerId { get; set; }
       // [Json]
        public virtual ICollection<Player> Players { get; set; }

    }
}
