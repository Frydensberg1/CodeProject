
using DrunkenWizard_SharedProject.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenWizard_SharedProject.WebService.Hubs
{
  public class GameHub
    {
        HubConnection hubConn;
    //    string local = "http://localhost:50057";
        string ngrok = "http://9fed388cd313.ngrok.io";
        string testLive = "http://drinkinggame.azurewebsites.net";
        string hosted = "http://drunkenwizard.azurewebsites.net";
      
        public EventHandler<Game> CreateGameReturnedGame;
        public GameHub() 
        {
            
        }

        public void CreateGame()
        {
            try
            {
                hubConn = new HubConnectionBuilder().WithUrl(hosted + "/GameHub").Build();
                hubConn.On("CreateGame", (string json) =>
                {
                    var game = JsonConvert.DeserializeObject<Game>(json);
                    CreateGameReturnedGame?.Invoke(this, game);
                });

                hubConn.StartAsync().Wait();

                hubConn.InvokeAsync("CreateGame");
            }
            catch (Exception e )
            {
                var d = e;
            }
        }


        public void RemoveCLientFromGame(string GameKeyGroupName) 
        {
            hubConn.InvokeAsync("Remove", GameKeyGroupName).Wait();
            hubConn.StopAsync();
        }

      


        public void DeleteGame(int Key) 
        {
            hubConn.InvokeAsync("DeleteGame", Key);
            hubConn.StopAsync();

        }

    }
}
