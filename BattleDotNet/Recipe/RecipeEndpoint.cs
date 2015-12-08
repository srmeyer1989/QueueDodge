using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Recipe
{
    public class RecipeEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public RecipeEndpoint(string recipeID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("recipe", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("recipeID", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));

        }
    }
}