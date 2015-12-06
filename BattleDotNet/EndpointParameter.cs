using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet
{
    public class EndpointParameter : IEndpointParameter
    {
        public string Key { get; set; }

        public EndpointParameterType ParameterType { get; set; }

        public string Value { get; set; }

        public EndpointParameter(string key, string value, EndpointParameterType parameterType)
        {
            Key = key;
            Value = value;
            ParameterType = parameterType;
        }

        public EndpointParameter(string value, EndpointParameterType parameterType)
        {
            if (parameterType == EndpointParameterType.Query)
            {
                throw new ArgumentException("BattleNetEndPointParameter:  Cannot use this constructor with this parameter type.");
            }

            Value = value;
            ParameterType = parameterType;
        }
    }
}
