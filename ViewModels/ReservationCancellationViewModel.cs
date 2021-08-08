using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class ReservationCancellationViewModel
    {
        public Reservation Reservation { get; set; }
        public IEnumerable<int> SpectatorsId { get; set; }
    }
}
