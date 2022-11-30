using System;
using System.Collections.Generic;

namespace GameData
{
    public partial class SpUser
    {
        public SpUser()
        {
            DtUserCombinations = new HashSet<DtUserCombination>();
            SpGames = new HashSet<SpGame>();
        }

        public int IdUser { get; set; }
        public string? Username { get; set; }
        public string? Userpass { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateRegistration { get; set; }

        public virtual ICollection<DtUserCombination> DtUserCombinations { get; set; }
        public virtual ICollection<SpGame> SpGames { get; set; }
    }
}
