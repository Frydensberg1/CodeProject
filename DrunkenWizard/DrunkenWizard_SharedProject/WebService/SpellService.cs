using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace DrunkenWizard_SharedProject.Webservice
{
   public class SpellService
    {
        private static readonly HttpClient clientHTTP = new HttpClient();
        string urlAPI = "https://drinkinggame.azurewebsites.net";
        string testlocal = "http://localhost:55158";
    }
}