using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.PVP
{
    public class Row
    {
        public int Ranking { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public int RealmID { get; set; }
        public string RealmName { get; set; }
        public string RealmSlug { get; set; }
        public int RaceID { get; set; }
        public int ClassID { get; set; }
        public int SpecID { get; set; }
        public int FactionID { get; set; }
        public int GenderID { get; set; }
        public int SeasonWins { get; set; }
        public int SeasonLosses { get; set; }
        public int WeeklyWins { get; set; }
        public int WeeklyLosses { get; set; }
    }
}
