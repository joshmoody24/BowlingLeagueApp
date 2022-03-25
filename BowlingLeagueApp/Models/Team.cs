using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Models
{
    public class Team
    {
        [Required]
        [Key]
        public int TeamID { get; set; }

        [MaxLength(50)]
        public string TeamName { get; set; }
    }
}
