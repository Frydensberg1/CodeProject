using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrunkenWizard_API.Repos;
using DrunkenWizard_API.Entities;

namespace DrunkenWizard_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : Controller
    {
        [HttpGet]
        [Route("AddSpells")]
        public string AddSpells()
        {
            try
            {
                int DruidID = 1;
                int ClericID = 2;
                int IllusionistID = 3;
                int PyromancerID = 4;
                int NecromancerID = 5;
                int WarlockID = 6;
                int DisruptedSorcerer = 7;
                int TimeMage = 8;
                int ShamanID = 9;
                int AlchemistID = 10;
                int WitchID = 11;
                int ElementalistID = 12;
                int SummonerID = 13;
                int DracsorisID = 14;
                string Reaction = "Reaction";
                string Passive = "Passive";
                string Multiple = "Multiple";
                string First = "First";

                List<Spell> Spells = new List<Spell>();

                Spells.Add(new Spell { GameClassName = "Necromancer", Name = "Sickened", Level = 1, Style = Multiple, Description = "Target wizard drinks a shot, if he rolls 4 on his next roll.", GameClassId = NecromancerID });
                Spells.Add(new Spell { GameClassName = "Necromancer", Name = "Shun the sceptic", Level = 2, Style = Passive, Description = "When you level up, each wizard lower level than you takes 2 drinks.", SpellImage = "NecromancerLevel2", GameClassId = NecromancerID });
                Spells.Add(new Spell { GameClassName = "Necromancer", Name = "Death ripple", Level = 4, Style = "", Description = "Every other classes than necromancer sleeps for 2 rounds.", GameClassId = NecromancerID });
                Spells.Add(new Spell { GameClassName = "Necromancer", Name = "Curse", Level = 5, Style = Reaction, Description = "If you get targeted, you may take a roll.", SpellImage = "NecromancerLevel5", GameClassId = NecromancerID });
                Spells.Add(new Spell { GameClassName = "Necromancer", Name = "Skeleton Army", Level = 7, Style = "", Description = "Every other wizard drinks equal to their level.", GameClassId = NecromancerID });
                Spells.Add(new Spell { GameClassName = "Necromancer", Name = "Duel of Sickness", Level = 8, Style = "", Description = "Choose 2 wizards to duel with a die. The first to roll a 6 three times wins. The loser decreases a level.", GameClassId = NecromancerID });

                Spells.Add(new Spell { GameClassName = "Pyromancer", Name = "BounceBall", Level = 1, Style = "", Description = "Pick any 2 to bounce a beer cap to a cup. Loser takes 5 drinks.", GameClassId = PyromancerID });
                Spells.Add(new Spell { GameClassName = "Pyromancer", Name = "FireWhip", Level = 2, Style = "", Description = "Wizard next to you drinks 1 drink, players next to them 2 and so on. Untill they meet at one person, who takes 5 drinks.", GameClassId = PyromancerID });
                Spells.Add(new Spell { GameClassName = "Pyromancer", Name = "FireShield", Level = 4, Style = Reaction, Description = "Whenever someone targets you, pick another wizard to suffer half the damage.(Can’t be the attacker).", SpellImage = "PyroLevel4", GameClassId = PyromancerID });
                Spells.Add(new Spell { GameClassName = "Pyromancer", Name = "Rage", Level = 5, Style = "", Description = "Wizards below your level has to empty their current drink, or  they lose a level.", GameClassId = PyromancerID });
                Spells.Add(new Spell { GameClassName = "Pyromancer", Name = "Firestorm", Level = 7, Style = "", Description = "Choose a wizard to take 1 drink. He chooses one to take 2. This continues untill everyone has drunk.", GameClassId = PyromancerID });
                Spells.Add(new Spell { GameClassName = "Pyromancer", Name = "Orb of Fire", Level = 8, Style = Reaction, Description = "Everytime a wizard levels up, he takes a shot.", SpellImage = "PyroLevel8", GameClassId = PyromancerID });

                Spells.Add(new Spell { GameClassName = "Druid", Name = "Apprentice", Level = 1, Style = Multiple, Description = "Pick two people to play rock-paper-scissors. Loser takes 3 drinks.", GameClassId = DruidID });
                Spells.Add(new Spell { GameClassName = "Druid", Name = "Animal shapes", Level = 2, Style = "", Description = "The wizard next to you names an animal with same start letter as him, so does the next and so on. First to fail decreases a level.", GameClassId = DruidID });
                Spells.Add(new Spell { GameClassName = "Druid", Name = "Laws of nature", Level = 4, Style = Passive, Description = "Make a rule. Anyone who fails to follow this rule, drinks 2 drinks", SpellImage = "DruidLevel4", GameClassId = DruidID });
                Spells.Add(new Spell { GameClassName = "Druid", Name = "Animal Messenger", Level = 5, Style = "", Description = "Every wizard imitates an animal sound. You declare a loser. He takes 5 drinks. If a wizard refuses to imitate a sound, he has to drink 2 shots.", GameClassId = DruidID });
                Spells.Add(new Spell { GameClassName = "Druid", Name = "Bound by nature", Level = 7, Style = "", Description = "Target wizard can’t move from their current location or roll, untill you level up. Unless he drinks 3 drinks and a shot", GameClassId = DruidID });
                Spells.Add(new Spell { GameClassName = "Druid", Name = "Ressistance", Level = 8, Style = Reaction, Description = "You only drink half of your penalty drinks.", SpellImage = "DruidLevel8", GameClassId = DruidID });

                Spells.Add(new Spell { GameClassName = "Illusionist", Name = "Paralyzation Wand", Level = 1, Style = "", Description = "Target a wizard that can't level up before you, or if they drink a shot.", GameClassId = IllusionistID });
                Spells.Add(new Spell { GameClassName = "Illusionist", Name = "Counter-Spell ", Level = 2, Style = Reaction, Description = "Cancel spells targeted on you.", SpellImage = "IllusionistLevel2", GameClassId = IllusionistID });
                Spells.Add(new Spell { GameClassName = "Illusionist", Name = "Talismans og Knowledge", Level = 4, Style = "", Description = "You may cast a non passive/reaction level 4 or 5 spell from another class.", GameClassId = IllusionistID });
                Spells.Add(new Spell { GameClassName = "Illusionist", Name = "Staff of command", Level = 5, Style = Passive, Description = "Choose a title. Any wizard who fails to address you by that, must drink 3 drinks.", SpellImage = "IllusionistLevel5", GameClassId = IllusionistID });
                Spells.Add(new Spell { GameClassName = "Illusionist", Name = "Illusion Wand", Level = 7, Style = Multiple, Description = "When you raise your glass/drink, all wizards cheer and take a drink. Then you get the turn, no matter whoms turn it is at the moment", GameClassId = IllusionistID });
                Spells.Add(new Spell { GameClassName = "Illusionist", Name = "Polymorph", Level = 8, Style = "", Description = "Change 2 wizard’s classes to any other class. You may use one of their lowest active spells.", GameClassId = IllusionistID });

                Spells.Add(new Spell { GameClassName = "Cleric", Name = "Lights of hope", Level = 1, Style = Multiple, Description = "Target a wizard. If he levels up on his next roll, so do you.", GameClassId = ClericID });
                Spells.Add(new Spell { GameClassName = "Cleric", Name = "Calm emotions", Level = 2, Style = Passive, Description = "You drink half when you fight against bosses.", SpellImage = "ClericLevel2", GameClassId = ClericID });
                Spells.Add(new Spell { GameClassName = "Cleric", Name = "Silence", Level = 4, Style = "", Description = "Target wizard can’t use his next spell", GameClassId = ClericID });
                Spells.Add(new Spell { GameClassName = "Cleric", Name = "Inflicted wounds", Level = 5, Style = Reaction, Description = "Spells cast on you is cancelled unless attacker drinks 3 drinks.", SpellImage = "ClericLevel5", GameClassId = ClericID });
                Spells.Add(new Spell { GameClassName = "Cleric", Name = "Holy arua", Level = 7, Style = First, SecondStyle = "The rest drinks 5 drinks.", Description = "You and the players next to you are Immune, the rest decreases a level and drink 5 drinks", GameClassId = ClericID });
                Spells.Add(new Spell { GameClassName = "Cleric", Name = "Create Undead", Level = 8, Style = "", Description = "Cast a none passive spell from the necromancer class (8 or below).", GameClassId = ClericID });

                Spells.Add(new Spell { GameClassName = "Warlock", Name = "Darkness", Level = 1, Style = "", Description = "Target wizard is blinded untill he levels up. If eyes are opened, he drinks 5 drinks.(Eyes are open, when you roll)", GameClassId = WarlockID });
                Spells.Add(new Spell { GameClassName = "Warlock", Name = "Vampiric Touch", Level = 2, Style = Multiple, Description = "You get target wizards next roll.", GameClassId = WarlockID });
                Spells.Add(new Spell { GameClassName = "Warlock", Name = "Dimension Door", Level = 4, Style = First, SecondStyle = "Use a level 2 none passive spell from another class.", Description = "Use a level 7 none passive spell from another class.", GameClassId = WarlockID });
                Spells.Add(new Spell { GameClassName = "Warlock", Name = "Circle of Death", Level = 5, Style = Reaction, Description = "When hit by a spell, every other wizard drinks 2 drinks.", SpellImage = "WarlockLevel5", GameClassId = WarlockID });
                Spells.Add(new Spell { GameClassName = "Warlock", Name = "True Strike", Level = 7, Style = Multiple, Description = "Target wizard rolls a dice. If its 5 or 6 target wizard levels down.", GameClassId = WarlockID });
                Spells.Add(new Spell { GameClassName = "Warlock", Name = "Invisibility", Level = 8, Style = Reaction, Description = "Can’t be hit by any spells while invisible.", SpellImage = "WarlockLevel8", GameClassId = WarlockID });

                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Magic Missile", Level = 1, Style = Multiple, Description = "Roll twice this turn.", GameClassId = DisruptedSorcerer });
                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Dispel", Level = 2, Style = Passive, Description = "For every spell that hits you, roll a die. If its 6, you may cancel the spell cast on you.", SpellImage = "DisruptedLevel2", GameClassId = DisruptedSorcerer });
                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Silent war", Level = 4, Style = "", Description = "Every other wizard rolls a die, the lowest 1 is silenced for his next spell (not bosses).", GameClassId = DisruptedSorcerer });
                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Acid splash", Level = 5, Style = "", Description = "Choose a wizard. You and the target wizard roll a die. If you roll higher, the target wizard and the wizards next to him drink 5 drinks each. You may reroll once.", GameClassId = DisruptedSorcerer });
                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Fog of confusion", Level = 7, Style = "", Description = "Every wizard but you, uses their roll 1 spell. You are immune.", GameClassId = DisruptedSorcerer });
                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "False Life", Level = 8, Style = Multiple, Description = "Every other wizard rolls a die. Those who hit 1 take a shot.", GameClassId = DisruptedSorcerer });
                Spells.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Wish", Level = 9, Style = First, SecondStyle = "if you roll  5 or 6 you become level 10and are now a wizard.", Description = "If you roll 3, 4, 5 or 6 you become level 10 and are now a wizard.", GameClassId = DisruptedSorcerer });

                Spells.Add(new Spell { GameClassName = "Time Mage", Name = "Magic Drink", Level = 1, Style = Passive, Description = "Everytime spells make you drink, ignore the first drink.", SpellImage = "TimeMageLevel1", GameClassId = TimeMage });
                Spells.Add(new Spell { GameClassName = "Time Mage", Name = "Blink", Level = 2, Style = First, Description = "Increase a level.", GameClassId = TimeMage });
                Spells.Add(new Spell { GameClassName = "Time Mage", Name = "Gravity Force", Level = 4, Style = "", Description = "Target Wizard must hold a full beer with stretched arm until he levels up. If failed, target wizard drinks 1 shot.", GameClassId = TimeMage });
                Spells.Add(new Spell { GameClassName = "Time Mage", Name = "Future peek", Level = 5, Style = "", Description = "You get one free peek at a mighty magic beast, and can go back without decreasing a level, if you dont want the quest.", GameClassId = TimeMage });
                Spells.Add(new Spell { GameClassName = "Time Mage", Name = "Stop Time", Level = 7, Style = "", Description = "Wizards higher level than you, can’t roll for the next two rounds.", GameClassId = TimeMage });
                Spells.Add(new Spell { GameClassName = "Time Mage", Name = "Haste", Level = 8, Style = Passive, Description = "When you roll a 5, either give away 5 drinks, or take a free reroll.", SpellImage = "TimeMageLevel8", GameClassId = TimeMage });

                Spells.Add(new Spell { GameClassName = "Shaman", Name = "Summon Totem", Level = 1, Style = Passive, Description = "Every level you will recieve a new totem, that has an effect. It will display as a passive spell in your game collumn.", SpellImage = "ShamanLevelTotem", GameClassId = ShamanID });
                Spells.Add(new Spell { GameClassName = "Shaman", Name = "Earth Shock", Level = 2, Style = Reaction, Description = "Every roll is -1. If the result of a roll is now 0, you may take a roll.", SpellImage = "ShamanLevel2", GameClassId = ShamanID });
                Spells.Add(new Spell { GameClassName = "Shaman", Name = "Cleanse Spirit", Level = 4, Style = First, SecondStyle = "Silence target wizard.", Description = "Silence all other wizards for their next spell.", GameClassId = ShamanID });
                Spells.Add(new Spell { GameClassName = "Shaman", Name = "Chain Lightning", Level = 5, Style = "", Description = "Lowest level drinks 1 drink, second lowest drinks 2 and so on. You are immune.", GameClassId = ShamanID });
                Spells.Add(new Spell { GameClassName = "Shaman", Name = "Far sight", Level = 7, Style = Multiple, Description = "Use a level 5 or lower spell from another class (can't use same spell twice).", GameClassId = ShamanID });
                Spells.Add(new Spell { GameClassName = "Shaman", Name = "Water Walking", Level = 8, Style = Reaction, Description = "All penalty drinks may be drunk as water instead of a beer.", SpellImage = "ShamanLevel8", GameClassId = ShamanID });

                Spells.Add(new Spell { GameClassName = "Alchemist", Name = "Stone Fist", Level = 1, Style = Passive, Description = "Everytime you level up, target wizard fist bombs you. If he forgets, he drinks 3 drinks.", SpellImage = "AlchemistLevel1", GameClassId = AlchemistID });
                Spells.Add(new Spell { GameClassName = "Alchemist", Name = "Touch of Slime", Level = 2, Style = Passive, Description = "Everytime you level up, pick a wizard to skip his next roll.", SpellImage = "AlchemistLevel2", GameClassId = AlchemistID });
                Spells.Add(new Spell { GameClassName = "Alchemist", Name = "Beast Shape", Level = 4, Style = Reaction, Description = "If your ordinary roll is a 4,  target  players drink a shot.", GameClassId = AlchemistID });
                Spells.Add(new Spell { GameClassName = "Alchemist", Name = "Stone Skin", Level = 5, Style = Reaction, Description = "You are immune for any punishments.", SpellImage = "AlchemistLevel5", GameClassId = AlchemistID });
                Spells.Add(new Spell { GameClassName = "Alchemist", Name = "Delayed Posion", Level = 7, Style = "", Description = "If nobody levels up before its your turn again, they all decrease a level.", GameClassId = AlchemistID });
                Spells.Add(new Spell { GameClassName = "Alchemist", Name = "Deadly elixir", Level = 8, Style = "", Description = "Mix a shot of whatever you want. All players roll a die, lowest roll drinks the shot. You may roll twice.", GameClassId = AlchemistID });


                Spells.Add(new Spell { GameClassName = "Witch", Name = "Corrupt", Level = 1, Style = Passive, Description = "Everytime a player levels up, you may give away 1 drink." ,GameClassId = WitchID, SpellImage = "WitchLevel1" });
                Spells.Add(new Spell { GameClassName = "Witch", Name = "Shock", Level = 2, Style = Passive, Description = "Boost Corrupt, now give away 2 drinks + paralize a player for his next roll.", GameClassId = WitchID, SpellImage = "WitchLevel2" });
                Spells.Add(new Spell { GameClassName = "Witch", Name = "Demonic Boost", Level = 4, Style = Reaction, Description = "Boost Corrupt, you may roll, if higher than a 3, you level up.", GameClassId = WitchID, SpellImage = "WitchLevel4" });
                Spells.Add(new Spell { GameClassName = "Witch", Name = "Calling of Horror", Level = 5, Style = "", Description = "Name a celebrity, then next player names another celebrity with start letter equal to your celebrety lastname startletter. The second you name a celebrity, the next player starts drinking until he has a celebrity. If wrong name, take a shot. it ends before its your turn again.", GameClassId = WitchID });
                Spells.Add(new Spell { GameClassName = "Witch", Name = "Hellfire Shield", Level = 7, Style = Reaction, Description = "If you get targeted, all other players roll a die, if its 3 or under, they will decrease a level.", GameClassId = WitchID, SpellImage = "WitchLevel7" });
                Spells.Add(new Spell { GameClassName = "Witch", Name = "Insanity", Level = 8, Style = Multiple, Description = "All wizard rolls a die, the player who rolls highest may decrease another player a level. You are immune", GameClassId = WitchID });



                Spells.Add(new Spell { GameClassName = "Elementalist", Name = "Fire: Burning Burst", Level = 1, Style = Passive, Description = "Every level give away drinks amount equal to half your level rounded up.", GameClassId = ElementalistID, SpellImage = "ElementalistLevel1" });
                Spells.Add(new Spell { GameClassName = "Elementalist", Name = "Air: Gust", Level = 2, Style = "", Description = "Players higher level than you, decreaes a level or drink a shot.", GameClassId = ElementalistID });
                Spells.Add(new Spell { GameClassName = "Elementalist", Name = "Ice: Frozen Ground", Level = 4, Style = Reaction, Description = "Every other wizards has to end all sentences with: On Ice. Otherwise they drink 5 drinks.", GameClassId = ElementalistID, SpellImage = "ElementalistLevel4" });
                Spells.Add(new Spell { GameClassName = "Elementalist", Name = "Earth: Impale", Level = 5, Style = Reaction, Description = "Every rolls but 6 is invalid for every other wizards.", GameClassId = ElementalistID, SpellImage = "ElementalistLevel5" });
                Spells.Add(new Spell { GameClassName = "Elementalist", Name = "Thunder: Magnetic Aura", Level = 7, Style = Reaction, Description = "Whenever a spell is used, you may re use it.", GameClassId = ElementalistID, SpellImage = "ElementalistLevel7" });
                Spells.Add(new Spell { GameClassName = "Elementalist", Name = "Darkness: Fog of Evil", Level = 8, Style = First, SecondStyle = "Everybody but you drinks a shot", Description = "Everybody but you decreases a level and drinks a shot", GameClassId = ElementalistID });



                Spells.Add(new Spell { GameClassName = "Summoner", Name = "Brozish", Level = 1, Style = Passive, Description = "Summon Brozish which is you helping assistant. He removes half of your beer punishments.", GameClassId = SummonerID, SpellImage = "SummonerLevel1" });
                Spells.Add(new Spell { GameClassName = "Summoner", Name = "Summon Inferno", Level = 2, Style = Multiple, Description = "Target wizard drinks double on his next punishment", GameClassId = SummonerID });
                Spells.Add(new Spell { GameClassName = "Summoner", Name = "T-rex Transformation", Level = 4, Style = "", Description = "Target wizard has to pull his arm inside his shirt so only his hands sticks out. If he fails or refuses, he drinks 2 shots", GameClassId = SummonerID });
                Spells.Add(new Spell { GameClassName = "Summoner", Name = "Poison Imp", Level = 5, Style = Reaction, Description = "Summons an imp for every other wizards. Every time its a wizards turn the imp makes the wizard drink 2 drinks", SpellImage = "SummonerLevel5", GameClassId = SummonerID });
                Spells.Add(new Spell { GameClassName = "Summoner", Name = "Summon Dragon", Level = 7, Style = Multiple, Description = "Target wizard has to roll a die. If it's 3 or below, he is forced to fight a dragon.(Can't be use on wizards below level 5 or wizards who already won against a dragon)", GameClassId = SummonerID });
                Spells.Add(new Spell { GameClassName = "Summoner", Name = "Angel Protection", Level = 8, Style = Reaction, Description = "You are immune to everything", SpellImage = "SummonerLevel8", GameClassId = SummonerID });





                Spells.Add(new Spell { GameClassName = "Dracsoris", Name = "DragonPower", Level = 5, Style = Passive, Description = "You can't decrease or change dracsoris", SpellImage = "DracsorisLevel5", GameClassId = DracsorisID });
                Spells.Add(new Spell { GameClassName = "Dracsoris", Name = "Retaliate", Level = 7, Style = Passive, Description = "When targeted, send a fireball back, that deals 5 drinks as damage.", SpellImage = "DracsorisLevel7", GameClassId = DracsorisID });
                Spells.Add(new Spell { GameClassName = "Dracsoris", Name = "Ice Tower", Level = 8, Style = Multiple, Description = "Freeze a target wizard till you level up, or he drinks 2 shots", GameClassId = DracsorisID });


                using (var context = new Repository())
                {
                    foreach (var item in Spells)
                    {
                        context.Spell.Add(item);
                    }

                    context.SaveChanges();
                    return "Spells added";
                }
            }
            catch (Exception e)
            {
                string er = e.ToString();
                return er;
            }
        }


        [HttpGet]
        [Route("DeleteSpamSpells")]
        public string DeleteSpamSpells()
        {
            try
            {
                using (var context = new Repository())
                {
                    var data = context.Spell.ToList();
                    foreach (var item in data)
                    {
                        if (item.Id> 82)
                        {
                            context.Spell.Remove(item);
                        }
                       
                    }
                    context.SaveChanges();
                    return "spells deleted";
                }
            }
            catch (Exception e)
            {
                return e.ToString();

            }
        }




        [HttpGet]
        [Route("Delete")]
        public string Delete()
        {
            try
            {


                using (var context = new Repository())
                {
                    var data = context.Spell.ToList();
                    foreach (var item in data)
                    {
                        context.Spell.Remove(item);
                    }
                    context.SaveChanges();
                    return "spells deleted";
                }
            }
            catch (Exception e)
            {
                return e.ToString();

            }
        }

    }
}