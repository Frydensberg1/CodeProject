using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.ViewModels
{
   public class RulesViewModel
    {
      public  RulesViewModel()
        {
            List<FAQ> List = new List<FAQ>();
            List.Add(new FAQ { Titel = "What does it mean to be stunned?", Description = "Stunned/Frozen means you are able to roll, but not level up. Sleep or paralyzed means you are not able to either roll or level up." });
            List.Add(new FAQ { Titel = "Can i change my class?", Description = "Only if a spell gives you the permission." });
            List.Add(new FAQ { Titel = "What happens when i fight a boss?", Description = "You will get the shot and your fellow wizards will cheer for you, when you finish the fight/shot. Afterwards you will unlock a new rollingspell" });
            List.Add(new FAQ { Titel = "What is the dragon fighting?", Description = "When you are level 5 or over, you haev the possibility to fight against a random dragon, and you will recieve a gift if you finishes the quest. But will decrease a level if you dont." });
            List.Add(new FAQ { Titel = "Can i save my spells?", Description = "No, you have to use your spells right away if they are active. If you have a multiple spell you may use it twice during your current level." });
            FAQList = List;
        }
        public List<FAQ> FAQList { get; set; }       
    }
}