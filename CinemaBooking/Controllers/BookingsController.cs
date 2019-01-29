using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Controllers
{
    [EnableCors("AllowCors")]
    public class BookingsController : Controller// controllers
    {
        protected readonly Moviedbcontext _dbcontext;

        public BookingsController(Moviedbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var booking = _dbcontext.Booking.Include(x => x.Movie).Include(x=> x.User);

            return Ok(new {result = booking});
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.movies = _dbcontext.Movies.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.users = _dbcontext.Users.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.FirstName,
                Value = x.Id.ToString()
            });
            ViewBag.ShowTime = _dbcontext.ShowTime.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Showtimes,
                Value = x.Id.ToString()
            });
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            _dbcontext.Booking.Add(booking);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var booking = _dbcontext.Booking.FirstOrDefault(x => x.Id == id);
            return View(booking);

        }
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            

            _dbcontext.Booking.Update(booking);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var booking = _dbcontext.Booking.FirstOrDefault(x => x.Id == id);
            return View(booking);
        }

        [HttpPost]
        public IActionResult Delete(Booking booking)
        {
            _dbcontext.Booking.Remove(booking);
            _dbcontext.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var booking = _dbcontext.Booking.Include(x=> x.User).Include(x=> x.Movie).FirstOrDefault(x => x.Id == id);
            return View(booking);
        }
    }
}