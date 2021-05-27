using System.Collections.Generic;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.ViewModels
{
    public class BossFightViewModel
    {
        public BossFightViewModel()
        {
            List<Monster> ListMonsters = new List<Monster>();
            ListMonsters.Add(new Monster { Picture = "Orecan", Name = "Orecan", Info = "Orecan is one of the only Silver Dragons left. For centuries he has been guarding the Holy area of Skyhouse. Nobody has ever passed Orecan, though plenty have tried....", Quest = "Wraaah who is the fool who thinks he can pass. Ha! You will never succeed! --  Finish 2 beers within one minute.", Reward = "The treasury hidden and guarded by Orecan, consists of a unique Scroll. With a formular for how to decrease all other wizards by 1 level and icrease yourself by 2. This scroll now belongs to you." });
            ListMonsters.Add(new Monster { Picture = "Trexzor", Name = "Trexzor", Info = "You have arrived in the dry hot extincted area of Orbet Canyon. The mighty beast, Trexzor, lives here and has done so for many years. Skeletons and half eaten creatures are to be found all over the place. You are face to face with Trexzor.", Quest = "Sssssoon you are aboutsss to become a ssskeleton! -- Drink 3 shots, mixed by your fellow wizards.", Reward = "You may increase a level, and decrease another wizard a level." });
            ListMonsters.Add(new Monster { Picture = "Ile", Name = "Ile", Info = "Millions of years ago, Ile produced a very special and rare form of metal, nothing has ever been able to penetrate Iles hard skin.", Quest = "Chug a beer, within 8 seconds. if failed, you may try again.", Reward = " The skin of Ile now belongs to you. Its power makes you immune to spells for the next 3 levels.(You can still use your own spells)." });
            ListMonsters.Add(new Monster { Picture = "Dracyllis", Name = "Dracyllis", Info = "Dracyllis the mighty old rust dragon, diving from the mountain at high speed looking for prey. He has spotted you...", Quest = "Dracyllis made such a strong gust that you have to spin around yourself 10 times. Afterwards chug a beer.", Reward = "You may reuse your boost" });
            ListMonsters.Add(new Monster { Picture = "Barcyl", Name = "Barcyl", Info = "You are facing Barcyl, The Swamp Beast. Due to poison so strong that even blue whales will perish by a single touch, Barcyl is the ruler of the underground.", Quest = "For each of the 3 bosses. Roll a dice. If it is 4-5-6 you will beat the boss. Otherwise you will drink the normal amount involved in the boss fights", Reward = "You have taken over a drop of Barcyl's strong poison, and now everytime you level up, every other wizards get a bit of the posion, and have to roll a dice. 3 or lower and they take a shot." });
            ListMonsters.Add(new Monster { Picture = "Zeodrenth", Name = "Zeodrenth", Info = "This formidable zombie dragon has killed more creatures than any other beings. Zeodrenth has eradicated civilizations all over the world, and is about to do it again.", Quest = "Pour 10 shots up, 5 with water and 5 with booze. Close your eyes and your fellow wizards mix the shots around. You have to drink 5 of the 10 shots in order to win the battle. Then you will have impressed Zeodrenth and he will grant you a reward.", Reward = "You may now roll 2 times every turn" });
            ListMonsters.Add(new Monster { Picture = "Dracenic", Name = "Dracenic", Info = "Ever experienced wild thunderstorms? It's nothing compared to when Dracenic is around. It is told that Dracenic has made thunder that has killed legions instantly", Quest = "Drink 2 shots without using your arms. If you spill more than a few drops, the quest is failed.", Reward = "Decrease 2 wizards by 1 level." });
            ListMonsters.Add(new Monster { Picture = "Dracsoris", Name = "Dracsoris", Info = "Dracsoris is the biggest dragon of all time. With a huge love for the secret Ice Tower, Dracsoris has never left the area. Nobody has ever managed to set foot in the Ice Tower.", Quest = "Balance a beer ontop of your hand and clsoe your eyes, while drinking an entire beer with the other hand. If failed, you have to empty your beer, before you can try again.", Reward = "You become Dracsoris for the rest of the game!" });
            MonsterList = ListMonsters;
        }

        public List<Monster> MonsterList { get; set; }
        public Player selectedplayer { get; set; }
        public Monster SelectedDragon { get; set; }
    }
}