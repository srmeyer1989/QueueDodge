using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleDotNet.Pet.MasterList
{
    public class Ability
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int cooldown { get; set; }
        public int rounds { get; set; }
        public int petTypeId { get; set; }
        public bool isPassive { get; set; }
        public bool hideHints { get; set; }
    }
}