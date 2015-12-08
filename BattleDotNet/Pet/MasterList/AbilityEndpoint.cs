using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Pet.MasterList
{
    public class AbilityEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public AbilityEndpoint(string abilityID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("pet", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("ability", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("abilityID", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));

        }
    }
}
