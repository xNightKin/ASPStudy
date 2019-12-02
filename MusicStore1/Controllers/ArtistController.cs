using MusicStore1.Models;
using MusicStore1.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore1.Controllers
{
    public class ArtistController : Controller
    {
        //MusicStoreDbContext context = new MusicStoreDbContext();
        ArtistRepository repos = new ArtistRepository(); 
        // GET: Detail
        public ActionResult Detail(int id)
        {
            Artist artist = repos.Get(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(artist);
            }
        }
        // GET: Artist
        public ActionResult Index()
        {
            return View(repos.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist); 
            repos.Add(artist);
            repos.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}