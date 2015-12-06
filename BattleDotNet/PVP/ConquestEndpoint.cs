using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.PVP
{
    public class ConquestEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public ConquestEndpoint(Locale locale, int arenaRating, int bgRating)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter(locale.ToString().Substring(0,2), EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("pvp", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("conquest-calculator", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("arenaRating", arenaRating.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("bgRating", bgRating.ToString(), EndpointParameterType.Query));
        }
    }
}
