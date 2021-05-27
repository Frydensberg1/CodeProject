using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.DTO
{
   public class JoinGameDTO
    {
        public int key { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string GameClassName { get; set; }
        public int Level { get; set; }
        public string picture { get; set; }
        public BeastEnum SlayedBeast { get; set; }
        public List<Spell> Spells { get; set; }
        public PlayerStateEnum PlayerState { get; set; }
        public int GameId { get; set; }
        public int GameClassId { get; set; }
        public bool IsHost { get; set; }
        public bool BoostUsed { get; set; }
    }
}