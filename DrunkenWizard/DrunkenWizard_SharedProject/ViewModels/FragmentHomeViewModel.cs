using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.ViewModels
{
    public  class FragmentHomeViewModel
    {
       public FragmentHomeViewModel() { }
        public bool Host { get; set; }
        public Player ThisPlayer { get; set; }
        public GameClass ClassPicture(string classname)
        {
            GameClass newclass = new GameClass()
            {
                Name = classname,
                Picture = GetClassImage(classname),
                PremiumClass = CheckIfPremium(classname)
            };
            return newclass;
        }

        public string GetClassImage(string classname)
        {
            string ClassImage = "";
            switch (classname)
            {
                case "Necromancer":
                    ClassImage = "NecromancerLogo_tsp";
                    break;
                case "Pyromancer":
                    ClassImage = "PyromancerLogo_tsp";
                    break;
                case "Cleric":
                    ClassImage ="ClericLogo_tsp";
                    break;
                case "Druid":
                    ClassImage = "DruidLogo_tsp";
                    break;
                case "Warlock":
                    ClassImage ="WarlockLogo_tsp";
                    break;
                case "Illusionist":
                    ClassImage = "IllusionistLogo_tsp";
                    break;
                case "Time Mage":
                    ClassImage = "TimeMage_tsp";
                    break;
                case "Disrupted Sorcerer":
                    ClassImage = "DistruptedSorcerer_tsp";
                    break;
                case "Shaman":
                    ClassImage = "Shaman_tsp";
                    break;
                case "Alchemist":
                    ClassImage = "Alchemist_tsp";
                    break;               
            }

            return ClassImage;
        }

        public bool CheckIfPremium(string classname)
        {
            
            if (classname == "Druid" || classname == "Cleric" || classname == "Illusionist")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }    
}

