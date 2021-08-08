using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class Pegi
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string IllustrationPath { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
