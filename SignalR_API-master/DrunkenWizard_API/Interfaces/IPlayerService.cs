using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Enums;

namespace DrunkenWizard_API.Interfaces
{
   public interface IPlayerService
    {
        IEnumerable<Player> GetAllExistingPlayers();
        Player GetSpecificPlayer(string player);
        List<Player> GetExistingPlayersFromGame(int Key);
        //Player UpdatePlayerChangedClass(ChangeClassDTO player_ccDTO);
        void UpdatePlayer(Player player);
        Player UpdatePlayerLevel(int playerID, int level);
        Player UpdatePlayerBoost(int playerID, bool boostUsed);
        Player UpdateslayedBeast(int playerID, BeastEnum slayedBeast);
        Player UpdateHost(int playerID, bool isHost);
        Player UpdateGameClass(int playerID, string GameClass);
        Player JoinGame(JoinPlayerDTO joinplayerdto);
        void AddPlayer(JoinPlayerDTO joinplayerdto);
        void RemovePlayer(int playerid);
    }
}
