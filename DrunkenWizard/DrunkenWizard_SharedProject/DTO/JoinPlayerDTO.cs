using DrunkenWizard_SharedProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrunkenWizard_SharedProject.DTO
{
  public  class JoinPlayerDTO
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
