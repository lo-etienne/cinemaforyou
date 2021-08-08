using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Implantation
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Introduisez une localité")]
        [Display(Name = "Localité")]
        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public List<Show> Shows { get; set; }

    }
}
