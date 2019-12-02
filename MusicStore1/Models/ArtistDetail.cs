using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore1.Models
{
    public class ArtistDetail
    {
        [Key()]
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public string BIO { get; set; }
        public virtual Artist Artist { get; set; }
    }
}