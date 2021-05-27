using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.Table;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DrunkenWizard_SharedProject.ViewModels
{
    public class SQLiteViewModel
    {
        SQLiteConnection _db;
        public  Language CurrentLanguage { get; set; } = new Language();
        public SQLiteViewModel()
        {
            var dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db");
            _db = new SQLiteConnection(dpPath);
            _db.CreateTable<PlayerTable>();
            _db.CreateTable<Language>();


        }

        public void ChangeLanguage(string LanguageCode) 
        {
          var languge =  GetLanguage();
            if (languge != null)
            {
                languge.LanguageCode = LanguageCode;
                _db.Update(languge);
                CurrentLanguage = languge;
            }
            else
            {
              var newlanguage =  new Language()  { LanguageCode = LanguageCode };
                _db.Insert(newlanguage);
                CurrentLanguage = newlanguage;
            }
   
        }

        public Language GetLanguage()
        {
            var languagetable = _db.Table<Language>().FirstOrDefault();
            if (string.IsNullOrWhiteSpace(languagetable?.LanguageCode))
            {
                return languagetable;
            }
            return null;
        }


        public void SavePlayer(int id, int key, int gameid, bool ishost)
        {
            var obj = new PlayerTable
            {
                Id = id,
                GameKey = key,
                GameId = gameid,
                IsHost = ishost
            };
            _db.Insert(obj);
        }

        public Player GetLocalPlayer()
        {
            var playertable = _db.Table<PlayerTable>().FirstOrDefault();
            if (playertable != null)
            {
                Player player = new Player { Id = playertable.Id, GameKey = playertable.GameKey, GameId = Convert.ToInt32(playertable.GameId), IsHost = playertable.IsHost };
                return player;
            }
            else
            {
                return null;
            }
        }

        public void UpdateLocalPlayer(Player player)
        {
            var playertable = _db.Table<PlayerTable>().FirstOrDefault(x => x.Id == player.Id);
            playertable.IsHost = player.IsHost;
            _db.Update(playertable);
        }

        public void Delete(Player player)
        {
            try
            {
                var playertable = _db.Table<PlayerTable>().FirstOrDefault(x => x.Id == player.Id);
                _db.Delete(playertable);
            }
            catch (Exception e)
            {
                var d = e;
            }
        }
    }
}
