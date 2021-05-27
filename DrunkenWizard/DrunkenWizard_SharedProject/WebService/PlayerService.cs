using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using DrunkenWizard_SharedProject.DTO;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.Webservice
{
    public class PlayerService
    {
        private static readonly HttpClient clientHTTP = new HttpClient();
        string urlAPI = "https://drunkenwizard.azurewebsites.net";
      //  string local = "http://localhost:50057";
        string ngrok = "http://9fed388cd313.ngrok.io";
        string testLive = "http://drinkinggame.azurewebsites.net";
        public  PlayerService()
        {

        }

        public void UpdatePlayer(Player player)
        {

            string json = JsonConvert.SerializeObject(player);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            string url = urlAPI + "/api/Player/UpdatePlayer";
            HttpResponseMessage response = clientHTTP.PutAsync(url, httpContent).Result;
            // Tjek status koden på din request.
            HttpStatusCode statusCode = response.StatusCode;
            // Få data fra din request tilbage i string format.
            string result = response.Content.ReadAsStringAsync().Result;

        }


        public void UpdatePlayerChangeClass(Player PlayerChange)
        {
            ChangeClassDTO player = new ChangeClassDTO
            {
                PlayerId = PlayerChange.Id, 
                GameClassName = PlayerChange.GameClass.Name
            };
            string json = JsonConvert.SerializeObject(player);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            string url = urlAPI + "/api/Player/UpdatePlayerChangeClass";
            HttpResponseMessage response = clientHTTP.PutAsync(url, httpContent).Result;
            // Tjek status koden på din request.
            HttpStatusCode statusCode = response.StatusCode;
            // Få data fra din request tilbage i string format.
            string result = response.Content.ReadAsStringAsync().Result;

        }

        public void DeletePlayer(int playerid)
        { 
            string url = urlAPI + "/api/Player/RemovePlayer/" + playerid;
            string accept = "application/json";
            clientHTTP.DefaultRequestHeaders.Add("Accept", accept);
            HttpResponseMessage response = clientHTTP.DeleteAsync(url).Result;
            // Tjek status koden på din request.
            HttpStatusCode statusCode = response.StatusCode;
            // Få data fra din request tilbage i string format.
            string result = response.Content.ReadAsStringAsync().Result;

        }
    }
}