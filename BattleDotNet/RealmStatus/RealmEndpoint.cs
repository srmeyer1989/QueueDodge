using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.RealmStatus
{
    public class RealmEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public RealmEndpoint(Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("realm", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("status", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }
    }
}
