using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class ShowDataViewModel
    {

        public Show Show { get; set; }

        public Movie Movie { get; set; }

        public Implantation Implantation { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
