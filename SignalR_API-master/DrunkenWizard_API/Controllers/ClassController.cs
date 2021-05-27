using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Repos;

namespace DrunkenWizard_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpGet]
        [Route("addclassList")]
        public string AddClassList()
        {
            try
            {
                
                  List<GameClass> classes = new List<GameClass>();

                classes.Add(new GameClass { Picture = "DruidLogo_tsp", Name = "Druid", Color = "#32CD32", ClassType = "Entertaining", PremiumClass = false, SelectedColor = "#80FF84", RollEffect1 = "Target wizard can't level up this round", RollEffect2 = "Wizard higher level than u drinks 3 drinks.", RollEffect3 = "If you are lowest level, Increase a level. Else reroll.", RollEffect4 = "Split 10 drinks out on wizards", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "ClericLogo_tsp", Name = "Cleric", Color = "#FFD700", PremiumClass = false, SelectedColor = "#f1f6a3", ClassType = "Defensive", RollEffect1 = "You are immune for target spells this round", RollEffect2 = "Stun a player for 1 round", RollEffect3 = "Increase a wizard, decrease another(can't be you).", RollEffect4 = "Silence up to 3 players for their next roll.", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "IllusionistLogo_tsp", Name = "Illusionist", Color = "#4169E1", PremiumClass = false, SelectedColor = "#80D7FF", ClassType = "Entertaining", RollEffect1 = "The next players roll, counts for you as well.", RollEffect2 = "Give away 2 drinks to 3 players", RollEffect3 = "Last wizard to say your name sleeps for 2 round.Only if more than 2 players", RollEffect4 = "Target wizard drinks 7 drinks", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "PyromancerLogo_tsp", Name = "Pyromancer", Color = "#FF4500", PremiumClass = true, SelectedColor = "#FF8880", ClassType = "Aggressive", RollEffect1 = "Target wizard drinks 3 drinks", RollEffect2 = "Reroll", RollEffect3 = "Target wizard drinks 5 drinks", RollEffect4 = "Use a level 7 spell from any class once", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "NecromancerLogo_tsp", Name = "Necromancer", Color = "#4B0082", SelectedColor = "#8093FF", PremiumClass = true, ClassType = "Aggressive", RollEffect1 = "You drink 2 drinks, target wizard drinks 4 drinks.", RollEffect2 = "Use spell 1 once", RollEffect3 = "Every wizards but necromancers sleeps for 1 rounds", RollEffect4 = "Do a shot and decrease a wizard a level (Optional).", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "WarlockLogo_tsp", Name = "Warlock", Color = "#800000", SelectedColor = "#b25959", PremiumClass = true, ClassType = "Mixed", RollEffect1 = "All other wizards drink a drink", RollEffect2 = "Switch another players class.", RollEffect3 = "All others drinks 2 drinks, reroll", RollEffect4 = "Level up", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "DistruptedSorcerer_tsp", Name = "Disrupted Sorcerer", Color = "#696969", SelectedColor = "#7295A6", PremiumClass = true, ClassType = "Mixed",RollEffect1 = "Roll a die, give target wizard the amount as drinks.", RollEffect2 = "Use the same effect of a target wizards next roll", RollEffect3 = "Say a word, then clockwise players rime, loser decreases a level.", RollEffect4 = "Use time mage lvl 4 spell", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "TimeMage_tsp", Name = "Time Mage", Color = "#40E0D0", SelectedColor = "#86f0e5", PremiumClass = true, ClassType = "Fast", RollEffect1 = "Reroll and drink 2 drinks", RollEffect2 = "Change your class, if you want.", RollEffect3 = "Reroll, only 6 is valid", RollEffect4 = "Give away a shot", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "Shaman_tsp", Name = "Shaman", Color = "#008080", SelectedColor = "#6cbfbf", PremiumClass = true, ClassType = "Mixed", RollEffect1 = "Use your totem's effect", RollEffect2 = "Players next to you drink 2 drinks", RollEffect3 = "All other wizards who hasnt killed a dragon drinks 3 drinks", RollEffect4 = "Reroll", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "Alchemist_tsp", Name = "Alchemist", Color = "#FF05E1", SelectedColor = "#f688e9", PremiumClass = true, ClassType = "Entertaining", RollEffect1 = "Drink 2 drinks, and Reroll", RollEffect2 = "Make a player sleep for 1 round", RollEffect3 = "Immune for rolling spells this turn", RollEffect4 = "Cast you spell lvl 8 without participating", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "Witch_tsp", Name = "Witch", Color = "#CCCC00", SelectedColor = "#e5f27b", PremiumClass = true, ClassType = "Aggressive",RollEffect1 = "Use your Corrupt Spell", RollEffect2 = "Clerics, druids, illusionists and pyromancers drink 2 drinks", RollEffect3 = "Immune for drinking punishments this turn", RollEffect4 = "All wizards but you drink 4 drinks", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "Elementalist_tsp", Name = "Elementalist", Color = "#FFFFF0", PremiumClass = true, ClassType = "Mixed", SelectedColor = "#e7e3e3", RollEffect1 = "Target wizard can't level up this round", RollEffect2 = "Reroll but only 6 is valid.", RollEffect3 = "Give away half of your level in drinks to 2 wizards", RollEffect4 = "Use spell 5", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "Summoner_tsp", Name = "Summoner", Color = "#D0021B", SelectedColor = "#F1574E", PremiumClass = true, ClassType = "Mixed", RollEffect1 = "All wizards drink 2 drinks, including you.", RollEffect2 = "Use Summon Inferno (Spell 2)", RollEffect3 = "Use T-rex Transformation untill the targeted wizards turn, and reroll", RollEffect4 = "If targeted wizard rolls 5 or 6 you level up and he dismisses his roll", RollEffect5 = "", RollEffect6 = "Level up!" });
                classes.Add(new GameClass { Picture = "DragonBoss", Name = "Dracsoris", Color = "#8B0000", SelectedColor = "#FF80AA", PremiumClass = false, RollEffect1 = "Reroll", ClassType = "MONSTER", RollEffect2 = "You are immune this turn", RollEffect3 = "Every other wizard roll a die, highest roll drinks the amount he rolled", RollEffect4 = "Level up!", RollEffect5 = "", RollEffect6 = "Level up!" });

                using (var context = new Repository())
                {
                    foreach (var item in classes)
                    {
                        context.GameClass.Add(item);
                    }

                    context.SaveChanges();
                    return "Classes added";
                }
            }
            catch (Exception e)
            {
                string ee = e.ToString();
                return ee;
            }
        }



        [HttpGet]
        [Route("test")]
        public ActionResult<string> test()
        {
            return "Nemt";
        }




        [HttpGet]
        [Route("testlist")]
        public ActionResult<List<Player>> GetClass()
        {
            using (var context = new Repository())
            {
                var data = context.Player.ToList();
                return data;
            }
        }

        [HttpGet]
        [Route("GetClass/{ClassId}")]
        public ActionResult<GameClass> GetClass(int ClassId)
        {
            using (var context = new Repository())
            {
                var data = context.GameClass.FirstOrDefault(x => x.Id == ClassId);
                return data;
            }
        }

        [HttpGet]
        [Route("DeleteSpamClasses")]
        public string DeleteSpamClasses()
        {
            try
            {
                using (var context = new Repository())
                {
                    var data = context.GameClass.ToList();
                    foreach (var item in data)
                    {
                        if (item.Id > 14)
                        {
                            context.GameClass.Remove(item);
                        }
                       
                    }
                    context.SaveChanges();
                    return "Classes deleted";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }



        [HttpGet]
        [Route("Delete")]
        public String Delete()
        {
            try
            {
                using (var context = new Repository())
                {
                    var data = context.GameClass.ToList();
                    foreach (var item in data)
                    {
                        context.GameClass.Remove(item);
                    }
                    context.SaveChanges();
                    return "Classes deleted";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}