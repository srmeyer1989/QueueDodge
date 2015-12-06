using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet
{
    public interface IEndpointParameter
    {
        EndpointParameterType ParameterType { get; set; }
        string Key { get; set; }
        string Value { get; set; }
    }
}
