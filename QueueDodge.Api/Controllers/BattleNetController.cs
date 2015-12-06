using BattleDotNet;
using Microsoft.AspNet.SignalR.Client;
using QueueDodge.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Web.Configuration;
using System.Web.Http;

namespace QueueDodge.Api.Controllers
{
    [Route("battlenet")]
    public class BattleNetController : ApiController
    {
        private LeaderboardIntegrationService battleNetLeaderboardService { get; set; }

        public BattleNetController()
        {
            battleNetLeaderboardService = new LeaderboardIntegrationService(new QueueDodgeDB(), "heuemgj94eyv484cekut2a82d6crnskm");
        }

        [HttpGet]
        [Route("battlenet/leaderboard/{regionCode}/{bracket}")]
        public async void Get(string regionCode, string bracket)
        {
            Region region = (Region)Enum.Parse(typeof(Region), regionCode, true);
            Locale locale;

            switch (region.ToString())
            {
                case "us":
                    locale = Locale.en_us;
                    break;
                case "eu":
                    locale = Locale.en_gb;
                    break;

                default:
                    locale = Locale.en_us;
                    throw new Exception("Region or locale not supported.");
            }
            var hub = WebConfigurationManager.AppSettings["HubAddress"];

            var connection = new HubConnection(hub);
            IHubProxy myHub = connection.CreateHubProxy("LeaderboardHub");
            connection.Start().Wait(); // not sure if you need this if you are simply posting to the hub

            // myHub.Invoke("LeaderboardRequestStarted", bracket, (int)region, DateTime.Now);
            battleNetLeaderboardService.GetLeaderboard(bracket, ".api.battle.net/", region, Game.wow, locale);
            await myHub.Invoke("LeaderboardRequestComplete", bracket, (int)region, DateTime.Now);

        }
    }


}

