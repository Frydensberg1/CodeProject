using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using DrunkenWizard_SharedProject.Models;

namespace DrunkenWizard_SharedProject.Webservice
{
    public class ClassService
    {
        private static readonly HttpClient clientHTTP = new HttpClient();
        string urlAPI = "http://drunkenwizard.azurewebsites.net";
        string testlocal = "http://localhost:55158";

        public void Addclass(GameClass addclass)
        {
            string json = JsonConvert.SerializeObject(addclass);
            string url = urlAPI + "/api/Class/addclass";
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = clientHTTP.PostAsync(url, httpContent).Result;
            HttpStatusCode statusCode = response.StatusCode;
            string result = response.Content.ReadAsStringAsync().Result;
        }

        public GameClass GetClass(int ClassKey)
        {
            try
            {             
                string accept = "application/json";
                string url = urlAPI + "/api/Class/GetClass/" + ClassKey.ToString();
                clientHTTP.DefaultRequestHeaders.Add("Accept", accept);
                HttpResponseMessage response = clientHTTP.GetAsync(url).Result;
                HttpStatusCode statusCode = response.StatusCode;
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<GameClass>(result);
                return data;
            }
            catch (Exception e)
            {
                var we = e;
                return null;
            }
        }
    }
}