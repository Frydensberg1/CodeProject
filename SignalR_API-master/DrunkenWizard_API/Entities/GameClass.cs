
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrunkenWizard_API.Entities
{
    public class GameClass
    {
        public GameClass()
        {
            this.Spells = new HashSet<Spell>();
            this.Players = new HashSet<Player>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        //public int SpellId { get; set; }
        //public int PlayerId { get; set; }
        public string Picture { get; set; }
        public string Color { get; set; }
        public bool PremiumClass { get; set; }
        public string ClassType { get; set; }
        public string SelectedColor { get; set; }
        public string RollEffect1 { get; set; }
        public string RollEffect2 { get; set; }
        public string RollEffect3 { get; set; }
        public string RollEffect4 { get; set; }
        public string RollEffect5 { get; set; }
        public string RollEffect6 { get; set; }

        public virtual ICollection<Spell> Spells { get; set; }
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
    }
}
