using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleDotNet.Services;
using QueueDodge.Models;
using BattleDotNet.PVP;
using QueueDodge.Services;

namespace QueueDodge.Integrations
{
    public class ConquestIntegrationService
    {
        private BattleNetService<ConquestCap> conquestCapService;
        private QueueDodgeDB data;
        private RequestService requests;

        public ConquestIntegrationService()
        {
            conquestCapService = new BattleNetService<ConquestCap>();
            data = new QueueDodgeDB();
            requests = new RequestService(data);
        }

        public ConquestCap GetConquestCap(BattleDotNet.Region region, string host, BattleDotNet.Game game, BattleDotNet.Locale locale, int arenaRating, int bgRating)
        {
            var endpoint = new ConquestEndpoint(locale, arenaRating, bgRating);

            var newRequest = new Request()
            {
                Locale = locale.ToString(),
                RegionID = (int)region,
                RequestDate = DateTime.Now,
                RequestType = "leaderboards",
                Bracket = "",
                Url = conquestCapService.GetUri(endpoint, host, region, game).ToString()
            };

            var request = data.Requests.Add(newRequest);
            data.SaveChanges();
            ConquestCap cap = new ConquestCap();

            requests.Perform(10, 2, 5, request, () =>
            {
                 cap = conquestCapService.Get(endpoint, host, region, game).Result;
            });

            return cap;
        }
    }
}
