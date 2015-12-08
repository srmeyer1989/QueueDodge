using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Auction
{
    public class AuctionEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public AuctionEndpoint(string realm, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("auction", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("data", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(realm, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }
    }
}
