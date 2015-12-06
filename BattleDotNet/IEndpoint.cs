using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet
{
   public interface IEndpoint
    {
        IList<IEndpointParameter> Parameters { get; set; }
    }
}
