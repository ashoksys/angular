using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Controllers
{
    public class ShowTimesController : Controller
    {
        protected readonly Moviedbcontext _dbcontext;

        public ShowTimesController(Moviedbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var showtime = _dbcontext.ShowTime;
            return View(showtime);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShowTime showTime)
        {
            _dbcontext.Add(showTime);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var showtime = _dbcontext.ShowTime.FirstOrDefault(x => x.Id == id);
            return View(showtime);

        }
        [HttpPost]
        public IActionResult Edit(ShowTime showTime)
        {
            _dbcontext.ShowTime.Update(showTime);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var showtime = _dbcontext.ShowTime.FirstOrDefault(x => x.Id == id);
            return View(showtime);
        }

        [HttpPost]
        public IActionResult Delete(ShowTime Showtimes)
        {
            _dbcontext.ShowTime.Remove(Showtimes);
            _dbcontext.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var showtime = _dbcontext.ShowTime.FirstOrDefault(x => x.Id == id);
            return View(showtime);
        }
    }
}