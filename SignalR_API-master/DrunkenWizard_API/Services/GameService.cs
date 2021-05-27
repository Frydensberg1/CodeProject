
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.Repos;

namespace DrunkenWizard_API.Services
{
    public class GameService : IGameService
    {
        private Repository _repository { get; set; }

        public GameService(Repository repository)
        {

            this._repository = repository;

        }
        public Game CreateGame()
        {
            Random rnd = new Random();
            int key = rnd.Next(100000, 999999);
            Game game = new Game()
            {
                Key = key,
            };

            _repository.Game.Add(game);
            _repository.SaveChanges();

            return this._repository.Game.FirstOrDefault(x => x.Key == key);
        }


        public Game GetGame(string Key)
        {
            if (_repository.Game.FirstOrDefault(x => x.Key == Convert.ToInt32(Key)) != null)
            {
                var GamewithSameKey = _repository.Game.FirstOrDefault(x => x.Key == Convert.ToInt32(Key));
                return GamewithSameKey;
            }
            else
            {
                return null;
            }
        }


        public void DeleteEverythingInGame()
        {
            foreach (var item in _repository.Game)
            {
                _repository.Game.Remove(item);

            }

            foreach (var item in _repository.Player)
            {
                _repository.Player.Remove(item);

            }
            _repository.SaveChanges();

        }


     

        public Game GetGameWIthKey(int key)
        {
            var Game = _repository.Game.FirstOrDefault(x => x.Key == key);
            return Game;
        }

     

        public GameClass GetClassMatchingId(Player player)
        {
            var Class = _repository.GameClass.FirstOrDefault(x => x.Name == player.GameClass.Name);
            return Class;
        }

        public void DeleteGame(int Key)
        {
            var data = _repository.Game.FirstOrDefault(x => x.Key == Key);
            if (data != null)
            {
                foreach (var item in _repository.Player.Where(x => x.GameId == data.Id))
                {
                    _repository.Player.Remove(item);
                }

                _repository.Game.Remove(data);
                _repository.SaveChanges();
            }
        }
    }
}
