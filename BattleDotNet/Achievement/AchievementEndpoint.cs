using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Achievement
{
    public class AchievementEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public AchievementEndpoint(string achievementId, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("achievement", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(achievementId, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }
    }
}
