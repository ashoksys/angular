using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CinemaBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [DisplayName("Movie Name")]
        public int MovieId { get; set; }
        [DisplayName("User Name")]
        public int UserID { get; set; }
        public int ShowTimeId { get; set; }
      

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
        public virtual ShowTime ShowTime { get; set; }



    }
}
