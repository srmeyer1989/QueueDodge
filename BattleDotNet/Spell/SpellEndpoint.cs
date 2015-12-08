using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Spell
{
    public class SpellEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public SpellEndpoint(string spellID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("spell", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("spellID", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));

        }
    }
}
