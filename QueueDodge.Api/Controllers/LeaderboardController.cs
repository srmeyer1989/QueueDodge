using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QueueDodge.Models;
using QueueDodge.Services;
using Microsoft.AspNet.SignalR;
using QueueDodge.Api.Hubs;

namespace QueueDodge.Api.Controllers
{
    [RoutePrefix("api/region/{region}/leaderboard")]
    public class LeaderboardController : ApiController
    {
        private LeaderboardService leaderboards { get; set; }
        public LeaderboardController() {
            leaderboards = new LeaderboardService();
        }

        [HttpGet]
        [Route("{bracket}")]
        public IEnumerable<LadderChange> GetRecentActivity(string bracket, [FromUri] string region)
        {
            BattleDotNet.Region regionCode = (BattleDotNet.Region)Enum.Parse(typeof(BattleDotNet.Region), region);
            return leaderboards.GetRecentActivity(bracket, regionCode);
        }

        [HttpGet]
        public LeaderboardViewModel GetLeaderboard([FromUri]LeaderboardFilter filter)
        {
            var leaderboard = leaderboards.GetLeaderboard(filter);
            return leaderboard;
        }
    }
}
