using MusicStore1.Models;
using MusicStore1.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
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

        public ActionResult Edit(int id)
        {
            var artist = repos.Get(id);
            if (artist == null) return HttpNotFound();
            else return View(artist);
        }

        [HttpPost()]
        public ActionResult Edit(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    repos.Update(artist);
                    repos.SaveChanges();
                    scope.Complete();
                }
                return RedirectToAction("Index");
            }catch (DbUpdateConcurrencyException e)
            
            {
                ViewBag.Message= "Sorry, data have been changed";
                return View(artist);
            }
        }

        protected override void Dispose(bool disposing)
        {
            repos.Dispose();
            base.Dispose(disposing);
        }
    }
}