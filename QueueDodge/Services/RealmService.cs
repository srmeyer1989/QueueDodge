using QueueDodge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDodge.Services
{
    public class RealmService
    {
        private QueueDodgeDB data { get; set; }

        public RealmService()
        {
            data = new QueueDodgeDB();
        }

        public IEnumerable<Realm> GetRealms(BattleDotNet.Region region)
        {
            return data
                .Realms
                .Where(p => region == BattleDotNet.Region.all || p.RegionID == (int)region)
                .AsEnumerable();
        }
    }
}
