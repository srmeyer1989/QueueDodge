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
    [RoutePrefix("api/region")]
    public class RegionController : ApiController
    {
        private RegionService regions;

        public RegionController()
        {
            regions = new RegionService();
        }

        [HttpGet]
        public IEnumerable<Region> GetRegions()
        {
            return regions.GetRegions();
        }
    }
}
