using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Models
{
    public class Moviedbcontext:DbContext
    {
        public Moviedbcontext(DbContextOptions<Moviedbcontext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<ShowTime> ShowTime { get; set; }


    }
}
