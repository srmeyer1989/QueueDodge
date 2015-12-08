using System.Collections.Generic;

namespace BattleDotNet.Achievement
{
    public class RewardItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams tooltipParams { get; set; }
        public List<object> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
    }
}