using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DrunkenWizard_API.Repos;
using System.Threading.Tasks;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Interfaces;
using DrunkenWizard_API.Entities;
using Newtonsoft.Json;
using DrunkenWizard_API.Enums;

namespace DrunkenWizard_API.Hubs
{
    public class PlayerHub: Hub
    {
        private Repository _repository { get; set; }
        private IPlayerService _PlayerService { get; set; }
       // Dictionary<string, string> PlayersDictionary;
        public PlayerHub(Repository repository, IPlayerService playerservice)
        {
            this._PlayerService = playerservice;
            this._repository = repository;                     
        }
        public void GetAllExistingPlayersFromGame(int key)
        {
            try
            {  
                Join(key.ToString());
                var players = _PlayerService.GetExistingPlayersFromGame(key).ToList();
                string json = JsonConvert.SerializeObject(players);
                Clients.Group(key.ToString()).SendAsync("GetAllExistingPlayersFromGame", json);
            }
            catch (Exception e)
            {
                var d = e;
            }  
        }

        //public void LeaveGame(int playerid)
        //{
        //    try
        //    {
        //        Player deleteplayer = _repository.Player.Where(x => x.Id == playerid).Include("Game").FirstOrDefault();
        //        int key = deleteplayer.Game.Key;
        //        Remove(key.ToString());
        //        _PlayerService.RemovePlayer(playerid);
        //        var players = _PlayerService.GetExistingPlayersFromGame(key).ToList();
        //        string json = JsonConvert.SerializeObject(players);
        //        Clients.Group(key.ToString()).SendAsync("GetAllExistingPlayersFromGame", json);
        //    }
        //    catch (Exception e)
        //    {
        //        var data = e;
        //    }
        //}

        public void LeaveGame(int playerid)
        {
            try
            {
                Player deleteplayer = _repository.Player.Where(x => x.Id == playerid).Include("Game").FirstOrDefault();
                int key = deleteplayer.Game.Key;
                Remove(key.ToString());
                _PlayerService.RemovePlayer(playerid);
                //var players = _PlayerService.GetExistingPlayersFromGame(key).ToList();
                //string json = JsonConvert.SerializeObject(players);
                Clients.Group(key.ToString()).SendAsync("RemovePlayer",playerid);
            }
            catch (Exception e)
            {
                var data = e;
            }
        }

        //public void RemovePlayer(int playerid) 
        //{
        //    try
        //    {
        //        Player deleteplayer = _repository.Player.Where(x => x.Id == playerid).Include("Game").FirstOrDefault();
        //        int key = deleteplayer.Game.Key;
        //        _PlayerService.RemovePlayer(playerid);
        //        var players = _PlayerService.GetExistingPlayersFromGame(key).ToList();
        //        string json = JsonConvert.SerializeObject(players);
        //        Clients.Group(key.ToString()).SendAsync("GetAllExistingPlayersFromGame", json);
        //    }
        //    catch (Exception e)
        //    {
        //        var data = e;
        //    }
        //}


        public void RemovePlayer(int playerid)
        {
            try
            {
                Player deleteplayer = _repository.Player.Where(x => x.Id == playerid).Include("Game").FirstOrDefault();
                int key = deleteplayer.Game.Key;
                _PlayerService.RemovePlayer(playerid);
                //var players = _PlayerService.GetExistingPlayersFromGame(key).ToList();
                //string json = JsonConvert.SerializeObject(players);
                Clients.Group(key.ToString()).SendAsync("RemovePlayer", playerid);
            }
            catch (Exception e)
            {
                var data = e;
            }
        }


        public void UpdateLevelPlayer(int playerID, int level) 
        {
            try
            {
              var player =  _PlayerService.UpdatePlayerLevel(playerID, level);           
                Clients.Group(player.GameKey.ToString()).SendAsync("UpdateLevelPlayer", playerID,level);
            }
            catch (Exception e)
            {
                var data = e;
            }

        }

        public void UpdateBoostPlayer(int playerID, bool boostUsed)
        {
            try
            {
                var player = _PlayerService.UpdatePlayerBoost(playerID, boostUsed);
                Clients.Group(player.GameKey.ToString()).SendAsync("UpdateBoostPlayer", playerID, boostUsed);
            }
            catch (Exception e)
            {
                var data = e;
            }

        }

        public void UpdateSlayedBeast(int playerID, BeastEnum slayedBeast)
        {
            try
            {
                
                var player = _PlayerService.UpdateslayedBeast(playerID, slayedBeast);
                Clients.Group(player.GameKey.ToString()).SendAsync("UpdateSlayedBeast", playerID, slayedBeast);
            }
            catch (Exception e)
            {
                var data = e;
            }

        }

        public void UpdateHost(int playerID, bool isHost)
        {
            try
            {
                var player = _PlayerService.UpdateHost(playerID, isHost);
                Clients.Group(player.GameKey.ToString()).SendAsync("UpdateHost", playerID, isHost);
            }
            catch (Exception e)
            {
                var data = e;
            }

        }

        public void UpdateGameClass(int playerID, string GameClass)
        {
            try
            {
                var player = _PlayerService.UpdateGameClass(playerID, GameClass);
                Clients.Group(player.GameKey.ToString()).SendAsync("UpdateGameClass", playerID, GameClass);
            }
            catch (Exception e)
            {
                var data = e;
            }

        }

        //public void UpdatePlayer(Player player)
        //{
        //    try
        //    {
        //         _PlayerService.UpdatePlayer(player);
        //        var players = _PlayerService.GetExistingPlayersFromGame(player.GameKey);

        //        string json = JsonConvert.SerializeObject(players);
        //        Clients.Group(players.FirstOrDefault().Game.Key.ToString()).SendAsync("GetAllExistingPlayersFromGame", json);
        //    }
        //    catch (Exception e)
        //    {
        //        var data = e;
        //    }
        //}


        public void JoinGame(JoinPlayerDTO joinplayerDTO)
        {
            try
            {
                var newplayer = _PlayerService.JoinGame(joinplayerDTO);
                Join(newplayer.GameKey.ToString());
                string json = JsonConvert.SerializeObject(newplayer);
                Clients.Group(newplayer.GameKey.ToString()).SendAsync("JoinGame", json);
            }
            catch (Exception e)
            {
                var data = e;
                Clients.Client(Context.ConnectionId).SendAsync("WrongKey", "null");
            }
        }




        public void AddPlayerLocal(JoinPlayerDTO joinplayerdto)
        {
            try
            {
                _PlayerService.AddPlayer(joinplayerdto);
                var players = _PlayerService.GetExistingPlayersFromGame(joinplayerdto.GameKey);
                string json = JsonConvert.SerializeObject(players);
                Clients.Group(players.FirstOrDefault().Game.Key.ToString()).SendAsync("GetAllExistingPlayersFromGame", json);
            }
            catch (Exception e)
            {
                var data = e;
            }
        }



        public void Join(string groupName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            //var players = _PlayerService.GetExistingPlayersFromGame(Convert.ToInt32(groupName)).ToList();
            //string json = JsonConvert.SerializeObject(players);
            //Clients.Group(groupName).SendAsync("GetAllExistingPlayersFromGame", json);
        }

        public void Remove(string groupName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
  
        
    }
}
