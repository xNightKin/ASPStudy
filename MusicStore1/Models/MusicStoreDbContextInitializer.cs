using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore1.Models
{
    public class MusicStoreDbContextInitializer : DropCreateDatabaseAlways<MusicStoreDbContext>
    {
        protected override void Seed(MusicStoreDbContext context)
        {
            Artist artist = new Artist() { Name = "First Artist" };
            context.Artists.Add(artist);

            context.Albums.Add(new Album() { Title = "First Album", Artist = artist });
            context.Albums.Add(new Album() { Title = "Second Album", Artist = artist });

            context.Albums.Add(new Album()
            {
                Title="Third Album",
                Artist = context.Artists.Add(new Artist() { Name = "Second Artist" })
            });

            
            context.SaveChanges();
        }
    }
}