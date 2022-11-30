using System;
using System.Collections.Generic;

namespace GameData
{
    public partial class DtUserCombination
    {
        public int IdUserCombination { get; set; }
        public int? IdWinCombination { get; set; }
        public int? IdUser { get; set; }

        public virtual SpUser? IdUserNavigation { get; set; }
        public virtual SpWinCombination? IdWinCombinationNavigation { get; set; }
    }
}
