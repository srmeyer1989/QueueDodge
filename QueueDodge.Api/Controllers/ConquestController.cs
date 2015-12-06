using QueueDodge.Integrations;
using QueueDodge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueueDodge.Api.Controllers
{
    [Route("conquest")]
    public class ConquestController : ApiController
    {
        private ConquestIntegrationService conquestService;

        public ConquestController()
        {
            conquestService = new ConquestIntegrationService();
        }

        [HttpGet]
        [Route("conquest")]
        public ConquestCap Get([FromUri]int arenaRating, [FromUri]int bgRating)
        {
            return conquestService.GetConquestCap(BattleDotNet.Region.us, ".battle.net/", BattleDotNet.Game.wow, BattleDotNet.Locale.en_us, arenaRating, bgRating);
        }
    }
}
