using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrunkenWizard_API.DTO;
using DrunkenWizard_API.Entities;
using DrunkenWizard_API.Interfaces;
using DrunkenWizard_API.Repos;

namespace DrunkenWizard_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _PlayerService { get; set; }

        public PlayerController(IPlayerService playerservice)
        {
            this._PlayerService = playerservice;
        }

        [HttpGet]
        [Route("GetAllExistingPlayers")]
        public ActionResult<IEnumerable<Player>> GetAllExistingPlayers()
        {
            try
            {
                return Ok(this._PlayerService.GetAllExistingPlayers());
            }
            catch (Exception e)
            {
                return BadRequest(
                    e.Message
                );
            }
        }


        [HttpGet]
        [Route("GetExistingPlayersFromGame/{Key}")]
        public ActionResult<List<Player>> GetExistingPlayersFromGame(int Key)
        {
            try
            {
                return Ok(this._PlayerService.GetExistingPlayersFromGame(Key));
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
        public string test()
        {
            return "hihi";
        }


        // GET api/values/5
        [HttpGet]
        [Route("GetSpecificPlayer/{id}")]
        public ActionResult<string> GetSpecificPlayer(string player)
        {
            try
            {
                return Ok(this._PlayerService.GetSpecificPlayer(player));
            }
            catch (Exception e)
            {
                return BadRequest(
                    e.Message
                );
            }
        }

        // PUT api/values/5
        [HttpPut]
        [Route("UpdatePlayerChangeClass")]
        public void UpdatePlayerChangedClass([FromBody] ChangeClassDTO player_ccDTO)
        {
            try
            {
                //this._PlayerService.UpdatePlayerChangedClass(player_ccDTO);
            }
            catch (Exception e)
            {

            }
        }

        [HttpGet]
        [Route("DeleteAllPlayers")]
        public string DeleteAllPlayers()
        {
            try
            {
                using (var context = new Repository())
                {
                    var data = context.Player.ToList();
                    foreach (var item in data)
                    {

                        context.Player.Remove(item);


                    }
                    context.SaveChanges();
                    return "Players deleted";
                }
            }
            catch (Exception e)
            {
                return e.ToString();

            }
        }


        //[HttpPut]
        //[Route("UpdatePlayer")]
        //public void UpdatePlayer([FromBody] Player player)
        //{
        //    try
        //    {
        //        this._PlayerService.UpdatePlayer(player);
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        [HttpPut]
        [Route("AddPlayer")]
        public void AddPlayer([FromBody] JoinPlayerDTO joinplayerdto)
        {
            try
            {
                this._PlayerService.AddPlayer(joinplayerdto);
            }
            catch (Exception e)
            {

            }

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("RemovePlayer/{playerid}")]
        public void RemovePlayer(int playerid)
        {
            try
            {
                this._PlayerService.RemovePlayer(playerid);
            }
            catch (Exception e)
            {

            }
        }
    }
}