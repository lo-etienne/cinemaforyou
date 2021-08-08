using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaForYou.Models
{
    public class ShowEditorViewModel
    {

        public Show Show { get; set; }
        public TimeSpan StartingHours { get; set; }

        [NotMapped]
        public SelectList AvailableHours { get; set; }
    }
}
