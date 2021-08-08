using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CinemaForYou.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }

        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
