
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DrunkenWizard_API.Repos;
using System.Threading.Tasks;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Interfaces;
using DrunkenWizard_API.Entities;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace DrunkenWizard_API.Hubs
{
    public class GameHub: Hub
    {
        private Repository _repository { get; set; }
        private IGameService _GameService { get; set; }

        public GameHub(Repository repository, IGameService gameservice)
        {
            this._GameService = gameservice;
            this._repository = repository;
        }
        public void CreateGame()
        {
            try
            {
                var game = _GameService.CreateGame();
                Join(game.Key.ToString());
                //   Clients.Group(message.Group).SendAsync(message.Group, "GroupMessage" + message.Msg);
                // Clients.All.SendAsync("CreateGame", game);
                string json = JsonConvert.SerializeObject(game);
                Clients.Group(game.Key.ToString()).SendAsync("CreateGame", json);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void test() 
        {
             Clients.All.SendAsync("test", "nemt");
        }


       

        public void DeleteGame(int Key)
        {
            try
            {
                Remove(Key.ToString());
                _GameService.DeleteGame(Key);
                
            }
            catch (Exception e)
            {

                var d = e;
            }
            
        }




        public void Join(string groupName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public void Remove(string groupName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
