using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public string Showtimes { get; set; }
    }
}
