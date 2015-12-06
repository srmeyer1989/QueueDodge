using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.CharacterProfile
{
    public class CharacterProfileEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public CharacterProfileEndpoint(string realm, string characterName, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("character", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(realm, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(characterName, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));

        }
    }
}
