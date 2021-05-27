using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Enums;

namespace DrunkenWizard_API.DTO
{
    public class JoinGameDTO
    {
        public int key { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string picture { get; set; }
        public string ClassName { get; set; }
        public BeastEnum SlayedBeast { get; set; }
        public List<Spell> Spells { get; set; }
        public int GameId { get; set; }
        public int ClassId { get; set; }
        public bool BoostUsed { get; set; }
        public bool IsHost { get; set; }
    }
}
