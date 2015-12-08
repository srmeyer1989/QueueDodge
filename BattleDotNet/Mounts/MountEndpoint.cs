using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Mounts
{
    public class MountEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public MountEndpoint(Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("mount", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }


    }
}
