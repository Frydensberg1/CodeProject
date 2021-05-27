using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Interfaces;
using DrunkenWizard_API.Repos;

namespace DrunkenWizard_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _GameService { get; set; }

        public GameController(IGameService gameservice)
        {
            this._GameService = gameservice;
        }
        // POST api/values
        [HttpPost]
        [Route("CreateGame")]
        public ActionResult<Game> CreateGame()
        {
            try
            {
                return Ok(this._GameService.CreateGame());
            }
            catch (Exception e)
            {
                return BadRequest(
                    e.Message
                );
            }

        }

        [HttpGet]
        [Route("GetGame/{Key}")]
        public ActionResult<Game> GetGame(string Key)
        {
            try
            {
                return Ok(this._GameService.GetGame(Key));
            }
            catch (Exception e)
            {
                return BadRequest(
                   e.Message
               );
            }
        }

        [HttpGet]
        [Route("test")]
        public string GetGame()
        {
            return "nemt";
        }


        [HttpGet]
        [Route("Delete")]
        public void Delete()
        {
            try
            {
                this._GameService.DeleteEverythingInGame();
            }
            catch (Exception e)
            {

            }
        }


        [HttpGet]
        [Route("DeleteAllGames")]
        public string DeleteAllGames()
        {
            try
            {
                using (var context = new Repository())
                {
                    var data = context.Game.ToList();
                    foreach (var item in data)
                    {

                        context.Game.Remove(item);


                    }
                    context.SaveChanges();
                    return "Games deleted";
                }
            }
            catch (Exception e)
            {
                return e.ToString();

            }
        }


        //[HttpPost]
        //[Route("JoinGame")]
        //public ActionResult<JoinGameDTO> JoinGame([FromBody] Player player)
        //{
        //    try
        //    {
        //        return Ok(this._GameService.JoinGame(player));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(
        //           e.Message
        //       );
        //    }
        //}

        // DELETE Game 
        [HttpDelete]
        [Route("DeleteGame/{GameId}")]
        public void DeleteGame(int GameId)
        {
            try
            {
                this._GameService.DeleteGame(GameId);
            }
            catch (Exception e)
            {

            }
        }

    }
}