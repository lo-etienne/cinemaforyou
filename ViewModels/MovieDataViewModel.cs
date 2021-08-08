using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaForYou.Models
{
    public class MovieDataViewModel
    {
        public Movie Movie { get; set; }
        public Image Image { get; set; }
        public List<Implantation> Implantations { get; set; }

        public Dictionary<Implantation, List<Show>> Shows { get; set; }
    }
}
