using System.Collections.Generic;

namespace NBasketball.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }

        public virtual ICollection<Player> Players { get; set; } // Связь с игроками
    }
}