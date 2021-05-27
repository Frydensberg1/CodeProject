using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrunkenWizard_SharedProject.Models
{
   public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string Style { get; set; }
        public string SpellImage { get; set; }
        public string SecondStyle { get; set; }
        public int GameClassId { get; set; }
        public string GameClassName { get; set; }
        public virtual GameClass GameClass { get; set; }
    }
}