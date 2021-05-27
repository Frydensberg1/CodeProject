using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.Enums;

namespace DrunkenWizard_API.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public BeastEnum SlayedBeast { get; set; }
        public bool BoostUsed { get; set; }
        public bool LocalPLayer { get; set; }
        public bool PremiumAccount { get; set; }
        public bool IsHost { get; set; }
        public int GameKey { get; set; }
        public int GameId { get; set; }
        public int GameClassId { get; set; }
        [JsonIgnore]
        public virtual Game Game { get; set; }

        public virtual GameClass GameClass { get; set; }
    }
}
