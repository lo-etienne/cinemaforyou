using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int? ShowId { get; set; }

        [Display(Name = "Séance")]
        public Show Show { get; set; }

        public string MemberId { get; set; }
        public Member Member { get; set; }

        [Display(Name = "Nombre de spectateur(s)")]
        public List<Spectator> Spectators { get; set; }


    }
}
