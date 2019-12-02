using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore1.Models
{
    public class Artist
    {
        
        public int AlbumID { get; set; }
        [Required()]
        [StringLength(100, MinimumLength =2)]
        public string Name { get; set; }

        public int ArtistID { get; set; }
        public virtual List<Album> Album{ get; set; }

    }
}