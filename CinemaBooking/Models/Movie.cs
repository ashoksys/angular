using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        [DisplayName("List Of Movies")]
        public string Name { get; set; }

        public bool Available { get; set; }
        
    }
}
