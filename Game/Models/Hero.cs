using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Models
{
    public class Hero
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Level { get; set; }
        public int FreePoints { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int Protection { get; set; }
        public int Attack { get; set; }
        public int Evasion { get; set; }
        public int Crit { get; set; }
        public string Picture { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}