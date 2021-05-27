﻿using System.Collections.Generic;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.ViewModels
{
    public class ClassViewModel
    {
        SpellViewModel _spVM = ServiceContainer.Resolve<SpellViewModel>();
        public ClassViewModel()
        {          
            List<GameClass> ListClassLogo = new List<GameClass>();
            ListClassLogo.Add(new GameClass { Picture = "IllusionistLogo_tsp", Name = "Illusionist", ClassType = "Entertaining", Aggressive = 1, Defensive = 2, Speed = 2, Entertaining = 4, PremiumClass = false, Color = "#4169E1", SelectedColor = "#80D7FF", Spells = _spVM.IllusionistList, GameClassInfo = "An illusionist is a wizard who makes it seem that strange or impossible things are happening, for example that something has disappeared, changed bodies or illusuions of something has been created.", RollEffect1 = "The next players roll, counts for you as well.", RollEffect2 = "Give away 2 drinks to 3 players", RollEffect3 = "Last wizard to say your name sleeps for 2 round. Only if more than 2 players.", RollEffect4 = "Target wizard drinks 7 drinks", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "DruidLogo_tsp", Name = "Druid", SelectedColor = "#80FF84", PremiumClass= false, ClassType= "Entertaining", Aggressive=1,Defensive=2,Speed=2,Entertaining= 4,Color = "#32CD32", Spells = _spVM.DruidList, GameClassInfo = "In ancient times a Druid was a philosopher, teacher, counsellor and magician, the word probably meaning ‘A Forest Sage’ or ‘Strong Seer’. In modern times, a Druid is someone who follows Druidry as their chosen spiritual path. Druids are nature wizards.", RollEffect1 = "Target wizard can't level up this round", RollEffect2 = "Wizard higher level than u drinks 3 drinks.", RollEffect3 = "If you are lowest level, Increase a level. Else reroll.", RollEffect4 = "Split 10 drinks out on wizards", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "ClericLogo_tsp", Name = "Cleric", Color = "#FFD700", PremiumClass = false, ClassType = "Defensive", Aggressive = 1, Defensive = 5, Speed = 2, Entertaining = 2, SelectedColor = "#f1f6a3", Spells = _spVM.ClericList, GameClassInfo = "A cleric is ordained to perform pastoral or other religious work. Cleric is a general term and is used in reference to Catholic priests, Protestant ministers, and non-denominational pastors. Clerics are defensive wizards", RollEffect1 = "You are immune for target spells this round", RollEffect2 = "Stun a player for 1 round", RollEffect3 = "Increase a wizard, decrease another(can't be you).", RollEffect4 = "Silence up to 3 players for their next roll.", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "WarlockLogo_tsp", Name = "Warlock", Color = "#800000", PremiumClass = true, ClassType = "Mixed", Aggressive = 2, Defensive = 2, Speed = 3, Entertaining = 3,SelectedColor = "#b25959", Spells = _spVM.WarlockList, GameClassInfo = "Warlock is usually a male witch. Just as a witch uses magic witchcraft for evil, so does a warlock. A warlock might also be a demon straight from the mouth of hell. Warlocks are villains.", RollEffect1 = "All other wizards drink a drink", RollEffect2 = "Switch another players class.", RollEffect3 = "All others drinks 2 drinks, reroll", RollEffect4 = "Level up", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "PyromancerLogo_tsp", Name = "Pyromancer", ClassType="Aggressive", PremiumClass = true, Color = "#FF4500", Aggressive = 5, Defensive = 2, Speed = 2, Entertaining = 1, SelectedColor = "#FF8880", Spells = _spVM.PyromancerList, GameClassInfo = "Pyromancy is a very old fashioned kind of divination, or fortune telling. it was actually on a list of forbidden arts during the Renaissance. The method of pyromancy varies, but it mainly involves seeing shapes within a flame and using them to predict future events. In Greek, pyros means fire.", RollEffect1 = "Target wizard drinks 3 drinks", RollEffect2 = "Reroll", RollEffect3 = "Target wizard drinks 5 drinks", RollEffect4 = "Use a level 7 spell from any class once", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "NecromancerLogo_tsp", Name = "Necromancer", Color = "#4B0082", PremiumClass = true, ClassType = "Aggressive", Aggressive = 4, Defensive = 1, Speed = 3, Entertaining = 2, SelectedColor = "#8093FF", Spells = _spVM.NecromancerList, GameClassInfo = "A necromancer is a person who practices necromancy, a discipline of black magic used to communicate with the dead to foretell the future. Necromancy is often called the Dark Art or Death magic.", RollEffect1 = "You drink 2 drinks, target wizard drinks 4 drinks.", RollEffect2 = "Use spell 1 once", RollEffect3 = "Every wizards but necromancers sleeps for 1 rounds", RollEffect4 = "Do a shot and decrease a wizard a level (Optional).", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "DistruptedSorcerer_tsp", Name = "Disrupted Sorcerer", PremiumClass = true, Color = "#696969", ClassType="Mixed", Aggressive = 2, Defensive = 2, Speed = 3, Entertaining = 3, SelectedColor = "#7295A6", Spells = _spVM.DisruptedList, GameClassInfo = "Disrupted Sorcerer is a practitioner of magic, that has the ability to attain objectives or acquire knowledge or wisdom using supernatural means. But in the process has gone mad, and now despises everything. ", RollEffect1 = "Roll a die, give target wizard the amount as drinks.", RollEffect2 = "Use the same effect of a target wizards next roll", RollEffect3 = "Say a word, then clockwise players rime, loser decreases a level.", RollEffect4 = "Use time mage lvl 4 spell", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "TimeMage_tsp", Name = "Time Mage", Color = "#40E0D0", PremiumClass = true, ClassType = "Fast", Aggressive = 1, Defensive = 2, Speed = 5, Entertaining = 2, SelectedColor = "#86f0e5", Spells = _spVM.TimeMageList, GameClassInfo = "A time mage is a fairly evolved wizard, that has mastered fastness to the point, where it is becomming time travelling. Their speed also allows them to lurk information without being detected.", RollEffect1 = "Reroll and drink 2 drinks", RollEffect2 = "Change your class, if you want.", RollEffect3 = "Reroll, only 6 is valid", RollEffect4 = "Give away a shot", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "Shaman_tsp", Name = "Shaman", Color = "#008080", PremiumClass = true, ClassType = "Mixed", Aggressive = 2, Defensive = 2, Speed = 2, Entertaining = 3, SelectedColor = "#6cbfbf", Spells = _spVM.ShamanList, GameClassInfo = "The actual word Shaman is derived from the Siberian Tungusic word for a spiritual leader. As it became more widespread, the title of shaman was used interchangeably with medicine man, medium, and healer.", RollEffect1 = "Use your totem's effect", RollEffect2 = "Players next to you drink 2 drinks", RollEffect3 = "All other wizards who hasnt killed a dragon drinks 3 drinks", RollEffect4 = "Reroll", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "Alchemist_tsp", Name = "Alchemist", Color = "#FF05E1", PremiumClass = true, ClassType = "Entertaining", Aggressive = 2, Defensive = 2, Speed = 2, Entertaining = 4, SelectedColor = "#f688e9", Spells = _spVM.AlchemistList, GameClassInfo = "The word alchemist comes from alchemy, which has origins in the Greek word khemeia, meaning art of transmuting metals. Active since ancient times, alchemists could also be considered wizards because they attempted to make special elixirs that would give everlasting life and cure sickness.", RollEffect1 = "Drink 2 drinks, and Reroll", RollEffect2 = "Make a player sleep for 1 round", RollEffect3 = "Immune for rolling spells this turn", RollEffect4 = "Cast you spell lvl 8 without participating", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "Elementalist_tsp", Name = "Elementalist", Color = "#FFFFF0", PremiumClass = true, ClassType = "Mixed", SelectedColor = "#e7e3e3", Spells = _spVM.ElementalistList, Aggressive = 3, Defensive = 2, Speed = 2, Entertaining = 3, GameClassInfo = "Elementalism is connected to psychic power and dreams. Historical records are not always clear, but are always present. It was often mistaken for witchcraft, resulting in the destruction of most human operators of the sixth sense.", RollEffect1 = "Target wizard can't level up this round", RollEffect2 = "Reroll but only 6 is valid.", RollEffect3 = "Give away half of your level in drinks to 2 wizards", RollEffect4 = "Use spell 5", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "Witch_tsp", Name = "Witch", Color = "#CCCC00", PremiumClass = true, ClassType = "Aggressive", SelectedColor = "#e5f27b", Spells = _spVM.WitchList, Aggressive = 4, Defensive = 2, Speed = 1, Entertaining = 2, GameClassInfo = "Early witches were people who practiced witchcraft, using magic spells and calling upon spirits for help or to bring about change. Most witches were thought to be pagans doing the Devil’s work. Many, however, were simply natural healers or so-called “wise women” whose choice of profession was misunderstood.", RollEffect1 = "Use your Corrupt Spell", RollEffect2 = "Clerics, druids, illusionists and pyromancers drink 2 drinks", RollEffect3 = "Immune for drinking punishments this turn", RollEffect4 = "All wizards but you drink 4 drinks", RollEffect5 = "", RollEffect6 = "Level up!" });
            ListClassLogo.Add(new GameClass { Picture = "Summoner_tsp", Name = "Summoner", Color = "#D0021B", PremiumClass = true, ClassType = "Mixed", Aggressive = 3, Defensive = 3, Speed = 3, Entertaining = 1, SelectedColor = "#F1574E", Spells = _spVM.SummonerList, GameClassInfo = "Summoner is the magical art of calling forth spirits, angels or demons to bring spiritual inspiration, do the bidding of the magician or provide information. Methods of this exist in many cultures that feature a belief in spirits, such as the shamanic traditions, Daoism, Spiritism and the African religions (Santería, Umbanda).", RollEffect1 = "All wizards drink 2 drinks, including you.", RollEffect2 = "Use Summon Inferno (Spell 2)", RollEffect3 = "Use T-rex Transformation untill its the targeted wizards turn, and reroll", RollEffect4 = "If targeted wizard rolls 5 or 6 you level up and he dismisses his roll", RollEffect5 = "", RollEffect6 = "Level up!" });
            ClassList = ListClassLogo;

            Dracsoris = new GameClass { Picture = "DragonBoss", Name = "Dracsoris", PremiumClass = false, Color = "#8B0000", ClassType = "MONSTER", SelectedColor = "#FF80AA", Spells = _spVM.DracsorisList, RollEffect1 = "Reroll", RollEffect2 = "You are immune this turn", RollEffect3 = "Every other wizard roll a die, highest roll drinks the amount he rolled", RollEffect4 = "Level up!", RollEffect5 = "", RollEffect6 = "Level up!" };
        }

        public List<GameClass> ClassList { get; set; }
        public List<GameClass> ExtraFragmentItemsList { get; set; }
        public GameClass Dracsoris { get; set; }
        public GameClass SelectedClass { get; set; }
    }
}