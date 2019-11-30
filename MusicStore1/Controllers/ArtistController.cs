using MusicStore1.Models;
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
        MusicStoreDbContext context = new MusicStoreDbContext();
        // GET: Artist
        public ActionResult Index()
        {
            return View(context.Artists.ToList());
        }
    }
}