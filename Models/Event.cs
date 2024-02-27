using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerTeam.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public string? City { get; set; }
        public List<Team> Teams { get; set; }
        public List<Goal>? Goals { get; set; }
        public Player? MVP { get; set; }
        public byte[]? Formation { get; set; }
    }
}
