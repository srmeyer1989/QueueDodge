using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using QueueDodge.Models;
using QueueDodge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDodge.Api.Hubs
{
    public class LeaderboardHub : Hub
    {
        private LeaderboardService service;
        public LeaderboardHub()
        {
            service = new LeaderboardService();
        }

        public void LeaderboardRequestComplete(string bracket, BattleDotNet.Region region, DateTime completedTime)
        {

            var activity = service.GetRecentActivity(bracket, region);

            if (region == BattleDotNet.Region.us)
            {
                switch (bracket)
                {
                    case "2v2":
                        Clients.All.refresh_us_2v2(activity, completedTime);
                        break;
                    case "3v3":
                        Clients.All.refresh_us_3v3(activity, completedTime);
                        break;
                    case "5v5":
                        Clients.All.refresh_us_5v5(activity, completedTime);
                        break;
                    case "rbg":
                        Clients.All.refresh_us_rbg(activity, completedTime);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (bracket)
                {
                    case "2v2":
                        Clients.All.refresh_eu_2v2(activity, completedTime);
                        break;
                    case "3v3":
                        Clients.All.refresh_eu_3v3(activity, completedTime);
                        break;
                    case "5v5":
                        Clients.All.refresh_eu_5v5(activity, completedTime);
                        break;
                    case "rbg":
                        Clients.All.refresh_eu_rbg(activity, completedTime);
                        break;
                    default:
                        break;
                }
            }
        }

        public void LeaderboardRequestStarted(string bracket, BattleDotNet.Region region, DateTime requestTime)
        {
            if (region == BattleDotNet.Region.us)
            {
                switch (bracket)
                {
                    case "2v2":
                        Clients.All.request_us_2v2(requestTime);
                        break;
                    case "3v3":
                        Clients.All.request_us_3v3(requestTime);
                        break;
                    case "5v5":
                        Clients.All.request_us_5v5(requestTime);
                        break;
                    case "rbg":
                        Clients.All.request_us_rbg(requestTime);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (bracket)
                {
                    case "2v2":
                        Clients.All.request_eu_2v2(requestTime);
                        break;
                    case "3v3":
                        Clients.All.request_eu_3v3(requestTime);
                        break;
                    case "5v5":
                        Clients.All.request_eu_5v5(requestTime);
                        break;
                    case "rbg":
                        Clients.All.request_eu_rbg(requestTime);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
