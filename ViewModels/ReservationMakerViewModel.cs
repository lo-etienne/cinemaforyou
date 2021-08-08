using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaForYou.Models
{
    public class ReservationMakerViewModel
    {
        public int? ShowId { get; set; }

        public int SeatsAvailable { get; set; }
        public Movie Movie { get; set; }
        public Reservation Reservation { get; set; }

        [NotMapped]
        public IEnumerable<string> Name { get; set; }

        [NotMapped]
        public IEnumerable<string> Surname { get; set; }

        [NotMapped]
        public IEnumerable<DateTime> Age { get; set; }

    }
}
