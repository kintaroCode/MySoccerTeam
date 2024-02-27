using System.ComponentModel.DataAnnotations;

namespace MySoccerTeam.Models
{
    public class Goal
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event? Event { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public Player? Player { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Team? Team { get; set; }
    }
}