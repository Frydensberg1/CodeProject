using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using Microsoft.AppCenter.Crashes;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenWizard_SharedProject.WebService.Hubs
{
    public class PlayerHub
    {
        HubConnection hubConn;
        //HubConnection hubConn2;
        //string local = "http://localhost:50057";
        string ngrok = "http://9fed388cd313.ngrok.io";
        string testLive = "http://drinkinggame.azurewebsites.net";
        string urlAPI = "https://drunkenwizard.azurewebsites.net";
        public EventHandler<List<Player>> GetExistingPlayers;
        public EventHandler<Player> ReturnedPlayer;
        public EventHandler<UpdateDTO> ReturnedUpdateLevel;
        public EventHandler<UpdateDTO> ReturnedUpdateBoostPlayer;
        public EventHandler<UpdateDTO> ReturnedUpdateSlayedBeast;
        public EventHandler<UpdateDTO> ReturnedUpdateHost;
        public EventHandler<UpdateDTO> ReturnedUpdateGameClass;
        public EventHandler<Exception> Reconnecting;
        public EventHandler<UpdateDTO> ReturnedDeletedPlayer; 
        public EventHandler<string> Reconnected;
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        public EventHandler<string> IsKeyCorrect;

        void InitHub()
        {
            // Hvis hubConn allerede findes, så gøre vi ikke mere.
            if (hubConn != null)
            {
                if (hubConn.State == HubConnectionState.Connected || hubConn.State == HubConnectionState.Connecting)
                    return;
                if (hubConn.State == HubConnectionState.Disconnected)
                    hubConn.StartAsync().Wait();
            }

            // Laver hubConn objektet
            hubConn = new HubConnectionBuilder().WithUrl(urlAPI + "/PlayerHub").WithAutomaticReconnect().Build();
            hubConn.Reconnecting += HubConn_Reconnecting;
            hubConn.Reconnected += HubConn_Reconnected;
            // Opretter alle handlere
            hubConn.On("GetAllExistingPlayersFromGame", (string json) =>
            {
                var list = JsonConvert.DeserializeObject<List<Player>>(json);
                GetExistingPlayers?.Invoke(this, list);
            });

            hubConn.On("JoinGame", (string json) =>
            {
                var newplayer = JsonConvert.DeserializeObject<Player>(json);
                ReturnedPlayer?.Invoke(this, newplayer);
            });

            hubConn.On("WrongKey", (string json) =>
            {
                ReturnedPlayer?.Invoke(this, null);
            });

            hubConn.On("RemovePlayer", (int playerID) =>
            {
                UpdateDTO update = new UpdateDTO();
                update.playerID = playerID;
                update.prop = playerID;
                ReturnedDeletedPlayer?.Invoke(this, update);
            });


            hubConn.On("UpdateLevelPlayer", (int playerID, int Level) =>
            {
                UpdateDTO update = new UpdateDTO();
                update.playerID = playerID;
                update.prop = Level;
                ReturnedUpdateLevel?.Invoke(this, update);
            });


            hubConn.On("UpdateBoostPlayer", (int playerID, bool boostUsed) =>
            {
                UpdateDTO update = new UpdateDTO();
                update.playerID = playerID;
                update.prop = boostUsed;
                ReturnedUpdateBoostPlayer?.Invoke(this, update);
            });

            hubConn.On("UpdateSlayedBeast", (int playerID, BeastEnum slayedBeast) =>
            {
                UpdateDTO update = new UpdateDTO();
                update.playerID = playerID;
                update.prop = slayedBeast;
                ReturnedUpdateSlayedBeast?.Invoke(this, update);
            });

            hubConn.On("UpdateHost", (int playerID, bool isHost) =>
            {

                UpdateDTO update = new UpdateDTO();
                update.playerID = playerID;
                update.prop = isHost;
                ReturnedUpdateHost?.Invoke(this, update);
            });

            hubConn.On("UpdateGameClass", (int playerID, string GameClassName) =>
            {
                UpdateDTO update = new UpdateDTO();
                update.playerID = playerID;
                update.prop = GameClassName;
                ReturnedUpdateGameClass?.Invoke(this, update);
            });
            try
            {
                hubConn.StartAsync().Wait();
            }
            catch (Exception e)
            {

                throw;
            }

        }

        private Task HubConn_Reconnected(string arg)
        {
            Reconnected?.Invoke(this, arg);
            return hubConn.InvokeAsync("GetAllExistingPlayersFromGame", _sqlVM.GetLocalPlayer().GameKey);
        }

        private Task HubConn_Reconnecting(Exception arg)
        {
            //InitHub();
            Reconnecting?.Invoke(this, arg);
            return hubConn.StartAsync();

        }

        public void ExistingPLayers(int key)
        {
            try
            {
                InitHub();
                hubConn.InvokeAsync("GetAllExistingPlayersFromGame", key);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void JoinGameAsync(JoinPlayerDTO playerDTO)
        {

            try
            {
                InitHub();
               hubConn.InvokeAsync("JoinGame", playerDTO);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;

            }
        }

        public void AddPlayerLocal(JoinPlayerDTO joinplayerdto)
        {
            try
            {
                InitHub();
                hubConn.InvokeAsync("AddPlayerLocal", joinplayerdto);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        //public void UpdatePlayer(Player player)
        //{
        //    try
        //    {
        //        hubConn.InvokeAsync("UpdatePlayer", player);
        //    }
        //    catch (Exception e)
        //    {
        //        Crashes.TrackError(e);
        //        var data = e;
        //    }
        //}
        public void UpdateLevelChange(int playerID, int Level)
        {
            try
            {
                hubConn.InvokeAsync("UpdateLevelPlayer", playerID, Level);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void UpdateBoostPlayer(int playerID, bool BoostUsed)
        {
            try
            {
                hubConn.InvokeAsync("UpdateBoostPlayer", playerID, BoostUsed);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void UpdateSlayedBeast(int playerID, BeastEnum slayedBeast)
        {
            try
            {
                hubConn.InvokeAsync("UpdateSlayedBeast", playerID, slayedBeast);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void UpdateHost(int playerID, bool isHost)
        {
            try
            {
                hubConn.InvokeAsync("UpdateHost", playerID, isHost); 
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                Debug.WriteLine(e);
                var data = e;
            }
        }

        public void UpdateChangeGameClass(int playerID, string GameClass)
        {
            try
            {
                hubConn.InvokeAsync("UpdateGameClass", playerID, GameClass);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void RemovePlayer(int playerID)
        {
            try
            {
                InitHub();
                hubConn.InvokeAsync("RemovePlayer", playerID);
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void Leavegame(int playerID)
        {
            try
            {
                InitHub();
                hubConn.InvokeAsync("LeaveGame", playerID);
                SetHubConnToNull();
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
                var data = e;
            }
        }

        public void SetHubConnToNull() 
        {
            hubConn = null;
        }

        public void SubscribeGettingExistingPlayers(int GameKey)
        {
            try
            {
                InitHub();
                hubConn.InvokeAsync("Join", GameKey.ToString()).Wait();
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
            }
        }
    }
}