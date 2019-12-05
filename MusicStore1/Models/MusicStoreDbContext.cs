using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore1.Models
{

    public class MusicStoreDbContext: DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public System.Data.Entity.DbSet<MusicStore1.Models.ArtistDetail> ArtistDetails { get; set; }
    }
}