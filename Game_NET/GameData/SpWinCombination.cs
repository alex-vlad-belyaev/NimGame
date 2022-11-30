using System;
using System.Collections.Generic;

namespace GameData
{
    public partial class SpWinCombination
    {
        public SpWinCombination()
        {
            DtUserCombinations = new HashSet<DtUserCombination>();
        }

        public int IdWinCombination { get; set; }
        public string? A { get; set; }
        public string? B { get; set; }
        public string? C { get; set; }

        public virtual ICollection<DtUserCombination> DtUserCombinations { get; set; }
    }
}
