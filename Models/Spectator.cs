using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Spectator
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}
