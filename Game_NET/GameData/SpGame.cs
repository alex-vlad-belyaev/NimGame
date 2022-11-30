using System;
using System.Collections.Generic;

namespace GameData
{
    public partial class SpGame
    {
        public int IdGame { get; set; }
        public int? IdUser { get; set; }
        public string? Protocol { get; set; }
        public DateTime? DatePlay { get; set; }

        public virtual SpUser? IdUserNavigation { get; set; }
    }
}
