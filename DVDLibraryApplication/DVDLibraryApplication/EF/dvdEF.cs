using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDLibraryApplication.EF
{
    public class dvdEF
    {

      [Key]
        public int dvdId { get; set; }
        public int directorId { get; set; }
        public int? ratingId { get; set; }
        public string title { get; set; }
        public string realeaseYear { get; set; }

        public string notes { get; set; }
        public virtual DirectorEF director { get; set; }
        public virtual RatingEF rating { get; set; }
    }
}