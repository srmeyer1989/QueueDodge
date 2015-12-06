using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.DataResources
{
    public class RaceEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public RaceEndpoint(Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("data", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("character", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("races", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));

        }
    }
}
