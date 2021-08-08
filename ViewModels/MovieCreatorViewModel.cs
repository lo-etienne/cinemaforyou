using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaForYou.Models
{
    public class MovieCreatorViewModel
    {
        public Movie Movie { get; set; }
        [NotMapped]
        public SelectList Pegis { get; set; }
        [NotMapped]
        public SelectList Types { get; set; }
        [NotMapped]
        public Image Image { get; set; }
    }
}
