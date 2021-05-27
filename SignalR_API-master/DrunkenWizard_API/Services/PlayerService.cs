
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Enums;
using DrunkenWizard_API.Interfaces;
using DrunkenWizard_API.Repos;
using Microsoft.EntityFrameworkCore;

namespace DrunkenWizard_API.Services
{
    public class PlayerService : IPlayerService
    {
        private Repository _repository { get; set; }

        public PlayerService(Repository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Player> GetAllExistingPlayers()
        {
            return _repository.Player.ToList();
        }


        public List<Player> GetExistingPlayersFromGame(int Key)
        {
            try
            {
                var GameWithSameKey = _repository.Game.FirstOrDefault(x => x.Key == Key);
                var PlayersInTheGame = _repository.Player.Where(x => x.GameId == GameWithSameKey.Id).ToList();
                if (PlayersInTheGame != null)
                {
                    foreach (var player in PlayersInTheGame)
                    {
                        player.GameClass = _repository.GameClass.FirstOrDefault(x => x.Id == player.GameClassId);
                        player.GameClass.Spells = _repository.Spell.Where(x => x.GameClassId == player.GameClass.Id).ToList();
                    }
                    return PlayersInTheGame;
                }

                else return null;
            }
            catch (Exception e)
            {
                var data = e;
                return null;
            }
        }

        public Player GetSpecificPlayer(string playerID)
        {
            return _repository.Player.SingleOrDefault(x => x.Id == Convert.ToInt32(playerID));
        }

        //public Player UpdatePlayerChangedClass(ChangeClassDTO player_ccDTO)
        //{
        //    var Classobj = _repository.GameClass.FirstOrDefault(x => x.Name == player_ccDTO.ClassName);
        //    var playerfromdb = _repository.Player.Where(x => x.Id == player_ccDTO.PlayerId).Include("Game").FirstOrDefault(); 
        //    playerfromdb.GameClassId = Classobj.Id;
        //    _repository.Player.Update(playerfromdb);
        //    _repository.SaveChanges();
        //    return playerfromdb;
        //}

        public void UpdatePlayer(Player player)
        {
            if (player != null)
            {
                if (player.Id != 0)
                {
                    var existingplayer = _repository.Player.FirstOrDefault(x => x.Id == player.Id);
                    if (existingplayer != null)
                    {
                        try
                        {
                            existingplayer.BoostUsed = player.BoostUsed;
                            existingplayer.IsHost = player.IsHost;
                            existingplayer.Level = player.Level;
                            existingplayer.LocalPLayer = player.LocalPLayer;
                            existingplayer.Name = player.Name;
                            existingplayer.SlayedBeast = player.SlayedBeast;

                            if (player.GameClass != null)
                            {
                                var existinggameclass = _repository.GameClass.FirstOrDefault(x => x.Name == player.GameClass.Name);
                                existingplayer.GameClassId = existinggameclass.Id;
                            }
                            _repository.Player.Update(existingplayer);
                            _repository.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            var d = e;
                            throw;
                        }

                    }


                }

            }

        }


        public Player JoinGame(JoinPlayerDTO joinplayerDTO)
        {
            Game GameWIthKey = GetGameWIthKey(joinplayerDTO.GameKey);
            GameClass ClassMatchingId = GetClassMatchingId(joinplayerDTO.ClassName);
            Player newplayer = new Player()
            {
                Name = joinplayerDTO.Name,
                BoostUsed = false,
                IsHost = joinplayerDTO.IsHost,
                Level = joinplayerDTO.Level,
                LocalPLayer = joinplayerDTO.LocalPLayer,
                PremiumAccount = joinplayerDTO.PremiumAccount,
                SlayedBeast = joinplayerDTO.SlayedBeast,


            };

            if (GameWIthKey != null)
            {
                newplayer.GameId = GameWIthKey.Id;
                newplayer.GameKey = GameWIthKey.Key;
            }
            else
            {
                return null;
            }

            if (ClassMatchingId != null)
            {
                newplayer.GameClassId = ClassMatchingId.Id;

            }

            _repository.Player.Add(newplayer);
            _repository.SaveChanges();
            return getplayerback(newplayer);
            // player.GameClass.Spells = _repository.Spell.Where(x => x.GameClassId == player.GameClass.Id).ToList();
        }

        Player getplayerback(Player player)
        {
            player.GameClass = _repository.GameClass.FirstOrDefault(x => x.Id == player.GameClassId);
            player.GameClass.Spells = _repository.Spell.Where(x => x.GameClassId == player.GameClass.Id).ToList();
            return player;
        }


        public void AddPlayer(JoinPlayerDTO joinplayerdto)
        {
            Game GameWIthKey = GetGameWIthKey(joinplayerdto.GameKey);
            GameClass ClassMatchingId = GetClassMatchingId(joinplayerdto.ClassName);
            Player newplayer = new Player
            {
                Name = joinplayerdto.Name,
                Level = joinplayerdto.Level,
                SlayedBeast = joinplayerdto.SlayedBeast,
                IsHost = joinplayerdto.IsHost,
                BoostUsed = joinplayerdto.BoostUsed,
                LocalPLayer = joinplayerdto.LocalPLayer,
                GameKey = joinplayerdto.GameKey,
                PremiumAccount = joinplayerdto.PremiumAccount
            };

            if (GameWIthKey != null)
            {
                newplayer.GameId = GameWIthKey.Id;
            }
            if (ClassMatchingId != null)
            {
                newplayer.GameClassId = ClassMatchingId.Id;

            }
            _repository.Player.Add(newplayer);
            _repository.SaveChanges();
        }
        public Game GetGameWIthKey(int key)
        {
            var Game = _repository.Game.FirstOrDefault(x => x.Key == key);
            return Game;
        }
        public GameClass GetClassMatchingId(string classname)
        {
            var Class = _repository.GameClass.FirstOrDefault(x => x.Name == classname);
            return Class;
        }
        public void RemovePlayer(int playerid)
        {
            Player deleteplayer = _repository.Player.FirstOrDefault(x => x.Id == playerid);
            _repository.Player.Remove(deleteplayer);
            _repository.SaveChanges();
        }

        public Player UpdatePlayerLevel(int playerID, int level)
        {
            if (playerID != 0)
            {
                    var existingplayer = _repository.Player.FirstOrDefault(x => x.Id == playerID);
                    if (existingplayer != null)
                    {
                        try
                        {
                            existingplayer.Level = level;
                            _repository.Player.Update(existingplayer);
                            _repository.SaveChanges();
                        return existingplayer;
                        }
                        catch (Exception e)
                        {
                            var d = e;
                            throw;
                        }
                    }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Player UpdatePlayerBoost(int playerID, bool boostUsed)
        {
            if (playerID != 0)
            {
                var existingplayer = _repository.Player.FirstOrDefault(x => x.Id == playerID);
                if (existingplayer != null)
                {
                    try
                    {
                        existingplayer.BoostUsed = boostUsed;
                        _repository.Player.Update(existingplayer);
                        _repository.SaveChanges();
                        return existingplayer;
                    }
                    catch (Exception e)
                    {
                        var d = e;
                        throw;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Player UpdateslayedBeast(int playerID, BeastEnum slayedBeast)
        {
            if (playerID != 0)
            {
                var existingplayer = _repository.Player.FirstOrDefault(x => x.Id == playerID);
                if (existingplayer != null)
                {
                    try
                    {
                        existingplayer.SlayedBeast = slayedBeast;
                        _repository.Player.Update(existingplayer);
                        _repository.SaveChanges();
                        return existingplayer;
                    }
                    catch (Exception e)
                    {
                        var d = e;
                        throw;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Player UpdateHost(int playerID, bool isHost)
        {
            if (playerID != 0)
            {
                var existingplayer = _repository.Player.FirstOrDefault(x => x.Id == playerID);
                if (existingplayer != null)
                {
                    try
                    {
                        existingplayer.IsHost = isHost;
                        _repository.Player.Update(existingplayer);
                        _repository.SaveChanges();
                        return existingplayer;
                    }
                    catch (Exception e)
                    {
                        var d = e;
                        throw;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Player UpdateGameClass(int playerID, string GameClass)
        {
            if (playerID != 0)
            {
                var existingplayer = _repository.Player.FirstOrDefault(x => x.Id == playerID);
                var gameclass =_repository.GameClass.FirstOrDefault(x => x.Name == GameClass);
                if (existingplayer != null)
                {
                    try
                    {
                        existingplayer.GameClassId = gameclass.Id;
                        _repository.Player.Update(existingplayer);
                        _repository.SaveChanges();
                        return existingplayer;
                    }
                    catch (Exception e)
                    {
                        var d = e;
                        throw;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
