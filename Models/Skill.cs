using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySoccerTeam.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        [Range(0, 99)]
        public int Velocity { get; set; }

        [Range(0, 99)]
        public int Endurance { get; set; }

        [Range(0, 99)]
        public int Shoot { get; set; }

        [Range(0, 99)]
        public int Defense { get; set; }

        [Range(0, 99)]
        public int Strength { get; set; }

        [Range(0, 99)]
        public int Pass { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player? Player { get; set; }


        public int RatedPlayerId { get; set; }

        [ForeignKey("RatedPlayerId")]
        public Player? RatedPlayer { get; set; }
    }
}

