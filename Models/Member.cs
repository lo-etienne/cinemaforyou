using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CinemaForYou.Models
{
    public class Member : IdentityUser
    {
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Date de naissance")]
        public DateTime Birthdate { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
