using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaForYou.Models
{
    public class ShowViewModel
    {

        public Show Show { get; set; }
        [NotMapped]
        public Movie Movie { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Numéro de la salle")]
        public int RoomId { get; set; }

        [NotMapped]
        public int ImplantationId { get; set; }

        [NotMapped]
        public SelectList Rooms { get; set; }
        [NotMapped]

        public TimeSpan StartingHours { get; set; }

        [NotMapped]
        public SelectList AvailableHours { get; set; }

    }
}
