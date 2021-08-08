using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Room
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Numéro de la salle")]
        public int Number { get; set; }

        [Required]
        [DisplayName("Nombre de sièges")]
        public int Seats { get; set; }

        public int? ImplantationId { get; set; }
        public Implantation Implantation { get; set; }

        public List<Show> Shows { get; set; }
    }
}
