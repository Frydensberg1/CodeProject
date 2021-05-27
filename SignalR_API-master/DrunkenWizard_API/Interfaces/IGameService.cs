using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrunkenWizard_API.Interfaces
{
    public interface IGameService
    {

        Game CreateGame();
        Game GetGame(string Key);

        void DeleteEverythingInGame();
        void DeleteGame(int Key);
    }
}
