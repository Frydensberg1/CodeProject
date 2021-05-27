using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DrunkenWizard_SharedProject.Models
{
    public  class GameClass
    {
        public GameClass()
        {
            this.Spells = new HashSet<Spell>();
            this.Players = new HashSet<Player>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int SpellId { get; set; }
        public string Color { get; set; }
        public string GameClassInfo { get; set; }
        public string SelectedColor { get; set; }
        public int Aggressive { get; set; }
        public int Defensive { get; set; }
        public int Entertaining { get; set; }
        public int Speed { get; set; }
        public bool PremiumClass { get; set; }
        public string ClassType { get; set; }
        public string RollEffect1 { get; set; }
        public string RollEffect2 { get; set; }
        public string RollEffect3 { get; set; }
        public string RollEffect4 { get; set; }
        public string RollEffect5 { get; set; }
        public string RollEffect6 { get; set; }
        public int PlayerId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Spell> Spells { get; set; }

        private static object thisLock = new object();

        public List<Spell> SetSpellList(Player player)
        {
            try
            {
                var ListOfImages = player.GameClass.Spells.Where(x => x.Style == "Passive" || x.Style == "Reaction").ToList().OrderBy(x => x.Level).ToList();

                lock (thisLock)
                {
                    foreach (var item in ListOfImages.ToList())
                    {
                        if (item.Style == "Passive")
                        {
                            if (player.Level < item.Level)
                            {
                                ListOfImages.Remove(item);
                            }
                        }
                        if (item.Style == "Reaction")
                        {
                            if (player.Level != item.Level)
                            {
                                ListOfImages.Remove(item);
                            }
                        }
                    }

                }
                return ListOfImages;
            }
            catch (System.Exception e)
            {
                var data = e;
                return null;
            }
        }


    }
}