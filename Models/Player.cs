using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerTeam.Models
{
    public class Player
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PlayerFavorite { get; set; }

        public string Position { get; set; }

        public string FavoriteFoot { get; set; }
        public string? Image { get; set; }

        public List<Skill>? Skills { get; set; }
    }
}
