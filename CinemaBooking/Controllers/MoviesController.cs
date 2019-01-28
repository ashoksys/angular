using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CinemaBooking.Controllers
{
    public class MoviesController : Controller
    {
        
            protected readonly Moviedbcontext _dbcontext;

            public MoviesController(Moviedbcontext dbcontext)
            {
                _dbcontext = dbcontext;
            }
            public IActionResult Index()
        {

            var movies = _dbcontext.Movies;
            return View(movies);
               
        }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Movie  movie)
            {
                _dbcontext.Add(movie);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            [HttpGet]
            public IActionResult Edit(int? id)
            {
                var movie = _dbcontext.Movies.FirstOrDefault(x => x.Id == id);
                return View(movie);
            
            }
            [HttpPost]
            public IActionResult Edit(Movie movie)
            {
                _dbcontext.Movies.Update(movie);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            [HttpGet]
            public IActionResult Delete(int? id)
            {
                var movie = _dbcontext.Movies.FirstOrDefault(x => x.Id == id);
                return View(movie);
            }

            [HttpPost]
            public IActionResult Delete(Movie movie)
            {
                _dbcontext.Movies.Remove(movie);
                _dbcontext.SaveChanges();
                return RedirectToAction(actionName: nameof(Index));
            }
            [HttpGet]
            public IActionResult Details(int? id)
            {
                var movie = _dbcontext.Movies.FirstOrDefault(x => x.Id == id);
                return View(movie);
            }

           
    }
}