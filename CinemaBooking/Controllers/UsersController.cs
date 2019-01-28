using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Controllers
{
    public class UsersController : Controller
    {
        protected readonly Moviedbcontext _dbcontext;

        public UsersController(Moviedbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var user = _dbcontext.Users;
            return View(user);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _dbcontext.Add(user);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
            return View(user);

        }
        [HttpPost]
        public IActionResult Edit(Movie user)
        {
            _dbcontext.Add(user);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            _dbcontext.Users.Remove(user);
            _dbcontext.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
    }
}