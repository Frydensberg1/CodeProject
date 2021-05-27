using DrunkenWizard_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrunkenWizard_API.DTO
{
    public class JoinPlayerDTO
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public BeastEnum SlayedBeast { get; set; }
        public bool IsHost { get; set; }
        public bool PremiumAccount { get; set; }
        public bool LocalPLayer { get; set; }
        public bool BoostUsed { get; set; }
        public int GameKey { get; set; }
        public string ClassName { get; set; }
    }
}
