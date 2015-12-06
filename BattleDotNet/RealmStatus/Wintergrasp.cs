using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.RealmStatus
{
    public class Wintergrasp
    {
        public int Area { get; set; }
        public int ControllingFaction { get; set; }
        public int Status { get; set; }
        public object Next { get; set; }
    }
}
