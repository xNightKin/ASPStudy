using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore1.Models.Repository
{
    public class ArtistRepository : Repository<Artist>
    {

        public List<Artist> GetByName(string name)
        {
            return DBSet.Where(a => a.Name.Contains(name)).ToList();
        }

        public List<SoloArtist> GetSoloArtists()
        {
            return DBSet.OfType<SoloArtist>().ToList();
        }
    }
}