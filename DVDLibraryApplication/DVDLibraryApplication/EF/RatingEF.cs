using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDLibraryApplication.EF
{
    public class RatingEF
    {
        [Key]
        public int RatingId { get; set; }
        public string RatingName { get; set; }
    }
}