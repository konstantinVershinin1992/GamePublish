﻿using System;
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
        [Display(Name="Имя героя")]
        public string Name { get; set; }
        [Display(Name = "Уровень")]
        public int Level { get; set; }
        [Display(Name = "Очки")]
        public int FreePoints { get; set; }
        public int Experience { get; set; }
        [Display (Name = "Здоровье")]
        public int Health { get; set; }
        [Display(Name = "Защита")]
        public int Protection { get; set; }
        [Display(Name = "Атака")]
        public int Attack { get; set; }
        public int Evasion { get; set; }
        public int Crit { get; set; }
        [Display(Name = "Аватар")]
        public string Picture { get; set; }
        [Display(Name = "Пользователь")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}