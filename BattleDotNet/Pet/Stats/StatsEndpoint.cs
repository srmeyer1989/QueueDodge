using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Pet.Stats
{
    public class StatsEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public StatsEndpoint(string speciesID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("pet", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("stats", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("speciesID", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));

        }
    }
}
