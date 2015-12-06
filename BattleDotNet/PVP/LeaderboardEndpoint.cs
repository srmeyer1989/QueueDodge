using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.PVP
{
    public class LeaderboardEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public LeaderboardEndpoint(string bracket, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("leaderboard", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(bracket, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }
    }
}
