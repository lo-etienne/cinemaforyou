using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Show
    {
        public int Id { get; set; }

        [Required] 
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Heure")]
        public TimeSpan Heure { get; set; }
        public int? ImplantationId { get; set; }
        public Implantation Implantation { get; set; }

        public int? RoomId { get; set; }
        [Display(Name = "Salle")]
        public Room Room { get; set; }

        public int? MovieId { get; set; }
        [Display(Name = "Film")]
        public Movie Movie { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
