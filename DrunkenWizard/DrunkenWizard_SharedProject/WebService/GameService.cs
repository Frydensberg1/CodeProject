using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.Webservice
{
    public class GameService
    {
        private static readonly HttpClient clientHTTP = new HttpClient();
        string urlAPI = "https://drunkenwizard.azurewebsites.net";
        string ngrok = "http://9fed388cd313.ngrok.io";
        string testLive = "http://drinkinggame.azurewebsites.net";
     //   string local = "http://localhost:50057";
        ClassService _CS = ServiceContainer.Resolve<ClassService>();
        public List<Player> CurrentPlayers { get; set; }
        public async Task<List<Player>> GetAllExistingPlayersAsync(int Key)
        {
            try
            {
                List<Player> List = new List<Player>();
                string accept = "application/json";
                string url = urlAPI + "/api/Game/GetExistingPlayersFromGame/" + Key;
                clientHTTP.DefaultRequestHeaders.Add("Accept", accept);
                HttpResponseMessage response = await clientHTTP.GetAsync(url);
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                List = JsonConvert.DeserializeObject<List<Player>>(result);
                return List;
            }
            catch (Exception e)
            {
                var we = e;
                return null;
            }
        }

        public List<Player> GetAllExistingPlayers(int Key)
        {
            try
            {
                List<Player> List = new List<Player>();
                string accept = "application/json";
                string url = urlAPI + "/api/Player/GetExistingPlayersFromGame/" + Key;
                clientHTTP.DefaultRequestHeaders.Add("Accept", accept);
                HttpResponseMessage response = clientHTTP.GetAsync(url).Result;
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                List = JsonConvert.DeserializeObject<List<Player>>(result);
                return List;
            }
            catch (Exception e)
            {
                var we = e;
                return null;
            }
        }

        public async Task<Game> CreateGameAsync()
        {
            try
            {
                string url = urlAPI + "/api/Game/CreateGame";
                var response = await clientHTTP.PostAsync(url, null);
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                var game = JsonConvert.DeserializeObject<Game>(result);

                if (game != null)
                {
                    return game;
                }
                else return null;
            }

            catch (Exception e)
            {
                var data = e;
                return null;
            }
        }


        public async Task<Player> JoinGameAsync(Player player, int Key)
        {
            try
            {
                JoinGameDTO joingamedata = new JoinGameDTO
                {
                    key = Key,
                    Name = player.Name,
                    Level = player.Level,
                    GameClassName = player.GameClass.Name,
                    picture = player.GameClass.Picture,
                    SlayedBeast = player.SlayedBeast,
                    IsHost = player.IsHost
                };
                string json = JsonConvert.SerializeObject(joingamedata);

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                string url = urlAPI + "/api/Game/JoinGame";
                HttpResponseMessage response = await clientHTTP.PostAsync(url, httpContent);
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                var Newplayer = JsonConvert.DeserializeObject<JoinGameDTO>(result);

                GameClass newclass = new GameClass()
                {
                    Id = Newplayer.GameClassId,
                    Picture = Newplayer.picture,
                    Name = Newplayer.GameClassName,
                    Spells = Newplayer.Spells
                };

                Player newPlayer = new Player()
                {
                    Id = Newplayer.PlayerId,
                    GameClass = newclass,
                    Name = Newplayer.Name,
                    Level = Newplayer.Level,
                    SlayedBeast = Newplayer.SlayedBeast,
                    GameId = Newplayer.GameId,
                    BoostUsed = Newplayer.BoostUsed,
                    IsHost = Newplayer.IsHost
                };

                return newPlayer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Player JoinGame(Player player, int Key)
        {
            try
            {
                JoinGameDTO joingamedata = new JoinGameDTO
                {
                    key = Key,
                    Name = player.Name,
                    Level = player.Level,
                    GameClassName = player.GameClass.Name,
                    picture = player.GameClass.Picture,
                    SlayedBeast = player.SlayedBeast,
                    IsHost = player.IsHost

                };
                string json = JsonConvert.SerializeObject(joingamedata);

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                string url = urlAPI + "/api/Game/JoinGame";
                HttpResponseMessage response = clientHTTP.PostAsync(url, httpContent).Result;
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                var Newplayer = JsonConvert.DeserializeObject<JoinGameDTO>(result);
                GameClass newclass = new GameClass()
                {
                    Id = Newplayer.GameClassId,
                    Picture = Newplayer.picture,
                    Name = Newplayer.GameClassName
                };

                Player newPlayer = new Player()
                {
                    Id = Newplayer.PlayerId,
                    GameClass = newclass,
                    Name = Newplayer.Name,
                    Level = Newplayer.Level,
                    SlayedBeast = Newplayer.SlayedBeast,

                    GameId = Newplayer.GameId,
                    BoostUsed = Newplayer.BoostUsed,
                    IsHost = Newplayer.IsHost
                };

                return newPlayer;

            }
            catch (Exception)
            {

                return null;
            }
        }


        public Game GetGame(int Key)
        {
            try
            {
                string accept = "application/json";
                string url = urlAPI + "/api/Game/GetGame/" + Key.ToString();
                clientHTTP.DefaultRequestHeaders.Add("Accept", accept);
                HttpResponseMessage response = clientHTTP.GetAsync(url).Result;
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Game>(result);
                return data;
            }
            catch (Exception e)
            {
                var we = e;
                return null;
            }
        }

        public void DeleteGame(int GameId)
        {
            try
            {
                string accept = "application/json";
                // string url = urlAPI + "/api/Game/DeleteGame/" + GameId;
                string url = urlAPI + "/api/Game/DeleteGame/" + GameId;
                clientHTTP.DefaultRequestHeaders.Add("Accept", accept);
                HttpResponseMessage response = clientHTTP.DeleteAsync(url).Result;
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}