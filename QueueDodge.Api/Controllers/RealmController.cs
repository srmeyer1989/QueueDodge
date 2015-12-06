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
    [RoutePrefix("api/region/{regionID}")]
    public class RealmController : ApiController
    {
        private RealmService realms;

        public RealmController()
        {
            realms = new RealmService();
        }

        [HttpGet]
        [Route("realm")]
        public IEnumerable<Realm> Get(int regionID)
        {
            var selectedRegion = (BattleDotNet.Region)regionID;
            return realms.GetRealms(selectedRegion).OrderBy(p => p.Name);
        }
    }
}
