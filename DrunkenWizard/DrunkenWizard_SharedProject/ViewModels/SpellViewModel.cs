using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.ViewModels
{
  public  class SpellViewModel
    {
       public SpellViewModel() 
        {
            List<SpellType> spelltypes = new List<SpellType>();
            spelltypes.Add(new SpellType() {Name="Passive",Description = "The effect of a Passive spell last throughout the game. Passive spells can be seen as a small icon in the left side of players gamecells.", Color= "#0045ff" });
            spelltypes.Add(new SpellType() { Name = "Reaction", Description = "The effect of a Reaction spell applies only in the current level. Reaction spells can also be seen in the left side of players gamecells.", Color = "#04c925" });
            spelltypes.Add(new SpellType() { Name = "Multiple", Description = "Multiple spells may be used twice in the current level. If you level up or down, the effect disappears. So use the spells wisely!", Color = "#ee010d" });
            spelltypes.Add(new SpellType() { Name = "Aoe", Description = "If a spell has the Aoe tag, it means that the effect is applied to every wizards in the game besides yourself, unless anything else is specified.", Color = "#9f00e7" });
            spelltypes.Add(new SpellType() { Name = "First", Description = "If a spell has the first tag and you reach that level as the first wizard in the game, the effect of the spell will be boosted. Else the Not tag will show the effect. ", Color = "#ff7400" });
            List<Spell> druidList = new List<Spell>();
            List<Spell> necromancerList = new List<Spell>();
            List<Spell> pyromancerList = new List<Spell>();
            List<Spell> clericList = new List<Spell>();
            List<Spell> illusionistList = new List<Spell>();
            List<Spell> warlockList = new List<Spell>();
            List<Spell> disruptedList = new List<Spell>();
            List<Spell> timeMageList = new List<Spell>();
            List<Spell> shamanList = new List<Spell>();
            List<Spell> alchemistList = new List<Spell>();
            List<Spell> witchlist = new List<Spell>();
            List<Spell> elementalistlist = new List<Spell>();
            List<Spell> summonerlist = new List<Spell>();
            List<Spell> dracsorislist = new List<Spell>();
            string Reaction = "Reaction";
            string Aoe = "Aoe";
            string Passive = "Passive";
            string Multiple = "Multiple";
            string First = "First";

            necromancerList.Add(new Spell { GameClassName = "Necromancer", Name = "Sickened", Level = 1, Style = Multiple, Description = "Target wizard drinks a shot, if he rolls 4 on his next roll." });
            necromancerList.Add(new Spell { GameClassName = "Necromancer", Name = "Shun the sceptic", Level = 2, Style = Passive, Description = "When you level up, each wizard lower level than you takes 2 drinks.", SpellImage = "NecromancerLevel2" });
            necromancerList.Add(new Spell { GameClassName = "Necromancer", Name = "Death ripple", Level = 4, Style = "", Description = "Every other classes than necromancer sleeps for 2 rounds." });
            necromancerList.Add(new Spell { GameClassName = "Necromancer", Name = "Curse", Level = 5, Style = Reaction, Description = "If you get targeted, you may take a roll.", SpellImage = "NecromancerLevel5" });
            necromancerList.Add(new Spell { GameClassName = "Necromancer", Name = "Skeleton Army", Level = 7, Style = Aoe, Description = "drink equal to your level." });
            necromancerList.Add(new Spell { GameClassName = "Necromancer", Name = "Duel of Sickness", Level = 8, Style = "", Description = "Choose 2 wizards to duel with a die. The first to roll a 6 three times wins. The loser decreases a level." });

            pyromancerList.Add(new Spell { GameClassName = "Pyromancer", Name = "BounceBall", Level = 1, Style = "", Description = "Pick any 2 to bounce a beer cap to a cup. Loser takes 5 drinks." });
            pyromancerList.Add(new Spell { GameClassName = "Pyromancer", Name = "FireWhip", Level = 2, Style = "", Description = "Wizard next to you drinks 1 drink, players next to them 2 and so on. Untill they meet at one person, who takes 5 drinks."});
            pyromancerList.Add(new Spell { GameClassName = "Pyromancer", Name = "FireShield", Level = 4, Style = Reaction, Description = "Whenever someone targets you, pick another wizard to suffer half the damage.(Can’t be the attacker).", SpellImage = "PyroLevel4"});
            pyromancerList.Add(new Spell { GameClassName = "Pyromancer", Name = "Rage", Level = 5, Style = "", Description = "Wizards below your level has to empty their current drink, or  they lose a level."});
            pyromancerList.Add(new Spell { GameClassName = "Pyromancer", Name = "Firestorm", Level = 7, Style = "", Description = "Choose a wizard to take 1 drink. He chooses one to take 2. This continues untill everyone has drunk."});
            pyromancerList.Add(new Spell { GameClassName = "Pyromancer", Name = "Orb of Fire", Level = 8, Style = Reaction, Description = "Everytime a wizard levels up, he takes a shot.", SpellImage = "PyroLevel8" });

            druidList.Add(new Spell { GameClassName = "Druid", Name = "Apprentice", Level = 1, Style = Multiple, Description = "Pick two people to play rock-paper-scissors. Loser takes 3 drinks."});
            druidList.Add(new Spell { GameClassName = "Druid", Name = "Animal shapes", Level = 2, Style = "", Description = "The wizard next to you names an animal with same start letter as him, so does the next and so on. First to fail decreases a level." });
            druidList.Add(new Spell { GameClassName = "Druid", Name = "Laws of nature", Level = 4, Style = Passive, Description = "Make a rule. Anyone who fails to follow this rule, drinks 3 drinks", SpellImage = "DruidLevel4" });
            druidList.Add(new Spell { GameClassName = "Druid", Name = "Animal Messenger", Level = 5, Style = Aoe, Description = "imitate an animal sound. You declare a loser. He takes 5 drinks. If a wizard refuses to imitate a sound, he has to drink 2 shots." });
            druidList.Add(new Spell { GameClassName = "Druid", Name = "Bound by nature", Level = 7, Style = "", Description = "Target wizard can’t move from their current location or roll, untill you level up. Unless he drinks 3 drinks and a shot" });
            druidList.Add(new Spell { GameClassName = "Druid", Name = "Ressistance", Level = 8, Style = Reaction, Description = "You only drink half of your penalty drinks.", SpellImage = "DruidLevel8" });

            illusionistList.Add(new Spell { GameClassName = "Illusionist", Name = "Paralyzation Wand", Level = 1, Style = "", Description = "Target a wizard that can't level up before you, or if they drink a shot." });
            illusionistList.Add(new Spell { GameClassName = "Illusionist", Name = "Counter-Spell ", Level = 2, Style = Reaction, Description = "Cancel spells targeted on you.", SpellImage = "IllusionistLevel2" });
            illusionistList.Add(new Spell { GameClassName = "Illusionist", Name = "Talismans og Knowledge", Level = 4, Style = "", Description = "You may cast a non passive/reaction level 4 or 5 spell from another class." });
            illusionistList.Add(new Spell { GameClassName = "Illusionist", Name = "Staff of command", Level = 5, Style = Passive, Description = "Choose a title. Any wizard who fails to address you by that, must drink 3 drinks.", SpellImage = "IllusionistLevel5" });
            illusionistList.Add(new Spell { GameClassName = "Illusionist", Name = "Illusion Wand", Level = 7, Style = Multiple, Description = "When you raise your glass/drink, all wizards cheer and take a drink. Then you get the turn, no matter whoms turn it is at the moment" });
            illusionistList.Add(new Spell { GameClassName = "Illusionist", Name = "Polymorph", Level = 8, Style = "", Description = "Change 2 wizard’s classes to any other class. You may use one of their lowest active spells."});

            clericList.Add(new Spell { GameClassName = "Cleric", Name = "Lights of hope", Level = 1, Style = Multiple, Description = "Target a wizard. If he levels up on his next roll, so do you." });
            clericList.Add(new Spell { GameClassName = "Cleric", Name = "Calm emotions", Level = 2, Style = Passive, Description = "You drink half when you fight against bosses.", SpellImage = "ClericLevel2"});
            clericList.Add(new Spell { GameClassName = "Cleric", Name = "Silence", Level = 4, Style = "", Description = "Target wizard can’t use his next spell"});
            clericList.Add(new Spell { GameClassName = "Cleric", Name = "Inflicted wounds", Level = 5, Style = Reaction, Description = "Spells cast on you is cancelled unless attacker drinks 3 drinks.", SpellImage = "ClericLevel5"});
            clericList.Add(new Spell { GameClassName = "Cleric", Name = "Holy arua", Level = 7, Style = First, SecondStyle = "The rest drinks 5 drinks.", Description = "You and the players next to you are Immune, the rest decreases a level and drink 5 drinks" });
            clericList.Add(new Spell { GameClassName = "Cleric", Name = "Create Undead", Level = 8, Style = "", Description = "Cast a none passive spell from the necromancer class (8 or below)."});

            warlockList.Add(new Spell { GameClassName = "Warlock", Name = "Darkness", Level = 1, Style = "", Description = "Target wizard is blinded untill he levels up. If eyes are opened, he drinks 5 drinks.(Eyes are open, when you roll)" });
            warlockList.Add(new Spell { GameClassName = "Warlock", Name = "Vampiric Touch", Level = 2, Style = Multiple, Description = "You get target wizards next roll." });
            warlockList.Add(new Spell { GameClassName = "Warlock", Name = "Dimension Door", Level = 4, Style = First, SecondStyle = "Use a level 2 none passive spell from another class.", Description = "Use a level 7 none passive spell from another class."});
            warlockList.Add(new Spell { GameClassName = "Warlock", Name = "Circle of Death", Level = 5, Style = Reaction, Description = "When hit by a spell, every other wizard drinks 2 drinks.", SpellImage = "WarlockLevel5" });
            warlockList.Add(new Spell { GameClassName = "Warlock", Name = "True Strike", Level = 7, Style = Multiple, Description = "Target wizard rolls a dice. If its 5 or 6 target wizard levels down." });
            warlockList.Add(new Spell { GameClassName = "Warlock", Name = "Invisibility", Level = 8, Style = Reaction, Description = "Can’t be hit by any spells while invisible.", SpellImage = "WarlockLevel8" });

            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Magic Missile", Level = 1, Style = Multiple, Description = "Roll twice this turn."});
            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Dispel", Level = 2, Style = Passive, Description = "For every spell that hits you, roll a die. If its 6, you may cancel the spell cast on you.", SpellImage = "DisruptedLevel2" });
            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Silent war", Level = 4, Style = Aoe, Description = "Roll a die, the lowest 1 is silenced for his next spell (not bosses)." });
            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Acid splash", Level = 5, Style = "", Description = "Choose a wizard. You and the target wizard roll a die. If you roll higher, the target wizard and the wizards next to him drink 5 drinks each. You may reroll once." });
            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Fog of confusion", Level = 7, Style = Aoe, Description = "Use roll 1 spell. You are immune." });
            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "False Life", Level = 8, Style = Aoe, Description = "Roll a die. Those who hit 1 take a shot."});
            disruptedList.Add(new Spell { GameClassName = "Disrupted Sorcerer", Name = "Wish", Level = 9, Style = First, SecondStyle = "if you roll  5 or 6 you become level 10and are now a wizard.", Description = "If you roll 3, 4, 5 or 6 you become level 10 and are now a wizard." });

            timeMageList.Add(new Spell { GameClassName = "Time Mage", Name = "Magic Drink", Level = 1, Style = Passive, Description = "Everytime spells make you drink, ignore the first drink.", SpellImage = "TimeMageLevel1" });
            timeMageList.Add(new Spell { GameClassName = "Time Mage", Name = "Blink", Level = 2, Style = First, Description = "Increase a level."});
            timeMageList.Add(new Spell { GameClassName = "Time Mage", Name = "Gravity Force", Level = 4, Style = "", Description = "Target Wizard must hold a full beer with stretched arm until he levels up. If failed, target wizard drinks 1 shot." });
            timeMageList.Add(new Spell { GameClassName = "Time Mage", Name = "Future peek", Level = 5, Style = "", Description = "You get one free peek at a mighty magic beast, and can go back without decreasing a level, if you dont want the quest." });
            timeMageList.Add(new Spell { GameClassName = "Time Mage", Name = "Stop Time", Level = 7, Style = "", Description = "Wizards higher level than you, can’t roll for the next two rounds." });
            timeMageList.Add(new Spell { GameClassName = "Time Mage", Name = "Haste", Level = 8, Style = Passive, Description = "When you roll a 5, either give away 5 drinks, or take a free reroll.", SpellImage = "TimeMageLevel8"});

            shamanList.Add(new Spell { GameClassName = "Shaman", Name = "Summon Totem", Level = 1, Style = Passive, Description = "Every level you will recieve a new totem, that has an effect. It will display as a passive spell in your game collumn.", SpellImage = "ShamanLevelTotem" });
            shamanList.Add(new Spell { GameClassName = "Shaman", Name = "Earth Shock", Level = 2, Style = Reaction, Description = "Every roll is -1. If the result of a roll is now 0, you may take a roll.", SpellImage = "ShamanLevel2" });
            shamanList.Add(new Spell { GameClassName = "Shaman", Name = "Cleanse Spirit", Level = 4, Style = First, SecondStyle = "Silence target wizard.", Description = "Silence all other wizards for their next spell." });
            shamanList.Add(new Spell { GameClassName = "Shaman", Name = "Chain Lightning", Level = 5, Style = "", Description = "Lowest level drinks 1 drink, second lowest drinks 2 and so on. You are immune." });
            shamanList.Add(new Spell { GameClassName = "Shaman", Name = "Far sight", Level = 7, Style = Multiple, Description = "Use a level 5 or lower spell from another class (can't use same spell twice)."});
            shamanList.Add(new Spell { GameClassName = "Shaman", Name = "Water Walking", Level = 8, Style = Reaction, Description = "All penalty drinks may be drunk as water instead of a beer.", SpellImage = "ShamanLevel8" });

            alchemistList.Add(new Spell { GameClassName = "Alchemist", Name = "Stone Fist", Level = 1, Style = Passive, Description = "Everytime you level up, target wizard fist bombs you. If he forgets, he drinks 3 drinks.", SpellImage = "AlchemistLevel1" });
            alchemistList.Add(new Spell { GameClassName = "Alchemist", Name = "Touch of Slime", Level = 2, Style = Passive, Description = "Everytime you level up, pick a wizard to skip his next roll.", SpellImage = "AlchemistLevel2" });
            alchemistList.Add(new Spell { GameClassName = "Alchemist", Name = "Beast Shape", Level = 4, Style = Reaction, Description = "If your ordinary roll is a 4,  target  players drink a shot." });
            alchemistList.Add(new Spell { GameClassName = "Alchemist", Name = "Stone Skin", Level = 5, Style = Reaction, Description = "You are immune for any punishments.", SpellImage = "AlchemistLevel5" });
            alchemistList.Add(new Spell { GameClassName = "Alchemist", Name = "Delayed Posion", Level = 7, Style = "", Description = "If nobody levels up before its your turn again, they all decrease a level." });
            alchemistList.Add(new Spell { GameClassName = "Alchemist", Name = "Deadly elixir", Level = 8, Style = "", Description = "Mix a shot of whatever you want. All players roll a die, lowest roll drinks the shot. You may roll twice." });

            witchlist.Add(new Spell { GameClassName = "Witch", Name = "Corrupt", Level = 1, Style = Passive, Description = "Everytime a player levels up, you may give away 1 drink.", SpellImage = "WitchLevel1" });
            witchlist.Add(new Spell { GameClassName = "Witch", Name = "Shock", Level = 2, Style = Passive, Description = "Boost Corrupt, now give away 2 drinks + paralize a player for his next roll.", SpellImage = "WitchLevel2" });
            witchlist.Add(new Spell { GameClassName = "Witch", Name = "Demonic Boost", Level = 4, Style = Reaction, Description = "Boost Corrupt, you may roll, if higher than a 3, you level up.", SpellImage = "WitchLevel4" });
            witchlist.Add(new Spell { GameClassName = "Witch", Name = "Calling of Horror", Level = 5, Style = "", Description = "Name a celebrity, then next player names another celebrity with start letter equal to your celebrety lastname startletter. Right after you name a celebrity, the next player starts drinking until he has a celebrity. If wrong name, take a shot. it ends before its your turn again." });
            witchlist.Add(new Spell { GameClassName = "Witch", Name = "Hellfire Shield", Level = 7, Style = Reaction, Description = "If you get targeted, all other players roll a die, if its 3 or under, they will decrease a level.", SpellImage = "WitchLevel7" });
            witchlist.Add(new Spell { GameClassName = "Witch", Name = "Insanity", Level = 8, Style = Multiple, Description = "All wizard rolls a die, the player who rolls highest may decrease another player a level. You are immune" });

            elementalistlist.Add(new Spell { GameClassName = "Elementalist", Name = "Fire: Burning Burst", Level = 1, Style = Passive, Description = "Every level give away drinks amount equal to half your level rounded up.", SpellImage = "ElementalistLevel1" });
            elementalistlist.Add(new Spell { GameClassName = "Elementalist", Name = "Air: Gust", Level = 2, Style = "", Description = "Players higher level than you, decreaes a level or drink a shot." });
            elementalistlist.Add(new Spell { GameClassName = "Elementalist", Name = "Ice: Frozen Ground", Level = 4, Style = Reaction, Description = "Every other wizards has to end all sentences with: On Ice. Otherwise they drink 5 drinks.", SpellImage = "ElementalistLevel4" });
            elementalistlist.Add(new Spell { GameClassName = "Elementalist", Name = "Earth: Impale", Level = 5, Style = Reaction, Description = "Every rolls but 6 is invalid for every other wizards.", SpellImage = "ElementalistLevel5" });
            elementalistlist.Add(new Spell { GameClassName = "Elementalist", Name = "Thunder: Magnetic Aura", Level = 7, Style = Reaction, Description = "Whenever a spell is used, you may re use it.", SpellImage = "ElementalistLevel7" });
            elementalistlist.Add(new Spell { GameClassName = "Elementalist", Name = "Darkness: Fog of Evil", Level = 8, Style = First, SecondStyle = "Everybody but you drinks a shot", Description = "Everybody but you decreases a level and drinks a shot" });




            summonerlist.Add(new Spell { GameClassName = "Summoner", Name = "Brozish", Level = 1, Style = Passive, Description = "Summon Brozish which is you helping assistant. He removes half of your beer punishments.", SpellImage = "SummonerLevel1" });
            summonerlist.Add(new Spell { GameClassName = "Summoner", Name = "Summon Inferno", Level = 2, Style = Multiple, Description = "Target wizard drinks double on his next punishment" });
            summonerlist.Add(new Spell { GameClassName = "Summoner", Name = "T-rex Transformation", Level = 4, Style = "", Description = "Target wizard has to pull his arm inside his shirt so only his hands sticks out. If he fails or refuses, he drinks 2 shots" });
            summonerlist.Add(new Spell { GameClassName = "Summoner", Name = "Poison Imp", Level = 5, Style = Reaction, Description = "Summons an imp for every other wizards. Every time its a wizards turn the imp makes the wizard drink 2 drinks",SpellImage = "SummonerLevel5" });
            summonerlist.Add(new Spell { GameClassName = "Summoner", Name = "Summon Dragon", Level = 7, Style = Multiple, Description = "Target wizard has to roll a die. If it's 3 or below, he is forced to fight a dragon.(Can't be use on wizards below level 5 or wizards who already won against a dragon)" });
            summonerlist.Add(new Spell { GameClassName = "Summoner", Name = "Angel Protection", Level = 8, Style = Reaction, Description = "You are immune to everything", SpellImage = "SummonerLevel8" });

            dracsorislist.Add(new Spell { GameClassName = "Dracsoris", Name = "DragonPower", Level = 5, Style = Passive, Description = "You can't decrease or change dracsoris", SpellImage = "DragonHead"});
            dracsorislist.Add(new Spell { GameClassName = "Dracsoris", Name = "Retaliate", Level = 7, Style = Passive, Description = "When targeted, send a fireball back, that deals 5 drinks as damage.", SpellImage = "DracsorisLevel7" });
            dracsorislist.Add(new Spell { GameClassName = "Dracsoris", Name = "Ice Tower", Level = 8, Style = Multiple, Description = "Freeze a target wizard till you level up, or he drinks 2 shots" });

            SpellTypes = spelltypes;

            DruidList = druidList;
            NecromancerList = necromancerList;
            ClericList = clericList;
            PyromancerList = pyromancerList;
            IllusionistList = illusionistList;
            WarlockList = warlockList;
            DisruptedList = disruptedList;
            TimeMageList = timeMageList;
            ShamanList = shamanList;
            AlchemistList = alchemistList;
            WitchList = witchlist;
            ElementalistList = elementalistlist;
            SummonerList = summonerlist;
            DracsorisList = dracsorislist;
        }

        public List<Spell> DruidList { get; set; }
        public List<Spell> NecromancerList { get; set; }
        public List<Spell> ClericList { get; set; }
        public List<Spell> PyromancerList { get; set; }
        public List<Spell> WarlockList { get; set; }
        public List<Spell> DisruptedList { get; set; }
        public List<Spell> TimeMageList { get; set; }
        public List<Spell> ShamanList { get; set; }
        public List<Spell> AlchemistList { get; set; }
        public List<Spell> IllusionistList { get; set; }
        public List<Spell> WitchList { get; set; }
        public List<Spell> ElementalistList { get; set; }
        public List<Spell> SummonerList { get; set; }
        public List<Spell> DracsorisList { get; set; }
        public List<SpellType> SpellTypes { get; set; }


    }
}