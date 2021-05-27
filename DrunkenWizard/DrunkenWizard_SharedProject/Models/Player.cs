using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DrunkenWizard_SharedProject.Enums;
using Newtonsoft.Json;

namespace DrunkenWizard_SharedProject.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public GameClass GameClass { get; set; }
        public BeastEnum SlayedBeast { get; set; }
        public bool IsHost { get; set; }
        public bool PremiumAccount { get; set; }
        public bool LocalPLayer { get; set; }
        public bool BoostUsed { get; set; }
        public int GameId { get; set; }
        public int GameClassId { get; set; }
        public int GameKey { get; set; }
    }
}