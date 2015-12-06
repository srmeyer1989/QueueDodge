using QueueDodge.Models;
using QueueDodge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueueDodge.Api.Controllers
{
    [RoutePrefix("api/region/{regionID}/realm/{realmID}/character")]
    public class CharacterController : ApiController
    {
        private CharacterService characters;

        public CharacterController()
        {
            characters = new CharacterService();
        }

        [HttpGet]
        [Route("{name}")]
        public Character GetCharacters(int regionID, int realmID, string name)
        {
            return characters.GetCharacter(regionID, realmID, name);
        }
    }
}
