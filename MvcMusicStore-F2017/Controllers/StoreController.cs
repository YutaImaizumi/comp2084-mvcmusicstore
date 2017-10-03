using MvcMusicStore_F2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore_F2017.Controllers
{
    public class StoreController : Controller
    {
        //dv connection
        MusicStoreModel db = new MusicStoreModel();

        // GET: Store
        public ActionResult Index()
        {

            //// create a new list in memory in week 4 (deleted at week 5)
            //var genres = new List<Genre>();

            //// create 10 pretend genre records
            //for (int i = 1; i <= 10; i++)
            //{
            //    genres.Add(new Genre { Name = "Genre " + i.ToString() });
            //}

            // give the list to the view with ViewBag
            //ViewBag.genres = genres;


            // week5: now get the real Genre data from the genre model
            var genres = db.Genres.ToList().OrderBy(g => g.Name);

            // pass the genre list as a parameter to the view
            return View(genres);
        }

        // GET: Store/Browse
        public ActionResult Browse(string genre)
        {
            // add the selected genre to the viewbag so we can display it in the browse view
            var g = db.Genres.Include("Albums")
                .SingleOrDefault(gn => gn.Name == genre);

            return View(g); // リターン値はg!!!
        }

    }
}