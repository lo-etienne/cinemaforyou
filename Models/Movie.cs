using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Titre")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date de sortie")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DisplayName("Durée en minute(s)")]
        public int Duration { get; set; }

        public List<Show> Shows { get; set; }

        [DisplayName("Pegi")]
        public int? PegiId { get; set; }
        public Pegi Pegi { get; set; }

        [DisplayName("Genre")]
        public int? MovieTypeId { get; set; }
        public MovieType Type { get; set; }

        public Image Image { get; set; }


    }
}
