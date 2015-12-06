using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleDotNet.Services
{
    public class BattleNetService<T>
    {
        async public Task<T> Get(IEndpoint endpoint, string host, Region region, Game game)
        {
            var http = new HttpClient();

            var uri = GetUri(endpoint, host, region, game);

            var json = await http.GetStringAsync(uri);

            var data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        public Uri GetUri(IEndpoint endpoint, string host, Region region, Game game)
        {
            var uriString = new StringBuilder("https://");
            bool firstQueryParameter = true;

            uriString.Append(region.ToString());
            uriString.Append(host.ToString());
            uriString.Append(game.ToString());

            foreach (EndpointParameter p in endpoint.Parameters)
            {
                if (p.ParameterType == EndpointParameterType.Resource)
                {
                    uriString.Append("/");
                    uriString.Append(p.Value);
                }
                else if (p.ParameterType == EndpointParameterType.Query)
                {
                    if (firstQueryParameter)
                    {
                        uriString.Append("?");
                        firstQueryParameter = false;
                    }
                    else
                    {
                        uriString.Append("&");
                    }

                    uriString.Append(p.Key);
                    uriString.Append("=");
                    uriString.Append(p.Value);
                }
            };

            var uri = new Uri(uriString.ToString());

            return uri;
        }
    }
}
